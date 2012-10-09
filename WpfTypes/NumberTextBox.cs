using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TheSettlersCalculator.WpfTypes
{
	public class NumberTextBox : TextBox
	{
		public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register("MaxValue", typeof(int), typeof(NumberTextBox));

		public int MinValue { get; set; }
		public int MaxValue
		{
			get { return (int)GetValue(MaxValueProperty); }
			set { SetValue(MaxValueProperty, value); }
		}

		protected override void OnPreviewKeyDown(KeyEventArgs e)
		{
			switch(e.Key)
			{
				case Key.Up:
					int value; 
					if (int.TryParse(Text, out value))
					{
						if (value < MaxValue)
						{
							Text = (value + 1).ToString();
						}
					}
					break;
				case Key.Down:
					if (int.TryParse(Text, out value))
					{
						if (value > MinValue)
						{
							Text = (value - 1).ToString();
						}
					}
					break;
			}

			base.OnPreviewKeyUp(e);
		}

		protected override void OnPreviewTextInput(TextCompositionEventArgs e)
		{
			e.Handled = !AreAllValidNumericChars(e.Text);
			base.OnPreviewTextInput(e);
		}

		private static bool AreAllValidNumericChars(string str)
		{
			bool ret = true;
			if (str == System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator |
				str == System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyGroupSeparator |
				str == System.Globalization.NumberFormatInfo.CurrentInfo.CurrencySymbol |
				str == System.Globalization.NumberFormatInfo.CurrentInfo.NegativeSign |
				str == System.Globalization.NumberFormatInfo.CurrentInfo.NegativeInfinitySymbol |
				str == System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator |
				str == System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator |
				str == System.Globalization.NumberFormatInfo.CurrentInfo.PercentDecimalSeparator |
				str == System.Globalization.NumberFormatInfo.CurrentInfo.PercentGroupSeparator |
				str == System.Globalization.NumberFormatInfo.CurrentInfo.PercentSymbol |
				str == System.Globalization.NumberFormatInfo.CurrentInfo.PerMilleSymbol |
				str == System.Globalization.NumberFormatInfo.CurrentInfo.PositiveInfinitySymbol |
				str == System.Globalization.NumberFormatInfo.CurrentInfo.PositiveSign)
				return ret;

			int l = str.Length;
			for (int i = 0; i < l; i++)
			{
				char ch = str[i];
				ret &= Char.IsDigit(ch);
			}

			return ret;
		}
	}
}
