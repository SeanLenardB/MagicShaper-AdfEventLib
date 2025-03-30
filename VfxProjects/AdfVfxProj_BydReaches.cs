using MagicShaper.AdfExtensions;
using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects
{
	internal class AdfVfxProj_BydReaches
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\BYD Reaches\level-base.adofai");


			chart.ModernTrackAppear(0, 117, 4d, 8d, 0.5, 2, 0.5, 1.5, endOpacity: 1000);
			chart.ModernTrackDisappear(0, 117, 4d, -2d, -2, -0.5, -1.5, -0.5);

			chart.ModernTrackAppear(117, 740, 8d, 12d, -3, 3, -2, 2, endOpacity: 1000);
			chart.ModernTrackDisappear(117, 740, 8d, -6d, -3, 3, -2, 2);

			File.WriteAllText(@"G:\Adofai levels\BYD Reaches\level-eff.adofai", chart.ChartJson.ToJsonString());
		}

	}
}
