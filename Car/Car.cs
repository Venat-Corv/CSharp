using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Car
{
	class Car
	{
		Engine engine;
		Tank tank;
		

		uint speed;
		uint max_speed;
		public Engine Engine
		{
			get=>engine;
			private set => engine=value;
		}
		public Tank Tank
		{
			get => tank;
			private set => tank = value;
		}
		public uint Speed
		{
			get => speed;
			set => speed = value < max_speed ? value : max_speed;
		}
		public uint Max_speed
		{
			get => max_speed;
			private set => max_speed = value <= 420 ? value : throw new Exception("Error: You violanted the lows of phisics 0_0");
		}

		public Car(Engine engine, Tank tank)
		{
			Engine = engine;
			Tank = tank;
			if(Engine.Power >= 50 && Engine.Power <= 200)
			{
				Max_speed = Engine.Power * 140 / 100;
			}
			if (Engine.Power >= 200 && Engine.Power <= 300)
			{
				Max_speed = Engine.Power * 110 / 100;
			}
			if (Engine.Power >= 300 && Engine.Power <= 500)
			{
				Max_speed = Engine.Power * 80 / 100;
			}
			else
			{
				Max_speed = Engine.Power * 42 / 100;
			}

			Control = new Control();
			speed = 0;
		}

		public bool DriverInside { get; set; }

		public bool BreakPedal { get; set; }
		public bool GasPedal { get; set; }

		public Control Control { get; set; }

		public void Panel()
		{
			while(DriverInside)
			{
				Console.Clear();
				Console.WriteLine($"Engine is {(engine.Started ? "started" : "stopped")}");
				if (tank.Fuel <= 5)
				{
					ConsoleColor defaultColor = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("LOW FUEL!!!");
					Console.ForegroundColor = defaultColor;
				}
				Console.WriteLine($"Fuel level: {tank.Fuel}.");
				Console.WriteLine($"Speed: {Speed} km/h");
				Thread.Sleep(1000);
			}
		}

		public void GetIn()
		{
			DriverInside = true;
			Control.tControlPanelThread = new Thread(Panel);
			Control.tControlPanelThread.Start();
		}
		public void GetOut()
		{
			DriverInside = false;
			Control.tControlPanelThread.Join();
		}

		public void Start()
		{
			if (tank.Fuel > 0)
			{
				engine.Started = true;
				Control.tEngineIdleThread = new Thread(EngineIdle);
				Control.tEngineIdleThread.Start();
			}
			else
			{
				Console.WriteLine("No fuel :(");
			}
		}

		public void Stop()
		{
			engine.Started = false;
			if(Control.tEngineIdleThread != null)Control.tEngineIdleThread.Join();
		}



		public void EngineIdle()
		{
			while(engine.Started && tank.Fuel > 0)
			{
				tank.changeFuel(-engine.ConsumptionPerSecond);
				Thread.Sleep(1000);
			}
		}

		public void PressGas()
		{
			GasPedal = true;
			if(engine.Started && GasPedal && Control.tAccelerationThread == null)
			{
				Control.tAccelerationThread = new Thread(Acceleration);
				Control.tAccelerationThread.Start();
			}
		}

		public void Acceleration()
		{
			if (Speed < max_speed)
			{
				if (Speed < max_speed) speed += 10;
				if (Speed > max_speed) speed = max_speed;
			}
			
		}

		public void ReleaseGas()
		{
			GasPedal = false;
			if(Speed > 0 && !GasPedal && Control.tFreeWheelingThread == null)
			{
				Control.tFreeWheelingThread = new Thread(FreeWheeling);
				Control.tFreeWheelingThread.Start();
			}
		}

		public void FreeWheeling()
		{
			if(Speed > 0)
			{
				if (Speed > 0) Speed -= 1;
				if (Speed < 0) Speed = 0;
				Thread.Sleep(1000);
			}
			
		}

		public void Break()
		{
			if(Speed > 0 && Control.tBreakingThread == null)
			{
				Control.tBreakingThread = new Thread(Breaking);
				Control.tBreakingThread.Start();
			}
		}

		public void Breaking()
		{
			if (Speed > 0)
			{
				if (Speed > 0) Speed -= 20;
				if (Speed < 0) Speed = 0;
			}
		}

		public override string ToString()
		{
			return $"{Engine.ToString()}\n{Tank.ToString()}\nMax speed: {Max_speed} km/h";
		}
	}
}
