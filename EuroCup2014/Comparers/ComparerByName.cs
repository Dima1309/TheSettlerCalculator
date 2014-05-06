using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheSettlersCalculator.EuroCup2014.Comparers
{
	internal class ComparerByName : IComparer<BuffWithCount>, IComparer<ResourceWithCount>, IComparer<Skill>
	{
		public int Compare(BuffWithCount x, BuffWithCount y)
		{
			return x.Buff.Name.CompareTo(y.Buff.Name);
		}

		public int Compare(ResourceWithCount x, ResourceWithCount y)
		{
			return x.Resource.Name.CompareTo(y.Resource.Name);
		}

		public int Compare(Skill x, Skill y)
		{
			return x.Name.CompareTo(y.Name);
		}
	}
}
