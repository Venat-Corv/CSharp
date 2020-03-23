﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car
{
	class Engine
	{
		uint power;
		double consumption;
		public uint Power
		{
			get => power;
			set
			{
				power = value >= 50 && value <= 1000 ? value : throw new Exception("Error: Bad engine power");
			}
		}
		public double Consumption
		{
			get => consumption;
			private set
			{
				consumption = value;
			}
		}

		public double ConsumptionPerSecond { get; set; }
		public bool Started { get; set; }
		public Engine(uint power)
		{
			Power = power;
			Consumption = 0.0002 * (Power / 20);
			ConsumptionPerSecond = Consumption / 100;
			Started = false;
		}

		public override string ToString()
		{
			return $"Power: {Power} hp, Consumption {Consumption * 3600} 1/100km, engine {(Started ? "started": "stopped")}";
		}
	}
}
