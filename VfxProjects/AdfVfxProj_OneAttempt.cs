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
				.AsBackground().WithScale(250)
				.WithParallax(98, 99).WithParallaxOffset(-2, 4).FromFlash(100).ToFlash());

			sceneBlackBackSmoke.ApplyTo(chart, 0, 93);
			sceneWhiteForeSmoke.ApplyTo(chart, 0, 93);
			sceneRuins.ApplyTo(chart, 0, 93);



			var sceneWarehouse = factory.CreateScene();
			sceneWarehouse.Elements.Add(sceneWarehouse.CreateElement<MonoElement>().Use("warehouse.png")
				.AsBackground()
				.WithAutofit(chart)
				.FromFlash(60).ToFlash());
			sceneWarehouse.Elements.Add(sceneWarehouse.CreateElement<MassElement>().Use(new()
			{
				"pil1.png", "pil2.png", "pil3.png", "pil4.png", "pil5.png"
			}).AsSpan(6, scaleMin: 300, scaleMax: 800)
				.WithFloor(xmin: -32, xmax: 48, ymin: -5, ymax: -3)
				.WithMovement(5, 20, -3, 3, -1, 1, 128d)
				.FromVaryingLayer(parallaxXMin: -50, parallaxXMax: 70, opacityMin: 25, opacityMax: 100, rgbMin: 150).ToFlashOut());

			var sceneWares = factory.CreateScene();
			sceneWares.Elements.Add(sceneWares.CreateElement<MassElement>().Use(new()
			{
				"ware1.png", "ware2.png", "ware3.png", "ware4.png", "ware5.png", "ware6.png", "ware7.png", "ware8.png", "ware9.png", "ware10.png", "ware11.png", "ware12.png"
			}).AsSpan(100, -30, 60, -30, 20, scaleMin: 50, scaleMax: 350)
				.WithMovement(-50, -10, 10, 30, -90, 90, 128d)
				.FromVaryingLayer(25, 100, -50, 70, -50, 70, 50, 255, -180, 180)
				.ToFlyOut(16d, 5, 20));

			var sceneWarehouseSmoke = factory.CreateScene();
			sceneWarehouseSmoke.Elements.Add(sceneWarehouseSmoke.CreateElement<MassElement>().Use(new()
			{
				"smoke1.png", "smoke2.png"
			}).AsTiled(5, 150, 250, -250, 250, -500, 0, scaleMin: 850, scaleMax: 1200)
				.WithMovement(-200, -40, 250, 510, -45, 45, duration: 128d)
				.FromVaryingLayer(rgbMin: 0, rgbMax: 140).ToFlashOut());

			sceneWarehouse.ApplyTo(chart, 93, 1571);
			sceneWarehouseSmoke.ApplyTo(chart, 93, 1571);
			sceneWares.ApplyTo(chart, 93, 1571);



#pragma warning disable CA1416 // Validate platform compatibility
			chart.LyricWithTranslation("worldmachine.txt", "Bahnschrift", "方正楷体_GBK",
				0, 0, 100, 1, 1, -1145, "FFFFFFFF", "DDDDDDBB");
#pragma warning restore CA1416 // Validate platform compatibility


			File.WriteAllText(@"G:\Adofai levels\OneAttempt\level-eff.adofai", chart.ChartJson.ToJsonString());
		}

	}
}
