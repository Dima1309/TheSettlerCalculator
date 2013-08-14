using System;
using System.Collections;
using System.Linq;
using System.Resources;

namespace TheSettlersCalculator.Helper
{
	internal class Helper
	{
		#region Fields
		private static readonly ResourceSet resourceSet = null;
		
		#endregion

		#region Constructor
		static Helper()
		{
			ResourceManager rm = new ResourceManager("TheSettlersCalculator.Properties.Resources", typeof(Helper).Assembly);
			resourceSet = rm.GetResourceSet(System.Threading.Thread.CurrentThread.CurrentCulture, true, true);
		}
		#endregion

		internal static string getResourceName(string text)
		{
			DictionaryEntry entry = resourceSet.OfType<DictionaryEntry>()
				  .FirstOrDefault(e => e.Value.ToString().Equals(text, StringComparison.OrdinalIgnoreCase));

			return text.Equals(entry.Value.ToString(), StringComparison.OrdinalIgnoreCase) ? entry.Key.ToString() : text;
		}

		internal static string getResourceText(string text)
		{
			DictionaryEntry entry = resourceSet.OfType<DictionaryEntry>()
				  .FirstOrDefault(e => e.Key.ToString().Equals(text, StringComparison.OrdinalIgnoreCase));

			return entry.Value!=null && text.Equals(entry.Key.ToString(), StringComparison.OrdinalIgnoreCase) ? entry.Value.ToString() : text;
		}
	}
}
