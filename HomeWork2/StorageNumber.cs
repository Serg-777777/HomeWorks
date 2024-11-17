using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
	internal class StorageNumber : AStorage<int>
	{
		int _max=default;
		int _min = default;

		public StorageNumber(ALogValue<int> logConcole) : base(logConcole) { }
		public override void BeginProga()
		{
			int _attempsTmp;
			if(!base._settingWasSet) this.SetSettings();
			_attempsTmp = _attempts;
			rpt:
			base._logConcole.ReadAndSetValue($"Угадай число от {_min} до {_max}, осталось попыток {_attempsTmp}:");

				if(!base._logConcole.CheckValue(_target))
				{
					if ((--_attempsTmp) > 0)
						goto rpt;
					else
					base._logConcole.Write($"# Попытки закончились! Задуманое число '{_target}'\n");
				}
		}
		public override void SetSettings()
		{
			string str;
			agn:
			base._logConcole.Write("-настройки-");
			str = base._logConcole.Read("Макс число для угадывния:");
			if (int.TryParse(str, out _max) && _max>0)
			{
				_min = _max * (-1);
				this._Randomize();

				str = base._logConcole.Read("Количество попыток:");
				if (int.TryParse(str, out _attempts) && _attempts>0)
				{
					base._settingWasSet = true;
					base._logConcole.Write("----------");
					return;
				}	
			}
			base._logConcole.Write("#Не верный формат! Повторить.");
			goto agn;
		}
		private void _Randomize()
		{
			Random random = new Random();
			if (_max != default)
				_target = random.Next(_min, _max);
			else
				base._logConcole.Write("Не указано максимальное число!");
		}

	}
}
