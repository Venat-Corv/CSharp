using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car
{
	class Tank
	{
		uint volume;
		double fuel;
		public uint Volume
		{
			get => volume;
			private set => volume = value >= 40 && value <= 120 ? value : throw new Exception("Bad volume");
		}
		public double Fuel
		{
			get => fuel;
			set
			{
				fuel = value;
				if (fuel < 0) fuel = 0;
				if (fuel > Volume) fuel = Volume;
			}
		}

		public Tank(uint volume)
		{
			Volume = volume;
			Fuel = 0;
		}

		public double changeFuel(double fuel)
		{
			Fuel += fuel;
			return Fuel;
		}

		public override string ToString()
		{
			return $"Tank volume: {Volume}\nFuel level: {Fuel}";
		}
	}
}
