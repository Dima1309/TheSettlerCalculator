using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;

namespace TheSettlersCalculator.Types
{
	internal static class EnemyUnits
	{
		#region Fields
		private static Unit[] s_units;
		#endregion

		public static Unit[] Units
		{
			get
			{
				if (s_units == null)
				{
					InitializeUnits();
				}

				return s_units;
			}
		}

		private static void InitializeUnits()
		{
			s_units = new Unit[(int)EnemyUnitsEnum.MAX];

			Unit unit = new Unit();
			unit.Name = Resources.UNIT_SCAVENGER;
			unit.Health = 40;
			unit.MinDamage = 15;
			unit.MaxDamage = 30;
			unit.Accuracy = 60;
			unit.Experience = 4;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.scavenger.png");
			s_units[(int)EnemyUnitsEnum.SCAVENGER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_THUG;
			unit.Health = 60;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 60;
			unit.Experience = 3;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.thug.png");
			s_units[(int)EnemyUnitsEnum.THUG] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_STONE_THROWER;
			unit.Health = 10;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 60;
			unit.Experience = 3;
			unit.TowerBonus = true;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.stoneThrower.png");
			s_units[(int)EnemyUnitsEnum.STONE_THROWER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_GUARD_DOG;
			unit.Health = 5;
			unit.MinDamage = 5;
			unit.MaxDamage = 10;
			unit.Accuracy = 60;
			unit.Experience = 4;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.dog.png");
			s_units[(int)EnemyUnitsEnum.GUARD_DOG] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_RANGER;
			unit.Health = 10;
			unit.MinDamage = 30;
			unit.MaxDamage = 60;
			unit.Accuracy = 60;
			unit.Experience = 4;
			unit.TowerBonus = true;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.ranger.png");
			s_units[(int)EnemyUnitsEnum.RANGER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_SKUNK;
			unit.Health = 5000;
			unit.MinDamage = 1;
			unit.MaxDamage = 100;
			unit.Accuracy = 50;
			unit.Experience = 200;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.skunk.png");
			s_units[(int)EnemyUnitsEnum.SKUNK] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_CULTIST;
			unit.Health = 40;
			unit.MinDamage = 15;
			unit.MaxDamage = 30;
			unit.Accuracy = 80;
			unit.Experience = 3;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.Cultist.png");
			s_units[(int)EnemyUnitsEnum.CULTIST] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_SWAMP_WITCH;
			unit.Health = 13000;
			unit.MinDamage = 400;
			unit.MaxDamage = 600;
			unit.Accuracy = 75;
			unit.Experience = 250;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackOnArea = true;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.swampWitch.png");
			s_units[(int)EnemyUnitsEnum.SWAMP_WITCH] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_SHADOW_SNEAKER;
			unit.Health = 5;
			unit.MinDamage = 0;
			unit.MaxDamage = 5;
			unit.Accuracy = 60;
			unit.Experience = 6;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.ShadowSneaker.png");
			s_units[(int)EnemyUnitsEnum.SHADOWS_NEAKER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_FANATIC;
			unit.Health = 20;
			unit.MinDamage = 30;
			unit.MaxDamage = 60;
			unit.Accuracy = 90;
			unit.Experience = 6;
			unit.TowerBonus = true;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.Fanatic.png");
			s_units[(int)EnemyUnitsEnum.FANATIC] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_DARK_PRIEST;
			unit.Health = 20;
			unit.MinDamage = 40;
			unit.MaxDamage = 80;
			unit.Accuracy = 100;
			unit.Experience = 8;
			unit.TowerBonus = true;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.DarkPriest.png");
			s_units[(int)EnemyUnitsEnum.DARK_PRIEST] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_FIRE_DANCER;
			unit.Health = 30;
			unit.MinDamage = 60;
			unit.MaxDamage = 120;
			unit.Accuracy = 100;
			unit.Experience = 14;
			unit.TowerBonus = true;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.Firedancer.png");
			s_units[(int)EnemyUnitsEnum.FIRE_DANCER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_DARK_HIGH_PRIEST;
			unit.Health = 15000;
			unit.MinDamage = 800;
			unit.MaxDamage = 1000;
			unit.Accuracy = 75;
			unit.Experience = 350;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.DarkHighPriest.png");
			s_units[(int)EnemyUnitsEnum.DARK_HIGH_PRIEST] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_WOLF;
			unit.Health = 10;
			unit.MinDamage = 2;
			unit.MaxDamage = 3;
			unit.Accuracy = 80;
			unit.Experience = 1;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.wolf.png");
			s_units[(int)EnemyUnitsEnum.WOLF] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_ROUGHNECK;
			unit.Health = 90;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 60;
			unit.Experience = 6;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.roughneck.png");
			s_units[(int)EnemyUnitsEnum.ROUGHNECK] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_ONE_EYED_BERT;
			unit.Health = 6000;
			unit.MinDamage = 300;
			unit.MaxDamage = 500;
			unit.Accuracy = 50;
			unit.AttackOnArea = true;
			unit.Experience = 100;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.oneeyedbert.png");
			s_units[(int)EnemyUnitsEnum.ONE_EYED_BERT] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_METAL_TOOTHED;
			unit.Health = 11000;
			unit.MinDamage = 250;
			unit.MaxDamage = 500;
			unit.Accuracy = 50;
			unit.AttackOnArea = true;
			unit.Experience = 160;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.metal_toothed.png");
			s_units[(int)EnemyUnitsEnum.METAL_TOOTHED] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_CHUCK;
			unit.Health = 9000;
			unit.MinDamage = 2000;
			unit.MaxDamage = 2500;
			unit.Accuracy = 50;
			unit.AttackOnArea = true;
			unit.Experience = 250;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.chuck.png");
			s_units[(int)EnemyUnitsEnum.CHUCK] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_WILD_MARY;
			unit.Health = 60000;
			unit.MinDamage = 740;
			unit.MaxDamage = 800;
			unit.Accuracy = 50;
			unit.AttackOnArea = true;
			unit.Experience = 430;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.wild_mary.png");
			s_units[(int)EnemyUnitsEnum.WILD_MARY] = unit;

			unit.Name = Resources.UNIT_RECRUIT_DESERTER;
			unit.Health = 40;
			unit.MinDamage = 15;
			unit.MaxDamage = 30;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 2;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.recruit.png");
			s_units[(int)EnemyUnitsEnum.RECRUIT_DESERTER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_MILITIA_DESERTER;
			unit.Health = 60;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 4;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.militia.png");
			s_units[(int)EnemyUnitsEnum.MILITIA_DESERTER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_SOLDIER_DESERTER;
			unit.Health = 90;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 65;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 6;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.soldier.png");
			s_units[(int)EnemyUnitsEnum.SOLDIER_DESERTER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_ELITE_SOLDIER_DESERTER;
			unit.Health = 120;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 70;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 8;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.elitesoldier.png");
			s_units[(int)EnemyUnitsEnum.ELITE_SOLDIER_DESERTER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_CAVALRY_DESERTER;
			unit.Health = 5;
			unit.MinDamage = 5;
			unit.MaxDamage = 10;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.Experience = 4;
			unit.AttackWeaknessTarget = true;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.cavalry.png");
			s_units[(int)EnemyUnitsEnum.CAVALRY_DESERTER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_BOWMAN_DESERTER;
			unit.Health = 10;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 3;
			unit.TowerBonus = true;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.bowman.png");
			s_units[(int)EnemyUnitsEnum.BOWMAN_DESERTER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_LONGBOWMAN_DESERTER;
			unit.Health = 10;
			unit.MinDamage = 30;
			unit.MaxDamage = 60;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 5;
			unit.TowerBonus = true;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.longbowman.png");
			s_units[(int)EnemyUnitsEnum.LONGBOWMAN_DESERTER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_CROSSBOWMAN_DESERTER;
			unit.Health = 10;
			unit.MinDamage = 45;
			unit.MaxDamage = 90;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 7;
			unit.TowerBonus = true;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.crossbowman.png");
			s_units[(int)EnemyUnitsEnum.CROSSBOWMAN_DESERTER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_CANNONNEER_DESERTER;
			unit.Health = 60;
			unit.MinDamage = 60;
			unit.MaxDamage = 120;
			unit.Accuracy = 70;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 15;
			unit.TowerBonus = true;
			unit.IgnoreTowerBonus = 100;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.cannoneer.png");
			s_units[(int)EnemyUnitsEnum.CANNONEER_DESERTER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_SIR_ROBIN;
			unit.Health = 12000;
			unit.MinDamage = 200;
			unit.MaxDamage = 600;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.Experience = 200;
			unit.AttackOnArea = true;
			unit.AttackWeaknessTarget = true;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.sir_robin.png");
			s_units[(int)EnemyUnitsEnum.SIR_ROBIN] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_BIG_BERTHA;
			unit.Health = 40000;
			unit.MinDamage = 50;
			unit.MaxDamage = 150;
			unit.Accuracy = 75;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.Experience = 350;
			unit.AttackOnArea = true;
			unit.AttackWeaknessTarget = true;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.big_bertha.png");
			s_units[(int)EnemyUnitsEnum.BIG_BERTHA] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_DECKSCRUBBER;
			unit.Health = 15;
			unit.MinDamage = 10;
			unit.MaxDamage = 15;
			unit.Accuracy = 50;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 1;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.deckscrubber.png");
			s_units[(int)EnemyUnitsEnum.DECKSCRUBBER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_SABER_RATTLER;
			unit.Health = 30;
			unit.MinDamage = 10;
			unit.MaxDamage = 20;
			unit.Accuracy = 50;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 2;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.saber_rattler.png");
			s_units[(int)EnemyUnitsEnum.SABER_RATTLER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_KNIFETHROWER;
			unit.Health = 5;
			unit.MinDamage = 10;
			unit.MaxDamage = 20;
			unit.Accuracy = 50;
			unit.AttackPriority = AttackPriority.Normal;
			unit.TowerBonus = true;
			unit.Experience = 1;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.knifethrower.png");
			s_units[(int)EnemyUnitsEnum.KNIFETHROWER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_GUNMAN;
			unit.Health = 5;
			unit.MinDamage = 20;
			unit.MaxDamage = 30;
			unit.Accuracy = 50;
			unit.AttackPriority = AttackPriority.Normal;
			unit.TowerBonus = true;
			unit.Experience = 2;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.gunman.png");
			s_units[(int)EnemyUnitsEnum.GUNMAN] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_CALTROP;
			unit.Health = 4;
			unit.MinDamage = 0;
			unit.MaxDamage = 20;
			unit.Accuracy = 33;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 1;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.caltrop.png");
			s_units[(int)EnemyUnitsEnum.CALTROP] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_PETTY_OFFICER_2ND_CLASS;
			unit.Health = 60;
			unit.MinDamage = 40;
			unit.MaxDamage = 60;
			unit.Accuracy = 70;
			unit.AttackPriority = AttackPriority.Normal;
			unit.AttackWeaknessTarget = true;
			unit.AttackOnArea = true;
			unit.Experience = 6;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.petty_officer_2nd_class.png");
			s_units[(int)EnemyUnitsEnum.PETTY_OFFICER_2ND_CLASS] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_CRAZY_COOK;
			unit.Health = 5000;
			unit.MinDamage = 200;
			unit.MaxDamage = 300;
			unit.Accuracy = 66;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackOnArea = true;
			unit.Experience = 200;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.crazy_cook.png");
			s_units[(int)EnemyUnitsEnum.CRAZY_COOK] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_DANCING_DERVISH;
			unit.Health = 90;
			unit.MinDamage = 60;
			unit.MaxDamage = 120;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.Experience = 20;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.dancing_dervish.png");
			s_units[(int)EnemyUnitsEnum.DANCING_DERVISH] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_NIGHT_SPAWN;
			unit.Health = 35000;
			unit.MinDamage = 700;
			unit.MaxDamage = 800;
			unit.Accuracy = 75;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackOnArea = true;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 500;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.night_spawn.png");
			s_units[(int)EnemyUnitsEnum.NIGHT_SPAWN] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_NOMAD;
			unit.Health = 30;
			unit.MinDamage = 10;
			unit.MaxDamage = 20;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 2;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.nomad.png");
			s_units[(int)EnemyUnitsEnum.NOMAD] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_COMPOSITE_BOW;
			unit.Health = 20;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 2;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.composite_bow.png");
			s_units[(int)EnemyUnitsEnum.COMPOSITE_BOW] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_LANCE_RIDER;
			unit.Health = 20;
			unit.MinDamage = 5;
			unit.MaxDamage = 20;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 4;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.lance_rider.png");
			s_units[(int)EnemyUnitsEnum.LANCE_RIDER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_RIDING_BOWMAN;
			unit.Health = 20;
			unit.MinDamage = 30;
			unit.MaxDamage = 40;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 6;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.riding_bowman.png");
			s_units[(int)EnemyUnitsEnum.RIDING_BOWMAN] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_RIDING_AMAZONIAN;
			unit.Health = 20;
			unit.MinDamage = 40;
			unit.MaxDamage = 60;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 8;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.riding_amazonian.png");
			s_units[(int)EnemyUnitsEnum.RIDING_AMAZONIAN] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_CATAPHRACT;
			unit.Health = 20;
			unit.MinDamage = 90;
			unit.MaxDamage = 90;
			unit.Accuracy = 100;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 12;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.cataphract.png");
			s_units[(int)EnemyUnitsEnum.CATAPHRACT] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_UPROARIOUS_BULL;
			unit.Health = 2000;
			unit.MinDamage = 120;
			unit.MaxDamage = 120;
			unit.Accuracy = 100;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.Experience = 50;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.uproarious_bull.png");
			s_units[(int)EnemyUnitsEnum.UPROARIOUS_BULL] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_THRALL;
			unit.Health = 60;
			unit.MinDamage = 20;
			unit.MaxDamage = 25;
			unit.Accuracy = 85;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 3;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.thrall.png");
			s_units[(int)EnemyUnitsEnum.THRALL] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_KARL;
			unit.Health = 80;
			unit.MinDamage = 40;
			unit.MaxDamage = 50;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 6;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.karl.png");
			s_units[(int)EnemyUnitsEnum.KARL] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_HOUSECARL;
			unit.Health = 140;
			unit.MinDamage = 40;
			unit.MaxDamage = 50;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 10;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.housecarl.png");
			s_units[(int)EnemyUnitsEnum.HOUSECARL] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_JOMVIKING;
			unit.Health = 140;
			unit.MinDamage = 60;
			unit.MaxDamage = 80;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 14;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.jomviking.png");
			s_units[(int)EnemyUnitsEnum.JOMVIKING] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_VALKYRIE;
			unit.Health = 10;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 14;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.valkyrie.png");
			s_units[(int)EnemyUnitsEnum.VALKYRIE] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_BERSERK;
			unit.Health = 90;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 70;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.Experience = 20;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.berserk.png");
			s_units[(int)EnemyUnitsEnum.BERSERK] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_CROAKER;
			unit.Health = 10000;
			unit.MinDamage = 500;
			unit.MaxDamage = 700;
			unit.Accuracy = 50;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 200;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.croaker.png");
			s_units[(int)EnemyUnitsEnum.CROAKER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_TRIBESMAN;
			unit.Health = 40;
			unit.MinDamage = 15;
			unit.MaxDamage = 30;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 2;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.tribesman.png");
			s_units[(int)EnemyUnitsEnum.TRIBESMAN] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_SHAMAN;
			unit.Health = 5;
			unit.MinDamage = 0;
			unit.MaxDamage = 5;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 1;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.shaman.png");
			s_units[(int)EnemyUnitsEnum.SHAMAN] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_JAGUAR_WARRIOR;
			unit.Health = 90;
			unit.MinDamage = 60;
			unit.MaxDamage = 120;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackOnArea = true;
			unit.Experience = 2;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.jaguar_warrior.png");
			s_units[(int)EnemyUnitsEnum.JAGUAR_WARRIOR] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_STRIKER;
			unit.Health = 10;
			unit.MinDamage = 0;
			unit.MaxDamage = 10;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 10;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.striker.png");
			s_units[(int)EnemyUnitsEnum.STRIKER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_FULLBACK;
			unit.Health = 35;
			unit.MinDamage = 25;
			unit.MaxDamage = 35;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 10;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.fullback.png");
			s_units[(int)EnemyUnitsEnum.FULLBACK] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_MIDFIELDER;
			unit.Health = 10;
			unit.MinDamage = 30;
			unit.MaxDamage = 60;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.TowerBonus = true;
			unit.Experience = 5;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.midfielder.png");
			s_units[(int)EnemyUnitsEnum.MIDFIELDER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_GOALKEEPER;
			unit.Health = 10000;
			unit.MinDamage = 50;
			unit.MaxDamage = 150;
			unit.Accuracy = 75;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.Experience = 20;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.goalkeeper.png");
			s_units[(int)EnemyUnitsEnum.GOALKEEPER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_BOAR;
			unit.Health = 100;
			unit.MinDamage = 30;
			unit.MaxDamage = 60;
			unit.Accuracy = 85;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 12;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.boar.png");
			s_units[(int)EnemyUnitsEnum.BOAR] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_BEAR;
			unit.Health = 140;
			unit.MinDamage = 70;
			unit.MaxDamage = 90;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 18;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.bear.png");
			s_units[(int)EnemyUnitsEnum.BEAR] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_WOLF;
			unit.Health = 40;
			unit.MinDamage = 60;
			unit.MaxDamage = 100;
			unit.Accuracy = 85;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 10;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.wolf2.png");
			s_units[(int)EnemyUnitsEnum.WOLF2] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_FOX;
			unit.Health = 30;
			unit.MinDamage = 10;
			unit.MaxDamage = 40;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 12;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.fox.png");
			s_units[(int)EnemyUnitsEnum.FOX] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_ROYAL_RECRUIT;
			unit.Health = 100;
			unit.MinDamage = 30;
			unit.MaxDamage = 60;
			unit.Accuracy = 85;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 0;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.recruit.png");
			s_units[(int)EnemyUnitsEnum.ROYAL_RECRUIT] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_ROYAL_MILITIA;
			unit.Health = 160;
			unit.MinDamage = 70;
			unit.MaxDamage = 90;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 0;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.militia.png");
			s_units[(int)EnemyUnitsEnum.ROYAL_MILITIA] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_ROYAL_BOWMAN;
			unit.Health = 40;
			unit.MinDamage = 60;
			unit.MaxDamage = 100;
			unit.Accuracy = 85;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 0;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.bowman.png");
			s_units[(int)EnemyUnitsEnum.ROYAL_BOWMAN] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_ROYAL_LONGBOWMAN;
			unit.Health = 60;
			unit.MinDamage = 80;
			unit.MaxDamage = 140;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 0;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.longbowman.png");
			s_units[(int)EnemyUnitsEnum.ROYAL_LONGBOWMAN] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_ROYAL_LONGBOWMAN;
			unit.Health = 60;
			unit.MinDamage = 80;
			unit.MaxDamage = 140;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 0;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.longbowman.png");
			s_units[(int)EnemyUnitsEnum.ROYAL_LONGBOWMAN] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_ROYAL_CAVALRY;
			unit.Health = 40;
			unit.MinDamage = 10;
			unit.MaxDamage = 40;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 0;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.cavalry.png");
			s_units[(int)EnemyUnitsEnum.ROYAL_CAVALRY] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_ROYAL_CANNONEER;
			unit.Health = 160;
			unit.MinDamage = 60;
			unit.MaxDamage = 90;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 0;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.cannoneer.png");
			s_units[(int)EnemyUnitsEnum.ROYAL_CANNONEER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_GIANT_LEADER_1;
			unit.Health = 90000;
			unit.MinDamage = 100;
			unit.MaxDamage = 300;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.Experience = 150;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.giant_leader1.png");
			s_units[(int)EnemyUnitsEnum.GIANT_LEADER1] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_GIANT_LEADER_2;
			unit.Health = 70000;
			unit.MinDamage = 100;
			unit.MaxDamage = 250;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.Experience = 150;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.giant_leader2.png");
			s_units[(int)EnemyUnitsEnum.GIANT_LEADER2] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_UNICORN;
			unit.Health = 30000;
			unit.MinDamage = 250;
			unit.MaxDamage = 400;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.Normal;
			unit.AttackOnArea = true;
			unit.Experience = 300;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.unicorn.png");
			s_units[(int)EnemyUnitsEnum.UNICORN] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_GIANT_BOAR;
			unit.Health = 50000;
			unit.MinDamage = 200;
			unit.MaxDamage = 300;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.Normal;
			unit.AttackOnArea = true;
			unit.Experience = 400;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.giant_boar.png");
			s_units[(int)EnemyUnitsEnum.GIANT_BOAR] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_EVIL_KING;
			unit.Health = 30000;
			unit.MinDamage = 200;
			unit.MaxDamage = 300;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.AttackOnArea = true;
			unit.Experience = 800;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.evil_king.png");
			s_units[(int)EnemyUnitsEnum.EVIL_KING] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_WOLF_PACKLOADER;
			unit.Health = 60;
			unit.MinDamage = 80;
			unit.MaxDamage = 140;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 16;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.wolf_packloader.png");
			s_units[(int)EnemyUnitsEnum.WOLF_PACKLOADER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_GIANT;
			unit.Health = 160;
			unit.MinDamage = 60;
			unit.MaxDamage = 90;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 26;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.giant.png");
			s_units[(int)EnemyUnitsEnum.GIANT] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_GIANT;
			unit.Health = 160;
			unit.MinDamage = 60;
			unit.MaxDamage = 90;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 26;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.giant.png");
			s_units[(int)EnemyUnitsEnum.GIANT] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_GIANT_BEAR;
			unit.Health = 55000;
			unit.MinDamage = 400;
			unit.MaxDamage = 750;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.Experience = 1000;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.giant_bear.png");
			s_units[(int)EnemyUnitsEnum.GIANT_BEAR] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_ASSASSINE;
			unit.Health = 30000;
			unit.MinDamage = 200;
			unit.MaxDamage = 300;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.AttackOnArea = true;
			unit.Experience = 950;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.assassine.png");
			s_units[(int)EnemyUnitsEnum.ASSASSINE] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_GREEDY_INNKEEPER;
			unit.Health = 50000;
			unit.MinDamage = 1500;
			unit.MaxDamage = 2000;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 1200;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.greedy_innkeeper.png");
			s_units[(int)EnemyUnitsEnum.GREEDY_INNKEEPER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_IRON_FIST;
			unit.Health = 45000;
			unit.MinDamage = 200;
			unit.MaxDamage = 250;
			unit.Accuracy = 85;
			unit.AttackPriority = AttackPriority.Normal;
			unit.AttackOnArea = true;
			unit.Experience = 0;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.iron_fist.png");
			s_units[(int)EnemyUnitsEnum.IRON_FIRST] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_RIVAL_DRESSMAKER;
			unit.Health = 40000;
			unit.MinDamage = 150;
			unit.MaxDamage = 250;
			unit.Accuracy = 75;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 500;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.rival_dressmaker.png");
			s_units[(int)EnemyUnitsEnum.RIVAL_DRESSMAKER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_LYING_GOAT;
			unit.Health = 25000;
			unit.MinDamage = 100;
			unit.MaxDamage = 150;
			unit.Accuracy = 85;
			unit.AttackPriority = AttackPriority.Normal;
			unit.AttackOnArea = true;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 300;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.lying_goat.png");
			s_units[(int)EnemyUnitsEnum.LYING_GOAT] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_THUG_LEADER;
			unit.Health = 40000;
			unit.MinDamage = 200;
			unit.MaxDamage = 300;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.AttackOnArea = true;
			unit.Experience = 900;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.thug_leader.png");
			s_units[(int)EnemyUnitsEnum.THUG_LEADER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_BLACK_BULL;
			unit.Health = 60000;
			unit.MinDamage = 250;
			unit.MaxDamage = 300;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.Normal;
			unit.AttackOnArea = true;
			unit.Experience = 600;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.black_bull.png");
			s_units[(int)EnemyUnitsEnum.BLACK_BULL] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_DARK_WIZARD;
			unit.Health = 30000;
			unit.MinDamage = 2000;
			unit.MaxDamage = 2500;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.AttackOnArea = true;
			unit.Experience = 1200;
			unit.Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Images.dark_wizard.png");
			s_units[(int)EnemyUnitsEnum.DARK_WIZARD] = unit;
		}
	}
}
