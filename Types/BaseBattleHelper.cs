using System;
using System.Collections.Generic;
using TheSettlersCalculator.Specialists.Generals;

namespace TheSettlersCalculator.Types
{
	internal abstract class AbstractBaseBattleHelper
	{
		#region Constants
		private const int GENERAL_DAMAGE = 120;
		#endregion

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

		private int GetTargetIndex(Unit attackUnit, short[] enemyCounts, int[] enemyHealths)
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

		internal List<BattleStep> CalculateBattle2(Battle battle, BattleWaves waves, Random random)
		{
			return CalculateBattle2(battle, waves, random, null, null);
		}

		internal List<BattleStep> CalculateBattle2(
			Battle battle,
			BattleWaves waves,
			Random random,
			RoundStateHandler roundStateHandler,
			UnitAttackHandler unitAttackHandler)
		{
			List<BattleStep> steps = new List<BattleStep>();
			steps.Add(new BattleStep(battle));
			int roundIndex = 0;
			General avantgardGeneral = null;
			General general = null;
			General rearguardGeneral = null;
			if (battle.General != null)
			{
				switch(battle.General.AttackPriority)
				{
					case AttackPriority.AvantGarde:
						avantgardGeneral = battle.General;
						break;
					case AttackPriority.Normal:
						general = battle.General;
						break;
					case AttackPriority.RearGuard:
						rearguardGeneral = battle.General;
						break;
				}
			}
			
			General avantgardEnemyGeneral = null;
			General enemyGeneral = null;
			General rearguardEnemyGeneral = null;
			if (battle.EnemyGeneral != null)
			{
				switch (battle.EnemyGeneral.AttackPriority)
				{
					case AttackPriority.AvantGarde:
						avantgardEnemyGeneral = battle.EnemyGeneral;
						break;
					case AttackPriority.Normal:
						enemyGeneral = battle.EnemyGeneral;
						break;
					case AttackPriority.RearGuard:
						rearguardEnemyGeneral = battle.EnemyGeneral;
						break;
				}
			}

			while (true)
			{
				if (!Attack2(battle, waves.Avantgard, waves.EnemyAvantgard, steps, avantgardGeneral, avantgardEnemyGeneral, random, unitAttackHandler))
				{
					break;
				}

				if (roundStateHandler != null)
				{
					roundStateHandler(null, new RoundStateArgs(steps[steps.Count - 1], roundIndex++));
				}

				if (!Attack2(battle, waves.Normal, waves.EnemyNormal, steps, general, enemyGeneral, random, unitAttackHandler))
				{
					break;
				}

				if (roundStateHandler != null)
				{
					roundStateHandler(null, new RoundStateArgs(steps[steps.Count - 1], roundIndex++));
				}

				if (!Attack2(battle, waves.RearGuard, waves.EnemyRearGuard, steps, rearguardGeneral, rearguardEnemyGeneral, random, unitAttackHandler))
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

		private bool Attack2(
			Battle battle,
			IEnumerable<int> units,
			IEnumerable<int> enemyUnits,
			IList<BattleStep> steps,
			General general,
			General enemyGeneral,
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

			if (general != null)
			{
				targetIndex = -1;
				if (AttackUnits2(general, -1, 1, targetIndex, battle, newStep, BattleSideType.Player, random, unitAttackHandler) < 0)
				{
					result = false;
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

			if (enemyGeneral != null)
			{
				targetIndex = -1;
				if (AttackUnits2(enemyGeneral, -1, 1, targetIndex, battle, newStep, BattleSideType.Enemy, random, unitAttackHandler) < 0)
				{
					result = false;
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

		private int AttackUnits2(
			int unitIndex,
			int unitCount,
			int targetIndex,
			Battle battle,
			BattleStep newStep,
			BattleSideType attackerSide,
			Random random,
			UnitAttackHandler unitAttackHandler)
		{
			Unit unit = battle.Sides[(int)attackerSide].Units[unitIndex];

			return AttackUnits2(unit, unitIndex, unitCount, targetIndex, battle, newStep, attackerSide, random, unitAttackHandler);
		}

		private int AttackUnits2(
			Unit unit,
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

			int[] originalDamages = GetUnitsDamage(attackerSide, unit, unitCount, random);

			int[] reducedDamages = originalDamages;

			double towerBonus = battle.Sides[(int)defenderSideType].TowerBonus;
			if (towerBonus > 0 && unit.IgnoreTowerBonus != 100)
			{
				towerBonus = towerBonus * (1 - unit.IgnoreTowerBonus / 100);

				reducedDamages = new int[originalDamages.Length];
				for (int i = 0; i < originalDamages.Length; i++)
				{
					reducedDamages[i] = (int)Math.Truncate(originalDamages[i] * towerBonus);
				}
			}

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
			foreach (int temp in damages)
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

				if (defenderSideStep.Healts[targetIndex] <= 0)
				{
					defenderSideStep.Counts[targetIndex]--;
					damage = -defenderSideStep.Healts[targetIndex];
					int targetUnitHealth = battle.Sides[(int)defenderSideType].Units[targetIndex].Health;
					defenderSideStep.Healts[targetIndex] = targetUnitHealth;

					if (unit.AttackOnArea)
					{
						while (damage > 0)
						{
							targetUnitHealth = battle.Sides[(int)defenderSideType].Units[targetIndex].Health;
							int remDamage;
							int killedUnits = Math.DivRem(
								damage,
								targetUnitHealth,
								out remDamage);

							if (killedUnits < defenderSideStep.Counts[targetIndex])
							{
								defenderSideStep.Counts[targetIndex] -= (short)killedUnits;
								defenderSideStep.Healts[targetIndex] -= (short)remDamage;
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

									for (int i = 0; i < killedUnits; i++)
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

								if (targetIndex < 0)
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

					if (unit.AttackWeaknessTarget || defenderSideStep.Counts[targetIndex] == 0)
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

		protected abstract int[] GetUnitsDamage(BattleSideType battleSideTime, Unit unit, int unitCount, Random random);

		internal static void Shuffle(int[] array, Random random)
		{
			int n = array.Length;
			while (n > 1)
			{
				n--;
				int k = random.Next(array.Length);
				int value = array[k];
				array[k] = array[n];
				array[n] = value;
			}
		}
	}
}
