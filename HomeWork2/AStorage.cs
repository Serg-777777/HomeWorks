using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
	abstract class AStorage<TypeValue>
	{
		protected TypeValue _target = default!;
		protected int _attempts = default;
		protected ALogValue<TypeValue> _logConcole = default!;
		protected bool _settingWasSet = false;
		public AStorage(ALogValue<TypeValue> logConcole)
		{
			_logConcole = logConcole;
		}
		public abstract void BeginProga();
		public abstract void SetSettings();
	}
}
