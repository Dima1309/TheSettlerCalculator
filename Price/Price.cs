using System.Collections.Generic;
using TheSettlersCalculator.Properties;

namespace TheSettlersCalculator.Price
{
	public static class Price
	{
		#region Fields
		private static SortedDictionary<ProductEnum, Product> s_products;
		#endregion

		#region Properties
		public static IDictionary<ProductEnum, Product> Products
		{
			get
			{
				if (s_products == null)
				{
					InitializeResources();
				}

				return s_products;
			}
		}
		#endregion

		#region Methods
		private static void InitializeResources()
		{
			s_products = new SortedDictionary<ProductEnum, Product>();
			
			AddProduct(ProductEnum.RESOURCE_PINE_WOOD ,Resources.RESOURCE_PINE_WOOD, ProductType.BASIC, 4.8, "pine_wood");
			AddProduct(ProductEnum.RESOURCE_PINE_WOOD_PLANKS ,Resources.RESOURCE_PINE_WOOD_PLANKS, ProductType.BASIC, 5.7, "pine_wood_plank");
			AddProduct(ProductEnum.RESOURCE_STONE ,Resources.RESOURCE_STONE, ProductType.BASIC, 9.7, "stone");
			AddProduct(ProductEnum.RESOURCE_FISH ,Resources.RESOURCE_FISH, ProductType.BASIC, 7.8, "fish");
			AddProduct(ProductEnum.RESOURCE_EASTER_EGG ,Resources.RESOURCE_EASTER_EGG, ProductType.BASIC, 10000, "easter_egg");
			AddProduct(ProductEnum.RESOURCE_MAP_FRAGMENT ,Resources.RESOURCE_MAP_FRAGMENT, ProductType.BASIC, 6000, "map_fragment");
			AddProduct(ProductEnum.RESOURCE_GIFT ,Resources.RESOURCE_GIFT, ProductType.BASIC, 16000, "gift");
			AddProduct(ProductEnum.RESOURCE_SOCCER_BALL ,Resources.RESOURCE_SOCCER_BALL, ProductType.BASIC, 16000, "soccer_ball");
			AddProduct(ProductEnum.RESOURCE_GUILD_COINS ,Resources.RESOURCE_GUILD_COINS, ProductType.BASIC, 1029, "guild_coins");
					   
			AddProduct(ProductEnum.RESOURCE_COAL ,Resources.RESOURCE_COAL, ProductType.IMPROVED, 8.4, "coal");
			AddProduct(ProductEnum.RESOURCE_BRONZE_ORE ,Resources.RESOURCE_BRONZE_ORE, ProductType.IMPROVED, 24.6, "bronze_ore");
			AddProduct(ProductEnum.RESOURCE_BRONZE ,Resources.RESOURCE_BRONZE, ProductType.IMPROVED, 35.06, "bronze");
			AddProduct(ProductEnum.RESOURCE_TOOLS ,Resources.RESOURCE_TOOLS, ProductType.IMPROVED, 33, "tools");
			AddProduct(ProductEnum.RESOURCE_WATER ,Resources.RESOURCE_WATER, ProductType.IMPROVED, 2.8, "water");
			AddProduct(ProductEnum.RESOURCE_WHEAT ,Resources.RESOURCE_WHEAT, ProductType.IMPROVED, 21.4, "wheat");
			AddProduct(ProductEnum.RESOURCE_BREW ,Resources.RESOURCE_BREW, ProductType.IMPROVED, 16.9, "brew");
			AddProduct(ProductEnum.RESOURCE_FLOUR ,Resources.RESOURCE_FLOUR, ProductType.IMPROVED, 20.5, "flour");
			AddProduct(ProductEnum.RESOURCE_BREAD ,Resources.RESOURCE_BREAD, ProductType.IMPROVED, 22.8, "bread");
			AddProduct(ProductEnum.RESOURCE_BRONZE_SWORD ,Resources.RESOURCE_BRONZE_SWORD, ProductType.IMPROVED, 34.1, "bronze_sword");
			AddProduct(ProductEnum.RESOURCE_BOW ,Resources.RESOURCE_BOW, ProductType.IMPROVED, 36.6, "bow");
					   
			AddProduct(ProductEnum.RESOURCE_HARDWOOD ,Resources.RESOURCE_HARDWOOD, ProductType.ADVANCED, 9.3, "hardwood");
			AddProduct(ProductEnum.RESOURCE_HARDWOOD_PLANKS ,Resources.RESOURCE_HARDWOOD_PLANKS, ProductType.ADVANCED, 20, "hardwood_plank");
			AddProduct(ProductEnum.RESOURCE_IRON_ORE ,Resources.RESOURCE_IRON_ORE, ProductType.ADVANCED, 60.9, "iron_ore");
			AddProduct(ProductEnum.RESOURCE_IRON ,Resources.RESOURCE_IRON, ProductType.ADVANCED, 193.9, "iron");
			AddProduct(ProductEnum.RESOURCE_STEEL ,Resources.RESOURCE_STEEL, ProductType.ADVANCED, 269.33, "steel");
			AddProduct(ProductEnum.RESOURCE_GOLD_ORE ,Resources.RESOURCE_GOLD_ORE, ProductType.ADVANCED, 414.8, "gold_ore");
			AddProduct(ProductEnum.RESOURCE_GOLD ,Resources.RESOURCE_GOLD, ProductType.ADVANCED, 600.5, "gold");
			AddProduct(ProductEnum.RESOURCE_COINS ,Resources.RESOURCE_COINS, ProductType.ADVANCED, 1000, "coins");
			AddProduct(ProductEnum.RESOURCE_MARBLE ,Resources.RESOURCE_MARBLE, ProductType.ADVANCED, 32.4, "marble");
			AddProduct(ProductEnum.RESOURCE_MEAT ,Resources.RESOURCE_MEAT, ProductType.ADVANCED, 18, "meat");
			AddProduct(ProductEnum.RESOURCE_SAUSAGE ,Resources.RESOURCE_SAUSAGE, ProductType.ADVANCED, 54.6, "sausage");
			AddProduct(ProductEnum.RESOURCE_HORSE ,Resources.RESOURCE_HORSE, ProductType.ADVANCED, 33.9, "horse");
			AddProduct(ProductEnum.RESOURCE_IRON_SWORD ,Resources.RESOURCE_IRON_SWORD, ProductType.ADVANCED, 164.6, "iron_sword");
			AddProduct(ProductEnum.RESOURCE_STEEL_SWORD ,Resources.RESOURCE_STEEL_SWORD, ProductType.ADVANCED, 410.1, "steel_sword");
			AddProduct(ProductEnum.RESOURCE_LONGBOW ,Resources.RESOURCE_LONGBOW, ProductType.ADVANCED, 69.4, "long_bow");
					   
			AddProduct(ProductEnum.RESOURCE_EXOTIC_WOOD ,Resources.RESOURCE_EXOTIC_WOOD, ProductType.SKILLFUL, 283.4, "exotic_wood");
			AddProduct(ProductEnum.RESOURCE_EXOTIC_WOOD_PLANKS ,Resources.RESOURCE_EXOTIC_WOOD_PLANKS, ProductType.SKILLFUL, 282.8, "exotic_wood_planks");
			AddProduct(ProductEnum.RESOURCE_TITANIUM_ORE ,Resources.RESOURCE_TITANIUM_ORE, ProductType.SKILLFUL, 559.22, "titanium_ore");
			AddProduct(ProductEnum.RESOURCE_TITANIUM ,Resources.RESOURCE_TITANIUM, ProductType.SKILLFUL, 966.4, "titanium");
			AddProduct(ProductEnum.RESOURCE_SALPETRE ,Resources.RESOURCE_SALPETRE, ProductType.SKILLFUL, 252.2, "salpetre");
			AddProduct(ProductEnum.RESOURCE_GUN_POWDER ,Resources.RESOURCE_GUN_POWDER, ProductType.SKILLFUL, 252.2, "gun_powder");
			AddProduct(ProductEnum.RESOURCE_GRANITE ,Resources.RESOURCE_GRANITE, ProductType.SKILLFUL, 1778.6, "granite");
			AddProduct(ProductEnum.RESOURCE_WHEEL ,Resources.RESOURCE_WHEEL, ProductType.SKILLFUL, 1434.76, "wheel");
			AddProduct(ProductEnum.RESOURCE_CARRIAGE ,Resources.RESOURCE_CARRIAGE, ProductType.SKILLFUL, 3576.4, "carriage");
			AddProduct(ProductEnum.RESOURCE_DAMASCENE_SWORD ,Resources.RESOURCE_DAMASCENE_SWORD, ProductType.SKILLFUL, 577.42, "damascene_sword");
			AddProduct(ProductEnum.RESOURCE_CROSSBOW ,Resources.RESOURCE_CROSSBOW, ProductType.SKILLFUL, 790.6, "crossbow");
			AddProduct(ProductEnum.RESOURCE_CANNON, Resources.RESOURCE_CANNON, ProductType.SKILLFUL, 668.5, "cannon");
					   
			AddProduct(ProductEnum.QUEST_SATTELFEST ,Resources.QUEST_SATTELFEST, ProductType.QUEST, 73.1, "sattelfest");
			AddProduct(ProductEnum.QUEST_INSEL_DER_FREIBEUTER ,Resources.QUEST_INSEL_DER_FREIBEUTER, ProductType.QUEST, 468.4, "insel_der_freibeuter");
			AddProduct(ProductEnum.QUEST_SUMPFHEXE ,Resources.QUEST_SUMPFHEXE, ProductType.QUEST, 79.1, "sumpfhexe");
			AddProduct(ProductEnum.QUEST_DIE_SCHWARZEN_PRIESTER ,Resources.QUEST_DIE_SCHWARZEN_PRIESTER, ProductType.QUEST, 90.6, "die_schwarzen_priester");
			AddProduct(ProductEnum.QUEST_VERRATER ,Resources.QUEST_VERRATER, ProductType.QUEST, 46, "verrater");
			AddProduct(ProductEnum.QUEST_BEUTELSCHNEIDER ,Resources.QUEST_BEUTELSCHNEIDER, ProductType.QUEST, 186.8, "beutelschneider");
			AddProduct(ProductEnum.QUEST_RAUBERBANDE ,Resources.QUEST_RAUBERBANDE, ProductType.QUEST, 41.3, "rauberbande");
			AddProduct(ProductEnum.QUEST_SOHNE_DER_STEPPE ,Resources.QUEST_SOHNE_DER_STEPPE, ProductType.QUEST, 20, "sohne_der_steppe");
			AddProduct(ProductEnum.QUEST_DIE_NORDMANNER ,Resources.QUEST_DIE_NORDMANNER, ProductType.QUEST, 1884, "die_nordmanner");
			AddProduct(ProductEnum.QUEST_VIKTOR_DER_VERSCHLAGENE ,Resources.QUEST_VIKTOR_DER_VERSCHLAGENE, ProductType.QUEST, 48.4, "viktor_der_verschlagene");
			AddProduct(ProductEnum.QUEST_EINSAME_EXPERIMENTE ,Resources.QUEST_EINSAME_EXPERIMENTE, ProductType.QUEST, 28.39, "einsame_experimente");
			AddProduct(ProductEnum.QUEST_DIE_SCHWARZEN_RITTER ,Resources.QUEST_DIE_SCHWARZEN_RITTER, ProductType.QUEST, 1790.5, "die_schwarzen_ritter");
			AddProduct(ProductEnum.QUEST_DIE_DUNKLE_BRUDERSCHAFT ,Resources.QUEST_DIE_DUNKLE_BRUDERSCHAFT, ProductType.QUEST, 588.8, "die_dunkle_bruderschaft");
			AddProduct(ProductEnum.QUEST_DAS_BANDITENNEST,Resources.QUEST_DAS_BANDITENNEST, ProductType.QUEST, 1457.9, "die_banditennest");
			AddProduct(ProductEnum.QUEST_SCHIESPULVER ,Resources.QUEST_SCHIESPULVER, ProductType.QUEST, 668.4, "schiespulver");
			AddProduct(ProductEnum.QUEST_UBERRASCHUNGSANGRIFF ,Resources.QUEST_UBERRASCHUNGSANGRIFF, ProductType.QUEST, 2000, "uberraschungsangriff");
			AddProduct(ProductEnum.QUEST_DIE_WILDE_WALTRAUT ,Resources.QUEST_DIE_WILDE_WALTRAUT, ProductType.QUEST, 716.4, "fie_wilde_waltraut");
			AddProduct(ProductEnum.QUEST_RASENDER_BULLE ,Resources.QUEST_RASENDER_BULLE, ProductType.QUEST, 1786.75, "rasender_bulle");
			AddProduct(ProductEnum.QUEST_OLD_FRIENDS ,Resources.QUEST_OLD_FRIENDS, ProductType.QUEST, 300, "Alte_bekannte");
			AddProduct(ProductEnum.QUEST_MOTHER_LOVE ,Resources.QUEST_MOTHER_LOVE, ProductType.QUEST, 600, "Mutterliebe");
		}

		private static void AddProduct(ProductEnum index, string name, ProductType productType, double cost, string imagePath)
		{
			s_products.Add(index, new Product(index, name, productType, cost, imagePath));
		}
		#endregion
	}
}
