using System;

namespace TheSettlersCalculator.Types
{
	internal class BattleHelper : AbstractBaseBattleHelper
	{
		#region Fields
		private static readonly BattleHelper s_instance = new BattleHelper();
		#endregion

		#region Constructor
		private BattleHelper()
		{
		}
		#endregion

		#region Fields
		public static BattleHelper Instance
		{
			get { return s_instance; }
		}
		#endregion

		#region Methods
		protected override int[] GetUnitsDamage(BattleSideType battleSideTime, Unit unit, int unitCount, Random random)
		{
			int[] originalDamages = new int[unitCount];
			for(int i = 0; i < originalDamages.Length; i++)
			{
				originalDamages[i] = random.Next(1, 101) > unit.Accuracy
				                     	? unit.MinDamage
				                     	: unit.MaxDamage;
			}
			Shuffle(originalDamages, random);
			/*byte[] temp = new byte[unitCount];
			byte bound = (byte)Math.Round((double)255 * unit.Accuracy / 100);
			random.NextBytes(temp);
			for(int i = 0; i < temp.Length; i++)
			{
				originalDamages[i] = temp[i] > bound
						? unit.MinDamage
						: unit.MaxDamage;
			}*/
			return originalDamages;
		}
		#endregion
	}
}
