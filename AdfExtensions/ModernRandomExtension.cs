using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	internal static class ModernRandomExtension
	{
		public static double RandBetween(this Random r, double min, double max) 
		{ 
			return r.NextDouble() * (max - min) + min;
		}

		public static T RandIn<T>(this Random r, IList<T> values)
		{
			return values[r.Next(values.Count)];
		}

	}
}
