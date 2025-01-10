using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
	abstract class ALogValue<ValueType>
	{
		public ValueType Val => _val;
		protected ValueType _val = default!;

		public virtual void Write(string msg)
		{
			Console.WriteLine(msg);
		}
		public virtual string Read(string msg)
		{
			string str;
			rpt:
			Write(msg);
			str = Console.ReadLine()!;
			if (string.IsNullOrEmpty(str))
			{
				Write("Нет значения!");
				goto rpt;
			}
			else
				return str;
		}
		public abstract void ReadAndSetValue(string msg);
		public abstract bool CheckValue(ValueType valTarget);
	}
}
