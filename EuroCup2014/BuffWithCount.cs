using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheSettlersCalculator.EuroCup2014
{
	public class BuffWithCount
	{
		#region Fields
		private readonly Buff m_buff;
		private int m_count;
		#endregion

		#region Constructor
		public BuffWithCount(Buff buff, int count)
		{
			m_buff = buff;
			m_count = count;
		}
		#endregion

		#region Properties
		public Buff Buff
		{
			get
			{
				return m_buff;
			}
		}

		public int Count
		{
			get
			{
				return m_count;
			}

			set
			{
				m_count = value;
			}
		}
		#endregion
	}
}
