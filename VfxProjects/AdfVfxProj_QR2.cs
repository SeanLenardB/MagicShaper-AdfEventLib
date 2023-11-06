using MagicShaper.AdfExtensions;
using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects
{
	internal class AdfVfxProj_QR2
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.ParseChart(File.ReadAllText(@"G:\Adofai levels\QR2\nerfednew.adofai"));

			//22 238
			chart.TrackDisappearUplift(22, 238, 4d);

			//239 346
			chart.TrackDisappearExplosion(new()
			{
				247, 257, 268, 278, 297, 315, 347
			}, 4d);

			//363 653
			chart.TrackAppearScatter(363, 653, 2d, 6d);
			chart.TrackDisappearComingOutOfTheScreen(363, 653, 4d);

			chart.TrackAppearScatter(1170, 2103, 2d, 6d);
			chart.TrackDisappearDownlift(1170, 2103, 4d);

			chart.RandomCamera(-5d, 5d, -4d, 4d, -5d, 5d, 350d, 400d, 8, 8, 4, 4, 1440d, 1170);

			File.WriteAllText(@"G:\Adofai levels\QR2\nerfednew vfx.adofai", chart.ChartJson.ToJsonString());


		}
	}
}
