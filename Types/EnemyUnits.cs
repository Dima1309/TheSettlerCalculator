using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using TheSettlersCalculator.Properties;

namespace TheSettlersCalculator.Types
{
	internal static class EnemyUnits
	{
		private const string FILENAME = "enemies.xml";
		private const string UNITS_TAG = "units";

		#region Fields
		private static Unit[] s_units;

		#endregion

		public static Unit[] Units
		{
			get
			{
				if (s_units == null)
				{
					Load();
				}

				return s_units;
			}
		}

		private static void InitializeUnits()
		{
			s_units = new Unit[(int)EnemyUnitsEnum.MAX];

			Unit unit = new Unit("SCAVENGER");
			unit.Name = Resources.UNIT_SCAVENGER;
			unit.Health = 40;
			unit.MinDamage = 15;
			unit.MaxDamage = 30;
			unit.Accuracy = 60;
			unit.Experience = 4;
			unit.AttackPriority = AttackPriority.Normal;
			unit.IconPath = "Images\\scavenger.png";
			s_units[(int)EnemyUnitsEnum.SCAVENGER] = unit;

			unit = new Unit("THUG");
			unit.Name = Resources.UNIT_THUG;
			unit.Health = 60;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 60;
			unit.Experience = 3;
			unit.AttackPriority = AttackPriority.Normal;
			unit.IconPath = "Images\\thug.png";
			s_units[(int)EnemyUnitsEnum.THUG] = unit;

			unit = new Unit("STONE_THROWER");
			unit.Name = Resources.UNIT_STONE_THROWER;
			unit.Health = 10;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 60;
			unit.Experience = 3;
			unit.TowerBonus = true;
			unit.AttackPriority = AttackPriority.Normal;
			unit.IconPath = "Images\\stoneThrower.png";
			s_units[(int)EnemyUnitsEnum.STONE_THROWER] = unit;

			unit = new Unit("GUARD_DOG");
			unit.Name = Resources.UNIT_GUARD_DOG;
			unit.Health = 5;
			unit.MinDamage = 5;
			unit.MaxDamage = 10;
			unit.Accuracy = 60;
			unit.Experience = 4;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.IconPath = "Images\\dog.png";
			s_units[(int)EnemyUnitsEnum.GUARD_DOG] = unit;

			unit = new Unit("RANGER");
			unit.Name = Resources.UNIT_RANGER;
			unit.Health = 10;
			unit.MinDamage = 30;
			unit.MaxDamage = 60;
			unit.Accuracy = 60;
			unit.Experience = 4;
			unit.TowerBonus = true;
			unit.AttackPriority = AttackPriority.Normal;
			unit.IconPath = "Images\\ranger.png";
			s_units[(int)EnemyUnitsEnum.RANGER] = unit;

			unit = new Unit("SKUNK");
			unit.Name = Resources.UNIT_SKUNK;
			unit.Health = 5000;
			unit.MinDamage = 1;
			unit.MaxDamage = 100;
			unit.Accuracy = 50;
			unit.Experience = 200;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.IconPath = "Images\\skunk.png";
			s_units[(int)EnemyUnitsEnum.SKUNK] = unit;

			unit = new Unit("CULTIST");
			unit.Name = Resources.UNIT_CULTIST;
			unit.Health = 40;
			unit.MinDamage = 15;
			unit.MaxDamage = 30;
			unit.Accuracy = 80;
			unit.Experience = 3;
			unit.AttackPriority = AttackPriority.Normal;
			unit.IconPath = "Images\\Cultist.png";
			s_units[(int)EnemyUnitsEnum.CULTIST] = unit;

			unit = new Unit("SWAMP_WITCH");
			unit.Name = Resources.UNIT_SWAMP_WITCH;
			unit.Health = 13000;
			unit.MinDamage = 400;
			unit.MaxDamage = 600;
			unit.Accuracy = 75;
			unit.Experience = 250;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackOnArea = true;
			unit.IconPath = "Images\\swampWitch.png";
			s_units[(int)EnemyUnitsEnum.SWAMP_WITCH] = unit;

			unit = new Unit("SHADOW_SNEAKER");
			unit.Name = Resources.UNIT_SHADOW_SNEAKER;
			unit.Health = 5;
			unit.MinDamage = 0;
			unit.MaxDamage = 5;
			unit.Accuracy = 60;
			unit.Experience = 6;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.IconPath = "Images\\ShadowSneaker.png";
			s_units[(int)EnemyUnitsEnum.SHADOWS_NEAKER] = unit;

			unit = new Unit("FANATIC");
			unit.Name = Resources.UNIT_FANATIC;
			unit.Health = 20;
			unit.MinDamage = 30;
			unit.MaxDamage = 60;
			unit.Accuracy = 90;
			unit.Experience = 6;
			unit.TowerBonus = true;
			unit.AttackPriority = AttackPriority.Normal;
			unit.IconPath = "Images\\Fanatic.png";
			s_units[(int)EnemyUnitsEnum.FANATIC] = unit;

			unit = new Unit("DARK_PRIEST");
			unit.Name = Resources.UNIT_DARK_PRIEST;
			unit.Health = 20;
			unit.MinDamage = 40;
			unit.MaxDamage = 80;
			unit.Accuracy = 100;
			unit.Experience = 8;
			unit.TowerBonus = true;
			unit.AttackPriority = AttackPriority.Normal;
			unit.IconPath = "Images\\DarkPriest.png";
			s_units[(int)EnemyUnitsEnum.DARK_PRIEST] = unit;

			unit = new Unit("FIRE_DANCER");
			unit.Name = Resources.UNIT_FIRE_DANCER;
			unit.Health = 30;
			unit.MinDamage = 60;
			unit.MaxDamage = 120;
			unit.Accuracy = 100;
			unit.Experience = 14;
			unit.TowerBonus = true;
			unit.AttackPriority = AttackPriority.Normal;
			unit.IconPath = "Images\\Firedancer.png";
			s_units[(int)EnemyUnitsEnum.FIRE_DANCER] = unit;

			unit = new Unit("DARK_HIGH_PRIEST");
			unit.Name = Resources.UNIT_DARK_HIGH_PRIEST;
			unit.Health = 15000;
			unit.MinDamage = 800;
			unit.MaxDamage = 1000;
			unit.Accuracy = 75;
			unit.Experience = 350;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.IconPath = "Images\\DarkHighPriest.png";
			s_units[(int)EnemyUnitsEnum.DARK_HIGH_PRIEST] = unit;

			unit = new Unit("WOLF");
			unit.Name = Resources.UNIT_WOLF;
			unit.Health = 10;
			unit.MinDamage = 2;
			unit.MaxDamage = 3;
			unit.Accuracy = 80;
			unit.Experience = 1;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.IconPath = "Images\\wolf.png";
			s_units[(int)EnemyUnitsEnum.WOLF] = unit;

			unit = new Unit("ROUGHNECK");
			unit.Name = Resources.UNIT_ROUGHNECK;
			unit.Health = 90;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 60;
			unit.Experience = 6;
			unit.AttackPriority = AttackPriority.Normal;
			unit.IconPath = "Images\\roughneck.png";
			s_units[(int)EnemyUnitsEnum.ROUGHNECK] = unit;

			unit = new Unit("ONE_EYED_BERT");
			unit.Name = Resources.UNIT_ONE_EYED_BERT;
			unit.Health = 6000;
			unit.MinDamage = 300;
			unit.MaxDamage = 500;
			unit.Accuracy = 50;
			unit.AttackOnArea = true;
			unit.Experience = 100;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.IconPath = "Images\\oneeyedbert.png";
			s_units[(int)EnemyUnitsEnum.ONE_EYED_BERT] = unit;

			unit = new Unit("METAL_TOOTHED");
			unit.Name = Resources.UNIT_METAL_TOOTHED;
			unit.Health = 11000;
			unit.MinDamage = 250;
			unit.MaxDamage = 500;
			unit.Accuracy = 50;
			unit.AttackOnArea = true;
			unit.Experience = 160;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.IconPath = "Images\\metal_toothed.png";
			s_units[(int)EnemyUnitsEnum.METAL_TOOTHED] = unit;

			unit = new Unit("CHUCK");
			unit.Name = Resources.UNIT_CHUCK;
			unit.Health = 9000;
			unit.MinDamage = 2000;
			unit.MaxDamage = 2500;
			unit.Accuracy = 50;
			unit.AttackOnArea = true;
			unit.Experience = 250;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.IconPath = "Images\\chuck.png";
			s_units[(int)EnemyUnitsEnum.CHUCK] = unit;

			unit = new Unit("WILD_MARY");
			unit.Name = Resources.UNIT_WILD_MARY;
			unit.Health = 60000;
			unit.MinDamage = 740;
			unit.MaxDamage = 800;
			unit.Accuracy = 50;
			unit.AttackOnArea = true;
			unit.Experience = 430;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.IconPath = "Images\\wild_mary.png";
			s_units[(int)EnemyUnitsEnum.WILD_MARY] = unit;

			unit = new Unit("RECRUIT_DESERTER");
			unit.Name = Resources.UNIT_RECRUIT_DESERTER;
			unit.Health = 40;
			unit.MinDamage = 15;
			unit.MaxDamage = 30;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 2;
			unit.IconPath = "Images\\recruit.png";
			s_units[(int)EnemyUnitsEnum.RECRUIT_DESERTER] = unit;

			unit = new Unit("MILITIA_DESERTER");
			unit.Name = Resources.UNIT_MILITIA_DESERTER;
			unit.Health = 60;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 4;
			unit.IconPath = "Images\\militia.png";
			s_units[(int)EnemyUnitsEnum.MILITIA_DESERTER] = unit;

			unit = new Unit("SOLDIER_DESERTER");
			unit.Name = Resources.UNIT_SOLDIER_DESERTER;
			unit.Health = 90;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 65;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 6;
			unit.IconPath = "Images\\soldier.png";
			s_units[(int)EnemyUnitsEnum.SOLDIER_DESERTER] = unit;

			unit = new Unit("ELITE_SOLDIER_DESERTER");
			unit.Name = Resources.UNIT_ELITE_SOLDIER_DESERTER;
			unit.Health = 120;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 70;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 8;
			unit.IconPath = "Images\\elitesoldier.png";
			s_units[(int)EnemyUnitsEnum.ELITE_SOLDIER_DESERTER] = unit;

			unit = new Unit("CAVALRY_DESERTER");
			unit.Name = Resources.UNIT_CAVALRY_DESERTER;
			unit.Health = 5;
			unit.MinDamage = 5;
			unit.MaxDamage = 10;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.Experience = 4;
			unit.AttackWeaknessTarget = true;
			unit.IconPath = "Images\\cavalry.png";
			s_units[(int)EnemyUnitsEnum.CAVALRY_DESERTER] = unit;

			unit = new Unit("BOWMAN_DESERTER");
			unit.Name = Resources.UNIT_BOWMAN_DESERTER;
			unit.Health = 10;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 3;
			unit.TowerBonus = true;
			unit.IconPath = "Images\\bowman.png";
			s_units[(int)EnemyUnitsEnum.BOWMAN_DESERTER] = unit;

			unit = new Unit("LONGBOWMAN_DESERTER");
			unit.Name = Resources.UNIT_LONGBOWMAN_DESERTER;
			unit.Health = 10;
			unit.MinDamage = 30;
			unit.MaxDamage = 60;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 5;
			unit.TowerBonus = true;
			unit.IconPath = "Images\\longbowman.png";
			s_units[(int)EnemyUnitsEnum.LONGBOWMAN_DESERTER] = unit;

			unit = new Unit("CROSSBOWMAN_DESERTER");
			unit.Name = Resources.UNIT_CROSSBOWMAN_DESERTER;
			unit.Health = 10;
			unit.MinDamage = 45;
			unit.MaxDamage = 90;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 7;
			unit.TowerBonus = true;
			unit.IconPath = "Images\\crossbowman.png";
			s_units[(int)EnemyUnitsEnum.CROSSBOWMAN_DESERTER] = unit;

			unit = new Unit("CANNONNEER_DESERTER");
			unit.Name = Resources.UNIT_CANNONNEER_DESERTER;
			unit.Health = 60;
			unit.MinDamage = 60;
			unit.MaxDamage = 120;
			unit.Accuracy = 70;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 15;
			unit.TowerBonus = true;
			unit.IgnoreTowerBonus = 100;
			unit.IconPath = "Images\\cannoneer.png";
			s_units[(int)EnemyUnitsEnum.CANNONEER_DESERTER] = unit;

			unit = new Unit("SIR_ROBIN");
			unit.Name = Resources.UNIT_SIR_ROBIN;
			unit.Health = 12000;
			unit.MinDamage = 200;
			unit.MaxDamage = 600;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.Experience = 200;
			unit.AttackOnArea = true;
			unit.AttackWeaknessTarget = true;
			unit.IconPath = "Images\\sir_robin.png";
			s_units[(int)EnemyUnitsEnum.SIR_ROBIN] = unit;

			unit = new Unit("BIG_BERTHA");
			unit.Name = Resources.UNIT_BIG_BERTHA;
			unit.Health = 40000;
			unit.MinDamage = 50;
			unit.MaxDamage = 150;
			unit.Accuracy = 75;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.Experience = 350;
			unit.AttackOnArea = true;
			unit.AttackWeaknessTarget = true;
			unit.IconPath = "Images\\big_bertha.png";
			s_units[(int)EnemyUnitsEnum.BIG_BERTHA] = unit;

			unit = new Unit("DECKSCRUBBER");
			unit.Name = Resources.UNIT_DECKSCRUBBER;
			unit.Health = 15;
			unit.MinDamage = 10;
			unit.MaxDamage = 15;
			unit.Accuracy = 50;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 1;
			unit.IconPath = "Images\\deckscrubber.png";
			s_units[(int)EnemyUnitsEnum.DECKSCRUBBER] = unit;

			unit = new Unit("SABER_RATTLER");
			unit.Name = Resources.UNIT_SABER_RATTLER;
			unit.Health = 30;
			unit.MinDamage = 10;
			unit.MaxDamage = 20;
			unit.Accuracy = 50;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 2;
			unit.IconPath = "Images\\saber_rattler.png";
			s_units[(int)EnemyUnitsEnum.SABER_RATTLER] = unit;

			unit = new Unit("KNIFETHROWER");
			unit.Name = Resources.UNIT_KNIFETHROWER;
			unit.Health = 5;
			unit.MinDamage = 10;
			unit.MaxDamage = 20;
			unit.Accuracy = 50;
			unit.AttackPriority = AttackPriority.Normal;
			unit.TowerBonus = true;
			unit.Experience = 1;
			unit.IconPath = "Images\\knifethrower.png";
			s_units[(int)EnemyUnitsEnum.KNIFETHROWER] = unit;

			unit = new Unit("GUNMAN");
			unit.Name = Resources.UNIT_GUNMAN;
			unit.Health = 5;
			unit.MinDamage = 20;
			unit.MaxDamage = 30;
			unit.Accuracy = 50;
			unit.AttackPriority = AttackPriority.Normal;
			unit.TowerBonus = true;
			unit.Experience = 2;
			unit.IconPath = "Images\\gunman.png";
			s_units[(int)EnemyUnitsEnum.GUNMAN] = unit;

			unit = new Unit("CALTROP");
			unit.Name = Resources.UNIT_CALTROP;
			unit.Health = 4;
			unit.MinDamage = 0;
			unit.MaxDamage = 20;
			unit.Accuracy = 33;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 1;
			unit.IconPath = "Images\\caltrop.png";
			s_units[(int)EnemyUnitsEnum.CALTROP] = unit;

			unit = new Unit("PETTY_OFFICER_2ND_CLASS");
			unit.Name = Resources.UNIT_PETTY_OFFICER_2ND_CLASS;
			unit.Health = 60;
			unit.MinDamage = 40;
			unit.MaxDamage = 60;
			unit.Accuracy = 70;
			unit.AttackPriority = AttackPriority.Normal;
			unit.AttackWeaknessTarget = true;
			unit.AttackOnArea = true;
			unit.Experience = 6;
			unit.IconPath = "Images\\petty_officer_2nd_class.png";
			s_units[(int)EnemyUnitsEnum.PETTY_OFFICER_2ND_CLASS] = unit;

			unit = new Unit("CRAZY_COOK");
			unit.Name = Resources.UNIT_CRAZY_COOK;
			unit.Health = 5000;
			unit.MinDamage = 200;
			unit.MaxDamage = 300;
			unit.Accuracy = 66;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackOnArea = true;
			unit.Experience = 200;
			unit.IconPath = "Images\\crazy_cook.png";
			s_units[(int)EnemyUnitsEnum.CRAZY_COOK] = unit;

			unit = new Unit("DANCING_DERVISH");
			unit.Name = Resources.UNIT_DANCING_DERVISH;
			unit.Health = 90;
			unit.MinDamage = 60;
			unit.MaxDamage = 120;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.Experience = 20;
			unit.IconPath = "Images\\dancing_dervish.png";
			s_units[(int)EnemyUnitsEnum.DANCING_DERVISH] = unit;

			unit = new Unit("NIGHT_SPAWN");
			unit.Name = Resources.UNIT_NIGHT_SPAWN;
			unit.Health = 35000;
			unit.MinDamage = 700;
			unit.MaxDamage = 800;
			unit.Accuracy = 75;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackOnArea = true;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 500;
			unit.IconPath = "Images\\night_spawn.png";
			s_units[(int)EnemyUnitsEnum.NIGHT_SPAWN] = unit;

			unit = new Unit("NOMAD");
			unit.Name = Resources.UNIT_NOMAD;
			unit.Health = 30;
			unit.MinDamage = 10;
			unit.MaxDamage = 20;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 2;
			unit.IconPath = "Images\\nomad.png";
			s_units[(int)EnemyUnitsEnum.NOMAD] = unit;

			unit = new Unit("COMPOSITE_BOW");
			unit.Name = Resources.UNIT_COMPOSITE_BOW;
			unit.Health = 20;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 2;
			unit.IconPath = "Images\\composite_bow.png";
			s_units[(int)EnemyUnitsEnum.COMPOSITE_BOW] = unit;

			unit = new Unit("LANCE_RIDER");
			unit.Name = Resources.UNIT_LANCE_RIDER;
			unit.Health = 20;
			unit.MinDamage = 5;
			unit.MaxDamage = 20;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 4;
			unit.IconPath = "Images\\lance_rider.png";
			s_units[(int)EnemyUnitsEnum.LANCE_RIDER] = unit;

			unit = new Unit("RIDING_BOWMAN");
			unit.Name = Resources.UNIT_RIDING_BOWMAN;
			unit.Health = 20;
			unit.MinDamage = 30;
			unit.MaxDamage = 40;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 6;
			unit.IconPath = "Images\\riding_bowman.png";
			s_units[(int)EnemyUnitsEnum.RIDING_BOWMAN] = unit;

			unit = new Unit("RIDING_AMAZONIAN");
			unit.Name = Resources.UNIT_RIDING_AMAZONIAN;
			unit.Health = 20;
			unit.MinDamage = 40;
			unit.MaxDamage = 60;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 8;
			unit.IconPath = "Images\\riding_amazonian.png";
			s_units[(int)EnemyUnitsEnum.RIDING_AMAZONIAN] = unit;

			unit = new Unit("CATAPHRACT");
			unit.Name = Resources.UNIT_CATAPHRACT;
			unit.Health = 20;
			unit.MinDamage = 90;
			unit.MaxDamage = 90;
			unit.Accuracy = 100;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 12;
			unit.IconPath = "Images\\cataphract.png";
			s_units[(int)EnemyUnitsEnum.CATAPHRACT] = unit;

			unit = new Unit("UPROARIOUS_BULL");
			unit.Name = Resources.UNIT_UPROARIOUS_BULL;
			unit.Health = 2000;
			unit.MinDamage = 120;
			unit.MaxDamage = 120;
			unit.Accuracy = 100;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.Experience = 50;
			unit.IconPath = "Images\\uproarious_bull.png";
			s_units[(int)EnemyUnitsEnum.UPROARIOUS_BULL] = unit;

			unit = new Unit("THRALL");
			unit.Name = Resources.UNIT_THRALL;
			unit.Health = 60;
			unit.MinDamage = 20;
			unit.MaxDamage = 25;
			unit.Accuracy = 85;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 3;
			unit.IconPath = "Images\\thrall.png";
			s_units[(int)EnemyUnitsEnum.THRALL] = unit;

			unit = new Unit("KARL");
			unit.Name = Resources.UNIT_KARL;
			unit.Health = 80;
			unit.MinDamage = 40;
			unit.MaxDamage = 50;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 6;
			unit.IconPath = "Images\\karl.png";
			s_units[(int)EnemyUnitsEnum.KARL] = unit;

			unit = new Unit("HOUSECARL");
			unit.Name = Resources.UNIT_HOUSECARL;
			unit.Health = 140;
			unit.MinDamage = 40;
			unit.MaxDamage = 50;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 10;
			unit.IconPath = "Images\\housecarl.png";
			s_units[(int)EnemyUnitsEnum.HOUSECARL] = unit;

			unit = new Unit("JOMVIKING");
			unit.Name = Resources.UNIT_JOMVIKING;
			unit.Health = 140;
			unit.MinDamage = 60;
			unit.MaxDamage = 80;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 14;
			unit.IconPath = "Images\\jomviking.png";
			s_units[(int)EnemyUnitsEnum.JOMVIKING] = unit;

			unit = new Unit("VALKYRIE");
			unit.Name = Resources.UNIT_VALKYRIE;
			unit.Health = 10;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 14;
			unit.IconPath = "Images\\valkyrie.png";
			s_units[(int)EnemyUnitsEnum.VALKYRIE] = unit;

			unit = new Unit("BERSERK");
			unit.Name = Resources.UNIT_BERSERK;
			unit.Health = 90;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 70;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.Experience = 20;
			unit.IconPath = "Images\\berserk.png";
			s_units[(int)EnemyUnitsEnum.BERSERK] = unit;

			unit = new Unit("CROAKER");
			unit.Name = Resources.UNIT_CROAKER;
			unit.Health = 10000;
			unit.MinDamage = 500;
			unit.MaxDamage = 700;
			unit.Accuracy = 50;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 200;
			unit.IconPath = "Images\\croaker.png";
			s_units[(int)EnemyUnitsEnum.CROAKER] = unit;

			unit = new Unit("TRIBESMAN");
			unit.Name = Resources.UNIT_TRIBESMAN;
			unit.Health = 40;
			unit.MinDamage = 15;
			unit.MaxDamage = 30;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 2;
			unit.IconPath = "Images\\tribesman.png";
			s_units[(int)EnemyUnitsEnum.TRIBESMAN] = unit;

			unit = new Unit("SHAMAN");
			unit.Name = Resources.UNIT_SHAMAN;
			unit.Health = 5;
			unit.MinDamage = 0;
			unit.MaxDamage = 5;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 1;
			unit.IconPath = "Images\\shaman.png";
			s_units[(int)EnemyUnitsEnum.SHAMAN] = unit;

			unit = new Unit("JAGUAR_WARRIOR");
			unit.Name = Resources.UNIT_JAGUAR_WARRIOR;
			unit.Health = 90;
			unit.MinDamage = 60;
			unit.MaxDamage = 120;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackOnArea = true;
			unit.Experience = 2;
			unit.IconPath = "Images\\jaguar_warrior.png";
			s_units[(int)EnemyUnitsEnum.JAGUAR_WARRIOR] = unit;

			unit = new Unit("STRIKER");
			unit.Name = Resources.UNIT_STRIKER;
			unit.Health = 10;
			unit.MinDamage = 0;
			unit.MaxDamage = 10;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 10;
			unit.IconPath = "Images\\striker.png";
			s_units[(int)EnemyUnitsEnum.STRIKER] = unit;

			unit = new Unit("FULLBACK");
			unit.Name = Resources.UNIT_FULLBACK;
			unit.Health = 35;
			unit.MinDamage = 25;
			unit.MaxDamage = 35;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 10;
			unit.IconPath = "Images\\fullback.png";
			s_units[(int)EnemyUnitsEnum.FULLBACK] = unit;

			unit = new Unit("MIDFIELDER");
			unit.Name = Resources.UNIT_MIDFIELDER;
			unit.Health = 10;
			unit.MinDamage = 30;
			unit.MaxDamage = 60;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.TowerBonus = true;
			unit.Experience = 5;
			unit.IconPath = "Images\\midfielder.png";
			s_units[(int)EnemyUnitsEnum.MIDFIELDER] = unit;

			unit = new Unit("GOALKEEPER");
			unit.Name = Resources.UNIT_GOALKEEPER;
			unit.Health = 10000;
			unit.MinDamage = 50;
			unit.MaxDamage = 150;
			unit.Accuracy = 75;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.Experience = 20;
			unit.IconPath = "Images\\goalkeeper.png";
			s_units[(int)EnemyUnitsEnum.GOALKEEPER] = unit;

			unit = new Unit("BOAR");
			unit.Name = Resources.UNIT_BOAR;
			unit.Health = 100;
			unit.MinDamage = 30;
			unit.MaxDamage = 60;
			unit.Accuracy = 85;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 12;
			unit.IconPath = "Images\\boar.png";
			s_units[(int)EnemyUnitsEnum.BOAR] = unit;

			unit = new Unit("BEAR");
			unit.Name = Resources.UNIT_BEAR;
			unit.Health = 140;
			unit.MinDamage = 70;
			unit.MaxDamage = 90;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 18;
			unit.IconPath = "Images\\bear.png";
			s_units[(int)EnemyUnitsEnum.BEAR] = unit;

			unit = new Unit("WOLF2");
			unit.Name = Resources.UNIT_WOLF;
			unit.Health = 40;
			unit.MinDamage = 60;
			unit.MaxDamage = 100;
			unit.Accuracy = 85;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 10;
			unit.IconPath = "Images\\wolf2.png";
			s_units[(int)EnemyUnitsEnum.WOLF2] = unit;

			unit = new Unit("FOX");
			unit.Name = Resources.UNIT_FOX;
			unit.Health = 30;
			unit.MinDamage = 10;
			unit.MaxDamage = 40;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 12;
			unit.IconPath = "Images\\fox.png";
			s_units[(int)EnemyUnitsEnum.FOX] = unit;

			unit = new Unit("ROYAL_RECRUIT");
			unit.Name = Resources.UNIT_ROYAL_RECRUIT;
			unit.Health = 100;
			unit.MinDamage = 30;
			unit.MaxDamage = 60;
			unit.Accuracy = 85;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 0;
			unit.IconPath = "Images\\recruit.png";
			s_units[(int)EnemyUnitsEnum.ROYAL_RECRUIT] = unit;

			unit = new Unit("ROYAL_MILITIA");
			unit.Name = Resources.UNIT_ROYAL_MILITIA;
			unit.Health = 160;
			unit.MinDamage = 70;
			unit.MaxDamage = 90;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 0;
			unit.IconPath = "Images\\militia.png";
			s_units[(int)EnemyUnitsEnum.ROYAL_MILITIA] = unit;

			unit = new Unit("ROYAL_BOWMAN");
			unit.Name = Resources.UNIT_ROYAL_BOWMAN;
			unit.Health = 40;
			unit.MinDamage = 60;
			unit.MaxDamage = 100;
			unit.Accuracy = 85;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 0;
			unit.IconPath = "Images\\bowman.png";
			s_units[(int)EnemyUnitsEnum.ROYAL_BOWMAN] = unit;

			unit = new Unit("ROYAL_LONGBOWMAN");
			unit.Name = Resources.UNIT_ROYAL_LONGBOWMAN;
			unit.Health = 60;
			unit.MinDamage = 80;
			unit.MaxDamage = 140;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 0;
			unit.IconPath = "Images\\longbowman.png";
			s_units[(int)EnemyUnitsEnum.ROYAL_LONGBOWMAN] = unit;

			unit = new Unit("ROYAL_LONGBOWMAN");
			unit.Name = Resources.UNIT_ROYAL_LONGBOWMAN;
			unit.Health = 60;
			unit.MinDamage = 80;
			unit.MaxDamage = 140;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 0;
			unit.IconPath = "Images\\longbowman.png";
			s_units[(int)EnemyUnitsEnum.ROYAL_LONGBOWMAN] = unit;

			unit = new Unit("ROYAL_CAVALRY");
			unit.Name = Resources.UNIT_ROYAL_CAVALRY;
			unit.Health = 40;
			unit.MinDamage = 10;
			unit.MaxDamage = 40;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 0;
			unit.IconPath = "Images\\cavalry.png";
			s_units[(int)EnemyUnitsEnum.ROYAL_CAVALRY] = unit;

			unit = new Unit("ROYAL_CANNONEER");
			unit.Name = Resources.UNIT_ROYAL_CANNONEER;
			unit.Health = 160;
			unit.MinDamage = 60;
			unit.MaxDamage = 90;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 0;
			unit.IconPath = "Images\\cannoneer.png";
			s_units[(int)EnemyUnitsEnum.ROYAL_CANNONEER] = unit;

			unit = new Unit("GIANT_LEADER_1");
			unit.Name = Resources.UNIT_GIANT_LEADER_1;
			unit.Health = 90000;
			unit.MinDamage = 100;
			unit.MaxDamage = 300;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.Experience = 150;
			unit.IconPath = "Images\\giant_leader1.png";
			s_units[(int)EnemyUnitsEnum.GIANT_LEADER1] = unit;

			unit = new Unit("GIANT_LEADER_2");
			unit.Name = Resources.UNIT_GIANT_LEADER_2;
			unit.Health = 70000;
			unit.MinDamage = 100;
			unit.MaxDamage = 250;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.Experience = 150;
			unit.IconPath = "Images\\giant_leader2.png";
			s_units[(int)EnemyUnitsEnum.GIANT_LEADER2] = unit;

			unit = new Unit("UNICORN");
			unit.Name = Resources.UNIT_UNICORN;
			unit.Health = 30000;
			unit.MinDamage = 250;
			unit.MaxDamage = 400;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.Normal;
			unit.AttackOnArea = true;
			unit.Experience = 300;
			unit.IconPath = "Images\\unicorn.png";
			s_units[(int)EnemyUnitsEnum.UNICORN] = unit;

			unit = new Unit("GIANT_BOAR");
			unit.Name = Resources.UNIT_GIANT_BOAR;
			unit.Health = 50000;
			unit.MinDamage = 200;
			unit.MaxDamage = 300;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.Normal;
			unit.AttackOnArea = true;
			unit.Experience = 400;
			unit.IconPath = "Images\\giant_boar.png";
			s_units[(int)EnemyUnitsEnum.GIANT_BOAR] = unit;

			unit = new Unit("EVIL_KING");
			unit.Name = Resources.UNIT_EVIL_KING;
			unit.Health = 30000;
			unit.MinDamage = 200;
			unit.MaxDamage = 300;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.AttackOnArea = true;
			unit.Experience = 800;
			unit.IconPath = "Images\\evil_king.png";
			s_units[(int)EnemyUnitsEnum.EVIL_KING] = unit;

			unit = new Unit("WOLF_PACKLOADER");
			unit.Name = Resources.UNIT_WOLF_PACKLOADER;
			unit.Health = 60;
			unit.MinDamage = 80;
			unit.MaxDamage = 140;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 16;
			unit.IconPath = "Images\\wolf_packloader.png";
			s_units[(int)EnemyUnitsEnum.WOLF_PACKLOADER] = unit;

			unit = new Unit("GIANT");
			unit.Name = Resources.UNIT_GIANT;
			unit.Health = 160;
			unit.MinDamage = 60;
			unit.MaxDamage = 90;
			unit.Accuracy = 95;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 26;
			unit.IconPath = "Images\\giant.png";
			s_units[(int)EnemyUnitsEnum.GIANT] = unit;

			unit = new Unit("GIANT_BEAR");
			unit.Name = Resources.UNIT_GIANT_BEAR;
			unit.Health = 55000;
			unit.MinDamage = 400;
			unit.MaxDamage = 750;
			unit.Accuracy = 60;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.Experience = 1000;
			unit.IconPath = "Images\\giant_bear.png";
			s_units[(int)EnemyUnitsEnum.GIANT_BEAR] = unit;

			unit = new Unit("ASSASSINE");
			unit.Name = Resources.UNIT_ASSASSINE;
			unit.Health = 30000;
			unit.MinDamage = 200;
			unit.MaxDamage = 300;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.AttackOnArea = true;
			unit.Experience = 950;
			unit.IconPath = "Images\\assassine.png";
			s_units[(int)EnemyUnitsEnum.ASSASSINE] = unit;

			unit = new Unit("GREEDY_INNKEEPER");
			unit.Name = Resources.UNIT_GREEDY_INNKEEPER;
			unit.Health = 50000;
			unit.MinDamage = 1500;
			unit.MaxDamage = 2000;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 1200;
			unit.IconPath = "Images\\greedy_innkeeper.png";
			s_units[(int)EnemyUnitsEnum.GREEDY_INNKEEPER] = unit;

			unit = new Unit("IRON_FIST");
			unit.Name = Resources.UNIT_IRON_FIST;
			unit.Health = 45000;
			unit.MinDamage = 200;
			unit.MaxDamage = 250;
			unit.Accuracy = 85;
			unit.AttackPriority = AttackPriority.Normal;
			unit.AttackOnArea = true;
			unit.Experience = 0;
			unit.IconPath = "Images\\iron_fist.png";
			s_units[(int)EnemyUnitsEnum.IRON_FIRST] = unit;

			unit = new Unit("RIVAL_DRESSMAKER");
			unit.Name = Resources.UNIT_RIVAL_DRESSMAKER;
			unit.Health = 40000;
			unit.MinDamage = 150;
			unit.MaxDamage = 250;
			unit.Accuracy = 75;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.AttackOnArea = true;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 500;
			unit.IconPath = "Images\\rival_dressmaker.png";
			s_units[(int)EnemyUnitsEnum.RIVAL_DRESSMAKER] = unit;

			unit = new Unit("LYING_GOAT");
			unit.Name = Resources.UNIT_LYING_GOAT;
			unit.Health = 25000;
			unit.MinDamage = 100;
			unit.MaxDamage = 150;
			unit.Accuracy = 85;
			unit.AttackPriority = AttackPriority.Normal;
			unit.AttackOnArea = true;
			unit.AttackWeaknessTarget = true;
			unit.Experience = 300;
			unit.IconPath = "Images\\lying_goat.png";
			s_units[(int)EnemyUnitsEnum.LYING_GOAT] = unit;

			unit = new Unit("THUG_LEADER");
			unit.Name = Resources.UNIT_THUG_LEADER;
			unit.Health = 40000;
			unit.MinDamage = 200;
			unit.MaxDamage = 300;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.AttackOnArea = true;
			unit.Experience = 900;
			unit.IconPath = "Images\\thug_leader.png";
			s_units[(int)EnemyUnitsEnum.THUG_LEADER] = unit;

			unit = new Unit("BLACK_BULL");
			unit.Name = Resources.UNIT_BLACK_BULL;
			unit.Health = 60000;
			unit.MinDamage = 250;
			unit.MaxDamage = 300;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.Normal;
			unit.AttackOnArea = true;
			unit.Experience = 600;
			unit.IconPath = "Images\\black_bull.png";
			s_units[(int)EnemyUnitsEnum.BLACK_BULL] = unit;

			unit = new Unit("DARK_WIZARD");
			unit.Name = Resources.UNIT_DARK_WIZARD;
			unit.Health = 30000;
			unit.MinDamage = 2000;
			unit.MaxDamage = 2500;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.AttackOnArea = true;
			unit.Experience = 1200;
			unit.IconPath = "Images\\dark_wizard.png";
			s_units[(int)EnemyUnitsEnum.DARK_WIZARD] = unit;
		}

		internal static void Load()
		{
			if (File.Exists(FILENAME))
			{
				List<Unit> units = new List<Unit>();
				XmlReader reader = XmlReader.Create(FILENAME);

				while (!reader.EOF)
				{
					if (reader.IsStartElement(Unit.UNIT))
					{
						Unit unit = new Unit();
						unit.Load(reader);
						units.Add(unit);
						continue;
					}

					if (!reader.Read())
					{
						break;
					}
				}

				reader.Close();

				s_units = units.ToArray();
			}			
		}

		internal static void Save()
		{
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			XmlWriter writer = XmlWriter.Create(FILENAME, settings);
			
			writer.WriteStartElement(UNITS_TAG);
			foreach (Unit unit in Units)
			{				
				unit.Save(writer);				
			}
			writer.WriteEndElement();
			writer.Close();
		}
	}
}
