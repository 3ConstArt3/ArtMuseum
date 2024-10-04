using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ergasia3.Source.Backend
{
	public static class Globals
	{
		public static int SelectedPaletteIndex { get; set; } = 0;
		public static int Volume { get; set; } = 50;

		// AC related globals
		public static bool IsAcOn = false;
		public static _Temperature Temperature { get; set; } = new();

		// suppress name warnings (this class shouldn't be accessed outside of Globals anyway)
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Internal class")]
		public class _Temperature : IFormattable
		{
			public const float Delta = 0.54f;
			public static readonly float[] AcBounds = [15f, 30f];
			public static readonly float AvgTemperature = (AcBounds[1] - AcBounds[0]) / 2;
			private float temperature = AcBounds[0] + AvgTemperature;

			public static _Temperature operator ++(_Temperature t)
			{
				if (t.CanIncrement())
					t.temperature += Delta;
				return t;
			}

			public static _Temperature operator --(_Temperature t)
			{
				if (t.CanDecrement())
					t.temperature -= Delta;
				return t;
			}

			// automatic Temperature -> float cast
			public static implicit operator float(_Temperature t)
			{
				return t.temperature;
			}

			public static explicit operator _Temperature(float t)
			{
				return new _Temperature()
				{
					temperature = t
				};
			}

			public bool CanIncrement()
			{
				return temperature + Delta <= AcBounds[1];
			}

			public bool CanDecrement()
			{
				return temperature - Delta >= AcBounds[0];
			}

			public override string ToString()
			{
				return temperature.ToString();
			}

			// this is required so interpolated strings with composite formating (:f2)
			// like $"{Globals.Temperature:f2}" can work
			public string ToString(string? format, IFormatProvider? formatProvider)
			{
				return temperature.ToString(format, formatProvider);
			}
		}
	}
}
