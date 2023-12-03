using MagicShaper.AdfExtensions;
using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects
{
	internal class AdfVfxProj_EscapingAFoulPresence
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.ParseChart(File.ReadAllText(@"G:\Adofai levels\Escaping a Foul Presence (Cut)\levelbase.adofai"));

			chart.TrackDisappearDownlift(0, 25, 4d);

			chart.TrackDisappearUplift(25, 553, 2d, 80);
			chart.TrackAppearUplift(25, 553, 4d, 8d, endOpacity:300);

			chart.RandomCamera(-3d, 3d, 0d, 2d, -5d, 5d, 320d, 400d, 8, 8, 4, 4, 14*12d, 1);

			chart.RandomCamera(2d, 4d, 1d, 2d, 3d, 6d, 300d, 420d, 8*2, 8*2, 4*2, 4*2, 32*12d, 553);

			
			chart.TrackAppearUplift(553, 1131, 2d, 3d, endOpacity: 300);
			chart.TrackDisappearComingOutOfTheScreen(553, 1131, 1.5d);

			double con1 = 704.9999d / 660d;
			chart.RandomCamera(-3d, 3d, -2d, 2d, -5d, 5d, 420d, 500d, 8 * con1, 8 * con1, 4 * con1, 4 * con1, 4 * 12d * con1, 1131);
			chart.RandomCamera(0d, 3d, -2d, 2d, -5d, 5d, 300d, 350d, 16, 16, 8, 8, 4 * 24d, 1184);
			chart.TrackAppearUplift(1131, 1184, 4d, 6d, endOpacity: 300);
			chart.TrackDisappearDownlift(1131, 1184, 4d);

			chart.TrackAppearScatter(1184, 1298, 1.5d, 2d, endOpacity: 300);
			chart.TrackDisappearComingOutOfTheScreen(1184, 1298, 1.5d);

			chart.RandomCamera(-3d, 3d, -2d, 2d, -5d, 5d, 420d, 500d, 8 * con1, 8 * con1, 4 * con1, 4 * con1, 4 * 12d * con1, 1298);
			chart.RandomCamera(0d, 3d, -2d, 2d, -5d, 5d, 300d, 350d, 16, 16, 8, 8, 3 * 24d, 1355);
			chart.RandomCamera(2d, 5d, -2d, 2d, -5d, 5d, 250d, 320d, 8, 8, 4, 4, 48d, 1439);
			chart.TrackAppearUplift(1298, 1355, 4d, 6d, endOpacity: 300);
			chart.TrackDisappearDownlift(1298, 1355, 4d);

			chart.TrackAppearScatter(1355, 1499, 1.5d, 2d, endOpacity: 300);
			chart.TrackDisappearComingOutOfTheScreen(1355, 1439, 1.5d);
			chart.TrackDisappearScatter(1439, 1499, 0.5d);

			chart.RandomCamera(-3d, 3d, -2d, 2d, -5d, 5d, 300d, 350d, 16, 16, 8, 8, 4 * 24d, 1499);
			chart.TrackAppearScatter(1499, 1679, 2d, 2d, endOpacity: 300);
			chart.TrackDisappearUplift(1499, 1679, 2d);

			File.WriteAllText(@"G:\Adofai levels\Escaping a Foul Presence (Cut)\newer.adofai", chart.ChartJson.ToJsonString());


		}
	}
}
