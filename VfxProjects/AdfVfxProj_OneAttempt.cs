using MagicShaper.AdfExtensions;
using MagicShaper.AdfExtensions.DecoScene;
using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects
{
	internal class AdfVfxProj_OneAttempt
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\OneAttempt\level-base.adofai");


			for (int i = 0; i < chart.ChartTiles.Count; i++)
			{
				for (int j = 0; j < chart.ChartTiles[i].TileEvents.Count; j++)
				{
					if (chart.ChartTiles[i].TileEvents[j].EventType == "ColorTrack")
					{
						((AdfEventColorTrack)chart.ChartTiles[i].TileEvents[j]).TrackGlowIntensity = 0;
					}
				}
			}
			

			DecoScene.DecoSceneFactory factory = new();

			var sceneWhiteForeSmoke = factory.CreateScene();
			sceneWhiteForeSmoke.Elements.Add(sceneWhiteForeSmoke.CreateElement<MassElement>().Use(new()
			{
				"smoke1.png", "smoke2.png"
			}).AsTileSpan(3, -100, 100, -100, 100, 500, 800, 200, 200, 800, 1200)
			.WithMovementParallax(-40, 40, 250, 500, -25, 25, 2048d)
			.FromVaryingLayer(25, 50, 95, 99, 95, 99, 180, 230, -180, 180, -50, -30)
			.ToFlashOut());

			var sceneBlackBackSmoke = factory.CreateScene();
			sceneBlackBackSmoke.Elements.Add(sceneBlackBackSmoke.CreateElement<MassElement>().Use(new()
			{
				"smoke1.png", "smoke2.png"
			}).AsTileSpan(8, -100, 100, -100, 100, 500, 800, 200, 200, 800, 1200)
			.WithMovementParallax(-20, 20, 50, 100, -15, 15, 1024d)
			.FromVaryingLayer(85, 95, 95, 99, 95, 99, 0, 50, -180, 180, 20, 30)
			.ToFlashOut());



			var sceneRuins = factory.CreateScene();
			sceneRuins.Elements.Add(sceneRuins.CreateElement<MonoElement>().Use("nightsky.png")
				.AsBackground().WithAutofit(chart)
				.FromFlash(20).ToFlash());
			sceneRuins.Elements.Add(sceneRuins.CreateElement<MonoElement>().Use("peak.png")
				.AsBackground().WithScale(900)
				.WithParallax(98, 99).WithParallaxOffset(5, -3).FromFlash(100).ToFlash());
			sceneRuins.Elements.Add(sceneRuins.CreateElement<MonoElement>().Use("star2.png")
				.AsBackground().WithScale(200)
				.WithParallax(98, 99).WithParallaxOffset(2, 4).FromFlash(100).ToFlash());

			sceneBlackBackSmoke.ApplyTo(chart, 0, 93);
			sceneWhiteForeSmoke.ApplyTo(chart, 0, 93);
			sceneRuins.ApplyTo(chart, 0, 93);






#pragma warning disable CA1416 // Validate platform compatibility
			chart.LyricWithTranslation("worldmachine.txt", "Bahnschrift", "方正楷体_GBK",
				0, 0, 100, 1, 1, -1145, "FFFFFFFF", "DDDDDDBB");
#pragma warning restore CA1416 // Validate platform compatibility


			File.WriteAllText(@"G:\Adofai levels\OneAttempt\level-eff.adofai", chart.ChartJson.ToJsonString());
		}

	}
}
