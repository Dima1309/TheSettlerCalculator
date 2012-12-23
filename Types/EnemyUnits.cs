using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;

namespace TheSettlersCalculator.Types
{
	internal static class EnemyUnits
	{
		#region Constants
		internal const int SCAVENGER = 0;
		internal const int THUG = 1;
		internal const int STONE_THROWER = 2;
		internal const int GUARD_DOG = 3;
		internal const int RANGER = 4;
		internal const int SKUNK = 5;
		internal const int CULTIST = 6;
		internal const int SWAMP_WITCH = 7;
		internal const int SHADOWS_NEAKER = 8;
		internal const int FANATIC = 9;
		internal const int DARK_PRIEST = 10;
		internal const int FIRE_DANCER = 11;
		internal const int DARK_HIGH_PRIEST = 12;
		internal const int WOLF = 13;
		internal const int ROUGHNECK = 14;
		internal const int ONE_EYED_BERT = 15;
		internal const int METAL_TOOTHED = 16;
		internal const int CHUCK = 17;
		internal const int WILD_MARY = 18;
		internal const int BOWMAN_DESERTER = 19;
		internal const int CANNONNEER_DESERTER = 20;
		internal const int CAVALRY_DESERTER = 21;
		internal const int ELITE_SOLDIER_DESERTER = 22;
		internal const int LONGBOWMAN_DESERTER = 23;
		internal const int MILITIA_DESERTER = 24;
		internal const int RECRUIT_DESERTER = 25;
		internal const int SOLDIER_DESERTER = 26;
		internal const int CROSSBOWMAN_DESERTER = 27;
		internal const int SIR_ROBIN = 28;
		internal const int BIG_BERTHA = 29;
		internal const int DECKSCRUBBER = 30;
		internal const int SABER_RATTLER = 31;
		internal const int KNIFETHROWER = 32;
		internal const int GUNMAN = 33;
		internal const int CALTROP = 34;
		internal const int PETTY_OFFICER_2ND_CLASS = 35;
		internal const int CRAZY_COOK = 36;
		internal const int DANCING_DERVISH = 37;
		internal const int NIGHT_SPAWN = 38;
		
		internal const int NOMAD = 39;
		internal const int COMPOSITE_BOW = 40;
		internal const int LANCE_RIDER = 41;
		internal const int RIDING_BOWMAN = 42;
		internal const int RIDING_AMAZONIAN = 43;
		internal const int CATAPHRACT = 44;
		internal const int UPROARIOUS_BULL = 45;
		
		internal const int THRALL = 46;
		internal const int KARL = 47;
		internal const int HOUSECARL = 48;
		internal const int JOMVIKING = 49;
		internal const int VALKYRIE = 50;
		internal const int BERSERK = 51;
		
		internal const int CROAKER = 52;
		internal const int JAGUAR_WARRIOR = 53;
		internal const int SHAMAN = 54;
		internal const int TRIBESMAN = 55;
		internal const int FULLBACK	= 56;
		internal const int GOALKEEPER = 57;
		internal const int MIDFIELDER = 58;
		internal const int STRIKER = 59;
		
		private const int COUNT = 60;
		#endregion

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
			s_units = new Unit[COUNT];

			Unit unit = new Unit();
			unit.Name = Resources.UNIT_SCAVENGER;
			unit.Health = 40;
			unit.MinDamage = 15;
			unit.MaxDamage = 30;
			unit.Accuracy = 60;
			unit.Experience = 4;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.scavenger.png");
			s_units[SCAVENGER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_THUG;
			unit.Health = 60;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 60;
			unit.Experience = 3;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.thug.png");
			s_units[THUG] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_STONE_THROWER;
			unit.Health = 10;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 60;
			unit.Experience = 3;
			unit.TowerBonus = true;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.stoneThrower.png");
			s_units[STONE_THROWER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_GUARD_DOG;
			unit.Health = 5;
			unit.MinDamage = 5;
			unit.MaxDamage = 10;
			unit.Accuracy = 60;
			unit.Experience = 4;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.dog.png");
			s_units[GUARD_DOG] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_RANGER;
			unit.Health = 10;
			unit.MinDamage = 30;
			unit.MaxDamage = 60;
			unit.Accuracy = 60;
			unit.Experience = 4;
			unit.TowerBonus = true;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.ranger.png");
			s_units[RANGER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_SKUNK;
			unit.Health = 5000;
			unit.MinDamage = 1;
			unit.MaxDamage = 100;
			unit.Accuracy = 50;
			unit.Experience = 200;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.skunk.png");
			s_units[SKUNK] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_CULTIST;
			unit.Health = 40;
			unit.MinDamage = 15;
			unit.MaxDamage = 30;
			unit.Accuracy = 80;
			unit.Experience = 3;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.Cultist.png");
			s_units[CULTIST] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_SWAMP_WITCH;
			unit.Health = 13000;
			unit.MinDamage = 400;
			unit.MaxDamage = 600;
			unit.Accuracy = 75;
			unit.Experience = 250;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackOnArea = true;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.swampWitch.png");
			s_units[SWAMP_WITCH] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_SHADOW_SNEAKER;
			unit.Health = 5;
			unit.MinDamage = 0;
			unit.MaxDamage = 5;
			unit.Accuracy = 60;
			unit.Experience = 6;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.ShadowSneaker.png");
			s_units[SHADOWS_NEAKER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_FANATIC;
			unit.Health = 20;
			unit.MinDamage = 30;
			unit.MaxDamage = 60;
			unit.Accuracy = 90;
			unit.Experience = 6;
			unit.TowerBonus = true;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.Fanatic.png");
			s_units[FANATIC] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_DARK_PRIEST;
			unit.Health = 20;
			unit.MinDamage = 40;
			unit.MaxDamage = 80;
			unit.Accuracy = 100;
			unit.Experience = 8;
			unit.TowerBonus = true;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.DarkPriest.png");
			s_units[DARK_PRIEST] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_FIRE_DANCER;
			unit.Health = 30;
			unit.MinDamage = 60;
			unit.MaxDamage = 120;
			unit.Accuracy = 100;
			unit.Experience = 14;
			unit.TowerBonus = true;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.Firedancer.png");
			s_units[FIRE_DANCER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_DARK_HIGH_PRIEST;
			unit.Health = 15000;
			unit.MinDamage = 800;
			unit.MaxDamage = 1000;
			unit.Accuracy = 75;
			unit.Experience = 350;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.DarkHighPriest.png");
			s_units[DARK_HIGH_PRIEST] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_WOLF;
			unit.Health = 10;
			unit.MinDamage = 2;
			unit.MaxDamage = 3;
			unit.Accuracy = 80;
			unit.Experience = 1;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.wolf.png");
			s_units[WOLF] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_ROUGHNECK;
			unit.Health = 90;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 60;
			unit.Experience = 6;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.roughneck.png");
			s_units[ROUGHNECK] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_ONE_EYED_BERT;
			unit.Health = 6000;
			unit.MinDamage = 300;
			unit.MaxDamage = 500;
			unit.Accuracy = 50;
			unit.AttackOnArea = true;
			unit.Experience = 100;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.oneeyedbert.png");
			s_units[ONE_EYED_BERT] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_METAL_TOOTHED;
			unit.Health = 11000;
			unit.MinDamage = 250;
			unit.MaxDamage = 500;
			unit.Accuracy = 50;
			unit.AttackOnArea = true;
			unit.Experience = 160;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.metal_toothed.png");
			s_units[METAL_TOOTHED] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_CHUCK;
			unit.Health = 9000;
			unit.MinDamage = 2000;
			unit.MaxDamage = 2500;
			unit.Accuracy = 50;
			unit.AttackOnArea = true;
			unit.Experience = 250;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.chuck.png");
			s_units[CHUCK] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_WILD_MARY;
			unit.Health = 60000;
			unit.MinDamage = 740;
			unit.MaxDamage = 800;
			unit.Accuracy = 50;
			unit.AttackOnArea = true;
			unit.Experience = 430;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.wild_mary.png");
			s_units[WILD_MARY] = unit;

			unit.Name = Resources.UNIT_RECRUIT_DESERTER;
			unit.Health = 40;
			unit.MinDamage = 15;
			unit.MaxDamage = 30;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 2;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.recruit.png");
			s_units[RECRUIT_DESERTER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_MILITIA_DESERTER;
			unit.Health = 60;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 4;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.militia.png");
			s_units[MILITIA_DESERTER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_SOLDIER_DESERTER;
			unit.Health = 90;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 65;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 6;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.soldier.png");
			s_units[SOLDIER_DESERTER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_ELITE_SOLDIER_DESERTER;
			unit.Health = 120;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 70;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 8;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.elitesoldier.png");
			s_units[ELITE_SOLDIER_DESERTER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_CAVALRY_DESERTER;
			unit.Health = 5;
			unit.MinDamage = 5;
			unit.MaxDamage = 10;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.Experience = 4;
			unit.AttackWeaknessTarget = true;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.cavalry.png");
			s_units[CAVALRY_DESERTER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_BOWMAN_DESERTER;
			unit.Health = 10;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 3;
			unit.TowerBonus = true;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.bowman.png");
			s_units[BOWMAN_DESERTER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_LONGBOWMAN_DESERTER;
			unit.Health = 10;
			unit.MinDamage = 30;
			unit.MaxDamage = 60;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 5;
			unit.TowerBonus = true;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.longbowman.png");
			s_units[LONGBOWMAN_DESERTER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_CROSSBOWMAN_DESERTER;
			unit.Health = 10;
			unit.MinDamage = 45;
			unit.MaxDamage = 90;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 7;
			unit.TowerBonus = true;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.crossbowman.png");
			s_units[CROSSBOWMAN_DESERTER] = unit;

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
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.cannoneer.png");
			s_units[CANNONNEER_DESERTER] = unit;

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
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.sir_robin.png");
			s_units[SIR_ROBIN] = unit;

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
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.big_bertha.png");
			s_units[BIG_BERTHA] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_DECKSCRUBBER;
			unit.Health = 15;
			unit.MinDamage = 10;
			unit.MaxDamage = 15;
			unit.Accuracy = 50;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 1;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.deckscrubber.png");
			s_units[DECKSCRUBBER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_SABER_RATTLER;
			unit.Health = 30;
			unit.MinDamage = 10;
			unit.MaxDamage = 20;
			unit.Accuracy = 50;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 2;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.saber_rattler.png");
			s_units[SABER_RATTLER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_KNIFETHROWER;
			unit.Health = 5;
			unit.MinDamage = 10;
			unit.MaxDamage = 20;
			unit.Accuracy = 50;
			unit.AttackPriority = AttackPriority.Normal;
			unit.TowerBonus = true;
			unit.Experience = 1;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.knifethrower.png");
			s_units[KNIFETHROWER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_GUNMAN;
			unit.Health = 5;
			unit.MinDamage = 20;
			unit.MaxDamage = 30;
			unit.Accuracy = 50;
			unit.AttackPriority = AttackPriority.Normal;
			unit.TowerBonus = true;
			unit.Experience = 2;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.gunman.png");
			s_units[GUNMAN] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_CALTROP;
			unit.Health = 4;
			unit.MinDamage = 0;
			unit.MaxDamage = 20;
			unit.Accuracy = 33;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 1;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.caltrop.png");
			s_units[CALTROP] = unit;

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
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.petty_officer_2nd_class.png");
			s_units[PETTY_OFFICER_2ND_CLASS] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_CRAZY_COOK;
			unit.Health = 5000;
			unit.MinDamage = 200;
			unit.MaxDamage = 300;
			unit.Accuracy = 66;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackOnArea = true;
			unit.Experience = 200;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.craze_cook.png");
			s_units[CRAZY_COOK] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_DANCING_DERVISH;
			unit.Health = 90;
			unit.MinDamage = 60;
			unit.MaxDamage = 120;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.Experience = 20;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.dancing_dervish.png");
			s_units[DANCING_DERVISH] = unit;

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
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.night_spawn.png");
			s_units[NIGHT_SPAWN] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_NOMAD;
			unit.Health = 30;
			unit.MinDamage = 10;
			unit.MaxDamage = 20;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 2;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.nomad.png");
			s_units[NOMAD] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_COMPOSITE_BOW;
			unit.Health = 20;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 2;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.composite_bow.png");
			s_units[COMPOSITE_BOW] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_LANCE_RIDER;
			unit.Health = 20;
			unit.MinDamage = 5;
			unit.MaxDamage = 20;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 4;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.lance_rider.png");
			s_units[LANCE_RIDER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_RIDING_BOWMAN;
			unit.Health = 20;
			unit.MinDamage = 30;
			unit.MaxDamage = 40;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 6;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.riding_bowman.png");
			s_units[RIDING_BOWMAN] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_RIDING_AMAZONIAN;
			unit.Health = 20;
			unit.MinDamage = 40;
			unit.MaxDamage = 60;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 8;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.riding_amazonian.png");
			s_units[RIDING_AMAZONIAN] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_CATAPHRACT;
			unit.Health = 20;
			unit.MinDamage = 90;
			unit.MaxDamage = 90;
			unit.Accuracy = 100;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 12;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.cataphract.png");
			s_units[CATAPHRACT] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_UPROARIOUS_BULL;
			unit.Health = 2000;
			unit.MinDamage = 120;
			unit.MaxDamage = 120;
			unit.Accuracy = 100;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.Experience = 50;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.uproarious_bull.png");
			s_units[UPROARIOUS_BULL] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_THRALL;
			unit.Health = 60;
			unit.MinDamage = 20;
			unit.MaxDamage = 25;
			unit.Accuracy = 85;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 3;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.thrall.png");
			s_units[THRALL] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_KARL;
			unit.Health = 80;
			unit.MinDamage = 40;
			unit.MaxDamage = 50;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 6;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.karl.png");
			s_units[KARL] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_HOUSECARL;
			unit.Health = 140;
			unit.MinDamage = 40;
			unit.MaxDamage = 50;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 10;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.housecarl.png");
			s_units[HOUSECARL] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_JOMVIKING;
			unit.Health = 140;
			unit.MinDamage = 60;
			unit.MaxDamage = 80;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 14;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.jomviking.png");
			s_units[JOMVIKING] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_VALKYRIE;
			unit.Health = 10;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 14;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.valkyrie.png");
			s_units[VALKYRIE] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_BERSERK;
			unit.Health = 90;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 70;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.Experience = 20;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.berserk.png");
			s_units[BERSERK] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_CROAKER;
			unit.Health = 10000;
			unit.MinDamage = 500;
			unit.MaxDamage = 700;
			unit.Accuracy = 50;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 200;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.croaker.png");
			s_units[CROAKER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_TRIBESMAN;
			unit.Health = 40;
			unit.MinDamage = 15;
			unit.MaxDamage = 30;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 2;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.tribesman.png");
			s_units[TRIBESMAN] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_SHAMAN;
			unit.Health = 5;
			unit.MinDamage = 0;
			unit.MaxDamage = 5;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 1;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.shaman.png");
			s_units[SHAMAN] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_JAGUAR_WARRIOR;
			unit.Health = 90;
			unit.MinDamage = 60;
			unit.MaxDamage = 120;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackOnArea = true;
			unit.Experience = 2;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.jaguar_warrior.png");
			s_units[JAGUAR_WARRIOR] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_STRIKER;
			unit.Health = 10;
			unit.MinDamage = 0;
			unit.MaxDamage = 10;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 10;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.striker.png");
			s_units[STRIKER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_FULLBACK;
			unit.Health = 35;
			unit.MinDamage = 25;
			unit.MaxDamage = 35;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 10;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.fullback.png");
			s_units[FULLBACK] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_MIDFIELDER;
			unit.Health = 10;
			unit.MinDamage = 30;
			unit.MaxDamage = 60;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.TowerBonus = true;
			unit.Experience = 5;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.midfielder.png");
			s_units[MIDFIELDER] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_GOALKEEPER;
			unit.Health = 10000;
			unit.MinDamage = 50;
			unit.MaxDamage = 150;
			unit.Accuracy = 75;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.Experience = 20;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.goalkeeper.png");
			s_units[GOALKEEPER] = unit;
		}
	}
}
