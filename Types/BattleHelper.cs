using System;
using System.Collections.Generic;

namespace TheSettlersCalculator.Types
{
	internal static class BattleHelper
	{
		private const int GENERAL_DAMAGE = 120;

		private static BattleSideType GetEnemySide(BattleSideType side)
		{
			switch (side)
			{
				case BattleSideType.Player:
					return BattleSideType.Enemy;
				case BattleSideType.Enemy:
					return BattleSideType.Player;
				default:
					throw new ArgumentOutOfRangeException("side");
			}
		}

		private static int GetTargetIndex(Unit attackUnit, short[] enemyCounts, int[] enemyHealths)
		{
			int result = -1;
			if (attackUnit.AttackWeaknessTarget)
			{
				int minHealth = int.MaxValue;

				for (int i = 0; i < enemyHealths.Length; i++)
				{
					if (enemyCounts[i] > 0 && enemyHealths[i] > 0 & enemyHealths[i] < minHealth)
					{
						minHealth = enemyHealths[i];
						result = i;
					}
				}

				return result;
			}

			for (int i = 0; i < enemyCounts.Length; i++)
			{
				if (enemyCounts[i] > 0)
				{
					return i;
				}
			}

			return -1;
		}

		internal static List<BattleStep> CalculateBattle2(Battle battle, BattleWaves waves, Random random)
		{
			return CalculateBattle2(battle, waves, random, null, null);
		}			

		internal static List<BattleStep> CalculateBattle2(
			Battle battle, 
			BattleWaves waves, 
			Random random, 
			RoundStateHandler roundStateHandler, 
			UnitAttackHandler unitAttackHandler)
		{
			List<BattleStep> steps = new List<BattleStep>();
			steps.Add(new BattleStep(battle));
			int roundIndex = 0;

			while (true)
			{
				if (!Attack2(battle, waves.Avantgard, waves.EnemyAvantgard, steps, false, random, unitAttackHandler))
				{
					break;
				}

				if (roundStateHandler != null)
				{
					roundStateHandler(null, new RoundStateArgs(steps[steps.Count - 1], roundIndex++));
				}

				if (!Attack2(battle, waves.Normal, waves.EnemyNormal, steps, true, random, unitAttackHandler))
				{
					break;
				}

				if (roundStateHandler != null)
				{
					roundStateHandler(null, new RoundStateArgs(steps[steps.Count - 1], roundIndex++));
				}

				if (!Attack2(battle, waves.RearGuard, waves.EnemyRearGuard, steps, false, random, unitAttackHandler))
				{
					break;
				}

				if (roundStateHandler != null)
				{
					roundStateHandler(null, new RoundStateArgs(steps[steps.Count - 1], roundIndex++));
				}
			}

			if (roundStateHandler != null)
			{
				roundStateHandler(null, new RoundStateArgs(steps[steps.Count - 1], roundIndex));
				roundStateHandler(null, new RoundStateArgs(steps[steps.Count - 1], -1));
			}

			return steps;
		}

		private static bool Attack2(
			Battle battle, 
			IEnumerable<int> units, 
			IEnumerable<int> enemyUnits, 
			IList<BattleStep> steps, 
			bool generalAttack, 
			Random random,
			UnitAttackHandler unitAttackHandler)
		{
			bool result = true;
			BattleStep current = steps[steps.Count - 1];
			BattleStep newStep = new BattleStep(current);
			int targetIndex = -1;

			foreach (int unitIndex in units)
			{
				targetIndex = -1;
				// unit 
				targetIndex = AttackUnits2(
					unitIndex, 
					current.Counts[unitIndex], 
					targetIndex, 
					battle, 
					newStep, 
					BattleSideType.Player, 
					random,
					unitAttackHandler);

				if (targetIndex < 0)
				{
					result = false;
					break;
				}
			}

			if (generalAttack && battle.General && targetIndex >= 0)
			{
				// general attack
				if (unitAttackHandler != null)
				{
					unitAttackHandler(null, new UnitAttackArgs(BattleSideType.Player, PlayerUnits.GENERAL, 1, targetIndex, GENERAL_DAMAGE, newStep.EnemyHealts[targetIndex]));
				}

				newStep.EnemyHealts[targetIndex] -= GENERAL_DAMAGE;
				if(newStep.EnemyHealts[targetIndex] <= 0)
				{
					newStep.EnemyCounts[targetIndex]--;
					newStep.EnemyHealts[targetIndex] = battle.EnemyUnits[targetIndex].Health;
				}
			}

			foreach (int unitIndex in enemyUnits)
			{
				targetIndex = -1;
				targetIndex = AttackUnits2(
					unitIndex, 
					current.EnemyCounts[unitIndex], 
					targetIndex, 
					battle, 
					newStep, 
					BattleSideType.Enemy, 
					random,
					unitAttackHandler);
				if (targetIndex < 0)
				{
					result = false;
					break;
				}
			}

			if (generalAttack && battle.EnemyGeneral && targetIndex >= 0)
			{
				if (unitAttackHandler != null)
				{
					unitAttackHandler(null, new UnitAttackArgs(BattleSideType.Enemy, -1, 1, targetIndex, GENERAL_DAMAGE, newStep.Healts[targetIndex]));
				}

				newStep.Healts[targetIndex] -= GENERAL_DAMAGE;
				if (newStep.Healts[targetIndex] <= 0)
				{
					newStep.Counts[targetIndex]--;
					newStep.Healts[targetIndex] = battle.Units[targetIndex].Health;
				}
			}

			steps.Add(newStep);

			return result;
		}

		private static int[] GetDamageWithTargetUnitReduction(Unit targetUnit, int[] originalDamages, int[] reducedDamages)
		{
			if (targetUnit.TowerBonus)
			{
				return reducedDamages;
			}
			
			return originalDamages;
		}

		private static int AttackUnits2(
			int unitIndex, 
			int unitCount, 
			int targetIndex, 
			Battle battle, 
			BattleStep newStep, 
			BattleSideType attackerSide, 
			Random random,
			UnitAttackHandler unitAttackHandler)
		{
			BattleSideType defenderSideType = GetEnemySide(attackerSide);
			BattleSideStep defenderSideStep = newStep.Sides[(int)defenderSideType];

			Unit unit = battle.Sides[(int)attackerSide].Units[unitIndex];		

			int[] originalDamages = new int[unitCount];
			for(int i = 0; i < originalDamages.Length; i++)
			{
				originalDamages[i] = random.Next(1, 101) > unit.Accuracy
								? unit.MinDamage
								: unit.MaxDamage;
			}

			int[] reducedDamages = originalDamages;

			double towerBonus = battle.Sides[(int)defenderSideType].TowerBonus;
			if (towerBonus > 0 && unit.IgnoreTowerBonus != 100)
			{
				towerBonus = towerBonus * (1 - unit.IgnoreTowerBonus / 100);

				reducedDamages = new int[originalDamages.Length];
				for(int i = 0; i < originalDamages.Length; i++)
				{
					reducedDamages[i] = (int)Math.Truncate(originalDamages[i] * towerBonus);
				}

				Shuffle(reducedDamages, random);
			}

			Shuffle(originalDamages, random);

			if (targetIndex < 0)
			{
				targetIndex = GetTargetIndex(unit, defenderSideStep.Counts, defenderSideStep.Healts);
			}

			if (targetIndex < 0)
			{
				// no more targets
				return -1;
			}

            int[] damages = GetDamageWithTargetUnitReduction(
                battle.Sides[(int)defenderSideType].Units[targetIndex],
                originalDamages,
                reducedDamages);

			int unitId = 0;
			foreach(int temp in damages)
			{
				int damage = temp;
				unitId++;
				if (unitAttackHandler != null)
				{
					if (unit.AttackOnArea)
					{
						unitAttackHandler(null, new UnitAttackArgs(
							attackerSide, 
							unitIndex, 
							unitId, 
							targetIndex,
							Math.Min(damage, defenderSideStep.Healts[targetIndex]),
							defenderSideStep.Healts[targetIndex]));
					}
					else
					{
						unitAttackHandler(null, new UnitAttackArgs(
							attackerSide, 
							unitIndex, 
							unitId, 
							targetIndex, 
							damage,
						    defenderSideStep.Healts[targetIndex]));
					}
				}
				defenderSideStep.Healts[targetIndex] -= damage;

				if(defenderSideStep.Healts[targetIndex] <= 0)
				{
					defenderSideStep.Counts[targetIndex]--;
					damage = -defenderSideStep.Healts[targetIndex];
					int targetUnitHealth = battle.Sides[(int) defenderSideType].Units[targetIndex].Health;
					defenderSideStep.Healts[targetIndex] = targetUnitHealth;

					if(unit.AttackOnArea)
					{
						while(damage > 0)
						{
							targetUnitHealth = battle.Sides[(int)defenderSideType].Units[targetIndex].Health;
							int remDamage;
							int killedUnits = Math.DivRem(
								damage, 
								targetUnitHealth,
							    out remDamage);

							if(killedUnits < defenderSideStep.Counts[targetIndex])
							{
								defenderSideStep.Counts[targetIndex] -= (short) killedUnits;
								defenderSideStep.Healts[targetIndex] -= (short) remDamage;
								int prevDamage = 0;
								if (defenderSideStep.Healts[targetIndex] <= 0)
								{
									prevDamage = remDamage + defenderSideStep.Healts[targetIndex];
									remDamage = remDamage - prevDamage;
									defenderSideStep.Counts[targetIndex]--;
									defenderSideStep.Healts[targetIndex] = targetUnitHealth;
								}

								damage = 0;
								if (unitAttackHandler != null)
								{
									if (prevDamage > 0)
									{
										unitAttackHandler(null, new UnitAttackArgs(
												attackerSide,
												unitIndex,
												unitId,
												targetIndex,
												prevDamage,
												battle.Sides[(int)defenderSideType].Units[targetIndex].Health));
									}

									for(int i = 0; i<killedUnits;i++)
									{
										unitAttackHandler(null, new UnitAttackArgs(
												attackerSide, 
												unitIndex, 
												unitId, 
												targetIndex, 
												targetUnitHealth,
												battle.Sides[(int)defenderSideType].Units[targetIndex].Health));
									}

									if (remDamage > 0)
									{
										unitAttackHandler(null, new UnitAttackArgs(
												attackerSide,
												unitIndex,
												unitId,
												targetIndex,
												remDamage,
												battle.Sides[(int)defenderSideType].Units[targetIndex].Health));										
									}
								}
							}
							else
							{
								// squad killed
								damage -= defenderSideStep.Counts[targetIndex] * targetUnitHealth;
								if (unitAttackHandler != null)
								{
									for (int i = 0; i < defenderSideStep.Counts[targetIndex]; i++)
									{
										unitAttackHandler(null, new UnitAttackArgs(
												attackerSide,
												unitIndex,
												unitId,
												targetIndex,
												targetUnitHealth,
												targetUnitHealth));
									}
								}
								defenderSideStep.Counts[targetIndex] = 0;

								targetIndex = GetTargetIndex(unit, defenderSideStep.Counts, defenderSideStep.Healts);

								if(targetIndex < 0)
								{
									// no more targets
									return -1;
								}
								damages = GetDamageWithTargetUnitReduction(
									battle.Sides[(int)defenderSideType].Units[targetIndex],
									originalDamages,
									reducedDamages);
							}
						}
					}

					if(unit.AttackWeaknessTarget || defenderSideStep.Counts[targetIndex] == 0)
					{
						targetIndex = GetTargetIndex(unit, defenderSideStep.Counts, defenderSideStep.Healts);

						if (targetIndex < 0)
						{
							return targetIndex;
						}

                        damages = GetDamageWithTargetUnitReduction(
                            battle.Sides[(int)defenderSideType].Units[targetIndex],
                            originalDamages,
                            reducedDamages);
					}
				}
			}

			return targetIndex;
		}

		private static void Shuffle(int[] array, Random random)
		{
			int n = array.Length;
			while (n > 1)
			{
				n--;
				int k = random.Next(n + 1);
				int value = array[k];
				array[k] = array[n];
				array[n] = value;
			}
		}
	}
}
