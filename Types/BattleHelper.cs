using System;
using System.Collections.Generic;

namespace TheSettlersCalculator.Types
{
	internal static class BattleHelper
	{
		private const int GENERAL_DAMAGE = 120;
		private static readonly Random s_random = new Random();

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

		internal static List<BattleStep> CalculateBattle2(Battle battle, BattleWaves waves)
		{
			return CalculateBattle2(battle, waves, s_random);
		}			

		internal static List<BattleStep> CalculateBattle2(Battle battle, BattleWaves waves, Random random)
		{
			List<BattleStep> steps = new List<BattleStep>();
			steps.Add(new BattleStep(battle));

			while (true)
			{
				if (!Attack2(battle, waves.Avantgard, waves.EnemyAvantgard, steps, false, random))
				{
					break;
				}

				if (!Attack2(battle, waves.Normal, waves.EnemyNormal, steps, true, random))
				{
					break;
				}

				if (!Attack2(battle, waves.RearGuard, waves.EnemyRearGuard, steps, false, random))
				{
					break;
				}
			}

			return steps;
		}

		private static bool Attack2(
			Battle battle, IEnumerable<int> units, IEnumerable<int> enemyUnits, IList<BattleStep> steps, bool generalAttack, Random random)
		{
			bool result = true;
			BattleStep current = steps[steps.Count - 1];
			BattleStep newStep = new BattleStep(current);
			int targetIndex = -1;

			foreach (int unitIndex in units)
			{
				targetIndex = -1;
				targetIndex = AttackUnits2(
					unitIndex, current.Counts[unitIndex], targetIndex, battle, newStep, BattleSideType.Player, random);
				if (targetIndex < 0)
				{
					result = false;
					break;
				}
			}

			if (generalAttack && battle.General && targetIndex >= 0)
			{
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
					unitIndex, current.EnemyCounts[unitIndex], targetIndex, battle, newStep, BattleSideType.Enemy, random);
				if (targetIndex < 0)
				{
					result = false;
					break;
				}
			}

			if (generalAttack && battle.EnemyGeneral && targetIndex >= 0)
			{
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
			int unitIndex, int unitCount, int targetIndex, Battle battle, BattleStep newStep, BattleSideType attackerSide, Random random)
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
			int[] damages = GetDamageWithTargetUnitReduction(
				battle.Sides[(int)defenderSideType].Units[targetIndex],
				originalDamages,
				reducedDamages);

			if (targetIndex < 0)
			{
				targetIndex = GetTargetIndex(unit, defenderSideStep.Counts, defenderSideStep.Healts);
				damages = GetDamageWithTargetUnitReduction(
					battle.Sides[(int)defenderSideType].Units[targetIndex],
					originalDamages,
					reducedDamages);
			}

			if (targetIndex < 0)
			{
				// no more targets
				return -1;
			}

			foreach(int temp in damages)
			{
				int damage = temp;
				defenderSideStep.Healts[targetIndex] -= damage;
				if(defenderSideStep.Healts[targetIndex] <= 0)
				{
					defenderSideStep.Counts[targetIndex]--;
					damage = -defenderSideStep.Healts[targetIndex];
					defenderSideStep.Healts[targetIndex] = battle.Sides[(int) defenderSideType].Units[targetIndex].Health;

					if(unit.AttackOnArea)
					{
						while(damage > 0)
						{
							int remDamage;
							int killedUnits = Math.DivRem(
								damage, 
								battle.Sides[(int) defenderSideType].Units[targetIndex].Health,
							    out remDamage);

							if(killedUnits < defenderSideStep.Counts[targetIndex])
							{
								defenderSideStep.Counts[targetIndex] -= (short) killedUnits;
								defenderSideStep.Healts[targetIndex] -= (short) remDamage;
								damage = 0;
							}
							else
							{
								// squad killed
								damage -= defenderSideStep.Counts[targetIndex] * defenderSideStep.Healts[targetIndex];
								defenderSideStep.Counts[targetIndex] = 0;

								targetIndex = GetTargetIndex(unit, defenderSideStep.Counts, defenderSideStep.Healts);
								damages = GetDamageWithTargetUnitReduction(
									battle.Sides[(int)defenderSideType].Units[targetIndex],
									originalDamages,
									reducedDamages);

								if(targetIndex < 0)
								{
									// no more targets
									return -1;
								}
							}
						}
					}

					if(unit.AttackWeaknessTarget || defenderSideStep.Counts[targetIndex] == 0)
					{
						targetIndex = GetTargetIndex(unit, defenderSideStep.Counts, defenderSideStep.Healts);
						damages = GetDamageWithTargetUnitReduction(
							battle.Sides[(int)defenderSideType].Units[targetIndex],
							originalDamages,
							reducedDamages);

						if (targetIndex < 0)
						{
							return targetIndex;
						}
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
