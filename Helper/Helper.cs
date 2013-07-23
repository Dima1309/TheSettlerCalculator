using System.Collections;
using System.Linq;

namespace TheSettlersCalculator.Helper
{
	internal class Helper
	{
		internal static string getResourceName(string text)
		{
			System.Resources.ResourceManager rm = new System.Resources.ResourceManager("TheSettlersCalculator.Properties.Resources", typeof(Helper).Assembly);

			var entry =
				rm.GetResourceSet(System.Threading.Thread.CurrentThread.CurrentCulture, true, true)
				  .OfType<DictionaryEntry>()
				  .FirstOrDefault(e => e.Value.ToString() == text);

			var key = entry.Key.ToString();
			return key??text;			
		}
	}
}
