using System.Collections.Generic;
using TheSettlersCalculator.Properties;

namespace TheSettlersCalculator.Price
{
	public static class Price
	{
		#region Fields
		private static readonly List<Product> s_products = new List<Product>(100);
		#endregion

		#region Properties
		public static List<Product> Products
		{
			get { return s_products; }
		}
		#endregion

		#region Methods
		private static void InitializeResources()
		{
			//поселенцы
			s_products.Add(new Product(Resources.RESOURCE_PINE_WOOD, ProductType.BASIC, 4.8, "pine_wood"));
			s_products.Add(new Product(Resources.RESOURCE_PINE_WOOD_PLANKS, ProductType.BASIC, 5.7, "pine_wood_plank"));
			s_products.Add(new Product(Resources.RESOURCE_STONE, ProductType.BASIC, 9.7, "stone"));
			s_products.Add(new Product(Resources.RESOURCE_FISH, ProductType.BASIC, 7.8, "fish"));
			s_products.Add(new Product(Resources.RESOURCE_EASTER_EGG, ProductType.BASIC, 10000, "easter_egg"));
			s_products.Add(new Product(Resources.RESOURCE_MAP_FRAGMENT, ProductType.BASIC, 6000, "map_fragment"));
			s_products.Add(new Product(Resources.RESOURCE_GIFT, ProductType.BASIC, 16000, "gift"));
			s_products.Add(new Product(Resources.RESOURCE_SOCCER_BALL, ProductType.BASIC, 16000, "soccer_ball"));
			s_products.Add(new Product(Resources.RESOURCE_GUILD_COINS, ProductType.BASIC, 1029, "guild_coins"));

			s_products.Add(new Product(Resources.RESOURCE_COAL, ProductType.IMPROVED, 8.4, "coal"));
			s_products.Add(new Product(Resources.RESOURCE_BRONZE_ORE, ProductType.IMPROVED, 24.6, "bronze_ore"));
			s_products.Add(new Product(Resources.RESOURCE_BRONZE, ProductType.IMPROVED, 35.06, "bronze"));
			s_products.Add(new Product(Resources.RESOURCE_TOOLS, ProductType.IMPROVED, 33, "tools"));
			s_products.Add(new Product(Resources.RESOURCE_WATER, ProductType.IMPROVED, 2.8, "water"));
			s_products.Add(new Product(Resources.RESOURCE_WHEAT, ProductType.IMPROVED, 21.4, "wheat"));
			s_products.Add(new Product(Resources.RESOURCE_BREW, ProductType.IMPROVED, 16.9, "brew"));
			s_products.Add(new Product(Resources.RESOURCE_FLOUR, ProductType.IMPROVED, 20.5, "flour"));
			s_products.Add(new Product(Resources.RESOURCE_BREAD, ProductType.IMPROVED, 22.8, "bread"));
			s_products.Add(new Product(Resources.RESOURCE_BRONZE_SWORD, ProductType.IMPROVED, 34.1, "bronze_sword"));
			s_products.Add(new Product(Resources.RESOURCE_BOW, ProductType.IMPROVED, 36.6, "bow"));

			s_products.Add(new Product(Resources.RESOURCE_HARDWOOD, ProductType.ADVANCED, 9.3, "hardwood"));
			s_products.Add(new Product(Resources.RESOURCE_HARDWOOD_PLANKS, ProductType.ADVANCED, 20, "hardwood_plank"));
			s_products.Add(new Product(Resources.RESOURCE_IRON_ORE, ProductType.ADVANCED, 60.9, "iron_ore"));
			s_products.Add(new Product(Resources.RESOURCE_IRON, ProductType.ADVANCED, 193.9, "iron"));
			s_products.Add(new Product(Resources.RESOURCE_STEEL, ProductType.ADVANCED, 269.33, "steel"));
			s_products.Add(new Product(Resources.RESOURCE_GOLD_ORE, ProductType.ADVANCED, 414.8, "gold_ore"));
			s_products.Add(new Product(Resources.RESOURCE_GOLD, ProductType.ADVANCED, 600.5, "gold"));
			s_products.Add(new Product(Resources.RESOURCE_COINS, ProductType.ADVANCED, 1000, "coins"));
			s_products.Add(new Product(Resources.RESOURCE_MARBLE, ProductType.ADVANCED, 32.4, "marble"));
			s_products.Add(new Product(Resources.RESOURCE_MEAT, ProductType.ADVANCED, 18, "meat"));
			s_products.Add(new Product(Resources.RESOURCE_SAUSAGE, ProductType.ADVANCED, 54.6, "sausage"));
			s_products.Add(new Product(Resources.RESOURCE_HORSE, ProductType.ADVANCED, 33.9, "horse"));
			s_products.Add(new Product(Resources.RESOURCE_IRON_SWORD, ProductType.ADVANCED, 164.6, "iron_sword"));
			s_products.Add(new Product(Resources.RESOURCE_STEEL_SWORD, ProductType.ADVANCED, 410.1, "steel_sword"));
			s_products.Add(new Product(Resources.RESOURCE_LONGBOW, ProductType.ADVANCED, 69.4, "long_bow"));

			s_products.Add(new Product(Resources.RESOURCE_EXOTIC_WOOD, ProductType.SKILLFUL, 283.4, "exotic_wood"));
			s_products.Add(new Product(Resources.RESOURCE_EXOTIC_WOOD_PLANKS, ProductType.SKILLFUL, 282.8, "exotic_wood_planks"));
			s_products.Add(new Product(Resources.RESOURCE_TITANIUM_ORE, ProductType.SKILLFUL, 559.22, "titanium_ore"));
			s_products.Add(new Product(Resources.RESOURCE_TITANIUM, ProductType.SKILLFUL, 966.4, "titanium"));
			s_products.Add(new Product(Resources.RESOURCE_SALPETRE, ProductType.SKILLFUL, 252.2, "salpetre"));
			s_products.Add(new Product(Resources.RESOURCE_GUN_POWDER, ProductType.SKILLFUL, 252.2, "gun_powder"));
			s_products.Add(new Product(Resources.RESOURCE_GRANITE, ProductType.SKILLFUL, 1778.6, "granite"));
			s_products.Add(new Product(Resources.RESOURCE_WHEEL, ProductType.SKILLFUL, 1434.76, "wheel"));
			s_products.Add(new Product(Resources.RESOURCE_CARRIAGE, ProductType.SKILLFUL, 3576.4, "carriage"));
			s_products.Add(new Product(Resources.RESOURCE_DAMASCENE_SWORD, ProductType.SKILLFUL, 577.42, "damascene_sword"));
			s_products.Add(new Product(Resources.RESOURCE_CROSSBOW, ProductType.SKILLFUL, 790.6, "crossbow"));
			s_products.Add(new Product(Resources.RESOURCE_CANNON, ProductType.SKILLFUL, 668.5, "cannon"));
			
			s_products.Add(new Product(Resources.QUEST_SATTELFEST, ProductType.QUEST, 73.1, "sattelfest"));
			s_products.Add(new Product(Resources.QUEST_INSEL_DER_FREIBEUTER, ProductType.QUEST, 468.4, "insel_der_freibeuter"));
			s_products.Add(new Product(Resources.QUEST_SUMPFHEXE, ProductType.QUEST, 79.1, "sumpfhexe"));
			s_products.Add(new Product(Resources.QUEST_DIE_SCHWARZEN_PRIESTER, ProductType.QUEST, 90.6, "die_schwarzen_priester"));
			s_products.Add(new Product(Resources.QUEST_VERRATER, ProductType.QUEST, 46, "verrater"));
			s_products.Add(new Product(Resources.QUEST_BEUTELSCHNEIDER, ProductType.QUEST, 186.8, "beutelschneider"));
			s_products.Add(new Product(Resources.QUEST_RAUBERBANDE, ProductType.QUEST, 41.3, "rauberbande"));
			s_products.Add(new Product(Resources.QUEST_SOHNE_DER_STEPPE, ProductType.QUEST, 20, "sohne_der_steppe"));
			s_products.Add(new Product(Resources.QUEST_DIE_NORDMANNER, ProductType.QUEST, 1884, "die_nordmanner"));
			s_products.Add(new Product(Resources.QUEST_VIKTOR_DER_VERSCHLAGENE, ProductType.QUEST, 48.4, "viktor_der_verschlagene"));
			s_products.Add(new Product(Resources.QUEST_EINSAME_EXPERIMENTE, ProductType.QUEST, 28.39, "einsame_experimente"));
			s_products.Add(new Product(Resources.QUEST_DIE_SCHWARZEN_RITTER, ProductType.QUEST, 1790.5, "die_schwarzen_ritter"));
			s_products.Add(new Product(Resources.QUEST_DIE_DUNKLE_BRUDERSCHAFT, ProductType.QUEST, 588.8, "die_dunkle_bruderschaft"));
			s_products.Add(new Product(Resources.QUEST_DAS_BANDITENNEST, ProductType.QUEST, 1457.9, "die_banditennest"));
			s_products.Add(new Product(Resources.QUEST_SCHIESPULVER, ProductType.QUEST, 668.4, "schiespulver"));
			s_products.Add(new Product(Resources.QUEST_UBERRASCHUNGSANGRIFF, ProductType.QUEST, 2000, "uberraschungsangriff"));
			s_products.Add(new Product(Resources.QUEST_DIE_WILDE_WALTRAUT, ProductType.QUEST, 716.4, "fie_wilde_waltraut"));
			s_products.Add(new Product(Resources.QUEST_RASENDER_BULLE, ProductType.QUEST, 1786.75, "rasender_bulle"));



		}
		#endregion
	}
}
