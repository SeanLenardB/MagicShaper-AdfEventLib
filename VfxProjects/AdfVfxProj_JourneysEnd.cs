using MagicShaper.AdfExtensions;
using MagicShaper.AdfExtensions.DecoScene;
using MagicShaper.AdfExtensions.Gimmicks;
using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects
{
	internal class AdfVfxProj_JourneysEnd
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\JourneysEnd\level-loweffect.adofai");

			chart.SetupVisionLimit();
			chart.SetVisionLimitAutofit("banner.png", 0);


			for (int i = 1; i < chart.ChartTiles.Count; i++)
			{
				bool flag = false;

				foreach (var e in chart.ChartTiles[i].TileEvents)
				{
					if (e is AdfEventSetSpeed se)
					{
						if (Math.Abs(chart.GetTileBpmAt(i) / chart.GetTileBpmAt(i - 1)) >= 0.1)
						{
							flag = true; break;
						}
					}
				}

				if (flag)
				{
					chart.ChartTiles[i].TileEvents.Add(new AdfEventRecolorTrack()
					{
						AngleOffset = -114514d,
						TrackColor = new("FFFFFF"),
						TrackStyle = AdfTrackStyle.Basic,
						TrackGlowIntensity = 0
					});
				}
			}

			DecoScene.DecoSceneFactory factory = new();

			var sceneSmoke = factory.CreateScene();
			sceneSmoke.Elements.Add(sceneSmoke.CreateElement<MassElement>().Use(new()
			{
				"smoke1.png", "smoke2.png"
			}).AsTileSpan(3, -100, 100, -100, 100, 500, 800, 200, 200, 800, 1200)
			.WithMovementParallax(-20, 20, 200, 300, -15, 15, 1024d)
			.FromVaryingLayer(15, 30, 95, 99, 95, 99, 80, 130, -180, 180, 20, 30)
			.ToFlashOut());
			sceneSmoke.Elements.Add(sceneSmoke.CreateElement<MassElement>().Use(new()
			{
				"smoke1.png", "smoke2.png"
			}).AsTileSpan(3, -100, 100, -100, 100, 500, 800, 200, 200, 800, 1200)
			.WithMovementParallax(-40, 40, 300, 400, -25, 25, 1024d)
			.FromVaryingLayer(25, 50, 95, 99, 95, 99, 180, 230, -180, 180, -50, -30)
			.ToFlashOut());


			var sceneCrystalCave = factory.CreateScene();
			sceneCrystalCave.Elements.Add(sceneCrystalCave.CreateElement<MonoElement>().Use("crystal.png")
				.AsBackground().WithAutofit(chart).FromFlash(50).ToFlash());
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
			}).AsSpanParallax(15, -40, 40, 13, 20, 800, 1000)
			.FromVaryingLayer(60, 80, 85, 90, 95, 98, 20, 85, 180, 180, -50, -30)
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
			}).AsSpanParallax(15, -20, -15, -20, -10, 800, 1000)
			.FromVaryingLayer(20, 40, 85, 90, 95, 98, 20, 85, 0, 0, -50, -30)
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
			}).AsSpanParallax(15, 15, 20, -20, -10, 800, 1000)
			.FromVaryingLayer(20, 40, 85, 90, 95, 98, 20, 85, 0, 0, -50, -30)
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
			}).AsSpanParallax(15, -20, 20, -10, -3, 400, 500)
			.FromVaryingLayer(80, 90, 95, 98, 95, 98, 90, 185, 0, 0, 50, 70)
			.ToFlashOut());
			sceneCrystalCave.Elements.Add(sceneCrystalCave.CreateElement<MassElement>().Use(new()
			{
				"ware1.png",
				"ware2.png",
				"ware3.png",
				"ware4.png",
				"ware5.png",
				"ware6.png",
				"ware7.png",
				"ware8.png",
				"ware9.png",
				"ware10.png",
				"ware11.png",
				"ware12.png",
			}).AsSpanParallax(60, -20, 20, -30, 30, 300, 800)
			.FromVaryingLayer(50, 80, 85, 95, 95, 98, 0, 255, -180, 180, 10, 80)
			.ToFlashOut());





			sceneCrystalCave.ApplyTo(chart, 0, 3068);
			sceneSmoke.ApplyTo(chart, 0, 3068);

			chart.ModernTrackAppear(0, 165, 4d, 4d, -1.5, 1.5, 0.5, 1.5, -30, 30, 75, 80);





			File.WriteAllText(@"G:\Adofai levels\JourneysEnd\level-effect.adofai", chart.ChartJson.ToJsonString());
		}
	}
}
