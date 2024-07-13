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
	internal class AdfVfxProj_NextLife
	{
		internal static void ProjMain()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\Next Life\level-base.adofai");

			DecoScene.DecoSceneFactory factory = new();


			for (int i = 0; i < chart.ChartTiles[0].TileEvents.Count; i++)
			{
				if (chart.ChartTiles[0].TileEvents[i] is IAdfEventAngleOffsetable e)
				{
					e.AngleOffset = 180 * 4;
					chart.ChartTiles[0].TileEvents[i] = e;
				}
			}




			// First Part
			var sceneSunray = factory.CreateScene(39, 71);
			sceneSunray.Elements.Add(sceneSunray.CreateElement<MonoElement>().Use("light.png")
				.AsBackground()
				.WithScale(230).WithParallaxOffset(0, -3.5)
				.FromFlash().ToFlash());

			sceneSunray.ApplyTo(chart);


			var sceneMountainGrass = factory.CreateScene(1, 71);

			sceneMountainGrass.Elements.Add(sceneMountainGrass.CreateElement<MonoElement>().Use("bg1.png")
				.AsBackground()
				.WithScale(230).WithParallaxOffset(0, -2)
				.FromFlash().ToFlash());
			sceneMountainGrass.Elements.Add(sceneMountainGrass.CreateElement<MassElement>().Use(new()
			{
				"grass1.png", "grass3.png"
			}).AsSpan(20, scaleMin: 150, scaleMax: 280)
				.WithFloor(xmin: -8, xmax: 8, ymin: -4.5, ymax: -4)
				.FromVaryingLayer().ToFlashOut());
			sceneMountainGrass.Elements.Add(sceneMountainGrass.CreateElement<MassElement>().Use(new()
			{
				"grass2.png"
			}).AsTileSpan(3, scaleMin: 199, scaleMax: 350)
				.WithFloor(xmin: -8, xmax: 8, ymin: -4, ymax: -2.2)
				.FromVaryingLayer().ToFlashOut());
			sceneMountainGrass.Elements.Add(sceneMountainGrass.CreateElement<MassElement>().Use(new()
			{
				"smoke1.png"
			}).AsTilingSmoke(5, 150, 250, -250, 250, -500, 0, scaleMin: 850, scaleMax: 1200)
				.WithMovement(40, 200, 250, 510, 64d)
				.FromVaryingLayer(rgbMin: 140, rgbMax: 255).ToFlashOut());
			sceneMountainGrass.Elements.Add(sceneMountainGrass.CreateElement<MassElement>().Use(new()
			{
				"cloud1.png", "cloud2.png", "cloud3.png", "cloud4.png", "cloud5.png"
			}).AsSpan(8, scaleMin: 100, scaleMax: 150)
				.WithFloor(xmin: -20, xmax: 20, ymin: 4, ymax: 5)
				.FromVaryingLayer(rgbMin: 225, rgbMax: 255).ToFlashOut());
			sceneMountainGrass.ApplyTo(chart);

			chart.CameraTiltAndDiveTransition(1, 40, 125, 4d, 8d, outEase: AdfEaseType.OutCirc);
			chart.BlurByBeatOutEase(0, 1, 114514, 4d);

			chart.ModernTrackAppear(0, 71, 8d, 8d, 1, 2, 1, 1.5, -5, 10, 105, 120);
			chart.ModernTrackDisappear(0, 71, 8d, -2d, -1, -0.5, -1.5, -0.5, -15, 5, 75, 90);

			BlurCameraTo(chart, 11);
			BlurCameraTo(chart, 21);
			BlurCameraTo(chart, 31);
			BlurCameraTo(chart, 39);
			BlurCameraTo(chart, 46);
			BlurCameraTo(chart, 52);




			 

			File.WriteAllText(@"G:\Adofai levels\Next Life\level-vfx.adofai", chart.ChartJson.ToJsonString());
		}

		private static void BlurCameraTo(AdfChart chart, int tile, double max = 800d)
		{
			Random random = new();
			chart.BlurByBeatOutEase(tile, 1, 114514, 6d, max);
			chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveCamera()
			{
				Duration = 8d,
				Ease = AdfEaseType.OutCirc,
				RelativeTo = AdfCameraRelativeToType.Tile,
				Position = new(random.NextDouble() * 2, random.NextDouble() * 1.5 + 2),
				Zoom = random.NextDouble() * 30 + 140
			});
		}
	}
}
