using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
	 class ClientGame
	{
		public void Worker()
		{
			agn:
			Console.Write($"-Меню-\n1. Yгадать число\n2. Подставить текст\n----------\n");
			{
				switch(Console.ReadLine())
				{
					case "1":
						{
							StartGameNumber();
							break;
						}
					case "2":
						{
							StartGameString();
							break;
						}
				}
			}
			Console.Write($"\nПовторим? Y: ");
			if (Console.ReadKey().KeyChar.ToString()?.ToLower() == "y")
			{
				Console.Write($"\n\n----------");
				goto agn;
			}
		}
		 void StartGameNumber()
		{
			AStorage<int> _storage = new StorageNumber(new LogValueNumber());
			_storage.BeginProga();
		}
		 void StartGameString()
		{
			AStorage<string> _storage = new StorageString(new LogValueString());
			_storage.SetSettings();
			_storage.BeginProga();
		}
	}
}
