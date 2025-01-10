using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
	internal class LogValueNumber : ALogValue<int>
	{
		public override bool CheckValue(int valTarget)
		{
			if (base.Val < valTarget)
			{
				Write(":: Не верно! Загадано большее число");
			}
			else if (base.Val > valTarget)
			{
				Write(":: Не верно! Загадано меньшее число");
			}
			else
			{
				Write($"!!! Угадано !!!");
				return true;
			}
			return false;
		}
		public override void ReadAndSetValue(string msg)
		{
			if (!int.TryParse(base.Read(">>> " + msg), out base._val))
			{
				base.Write("Не верный формат! Повторить.");
				this.ReadAndSetValue(msg);
			}
		}
	}
	
}
