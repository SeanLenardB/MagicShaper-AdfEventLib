using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfClass
{
	internal class AdfScale
	{
		public AdfScale(double x, double y)
		{
			X = x;
			Y = y;
		}
		
		public AdfScale(double s)
		{
			X = s;
			Y = s;
		}

		public double X { get; set; }
		public double Y { get; set; }

		public override string ToString()
		{
			return $"[{X}, {Y}]";
		}
	}
}
