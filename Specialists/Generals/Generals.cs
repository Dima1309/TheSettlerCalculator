using System.Collections.Generic;
using TheSettlersCalculator.Properties;

namespace TheSettlersCalculator.Specialists.Generals
{
	public class Generals
	{
		#region Fields
		private static List<General> s_generals;
		#endregion

		#region Properties
		public static List<General> GeneralList
		{
			get
			{
				if (s_generals == null)
				{
					InitializeGenerals();
				}
				return s_generals;
			}
		}
		#endregion

		#region Methods
		private static void InitializeGenerals()
		{
			s_generals = new List<General>(5);
			s_generals.Add(new General(GeneralType.Tavern, Resources.GENERAL_TAVERN, 200, false, "TheSettlesCalculator.Specialists.Generals.Images.tavern_general.png"));
			s_generals.Add(new General(GeneralType.Quick, Resources.GENERAL_QUICK, 200, false, "TheSettlesCalculator.Specialists.Generals.Images.quick_general.png"));
			s_generals.Add(new General(GeneralType.Log, Resources.GENERAL_LOG, 220, false, "TheSettlesCalculator.Specialists.Generals.Images.general_log.png"));
			s_generals.Add(new General(GeneralType.Veteran, Resources.GENERAL_VETERAN, 250, false, "TheSettlesCalculator.Specialists.Generals.Images.veteran.png"));
			s_generals.Add(new General(GeneralType.Major, Resources.GENERAL_MAJOR, 270, false, "TheSettlesCalculator.Specialists.Generals.Images.general_major.png"));
		}
		#endregion
	}
}
