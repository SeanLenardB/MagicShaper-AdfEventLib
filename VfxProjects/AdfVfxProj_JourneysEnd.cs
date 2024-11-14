﻿using MagicShaper.AdfExtensions;
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

			chart.ChartTiles[0].TileEvents.Add(new AdfEventHallOfMirrors() { Enabled = true });

			for (int i = 1; i < chart.ChartTiles.Count; i++)
			{
				bool flag = false;

				foreach (var e in chart.ChartTiles[i].TileEvents)
				{
					if (e is AdfEventSetSpeed se)
					{
						if (Math.Abs(1 - chart.GetTileBpmAt(i) / chart.GetTileBpmAt(i - 1)) >= 0.1)
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

			for (int i = 165; i < 573; i++)
			{
				if (chart.GetInnerAngleAtTile(i) == 120d && chart.GetInnerAngleAtTile(i + 1) == 120d)
				{
					chart.ChartTiles[i].TileEvents.Add(new AdfEventSetFilter()
					{
						Filter = AdfFilter.Grayscale,
						Intensity = 50,
						AngleOffset = -0.001,
						Duration = 0
					});
					chart.ChartTiles[i].TileEvents.Add(new AdfEventSetFilter()
					{
						Filter = AdfFilter.Grayscale,
						Intensity = 25,
						AngleOffset = 0, 
						Duration = 16,
						Ease = AdfEaseType.OutCubic
					});
					chart.ChartTiles[i].TileEvents.Add(new AdfEventSetFilter()
					{
						Filter = AdfFilter.Aberration,
						Intensity = 30,
						AngleOffset = -0.001,
						Duration = 0
					});
					chart.ChartTiles[i].TileEvents.Add(new AdfEventSetFilter()
					{
						Filter = AdfFilter.Aberration,
						Intensity = 48,
						AngleOffset = 0, 
						Duration = 16,
						Ease = AdfEaseType.OutCubic
					});
				}
			}

			chart.AberrationByBeat(972, 14, 64d, 16d, 150);
			chart.BlurByBeatOutEase(972, 14, 64d, 32d, 600);
			chart.CameraRotationPulseByBeats(972, 64d, 14, -30, 30, 150, 350, 32d);
			chart.FilterEventByBeat(972, 14, 64d, 64d, AdfFilter.Fisheye, 45, 48);
			chart.FilterEventByBeat(972, 14, 64d, 48d, AdfFilter.Grayscale, 100, 20);

			

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
			}).AsSpanParallax(15, -40, 40, 16, 23, 800, 1000)
			.FromVaryingLayer(60, 80, 85, 90, 99, 99.9, 20, 85, 180, 180, -50, -30)
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
			.FromVaryingLayer(20, 40, 85, 90, 99, 99.9, 20, 85, 0, 0, -50, -30)
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
			.FromVaryingLayer(20, 40, 85, 90, 99, 99.9, 20, 85, 0, 0, -50, -30)
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
			.FromVaryingLayer(80, 90, 95, 99, 99, 99.9, 90, 185, 0, 0, 50, 70)
			.ToFlashOut());

			var sceneFlyingWares = factory.CreateScene();
			sceneFlyingWares.Elements.Add(sceneFlyingWares.CreateElement<MassElement>().Use(new()
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
			}).AsSpanParallax(120, -30, 30, -40, 40, 300, 800)
			.FromVaryingLayer(50, 80, 85, 95, 95, 98, 0, 255, -180, 180, 10, 40)
			.ToFlashOut());

			var sceneFlyingWares2 = factory.CreateScene();
			sceneFlyingWares2.Elements.Add(sceneFlyingWares2.CreateElement<MassElement>().Use(new()
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
			}).AsSpanParallax(120, -20, 20, -40, 20, 300, 800)
			.FromVaryingLayer(50, 80, 85, 95, 95, 98, 0, 255, -5, 5, 10, 40)
			.WithMovement(-0.5, 0.5, 10, 20, -3, 3, 128, AdfEaseType.OutCubic)
			.ToFlashOut());

			var sceneSnowFloor = factory.CreateScene();
			sceneSnowFloor.Elements.Add(sceneSnowFloor.CreateElement<MonoElement>().Use("snowfloor.png")
				.WithAutofit(chart).AsBackground().FromFlash(60).ToFlash());

			var sceneCosmos = factory.CreateScene();
			sceneCosmos.Elements.Add(sceneCosmos.CreateElement<MonoElement>().Use("space.png")
				.WithAutofit(chart).AsBackground().FromFlash(40).ToFlash());
			sceneCosmos.Elements.Add(sceneCosmos.CreateElement<MassElement>().Use(new()
			{
				"nebula1.png",
				"nebula2.png",
				"nebula3.png",
				"nebula4.png",
				"nebula5.png",
				"nebula6.png",
			}).AsSpanParallax(5, -20, 20, -20, 20, 850, 1500)
			.FromVaryingLayer(10, 30, 95, 98, 98, 99.5, 180, 255, -5, 5, 50, 60)
			.ToFlashOut());


			sceneCrystalCave.ApplyTo(chart, 0, 165);
			sceneFlyingWares.ApplyTo(chart, 0, 165);
			sceneBlackBackSmoke.ApplyTo(chart, 0, 165);


			sceneSnowFloor.ApplyTo(chart, 165, 369);
			sceneWhiteForeSmoke.ApplyTo(chart, 165, 3068);

			sceneFlyingWares2.ApplyTo(chart, 267, 369);
			sceneCrystalCave.ApplyTo(chart, 369, 950);
			sceneFlyingWares.ApplyTo(chart, 369, 950);

			sceneBlackBackSmoke.ApplyTo(chart, 573, 634);

			sceneCosmos.ApplyTo(chart, 950, 2108);


			chart.ModernTrackAppear(0, 165, 4d, 4d, -1.5, 1.5, 0.5, 1.5, -30, 30, 75, 80);
			chart.ModernTrackDisappear(0, 165, 4d, 0d, -1, 1, -1, -0.5, -45, 45, 75, 90);

			chart.ModernTrackAppear(165, 573, 4d, 4d, 1, 2, 0.5, 1.5, -15, 45, 50, 80);


			chart.ModernTrackAppear(573, 952, 4d, 4d, -0.5, 0.5, -0.5, -0.2, -3, 3, 60, 80, 45);
			chart.ModernTrackDisappear(573, 952, 4d, 0d, -0.5, 0.5, -0.5, -0.2, -3, 3, 80, 90, 90);

			chart.ModernTrackAppear(952, 2108, 4d, 2d, -1, 1, 0.3, 1, -30, 30, 110, 125, 30, 100);
			chart.ModernTrackDisappear(952, 2108, 4d, -3d, -3, 3, -4, -2, -30, 30, 110, 125, 30);


			 
			chart.MultipleTrack(165, 573, -20, -5, "000000", 90, 210, hideIcons: true);
			chart.MultipleTrack(165, 573, 2, -7, "000000", 95, 120, hideIcons: true);
			chart.MultipleTrack(165, 573, -0.98, -0.0006, "000000FF", 100, 100, 0.001, 0.001, hideIcons: true);




			Random random = new();
			for (int i = 165; i < 573; i++)
			{
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					Duration = chart.GetTileBpmAt(i) / 680 * 4d,
					Opacity = 0,
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile)
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					PositionOffset = new(random.NextDouble() * 0.5 - 1, - random.NextDouble()),
					RotationOffset = random.NextDouble() * 90 - 45,
					Duration = 0,
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = chart.GetTileBpmAt(i) / 680 * (12 * 180)
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					Duration = chart.GetTileBpmAt(i) / 680 * (random.NextDouble() * 12d + 4d),
					RotationOffset = 0,
					Opacity = 50,
					Ease = AdfEaseType.OutBack,
					PositionOffset = new(0, 0),
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = chart.GetTileBpmAt(i) / 680 * (12 * 180 + 0.00001)
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					Duration = chart.GetTileBpmAt(i) / 680 * 4d,
					Ease = AdfEaseType.OutQuad,
					Opacity = 0,
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = chart.GetTileBpmAt(i) / 680 * (30 * 180)
				});
			}



#pragma warning disable CA1416 // Validate platform compatibility
			chart.LyricWithTranslationWithWordByWordAppear("lyric.txt", translationYOffset: -70,
				positionYPixel: -500, inDuration: 4d, outDuration: 2d, scale: 75, translationScale: 45, intervalBeat: 0.5d, xmin: -0.3, xmax: 0.3, ymin: -1.6, ymax: -0.9);
#pragma warning restore CA1416 // Validate platform compatibility


			File.WriteAllText(@"G:\Adofai levels\JourneysEnd\level-effect.adofai", chart.ChartJson.ToJsonString());
		}
	}
}
