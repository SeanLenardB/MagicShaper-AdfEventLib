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
	public class AdfVfxProj_CollapsingStar
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\CollapsingStar\CollapsingStar\level-loweffect.adofai");

			chart.SetupVisionLimit();
			chart.SetVisionLimitAutofit("banner.png", 0);

			DecoScene.DecoSceneFactory factory = new();



			var sceneSmoke = factory.CreateScene();

			sceneSmoke.Elements.Add(sceneSmoke.CreateElement<MassElement>().Use(new()
			{
				"smoke1.png", "smoke2.png"
			}).AsTiled(5, 150, 250, -250, 250, -500, 0, scaleMin: 850, scaleMax: 1200)
				.WithMovement(40, 200, 350, 510, duration: 1024d)
				.FromVaryingLayer(20, 50, rgbMin: 140, rgbMax: 255, depthMin: 25500, depthMax: 25501).ToFlashOut());



			var sceneVolcano = factory.CreateScene();

			sceneVolcano.Elements.Add(sceneVolcano.CreateElement<MonoElement>().Use("volcano.png").AsBackground()
				.WithAutofit(chart).FromFlash(20).ToFlash());

			sceneVolcano.Elements.Add(sceneVolcano.CreateElement<MassElement>().Use(new() { "volcano1.png", "volcano2.png", "volcano3.png", "volcano4.png" })
				.AsSpan(3, -200, 200, -120, -90, 800, 1200).WithVaryingDepth(5, 10)
				.FromVaryingLayer(20, 50, 90, 100, 95, 100, 225, 255).ToFlashOut());

			sceneVolcano.Elements.Add(sceneVolcano.CreateElement<MassElement>().Use(new()
			{
				"shard1.png", "shard2.png", "shard3.png", "shard4.png", "shard5.png", "shard6.png", "shard7.png", "shard8.png"
			}).AsSpan(70, -300, 300, -400, 400, 30, 300)
			.WithMovement(-20, 20, 100, 150, -100, 100, 64d)
			.WithFlashingOnBeat(0.618, durationInterval: 2)
			.FromVaryingLayer(0, 75, rgbMin: 0, rgbMax: 0).ToFlashOut());

			sceneVolcano.ApplyTo(chart, 1, 235);

			chart.CameraTiltAndDiveTransition(1, 35, 250, 4, 8);
			chart.ModernTrackAppear(0, 235, 4d, 2d, ymin: 5, ymax: 10, endOpacity: 500, endScale: 90);
			chart.ModernTrackDisappear(0, 235, 4d, 1d, ymin: 2, ymax: 5, smin: 150);

			for (int i = 0; i < chart.ChartTiles.Count - 1; i++)
			{
				int flag = 0;
				foreach (var e in chart.ChartTiles[i].TileEvents)
				{
					if (e is AdfEventSetSpeed se)
					{
						if (Math.Abs(se.BpmMultiplier - 1) < 0.1) { break; }
						flag = se.BpmMultiplier > 1 ? 1 : 2; break;
					}
				}

				if (flag > 0)
				{
					chart.ChartTiles[i].TileEvents.Add(new AdfEventRecolorTrack()
					{
						TrackColor = new("FFFFFF"),
						SecondaryTrackColor = new(flag == 1 ? "FF00000" : "0000FF"),
						TrackGlowIntensity = 0,
						TrackColorPulse = AdfTrackColorPulseType.Forward,
						TrackColorAnimDuration = .2d,
						TrackPulseLength = 15,
						TrackStyle = AdfTrackStyle.NeonLight,
						TrackColorType = AdfTrackColorType.Glow,
						AngleOffset = -114514
					});
				}
			}

			chart.CameraRotationPulseByTile(new() { 32, 34, 37, 39, 42, 44, 47, 49, 52, 55, 58, 60 },
				-5, 5, 220, 250, 2d);

			chart.CameraRotationPulseByBeats(62, 8d, 16,
				-8, 8, 200, 250, 16d);


			chart.MultipleTrack(235, 579, 10, -9, "AAAAAA", 90, 200, 80, 80, AdfTrackStyle.Neon);
			chart.MultipleTrack(235, 579, -9, -2, "FFFFFF", 80, 200, 50, 70, AdfTrackStyle.Neon);
			chart.MultipleTrack(235, 579, -1, -4, "666666", 30, 200, -10, -30, AdfTrackStyle.Neon);
			chart.MultipleTrack(235, 579, 8, -1, "999999", 50, 200, 50, 60, AdfTrackStyle.Neon);

			chart.MultipleTrack(235, 579, -0.8, -0.1, "FFFFFF", 30, 100, 0.0001, 0.0001, AdfTrackStyle.Minimal);

			chart.ModernTrackAppear(235, 579, 4d, 2d, 5, 7, 2, 3, -30, -15, 120, 145, endOpacity: 500);
			Random random = new();
			for (int i = 235; i < 579; i++)
			{
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					Duration = chart.GetTileBpmAt(i) / 340 * 4d,
					Opacity = 0,
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile)
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					PositionOffset = new(random.NextDouble() * 10 - 5, random.NextDouble() * 2),
					RotationOffset = random.NextDouble() * 45 - 45,
					Opacity = 100,
					Duration = 0,
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = chart.GetTileBpmAt(i) / 340 * (6 * 180)
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventRecolorTrack()
				{
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					TrackColor = new("FFABAB"),
					TrackGlowIntensity = 0,
					TrackStyle = AdfTrackStyle.NeonLight,
					AngleOffset = chart.GetTileBpmAt(i) / 340 * (6 * 180 + 0.00001)
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					Duration = chart.GetTileBpmAt(i) / 340 * (random.NextDouble() * 6d + 4d),
					RotationOffset = 0,
					Opacity = 250,
					Ease = AdfEaseType.OutBack,
					PositionOffset = new(0, 0),
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = chart.GetTileBpmAt(i) / 340 * (6 * 180 + 0.00001)
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					Duration = chart.GetTileBpmAt(i) / 340 * 4d,
					Ease = AdfEaseType.OutQuad,
					Opacity = 0,
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = chart.GetTileBpmAt(i) / 340 * (12 * 180)
				});
			}

			chart.AberrationByTile(Enumerable.Range(237, 721 - 237).Where(i => chart.GetInnerAngleAtTile(i) == 30).ToList(), 8d, 45);
			chart.FisheyePulseByTile(Enumerable.Range(237, 721 - 237).Where(i => chart.GetInnerAngleAtTile(i) == 30).ToList(), 6d, 48.5);

			chart.CameraRotationPulseByBeats(411, 4d, 6, -15, 15, 140, 200, 4d);

			chart.CameraRotationPulseByTile(Enumerable.Range(435, 721 - 435)
				.Where(i => chart.GetInnerAngleAtTile(i) <= 90 && (i < 484 || i > 494)).ToList(),
				-7, 7, 150, 200, 4d);






			var sceneCave = factory.CreateScene();

			sceneCave.Elements.Add(sceneCave.CreateElement<MonoElement>().Use("cave.png").AsBackground()
				.WithAutofit(chart).FromFlash(20).ToFlash());

			sceneCave.ApplyTo(chart, 235, 962);
			sceneSmoke.ApplyTo(chart, 235, 962);
	



#pragma warning disable CA1416 // Validate platform compatibility
			chart.SetLineTrackStyle(579, 611, 50, 130, hideLineAtEnd: true, tag: "WCNMNMSL1");
			chart.SetLineTrackStyle(619, 658, 50, 130, hideLineAtEnd: true, tag: "WCNMNMSL2");
			chart.SetLineTrackStyle(660, 692, 50, 130, hideLineAtEnd: true, tag: "WCNMNMSL3");
			chart.SetLineTrackStyle(700, 729, 50, 130, hideLineAtEnd: true, tag: "WCNMNMSL4");
#pragma warning restore CA1416 // Validate platform compatibility

			chart.FloatingTrackBackground(579, 128, "000000", 514, 50, 200,
				0.6, 1.5, 80, 100, -150, 150, -150, -10);



			sceneCave.ApplyTo(chart, 1, 729);






			var sceneForest = factory.CreateScene();

			sceneForest.Elements.Add(sceneForest.CreateElement<MonoElement>().Use("forest.png")
				.AsBackground().WithAutofit(chart).FromFlash(50).ToFlash());

			sceneForest.ApplyTo(chart, 729, 1080);

			var sceneGrass = factory.CreateScene();
			sceneGrass.Elements.Add(sceneGrass.CreateElement<MassElement>().Use(new()
						{
							"grass1.png", "grass3.png"
						}).AsSpan(20, scaleMin: 150, scaleMax: 280)
				.WithFloor(xmin: -16, xmax: 16, ymin: -6.5, ymax: -5)
				.FromVaryingLayer().ToFlashOut());
			sceneGrass.Elements.Add(sceneGrass.CreateElement<MassElement>().Use(new()
						{
							"grass2.png"
						}).AsTileSpan(3, scaleMin: 150, scaleMax: 350, tileXMin: 30, tileXMax: 50)
				.WithFloor(xmin: -16, xmax: 16, ymin: -6, ymax: -4)
				.FromVaryingLayer().ToFlashOut());
			sceneGrass.ApplyTo(chart, 729, 1080);

			var sceneTrees = factory.CreateScene();

			sceneTrees.Elements.Add(sceneTrees.CreateElement<MassElement>().Use(new()
			{
				"tree1.png", "tree2.png", "tree3.png", "tree4.png", "tree5.png"
			}).AsSpan(10, scaleMin: 720, scaleMax: 900)
			.WithFloor(xmin: -80, xmax: 80, ymin: -80, ymax: -45)
			.FromVaryingLayer().ToFlashOut());

			sceneTrees.ApplyTo(chart, 729, 814);



			var sceneGallopTrees = factory.CreateScene();
			sceneGallopTrees.Elements.Add(sceneGallopTrees.CreateElement<MassElement>().Use(new()
			{
				"tree1.png", "tree2.png", "tree3.png", "tree4.png", "tree5.png"
			}).AsSpan(60, scaleMin: 520, scaleMax: 800)
			.WithFloor(xmin: -40, xmax: 200, ymin: -6, ymax: -2, parallaxXMin: -50, parallaxXMax: 50)
			.FromVaryingLayer().ToFlashOut());

			sceneGallopTrees.ApplyTo(chart, 814, 962);


			chart.ModernTrackAppear(729, 814, 4d, 4d, -2, 2, -2, 2, -30, 30, 50, 75, 75, 100, 90);
			chart.ModernTrackDisappear(729, 814, 4d, 0d, -2, 2, -2, 2, -30, 30, 50, 75, 75);

#pragma warning disable CA1416 // Validate platform compatibility
			chart.LyricWithTranslation("text.txt", "Lingo", inDuration: 0.5, outDuration: 0.5, depthOffset: -10, scale: 80);
#pragma warning restore CA1416 // Validate platform compatibility


			chart.ModernTrackAppear(814, 963, 8d, 4d, 3, 5, 2, 4, endOpacity: 200);
			chart.ModernTrackDisappear(814, 963, 8d, 0d, -6, -4, 1.5, -1.5);

			sceneTrees.ApplyTo(chart, 962, 1080);

			chart.OsuManiaGimmick(963, 1012, 4, positionX: 10, positionY: -5, dropSpeedTilePerBeat: 5);
			chart.ShapeFocusOnTile("cue.png", "wave.png", 757, 2d, 4d);
			chart.ShapeFocusOnTile("cue.png", "wave.png", 767, 2d, 4d);
			chart.ShapeFocusOnTile("cue.png", "wave.png", 779, 2d, 4d);
			chart.ShapeFocusOnTile("cue.png", "wave.png", 789, 2d, 4d);

#pragma warning disable CA1416 // Validate platform compatibility
			chart.LyricWithTranslation("bpmchange.txt", positionYPixel: 1000, scale: 250);
#pragma warning restore CA1416 // Validate platform compatibility

			chart.ModernTrackAppear(1006, 1080, 4d, 4d, -2, 2, -2, 2, -30, 30, 50, 75, 50, 90);
			chart.ModernTrackDisappear(1006, 1080, 4d, 0d, -2, 2, -2, 2, -30, 30, 50, 75, 75);

			sceneCave.ApplyTo(chart, 1080, 3048);
			sceneSmoke.ApplyTo(chart, 1080, 3048);
			sceneVolcano.ApplyTo(chart, 1080, 3048);

			for (int i = 2038; i < 2711; i++)
			{
				if (chart.GetInnerAngleAtTile(i) <= 90d && chart.GetInnerAngleAtTile(i) > 5d)
				{
					chart.ChartTiles[i].TileEvents.Add(new AdfEventAddObject()
					{
						TrackColor = new("FFAAAA"),
						TrackStyle = AdfTrackStyle.Minimal,
						ObjectType = AdfObjectType.Floor,
						Tag = $"CNM_{i}",
						RelativeTo = AdfMoveDecorationRelativeToType.Tile,
						Floor = i,
						TrackGlowColor = new("FFFFFF"),
						TrackGlowEnabled = true,
						TrackOpacity = 0
					});
					chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Scale = new(11451d, 200d),
						PositionOffset = new(0, -1),
						Duration = 0d,
						Opacity = 100,
						AngleOffset = -0.001d,
						Tag = $"CNM_{i}"
					});
					chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Opacity = 0,
						Duration = 8d,
						Tag = $"CNM_{i}"
					});
					i++;
				}
			}
			chart.TrackAppearExplosion(Enumerable.Range(1152, 2711 - 1152)
				.Where(i => chart.GetInnerAngleAtTile(i) <= 90).ToList(), 4d, 0d, m: 0.3d, endOpacity: 191.981);
			chart.TrackDisappearExplosion(Enumerable.Range(1152, 2711 - 1152)
				.Where(i => chart.GetInnerAngleAtTile(i) <= 90).ToList(), 4d, 1d, yBias: -2);
			chart.ModernTrackAppear(2711, 3048, 4d, 2d, -2, 2, 1, 2, angleOffsetVariationProportion: 50);
			chart.ModernTrackDisappear(2711, 3048, 4d, -2d, -2, 2, 1, 2, angleOffsetVariationProportion: 50);
			chart.CameraRotationPulseByBeats(1152, 4d, 256,
				-3, 3, 300, 320, 16d);
			chart.AberrationByBeat(1152, 256, 4d, 16d, 42);

			chart.FloatingTrackBackground(2724, 256d, "000000FF", 150, 150, 300, 0, 0, 0, 0, -180, 180, -180, 350, 50, 100, 50, 80);

			chart.CameraRotationPulseByTile(Enumerable.Range(2724, 3022 - 2724)
				.Where(i => chart.GetInnerAngleAtTile(i) <= 90 && chart.GetInnerAngleAtTile(i + 2) > 90).ToList(),
				-7, 7, 170, 220, 8d);



			chart.ModernTrackAppear(3048, 3156, 4d, 4d, -2, 2, -2, 2, -30, 30, 50, 75, 75, 100, 90);
			chart.ModernTrackDisappear(3048, 3156, 4d, 0d, -2, 2, -2, 2, -30, 30, 50, 75, 75);

			chart.CameraTiltAndDiveTransition(3048, 15, 250, 4d, 8d);

			var sceneNight = factory.CreateScene();

			sceneNight.Elements.Add(sceneNight.CreateElement<MonoElement>().Use("night.png")
				.AsBackground().WithAutofit(chart).FromFlash().ToFlash());




			var sceneGrassTwo = factory.CreateScene();
			sceneGrassTwo.Elements.Add(sceneGrassTwo.CreateElement<MassElement>().Use(new()
				{
					"grass1.png", "grass3.png"
				}).AsSpan(20, scaleMin: 150, scaleMax: 280)
				.WithFloor(xmin: -16, xmax: 16, ymin: -5.5, ymax: -4)
				.FromVaryingLayer().ToFlashOut());
			sceneGrassTwo.Elements.Add(sceneGrassTwo.CreateElement<MassElement>().Use(new()
				{
					"grass2.png"
				}).AsTileSpan(3, scaleMin: 150, scaleMax: 350, tileXMin: 30, tileXMax: 50)
				.WithFloor(xmin: -16, xmax: 16, ymin: -4, ymax: -3)
				.FromVaryingLayer().ToFlashOut());

			var sceneTreesTwo = factory.CreateScene();
			sceneTreesTwo.Elements.Add(sceneTreesTwo.CreateElement<MassElement>().Use(new()
				{
					"tree1.png", "tree2.png", "tree3.png", "tree4.png", "tree5.png"
				}).AsSpan(10, scaleMin: 720, scaleMax: 900)
				.WithFloor(xmin: -60, xmax: 60, ymin: -10, ymax: -5)
				.FromVaryingLayer().ToFlashOut());


			sceneNight.ApplyTo(chart, 3048, 3156);
			sceneTreesTwo.ApplyTo(chart, 3048, 3156);
			sceneGrassTwo.ApplyTo(chart, 3048, 3156);
			sceneSmoke.ApplyTo(chart, 3048, 3156);

			chart.CameraTiltAndDiveTransition(3158, 10, 350, 16d, 16d);



			var sceneVolcanoTwo = factory.CreateScene();

			sceneVolcanoTwo.Elements.Add(sceneVolcanoTwo.CreateElement<MonoElement>().Use("planet.png").AsBackground()
				.WithAutofit(chart).FromFlash(70).ToFlash());
			sceneVolcanoTwo.Elements.Add(sceneVolcanoTwo.CreateElement<MassElement>().Use(new() { "volcano1.png", "volcano2.png", "volcano3.png", "volcano4.png" })
				.AsSpan(3, -200, 200, -120, -90, 800, 1200).WithVaryingDepth(5, 10)
				.FromVaryingLayer(20, 50, 90, 100, 95, 100, 225, 255).ToFlashOut());
			sceneVolcanoTwo.Elements.Add(sceneVolcanoTwo.CreateElement<MassElement>().Use(new()
				{
					"shard1.png", "shard2.png", "shard3.png", "shard4.png", "shard5.png", "shard6.png", "shard7.png", "shard8.png"
				}).AsSpan(200, -100, 800, -400, 800, 250, 700)
			.WithMovement(-20, 20, 100, 150, -100, 100, 2048d)
			.FromVaryingLayer(0, 75, rgbMin: 0, rgbMax: 0).ToFlashOut());

			sceneSmoke.Elements.Add(sceneSmoke.CreateElement<MassElement>().Use(new()
			{
				"smoke1.png", "smoke2.png"
			}).AsTiled(15, 150, 250, -250, 250, -500, 0, scaleMin: 850, scaleMax: 2200)
				.WithMovement(40, 200, 350, 510, duration: 2048d)
				.FromVaryingLayer(40, 80, rgbMin: 40, rgbMax: 160, depthMin: 25500, depthMax: 25501).ToFlashOut());

			sceneVolcanoTwo.ApplyTo(chart, 3156, 4889);
			sceneSmoke.ApplyTo(chart, 3156, 4889);
			chart.TrackAppearExplosion(Enumerable.Range(3156, 4889 - 3156)
				.Where(i => chart.GetInnerAngleAtTile(i) <= 90).ToList(), 4d, 0d, m: 0.3d, endOpacity: 191.981);
			chart.TrackDisappearExplosion(Enumerable.Range(3156, 4889 - 3156)
				.Where(i => chart.GetInnerAngleAtTile(i) <= 90).ToList(), 4d, 1d, yBias: -2);
			chart.CameraRotationPulseByTile(Enumerable.Range(3156, 4889 - 3156)
				.Where(i => chart.GetInnerAngleAtTile(i) <= 90 && chart.GetInnerAngleAtTile(i + 2) > 90).ToList(),
				-4, 4, 320, 350, 8d);


			for (int i = 3156; i < 4889; i++)
			{
				chart.ChartTiles[i].TileEvents.Add(new AdfEventAddObject()
				{
					TrackColor = new("FFAAAA"),
					TrackStyle = AdfTrackStyle.Minimal,
					ObjectType = AdfObjectType.Floor,
					Tag = $"CSMM_{i}",
					RelativeTo = AdfMoveDecorationRelativeToType.Tile,
					Floor = i,
					TrackGlowColor = new("FFFFFF"),
					TrackGlowEnabled = true,
					TrackOpacity = 0
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Scale = new(11451, 500),
					PositionOffset = new(0, -6),
					Duration = 0d,
					Opacity = 100,
					AngleOffset = -0.001d,
					Tag = $"CSMM_{i}"
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Opacity = 0,
					Duration = 32d,
					Tag = $"CSMM_{i}",
					Ease = AdfEaseType.InSine
				});
				i++;
			}


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

			sceneWarehouse.ApplyTo(chart, 4889, 4952);
			sceneWarehouseSmoke.ApplyTo(chart, 4889, 4952);
			sceneWares.ApplyTo(chart, 4889, 4952);

			chart.ModernTrackAppear(4889, 4952, 4d, 2d, -1, 1, -1, -0.5, -10, 10, 75, 95, 50, 80, 95);
			chart.ModernTrackDisappear(4889, 4952, 4d, 4d, -1, 1, 0.5, 1, -10, 10, 75, 95, 50);

#pragma warning disable CA1416 // Validate platform compatibility
			chart.RenderCreditRoleAndName(4952, "Chart", "NanoCRotor", -700, -200);
			chart.RenderCreditRoleAndName(4952, "Visual", "quartrond", 700, -200);
#pragma warning restore CA1416 // Validate platform compatibility

			File.WriteAllText(@"G:\Adofai levels\CollapsingStar\CollapsingStar\level-effect.adofai", chart.ChartJson.ToJsonString());
		}
	}
}
