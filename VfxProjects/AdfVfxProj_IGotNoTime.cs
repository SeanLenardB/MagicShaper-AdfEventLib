using MagicShaper.AdfExtensions;
using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects
{
	internal class AdfVfxProj_IGotNoTime
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.ParseChart(File.ReadAllText(@"G:\Adofai levels\Five Nights at Freddy's\level.adofai"));
			// vfx

			//// Console.WriteLine(chart.GetEvents());
			for (int i = 0; i < chart.ChartTiles.Count; i++)
			{
				AdfEventMoveDecorations? flag = null;
				foreach (var e in chart.ChartTiles[i].TileEvents)
				{
					if (e is AdfEventMoveDecorations ee1)
					{
						if (ee1.Tag == "q")
						{
							flag = ee1;
						}
					}
					if (e is AdfEventSetHitsound ee2)
					{
						if (ee2.Hitsound == AdfHitsoundType.Sidestick)
						{
							ee2.Hitsound = AdfHitsoundType.IceTile;
						}
					}
				}
				if (flag is not null)
				{
					chart.ChartTiles[i].TileEvents.Remove(flag);
				}
			}
			//Console.WriteLine();
			//for (int i = 0; i < chart.ChartTiles.Count; i++)
			//{
			//	foreach (var e in chart.ChartTiles[i].TileEvents)
			//	{

			//		if (e is AdfEventSetSpeed ee2)
			//		{
			//			Console.WriteLine(i + ", ");
			//		}
			//	}
			//}
			// 20,32,51,86,110,129,163,180,199,235,258,277,306,313,320,336,343,350,367,380,396,428,453,485,529,835,847,866,902,925,944,978,995,1014,1050,1073,1092,1121,1128,1135,1151,1158,1165,1182,1195,1211,1243,1268,1296,1344,



			chart.TrackDisappearExplosion(new()
			{
				21,29,39,48,58,66,76,84,94,102,112,121,131,139,149,157,169,177,187,196,206,214,224,232,242,250,260,269,279,287,297,303,309,
			}, 2d);

			chart.TrackDisappearExplosion(new()
			{
				836,844,854,863,873,881,891,899,909,917,927,936,946,954,964,972,984,992,1002,1011,1021,1029,1039,1047,1057,1065,1075,1084,1094,1102,1112,1118,1124,
			}, 2d);
			
			chart.TrackAppearExplosion(new()
			{
				21,29,39,48,58,66,76,84,94,102,112,121,131,139,149,157,169,177,187,196,206,214,224,232,242,250,260,269,279,287,297,303,309,
			}, 2d, 4d);

			chart.TrackAppearExplosion(new()
			{
				836,844,854,863,873,881,891,899,909,917,927,936,946,954,964,972,984,992,1002,1011,1021,1029,1039,1047,1057,1065,1075,1084,1094,1102,1112,1118,1124,
			}, 2d, 4d);

			chart.FadeInOutLyric(new()
			{
				20,32,51,86,110,129,163,180,199,235,258,277,306,313,320,336,343,350,367,380,396,428,453,485,835,847,866,902,925,944,978,995,1014,1050,1073,1092,1121,1128,1135,1151,1158,1165,1182,1195,1211,1243,1268,1296
			}, 0.5d, "q");

			chart.TrackAppearUplift(309, 529, 4d, 2d);
			chart.TrackAppearUplift(0, 21, 4d, 2d);
			chart.TrackDisappearUplift(0, 21, 4d, 80d);
			chart.TrackDisappearUplift(309, 529, 4d, 80d);
			chart.TrackAppearScatter(530, 836, 2d, 5d);
			chart.TrackDisappearScatter(530, 836, 1.5d);
			chart.TrackAppearUplift(1124, 1344, 4d, 2d);
			chart.TrackDisappearUplift(1124, 1344, 4d, 80d);
			chart.TrackAppearScatter(1345, 2038, 2d, 5d);
			chart.TrackDisappearExplosion(new()
			{
				1354, 1373, 1393, 1419, 1445, 1472, 1497, 1523, 1543, 1562, 1582, 1608, 1628, 1647, 1668, 1692,
				1354+358, 1373+358, 1393+358, 1419+358, 1445+358, 1472+358, 1497+358, 1523+358, 1543+358, 1562+358, 1582+358, 1608+358, 1628+358, 1647+358, 1668+358,
				2039
			}, 2d);
			chart.TrackAppearUplift(2039, 2134, 4d, 2d);
			chart.TrackDisappearUplift(2039, 2134, 4d, 80d);


			chart.FlashlightWobbleEffect("fl", -11, 11, -6, 6, 3, 4, 4, 8, 2048d);
			chart.RandomCamera(-6, 6, -4, -1, -8d, 8d, 200d, 240d, 3, 3, 1, 1, 2048d, 0);



			File.WriteAllText(@"G:\Adofai levels\Five Nights at Freddy's\level vfx.adofai", chart.ChartJson.ToJsonString());




		}


	}
}
