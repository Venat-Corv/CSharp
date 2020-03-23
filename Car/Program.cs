using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Car
{
	class Program
	{
		static void Main(string[] args)
		{
			Car car = new Car(new Engine(250), new Tank(60));
			Console.WriteLine("Your car is ready, press Enter to get in");
			Console.ReadKey();
			car.GetIn();
			ConsoleKey key;
			do
			{
				key = Console.ReadKey(true).Key;
				switch (key)
				{
					case ConsoleKey.Enter: if (!car.Engine.Started) { car.Start(); } else car.Stop(); break;
					case ConsoleKey.F:
						car.Control.tControlPanelThread.Suspend();
						Console.WriteLine("How match?");
						car.Tank.changeFuel(Convert.ToDouble(Console.ReadLine()));
						car.Control.tControlPanelThread.Resume();
						break;
					case ConsoleKey.W:
						car.Acceleration();
						break;
					case ConsoleKey.S:
						car.Break();
						break;
					case ConsoleKey.Escape: car.Stop(); car.GetOut(); break;
				}
				car.ReleaseGas();
			} while (key != ConsoleKey.Escape);
		}
	}
}
