using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
	 class StorageString :AStorage<string>
	{
		protected List<string> _lib = default!;
		public StorageString(ALogValue<string> concole) : base(concole) 
		{
			_lib = new();
		}
		public override void BeginProga()
		{
			int _attemptsTmp = _attempts;

			if (!base._settingWasSet) SetSettings();

			foreach (var val in this._lib)
			{
				base._logConcole.Write($"{this._SplitedString(val)}");
				rpt:
				base._logConcole.ReadAndSetValue($"Подставь слово..");
				if(!base._logConcole.CheckValue(this._target))
				{
					base._logConcole.Write($":: Не верно! Осталось {--_attemptsTmp} попыток");
					if (_attemptsTmp > 0)
						goto rpt;
					else
						base._logConcole.Write($"# Попытки закончились! Задуманное слово '{_target}'\n[{val}]\n\n>>>Следующая строка\n");
				}
				else
				{
					base._logConcole.Write($"!!! Верно !!! Получилось с {_attempts -_attemptsTmp+1} попытки");
					base._logConcole.Write($"[{val}]\n");
				}
				_attemptsTmp = _attempts;
			}
		}
		public override void SetSettings()
		{
			string str;
			this.FillLib("у лукоморья дуб зелёный, золотая цепь на дубе том");
			this.FillLib("ночь была темна, но сало надо перепрятать");
			this.FillLib("колокольчик однозвучный утомительно гремит");

			base._logConcole.Write("-настройки-");
			agn:
			str = base._logConcole.Read("Количество попыток для строки:");
			if (int.TryParse(str, out _attempts) && _attempts > 0)
			{
				base._settingWasSet = true;
				base._logConcole.Write("----------");
				return;
			}
			base._logConcole.Write("#Не верный формат! Повторить.");
			goto agn;
		}

		private string _SplitedString(string str)
		{
			Random _rnd = new Random();
			string[] _str = str.Split(' ');
			
			this._target =  _str[_rnd.Next(0, _str.Length-1)].Replace(",", "").Trim();
			str = str.Replace(this._target, "[...]");
			return str;
		}
		public void FillLib(List<string> strings)
		{
			_lib = strings;
		}
		public void FillLib(string str)
		{
			_lib.Add(str);
		}
	}
}
