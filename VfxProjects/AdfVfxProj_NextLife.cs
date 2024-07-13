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
			var sceneSunray = factory.CreateScene(39, 169);
			sceneSunray.Elements.Add(sceneSunray.CreateElement<MonoElement>().Use("light.png")
				.AsBackground()
				.WithScale(230).WithParallaxOffset(0, -3.5)
				.FromFlash().ToFlash());

			sceneSunray.ApplyTo(chart);



			var sceneMountain = factory.CreateScene(1, 169);
			sceneMountain.Elements.Add(sceneMountain.CreateElement<MonoElement>().Use("bg1.png")
				.AsBackground()
				.WithScale(230).WithParallaxOffset(0, -2)
				.FromFlash().ToFlash());
			sceneMountain.Elements[0].OnTile.Add(t =>
			{
				if (t != 70) { return null; }

				return new AdfEventMoveDecorations()
				{
					Tag = "quartrond_Scene-1_Element-0", // do not try this at home. i shall find a way to do this without accessing from outside
					Ease = AdfEaseType.OutCubic,
					Duration = 6d,
					ParallaxOffset = new(0, -4)
				};
			});
			sceneMountain.ApplyTo(chart);



			var sceneClouds = factory.CreateScene(1, 70);
			sceneClouds.Elements.Add(sceneClouds.CreateElement<MassElement>().Use(new()
			{
				"smoke1.png"
			}).AsTiled(5, 150, 250, -250, 250, -500, 0, scaleMin: 850, scaleMax: 1200)
				.WithMovement(40, 200, 250, 510, 64d)
				.FromVaryingLayer(rgbMin: 140, rgbMax: 255).ToFlashOut());
			sceneClouds.Elements.Add(sceneClouds.CreateElement<MassElement>().Use(new()
			{
				"cloud1.png", "cloud2.png", "cloud3.png", "cloud4.png", "cloud5.png"
			}).AsTileSpan(3, scaleMin: 200, scaleMax: 350)
				.WithFloor(xmin: -20, xmax: 20, ymin: 6, ymax: 8)
				.FromVaryingLayer(rgbMin: 200, rgbMax: 255, opacityMax: 30, opacityMin: 10).ToFlashOut());
			sceneClouds.ApplyTo(chart);



			var sceneGrass = factory.CreateScene(1, 71);
			sceneGrass.Elements.Add(sceneGrass.CreateElement<MassElement>().Use(new()
			{
				"grass1.png", "grass3.png"
			}).AsSpan(20, scaleMin: 150, scaleMax: 280)
				.WithFloor(xmin: -16, xmax: 16, ymin: -4.5, ymax: -4)
				.FromVaryingLayer().ToFlyOut(6d));
			sceneGrass.Elements.Add(sceneGrass.CreateElement<MassElement>().Use(new()
			{
				"grass2.png"
			}).AsTileSpan(3, scaleMin: 150, scaleMax: 350, tileXMin: 30, tileXMax: 50)
				.WithFloor(xmin: -16, xmax: 16, ymin: -4, ymax: -2)
				.FromVaryingLayer().ToFlyOut(6d));
			sceneGrass.ApplyTo(chart);





			chart.BlurByBeatOutEase(1, 8, 8d, 6d);

			chart.CameraTiltAndDiveTransition(1, 5, 125, 4d, 4d, outEase: AdfEaseType.OutCirc);
			chart.BlurByBeatOutEase(0, 1, 114514, 4d);

			chart.ModernTrackAppear(0, 71, 8d, 8d, 1, 2, 1, 1.5, -5, 10, 105, 120);
			chart.ModernTrackDisappear(0, 71, 8d, -2d, -1, -0.5, -1.5, -0.5, -15, 5, 75, 90);



			// Part Two
#pragma warning disable CA1416 // Validate platform compatibility
			List<int> listOfLineTileEnd = new() { 70, 80, 90, 97, 106 };
			for (int i = 1; i < listOfLineTileEnd.Count; i++)
			{
				chart.ChartTiles[listOfLineTileEnd[i]].TileEvents.Add(new AdfEventRecolorTrack()
				{
					StartTile = new(listOfLineTileEnd[i - 1] + 1, AdfTileReferenceType.Start),
					EndTile = new(-1, AdfTileReferenceType.ThisTile),
					Duration = 0,
					TrackColor = new("FFFFFF"),
					TrackStyle = AdfTrackStyle.Minimal,
					TrackGlowIntensity = 0,
					AngleOffset = -0.001
				});
				chart.ChartTiles[listOfLineTileEnd[i]].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = "quartrond_linetrack_" + i.ToString(),
					Duration = 4d,
					PositionOffset = new(0, -2),
					Opacity = 0,
					Ease = AdfEaseType.OutCirc
				});
			}

			chart.TrackDisappearExplosion(listOfLineTileEnd, 6d, 0.25, yBias: 5, m: 0.3);
			chart.SetLineTrackStyle(71, 80, 50, 130, 100, tag: "quartrond_linetrack_1");
			chart.SetLineTrackStyle(81, 90, 50, 130, 100, tag: "quartrond_linetrack_2");
			chart.SetLineTrackStyle(91, 97, 50, 130, 100, tag: "quartrond_linetrack_3");
			chart.SetLineTrackStyle(98, 106, 50, 130, 100, tag: "quartrond_linetrack_4");
#pragma warning restore CA1416 // Validate platform compatibility

			chart.BlurByBeatOutEase(80, 1, 8d, 6d);
			chart.BlurByBeatOutEase(90, 3, 8d, 6d);

			chart.CameraHoverAndTiltToTileTransition(106, 5, 180, 150, 2d, 4d, 0, 4);
			chart.CameraMoveRelativeToPlayer(106, 4, 0, 4);

			chart.FisheyePulseByBeat(71, 32, 1d, 4d, 49);




			// Part Three
			chart.TrackAppearExplosion(new() { 169, 188 }, 4d, 20d, 100, 500, 0.2); // this is for big track not to appear to soon.
			chart.TrackDisappearExplosion(new() { 169 }, 4d, xBias: 10, yBias: 3, m: 0.5);

			chart.OsuManiaGimmick(104, 169);

			chart.FisheyePulseByBeat(106, 32, 1d, 4d, 48.5);


			// Part Four
			var sceneSpace = factory.CreateScene(170, 266);

			sceneSpace.Elements.Add(sceneSpace.CreateElement<MonoElement>().Use("space.png")
				.AsBackground()
				.WithAutofit(chart)
				.FromFlash(25).ToFlash());
			sceneSpace.Elements.Add(sceneSpace.CreateElement<MassElement>().Use(new()
			{
				"space1.png", "space2.png", "space3.png", "space4.png", "space5.png", "space6.png", "space7.png", "space8.png"
			}).AsSpan(20, -100, 100, -50, 100, 550, 800)
				.FromVaryingLayer(0, 75, -50, 80, -50, 80, 128, 255).ToFlashOut());
			sceneSpace.ApplyTo(chart);

			chart.CameraRotationPulseByTile(Enumerable.Range(170, 201).ToList(), -5, 5, 680, 750, 4d);
			chart.FisheyePulseByTile(Enumerable.Range(170, 201).ToList(), 4d, 48);
			
			
			File.WriteAllText(@"G:\Adofai levels\Next Life\level-vfx.adofai", chart.ChartJson.ToJsonString());
		}

	}
}
