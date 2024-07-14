using MagicShaper.AdfExtensions;
using MagicShaper.AdfExtensions.DecoScene;
using MagicShaper.AdfExtensions.Gimmicks;
using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
				"smoke1.png", "smoke2.png"
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
				.FromVaryingLayer().ToFlyOut(6d, flyY: -3));
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
			chart.SetLineTrackStyle(71, 80, 50, 130, 180, tag: "quartrond_linetrack_1");
			chart.SetLineTrackStyle(81, 90, 50, 130, 180, tag: "quartrond_linetrack_2");
			chart.SetLineTrackStyle(91, 97, 50, 130, 180, tag: "quartrond_linetrack_3");
			chart.SetLineTrackStyle(98, 106, 50, 130, 180, tag: "quartrond_linetrack_4");
#pragma warning restore CA1416 // Validate platform compatibility

			chart.BlurByBeatOutEase(80, 1, 8d, 6d);
			chart.BlurByBeatOutEase(90, 3, 8d, 6d);

			chart.CameraHoverAndTiltToTileTransition(106, 5, 180, 150, 2d, 4d, 0, 4);
			chart.CameraMoveRelativeToPlayer(106, 4, 0, 4);

			chart.FisheyePulseByBeat(71, 32, 1d, 4d, 49);




			// Part Three
			chart.TrackAppearExplosion(new() { 169, 172 }, 4d, 4d, 100, 500, 0.2); // this is for big track not to appear to soon.
			chart.TrackDisappearExplosion(new() { 169 }, 4d, xBias: 10, yBias: 3, m: 0.5);

			chart.OsuManiaGimmick(104, 169);

			chart.FisheyePulseByBeat(106, 32, 1d, 4d, 48.5);


			// Part Four
			var sceneSpace = factory.CreateScene(170, 266);

			sceneSpace.Elements.Add(sceneSpace.CreateElement<MonoElement>().Use("space.png")
				.AsBackground()
				.WithAutofit(chart)
				.FromFlash(20).ToFlash());
			sceneSpace.Elements.Add(sceneSpace.CreateElement<MassElement>().Use(new()
			{
				"space1.png", "space2.png", "space3.png", "space4.png", "space5.png", "space6.png", "space7.png", "space8.png",
				"space9.png", "space10.png", "space11.png", "space12.png"
			}).AsSpan(25, -110, 60, -160, 80, 250, 1000)
				.WithMovement(10, 30, 30, 80, -90, 90, 64d) // This is for part five as well
				.FromVaryingLayer(40, 90, -80, 80, -80, 80, 32, 255, -180, 180).ToFlashOut());
			sceneSpace.ApplyTo(chart);

			chart.CameraRotationPulseByTile(Enumerable.Range(170, 202 - 170).ToList(), -5, 5, 680, 750, 4d);
			chart.FisheyePulseByTile(Enumerable.Range(170, 202 - 170).ToList(), 4d, 47.5);
			chart.AberrationByTile(Enumerable.Range(170, 202 - 170).ToList(), 4d, 45);

			chart.ModernTrackAppear(172, 203, 4d, 6d, ymin: 5, ymax: 10, smin: 120, smax: 150, angleOffsetVariationProportion: 60, endScale: 500);
			chart.ModernTrackDisappear(172, 203, 4d, 0d, ymin: 5, ymax: 10, smin: 120, smax: 150, angleOffsetVariationProportion: 60);

			var sceneSunraySpace = factory.CreateScene(170, 266);
			sceneSunraySpace.Elements.Add(sceneSunraySpace.CreateElement<MonoElement>().Use("light.png")
				.AsForeground()
				.WithScale(230).WithParallaxOffset(0, -3.5)
				.FromFlash().ToFlash());

			sceneSunraySpace.ApplyTo(chart);



			// Part Five
			double distance = 3d;
			for (int i = 206; i < 265; i++)
			{
				if (chart.ChartTiles[i].TargetAngle != 999)
				{
					chart.ChartTiles[i].TileEvents.Add(new AdfEventRecolorTrack()
					{
						TrackStyle = AdfTrackStyle.Gems,
						TrackColor = new("000000FF"),
						TrackGlowIntensity = 0,
						AngleOffset = -114513
					});
				}
				else
				{
					chart.CameraRotationPulseByTile(new() { i }, -5, 5, 250, 300, 4d);
					chart.FisheyePulseByTile(new() { i }, 4d, 46.5);
					chart.AberrationByTile(new() { i }, 4d, 40);


					double yOffset = 0;
					double xOffset = 0;

					switch (chart.ChartTiles[i - 1].TargetAngle)
					{
						case 0:
							xOffset = distance; break;
						case 90:
							yOffset = distance; break;
						case 180:
							xOffset = -distance; break;
						case 270:
							yOffset = -distance; break;
						default:
                            Console.WriteLine("WTF?"); break;
                    }

					chart.ChartTiles[i].TileEvents.Add(new AdfEventRecolorTrack()
					{
						Duration = 0d,
						TrackStyle = AdfTrackStyle.Minimal,
						TrackColor = new("FFFFFF"),
						AngleOffset = -114518
					});
					chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
					{
						Duration = 0,
						AngleOffset = -114515,
						Opacity = 0,
						Scale = new(100),
						PositionOffset = new(xOffset * 3, yOffset * 3)
					});
					chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
					{
						Duration = 1d,
						AngleOffset = -180 * 4,
						Opacity = 100,
						Ease = AdfEaseType.OutSine
					});
					chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
					{
						Duration = 4d,
						AngleOffset = -180 * 4 - 0.0001,
						PositionOffset = new(0, 0),
					});
					chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
					{
						Duration = 2d,
						AngleOffset = -180 * 4 - 0.0002,
						Scale = new(300),
						Ease = AdfEaseType.OutSine
					});
					chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
					{
						Duration = 1d,
						Opacity = 0,
						PositionOffset = new(xOffset * 0.2, yOffset * 0.2),
						Scale = new(200),
						Ease = AdfEaseType.OutCirc
					});
					chart.ChartTiles[i].TileEvents.Add(new AdfEventRecolorTrack()
					{
						Duration = 0d,
						TrackStyle = AdfTrackStyle.Minimal,
						TrackColor = new("0689CFFF")
					});
				}
			}
			chart.TrackDisappearExplosion(new() { 206 }, 4d, failProof: 3, xBias: 10, yBias: 3, m: 0.5);

			chart.ModernTrackAppear(265, 266, 4d, 2d, ymin: 5, ymax: 10, smin: 120, smax: 150, angleOffsetVariationProportion: 60, endScale: 500);

			chart.CameraHoverAndTiltToTileTransition(206, -5, 300, 180, 2d, 2d);


			// Part Six
			chart.ModernTrackAppear(266, 307, 4d, 3d, ymin: 5, ymax: 10, smin: 120, smax: 150, angleOffsetVariationProportion: 60);
			chart.ModernTrackDisappear(266, 307, 4d, 3d, ymin: 5, ymax: 10, smin: 120, smax: 150, angleOffsetVariationProportion: 60);

			var sceneWarehouse = factory.CreateScene(266, 446);

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
			sceneWarehouse.ApplyTo(chart);

			var sceneWares = factory.CreateScene(266, 445);
			sceneWares.Elements.Add(sceneWares.CreateElement<MassElement>().Use(new()
			{
				"ware1.png", "ware2.png", "ware3.png", "ware4.png", "ware5.png", "ware6.png", "ware7.png", "ware8.png", "ware9.png", "ware10.png", "ware11.png", "ware12.png"
			}).AsSpan(100, -30, 60, -30, 20, scaleMin: 50, scaleMax: 350)
				.WithMovement(-50, -10, 10, 30, -90, 90, 128d)
				.FromVaryingLayer(25, 100, -50, 70, -50, 70, 50, 255, -180, 180)
				.ToFlyOut(16d, 5, 20));
			sceneWares.ApplyTo(chart);
			
			var sceneWarehouseSmoke = factory.CreateScene(266, 445);
			sceneWarehouseSmoke.Elements.Add(sceneWarehouseSmoke.CreateElement<MassElement>().Use(new()
			{
				"smoke1.png", "smoke2.png"
			}).AsTiled(5, 150, 250, -250, 250, -500, 0, scaleMin: 850, scaleMax: 1200)
				.WithMovement(-200, -40, 250, 510, -45, 45, duration: 128d)
				.FromVaryingLayer(rgbMin: 0, rgbMax: 140).ToFlashOut());
			sceneWarehouseSmoke.ApplyTo(chart);

			chart.FloatingTrackBackground(266, 64d, minSize: 75, maxSize: 150, directionMin: 95, directionMax: 125, totalTracks: 50, ymax: 20);

			chart.BlurByBeatOutEase(266, 4, 8d, 4d);

			chart.OsuManiaGimmick(302, 338, 1, 3);


			// Part Seven
			chart.FisheyePulseByBeat(339, 64, 1d, 4d, 48.5);
			chart.AberrationByBeat(339, 64, 1d, 4d, 45);

			chart.CameraHoverAndTiltToTileTransition(377, -5, 220, 120, 2d, 4d, 0, 3);

			chart.ModernTrackAppear(336, 377, 4d, 3d, ymin: 5, ymax: 10, smin: 120, smax: 150, angleOffsetVariationProportion: 60);
			chart.ModernTrackDisappear(336, 440, 4d, 3d, ymin: 5, ymax: 10, smin: 120, smax: 150, angleOffsetVariationProportion: 60);

			chart.OsuManiaGimmick(375, 444, 16, 4, 10, 0.618, 0);


			// Part Eight
			var sceneSnowMountain = factory.CreateScene(446, 515);
			sceneSnowMountain.Elements.Add(sceneSnowMountain.CreateElement<MonoElement>().Use("snow.png")
				.AsBackground()
				.WithAutofit(chart)
				.FromFlash(40).ToFlash());
			sceneSnowMountain.Elements.Add(sceneSnowMountain.CreateElement<MassElement>().Use(new()
			{
				"grass1.png", "grass3.png"
			}).AsSpan(20, scaleMin: 150, scaleMax: 280)
				.WithFloor(xmin: -16, xmax: 16, ymin: -7, ymax: -5.5)
				.FromVaryingLayer().ToFlyOut(6d));
			sceneSnowMountain.Elements.Add(sceneSnowMountain.CreateElement<MassElement>().Use(new()
			{
				"grass2.png"
			}).AsTileSpan(3, scaleMin: 320, scaleMax: 450, tileXMin: 30, tileXMax: 50)
				.WithFloor(xmin: -16, xmax: 16, ymin: -7, ymax: -5)
				.FromVaryingLayer().ToFlyOut(6d, flyY: -3));
			sceneSnowMountain.ApplyTo(chart);

			var sceneStar = factory.CreateScene(446, 515);
			sceneStar.Elements.Add(sceneStar.CreateElement<MassElement>().Use(new()
			{ 
				"star1.png", "star2.png", "star3.png" 
			})
				.AsSpan(9, -50, 50, 65, 90, 80, 180)
				.FromVaryingLayer(20, 100, 50, 80, 80, 95, 128, 255, -45, 45)
				.ToFlashOut());
			sceneStar.ApplyTo(chart);

			var sceneCosmic = factory.CreateScene(446, 515);
			sceneCosmic.Elements.Add(sceneCosmic.CreateElement<MonoElement>().Use("cosmic.png")
				.AsForeground()
				.WithPivotOffset(0, 4).WithParallax(100, 96)
				.FromFlash().ToFlash());
			sceneCosmic.ApplyTo(chart);

			//var sceneCosmicSmoke = factory.CreateScene(446, 515);
			//sceneCosmicSmoke.Elements.Add(sceneCosmicSmoke.CreateElement<MassElement>().Use(new()
			//{
			//	"smoke1.png", "smoke2.png"
			//}).AsTiled(5, 150, 250, -250, 250, -500, 0, scaleMin: 850, scaleMax: 1200)
			//	.WithMovement(-200, -40, 250, 510, -45, 45, duration: 128d)
			//	.FromVaryingLayer(rgbMin: 128, rgbMax: 255).ToFlashOut());
			//sceneCosmicSmoke.ApplyTo(chart);



			chart.CameraRotationPulseByTile(Enumerable.Range(447, 457 - 447).ToList(), -3, 3, 180, 220, 3d);

			chart.OsuManiaGimmick(459, 514, 7, 3, 12, 1, 0.18);

			chart.ModernTrackDisappear(459, 514, 8d, 4d, 1, 2, 1, 1.5, -5, 10, 105, 120);

			// lyrics

#pragma warning disable CA1416 // Validate platform compatibility
			chart.LyricWithTranslation("lyric.txt", inDuration: 1, outDuration: 1, scale: 50, depthOffset: -100);
#pragma warning restore CA1416 // Validate platform compatibility

			File.WriteAllText(@"G:\Adofai levels\Next Life\level-vfx.adofai", chart.ChartJson.ToJsonString());
		}

	}
}
