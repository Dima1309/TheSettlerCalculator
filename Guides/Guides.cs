using System.Collections.ObjectModel;

namespace TheSettlersCalculator.Guides
{
	public static class Guides
	{
		#region Fields
		static private ObservableCollection<Guide> s_guides;
		#endregion

		public static ObservableCollection<Guide> GuideList
		{
			get
			{
				if (s_guides==null)
				{
					LoadGuides();
				}

				return s_guides;
			}
		}

		private static void LoadGuides()
		{}
	}
}
