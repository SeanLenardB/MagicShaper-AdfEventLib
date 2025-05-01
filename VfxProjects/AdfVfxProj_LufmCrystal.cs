using MagicShaper.AdfExtensions;
using MagicShaper.AdfExtensions.DecoScene;
using MagicShaper.AdfExtensions.Gimmicks;
using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects
{
	internal class AdfVfxProj_LufmCrystal
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\Lufm Crystal Dragon\level-noeffect.adofai");

			
			DecoScene.DecoSceneFactory factory = new();

			chart.OsuManiaGimmickAdvanced(1199, 2141, (i) => chart.ChartTiles[i].TargetAngle >= 999d && chart.GetTileBpmAt(i) > 1000,
				1, 0.6d, 2d, 1d, 0.1d, 32d, 0.2d, -10d, -7.2d,
				true, true, -90, -18020, AdfHitsoundType.FireTile);

			chart.OsuManiaGimmickAdvanced(3300, 3600, (i) => chart.ChartTiles[i].TargetAngle >= 999d && chart.GetTileBpmAt(i) > 1000,
				1, 0.6d, 2d, 1d, 0.1d, 32d, 0.2d, -10d, -7.2d,
				true, true, -90, -18020, AdfHitsoundType.FireTile);





			chart.ModernTrackAppear(1238, 2141, 4d, 2d, -8, -5, 4, 6, -45, 45, 75, 90,
				20, 500, 100, 1);
			chart.ModernTrackDisappear(1238, 2141, 2d, -2d, 5, 8, 2, 5, -45, 45, 35, 55,
				10, 0.8);

			chart.ModernTrackAppear(3307, 3600, 4d, 2d, 5, 8, 4, 6, -45, 45, 75, 90,
				20, 500, 100, 1);
			chart.ModernTrackDisappear(3307, 3600, 2d, -2d, -8, -5, 2, 5, -45, 45, 35, 55,
				10, 0.8);




			for (int i = 987; i < 1198; i++)
			{
				if (chart.GetInnerAngleAtTile(i) <= 30d && chart.GetInnerAngleAtTile(i + 1) != 150d)
				{
					chart.FisheyePulseByTile(new List<int>() { i }, 24d);
					i += 2;
				}
			}


			for (int i = 2725; i < 3048; i++)
			{
				if (chart.GetInnerAngleAtTile(i) <= 30d && chart.GetInnerAngleAtTile(i + 1) != 150d)
				{
					chart.FisheyePulseByTile(new List<int>() { i }, 24d);
					i += 2;
				}
			}

			for (int i = 3101; i < 3216; i++)
			{
				if (chart.GetInnerAngleAtTile(i) <= 30d && chart.GetInnerAngleAtTile(i + 1) != 150d)
				{
					chart.FisheyePulseByTile(new List<int>() { i }, 24d);
					i += 2;
				}
			}

			for (int i = 3798; i < 4046; i++)
			{
				if (chart.GetInnerAngleAtTile(i) <= 30d && chart.GetInnerAngleAtTile(i + 1) != 150d)
				{
					chart.FisheyePulseByTile(new List<int>() { i }, 24d);
					i += 2;
				}
			}

			for (int i = 4168; i < 4252; i++)
			{
				if (chart.GetInnerAngleAtTile(i) <= 30d && chart.GetInnerAngleAtTile(i + 1) != 150d)
				{
					chart.FisheyePulseByTile(new List<int>() { i }, 24d);
					i += 2;
				}
			}



			var sceneCrystalCave = factory.CreateScene();
			sceneCrystalCave.Elements.Add(sceneCrystalCave.CreateElement<MassElement>().Use(new()
			{
				"m1.png",
				"m2.png",
				"m3.png",
				"m4.png",
				"m5.png",
				"m6.png",
				"m7.png",
				"m8.png",
				"m9.png",
			}).AsSpanParallax(15, -40, 40, 20, 27, 800, 1000)
			.FromVaryingLayer(60, 80, 92, 98, 99, 99.9, 0, 0, 180, 180, -50, -30)
			.ToFlashOut());
			sceneCrystalCave.Elements.Add(sceneCrystalCave.CreateElement<MassElement>().Use(new()
			{
				"m1.png",
				"m2.png",
				"m3.png",
				"m4.png",
				"m5.png",
				"m6.png",
				"m7.png",
				"m8.png",
				"m9.png",
			}).AsSpanParallax(25, -45, -12, -25, -15, 800, 1000)
			.FromVaryingLayer(20, 40, 92, 98, 99, 99.9, 0, 0, 0, 0, -50, -30)
			.ToFlashOut());
			sceneCrystalCave.Elements.Add(sceneCrystalCave.CreateElement<MassElement>().Use(new()
			{
				"m1.png",
				"m2.png",
				"m3.png",
				"m4.png",
				"m5.png",
				"m6.png",
				"m7.png",
				"m8.png",
				"m9.png",
			}).AsSpanParallax(25, 12, 45, -25, -15, 800, 1000)
			.FromVaryingLayer(20, 40, 90, 98, 99, 99.9, 0, 0, 0, 0, -50, -30)
			.ToFlashOut());
			sceneCrystalCave.Elements.Add(sceneCrystalCave.CreateElement<MassElement>().Use(new()
			{
				"m1.png",
				"m2.png",
				"m3.png",
				"m4.png",
				"m5.png",
				"m6.png",
				"m7.png",
				"m8.png",
				"m9.png",
			}).AsSpanParallax(15, -20, 20, -15, -8, 400, 500)
			.FromVaryingLayer(80, 90, 95, 99, 99, 99.9, 0, 0, 0, 0, 50, 70)
			.ToFlashOut());


			sceneCrystalCave.ApplyTo(chart, 0, 4483);



			File.WriteAllText(@"G:\Adofai levels\Lufm Crystal Dragon\level-eff.adofai", chart.ChartJson.ToJsonString());

		}
	}
}
