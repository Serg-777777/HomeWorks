using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace HomeWork2
{
	internal class LogValueString : ALogValue<string>
	{
		public override void ReadAndSetValue(string msg)
		{
			base._val = base.Read(msg);
		}
		public override bool CheckValue(string valTarget)
		{
			return String.Equals(base.Val, valTarget);
		}
	}
}
