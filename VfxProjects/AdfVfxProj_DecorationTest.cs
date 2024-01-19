using MagicShaper.AdfExtensions;
using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.DerivedClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects
{
	[Obsolete]
	internal class AdfVfxProj_DecorationTest
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.ParseChart(File.ReadAllText(@"G:\Adofai levels\decotest\level.adofai"));

			chart.AddDecorationToChart(new AdfDecoration() { DecorationImage = @"keyicon.png" });

			

			File.WriteAllText(@"G:\Adofai levels\decotest\level output.adofai", chart.ChartJson.ToJsonString());
		}

	}
}
