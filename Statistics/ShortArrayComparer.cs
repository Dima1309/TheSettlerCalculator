using System.Collections.Generic;

namespace TheSettlersCalculator.Statistics
{
	internal class ShortArrayComparer : IComparer<short[]>, IEqualityComparer<short[]>
	{
		public int Compare(short[] x, short[] y)
		{
			if (x == null && y == null)
			{
				return 0;
			}

			if (x == null)
			{
				return -1;
			}

			if (y == null)
			{
				return 1;
			}

			int length = x.Length;
			if (y.Length <  length)
			{
				length = y.Length;
			}

			for(int i=0; i<length;i++)
			{
				int result = x[i].CompareTo(y[i]);
				if (result != 0)
				{
					return result;
				}
			}

			return x.Length.CompareTo(y.Length);
		}

		public bool Equals(short[] x, short[] y)
		{
			if (x == null && y == null)
			{
				return true;
			}

			if (x == null || y == null)
			{
				return false;
			}

			if (x.Length != y.Length)
			{
				return false;
			}

			for (int i = 0; i < x.Length; i++)
			{
				if (x[i] != y[i])
				{
					return false;
				}
			}

			return true;
		}

		public int GetHashCode(short[] obj)
		{
			int hash = 0;
			for(int i = 0; i < obj.Length; i++)
			{
				hash ^= ((hash << 7) + hash + (hash >> 22)) ^ obj[i];
			}

			return hash;
		}
	}
}
