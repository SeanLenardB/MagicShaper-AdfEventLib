using MagicShaper.AdfExtensions;
using MagicShaper.AdfExtensions.DecoScene;
using MagicShaper.AdfExtensions.Gimmicks;
using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

			chart.AberrationByBeat(972, 14, 64d, 16d, 20);
			chart.BlurByBeatOutEase(972, 14, 64d, 32d, 600);
			chart.CameraRotationPulseByBeats(972, 64d, 14, -30, 30, 150, 350, 32d);
			chart.FilterEventByBeat(972, 14, 64d, 64d, AdfFilter.Fisheye, 45, 48);
			chart.FilterEventByBeat(972, 14, 64d, 48d, AdfFilter.Grayscale, 100, 20);

			chart.AberrationByBeat(1685, 14, 16d, 4d, 20);
			chart.BlurByBeatOutEase(1685, 14, 16d, 8d, 600);
			chart.CameraRotationPulseByBeats(1685, 16d, 14, -30, 30, 150, 350, 8d);
			chart.FilterEventByBeat(1685, 14, 16d, 16d, AdfFilter.Fisheye, 45, 48);
			chart.FilterEventByBeat(1685, 14, 16d, 12d, AdfFilter.Grayscale, 100, 20);

			chart.AberrationByBeat(2408, 8, 64d / 2, 16d / 2, 20);
			chart.BlurByBeatOutEase(2408, 8, 64d / 2, 32d / 2, 600);
			chart.CameraRotationPulseByBeats(2408, 64d / 2, 8, -30, 30, 150, 350, 32d / 2 * 2);
			chart.FilterEventByBeat(2408, 8, 64d / 2, 64d / 2, AdfFilter.Fisheye, 45, 48);
			chart.FilterEventByBeat(2408, 8, 64d / 2, 48d / 2, AdfFilter.Grayscale, 100, 20);

			chart.AberrationByBeat(2722, 12, 64d / 4, 16d / 4, 20);
			chart.BlurByBeatOutEase(2722, 12, 64d / 4, 32d / 4, 600);
			chart.CameraRotationPulseByBeats(2722, 64d / 4, 12, -10, 10, 150, 350, 32d / 4 * 2);
			chart.FilterEventByBeat(2722, 12, 64d / 4, 64d / 4, AdfFilter.Fisheye, 45, 48);
			chart.FilterEventByBeat(2722, 12, 64d / 4, 48d / 4, AdfFilter.Grayscale, 100, 20);

			chart.AberrationByBeat(2990, 3, 1.5d, 16d / 8, 20);
			chart.BlurByBeatOutEase(2990, 3, 1.5d, 32d / 8, 600);
			chart.CameraRotationPulseByBeats(2990, 1.5d, 3, -10, 10, 150, 350, 32d / 8 * 2);
			chart.FilterEventByBeat(2990, 3, 1.5d, 1.5d, AdfFilter.Fisheye, 45, 48);
			chart.FilterEventByBeat(2990, 3, 1.5d, 48d / 8, AdfFilter.Grayscale, 100, 20);



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
			}).AsSpanParallax(25, -45, -12, -20, -10, 800, 1000)
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
			}).AsSpanParallax(25, 12, 45, -20, -10, 800, 1000)
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
			}).AsSpanParallax(5, -20, 20, -20, 20, 850, 1500)
			.FromVaryingLayer(10, 50, 95, 98, 98, 99.5, 180, 255, -5, 5, 50, 60)
			.ToFlashOut());
			sceneCosmos.Elements.Add(sceneCosmos.CreateElement<MonoElement>().Use("gemlight.png").AsForeground(5, false, false)
				.WithScale(600).WithParallax(97.7, 99.7).WithParallaxOffset(0, 2)
				.FromFlash(30).ToFlash());
			sceneCosmos.Elements.Add(sceneCosmos.CreateElement<MonoElement>().Use("nebula6.png").AsForeground(11, false, false)
				.WithScale(200).WithParallax(98.7, 99.7).WithParallaxOffset(0.2, 2)
				.FromFlash(60).ToFlash());
			sceneCosmos.Elements.Add(sceneCosmos.CreateElement<MonoElement>().Use("wave.png").AsForeground(13, false, false)
				.WithScale(1).WithParallax(98.7, 99.7).WithParallaxOffset(0, 2)
				.FromFlash(100).ToFlash());
			sceneCosmos.Elements.Add(sceneCosmos.CreateElement<MonoElement>().Use("gemc.png").AsForeground(9, false, false)
				.WithScale(57.5).WithParallax(98.8, 99.8).WithParallaxOffset(0, 2)
				.FromFlash(80).ToFlash());
			sceneCosmos.Elements.Add(sceneCosmos.CreateElement<MonoElement>().Use("gem.png").AsForeground(10, false, false)
				.WithScale(60).WithParallax(99, 99.9).WithParallaxOffset(0, 2)
				.FromFlash(50).ToFlash());

			var sceneFinal = factory.CreateScene();
			sceneFinal.Elements.Add(sceneFinal.CreateElement<MonoElement>().Use("gemlight.png").AsForeground(5, false, false)
				.WithScale(600).WithParallax(97.7, 99.7).WithParallaxOffset(0, 2)
				.FromFlash(30));
			sceneFinal.Elements.Add(sceneFinal.CreateElement<MonoElement>().Use("wave.png").AsForeground(13, false, false)
				.WithScale(1).WithParallax(98.7, 99.7).WithParallaxOffset(0, 2)
				.FromFlash(100));
			sceneFinal.Elements.Add(sceneFinal.CreateElement<MonoElement>().Use("gemc.png").AsForeground(9, false, false)
				.WithScale(57.5).WithParallax(98.8, 99.8).WithParallaxOffset(0, 2)
				.FromFlash(80));
			sceneFinal.Elements.Add(sceneFinal.CreateElement<MonoElement>().Use("gem.png").AsForeground(10, false, false)
				.WithScale(60).WithParallax(99, 99.9).WithParallaxOffset(0, 2)
				.FromFlash(50));




			sceneCrystalCave.ApplyTo(chart, 0, 165);
			sceneFlyingWares.ApplyTo(chart, 0, 165);
			sceneBlackBackSmoke.ApplyTo(chart, 0, 165);


			sceneSnowFloor.ApplyTo(chart, 165, 369);
			sceneWhiteForeSmoke.ApplyTo(chart, 165, 3068);

			sceneFlyingWares2.ApplyTo(chart, 267, 369);
			sceneCrystalCave.ApplyTo(chart, 369, 950);
			sceneFlyingWares.ApplyTo(chart, 369, 950);

			sceneBlackBackSmoke.ApplyTo(chart, 573, 634);

			string gemSceneAId = sceneCosmos.ApplyTo(chart, 950, 2108);

			sceneCrystalCave.ApplyTo(chart, 2108, 2390);
			sceneFlyingWares.ApplyTo(chart, 2108, 2390);
			sceneBlackBackSmoke.ApplyTo(chart, 2108, 2142);

			sceneBlackBackSmoke.ApplyTo(chart, 2274, 2302);

			string gemSceneAId2 = sceneCosmos.ApplyTo(chart, 2390, 2995);
			sceneBlackBackSmoke.ApplyTo(chart, 2390, 2995);
			sceneFlyingWares.ApplyTo(chart, 2390, 2995);


			sceneCrystalCave.ApplyTo(chart, 2995, 3068);
			sceneFlyingWares.ApplyTo(chart, 2995, 3068);
			sceneBlackBackSmoke.ApplyTo(chart, 2995, 3068);
			sceneFinal.ApplyTo(chart, 2995, 3068);




			chart.ModernTrackAppear(0, 165, 4d, 4d, -1.5, 1.5, 0.5, 1.5, -30, 30, 75, 80);
			chart.ModernTrackDisappear(0, 165, 4d, 0d, -1, 1, -1, -0.5, -45, 45, 75, 90);

			chart.ModernTrackAppear(165, 573, 4d, 4d, 1, 2, 0.5, 1.5, -15, 45, 50, 80);


			chart.ModernTrackAppear(573, 952, 4d, 4d, -0.5, 0.5, -0.5, -0.2, -3, 3, 60, 80, 45);
			chart.ModernTrackDisappear(573, 952, 4d, 0d, -0.5, 0.5, -0.5, -0.2, -3, 3, 80, 90, 90);


			chart.ModernTrackAppear(2108, 2365, 4d, 4d, -1.5, 1.5, 0.5, 1.5, -30, 30, 75, 80);
			chart.ModernTrackDisappear(2108, 2365, 4d, 0d, -1, 1, -1, -0.5, -45, 45, 75, 90);

			chart.ModernTrackAppear(2996, 3069, 4d, 4d, -1.5, 1.5, 0.5, 1.5, -30, 30, 75, 80);
			chart.ModernTrackDisappear(2996, 3069, 4d, 0d, -1, 1, -1, -0.5, -45, 45, 75, 90);



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
					PositionOffset = new(random.NextDouble() * 0.5 - 1, -random.NextDouble()),
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

			for (int i = 952; i < 2108; i++)
			{
				double bpmMultiplier = chart.GetTileBpmAt(i) / chart.GetTileBpmAt(0);
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = -114514,
					Duration = 0,
					Scale = new(61.8),
					Opacity = 15
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = -180 * bpmMultiplier * 3,
					Duration = 1 * bpmMultiplier,
					Opacity = 150,
					Scale = new(100),
					Ease = AdfEaseType.OutElastic
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventRecolorTrack()
				{
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = 0,
					Duration = 0,
					TrackColor = new("3aceffff"),
					SecondaryTrackColor = new("0093c3ff"),
					TrackStyle = AdfTrackStyle.NeonLight,
					TrackGlowIntensity = 0,
					TrackColorAnimDuration = 1,
					TrackColorPulse = AdfTrackColorPulseType.Forward,
					TrackPulseLength = 55,
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = -0.001,
					Duration = 0,
					Opacity = 300,
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = 0,
					Duration = 4 * bpmMultiplier,
					Opacity = 30,
					Ease = AdfEaseType.OutCirc
				});
			}

			for (int i = 2365; i < 2996; i++)
			{
				double bpmMultiplier = chart.GetTileBpmAt(i) / chart.GetTileBpmAt(0);
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = -114514,
					Duration = 0,
					Scale = new(61.8),
					Opacity = 15
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = -180 * bpmMultiplier * 3,
					Duration = 1 * bpmMultiplier,
					Opacity = 150,
					Scale = new(100),
					Ease = AdfEaseType.OutElastic
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventRecolorTrack()
				{
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = 0,
					Duration = 0,
					TrackColor = new("3aceffff"),
					SecondaryTrackColor = new("0093c3ff"),
					TrackStyle = AdfTrackStyle.NeonLight,
					TrackGlowIntensity = 0,
					TrackColorAnimDuration = 1,
					TrackColorPulse = AdfTrackColorPulseType.Forward,
					TrackPulseLength = 55,
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = -0.001,
					Duration = 0,
					Opacity = 300,
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = 0,
					Duration = 4 * bpmMultiplier,
					Opacity = 30,
					Ease = AdfEaseType.OutCirc
				});
			}




			string gemTag = (sceneCosmos.Elements[^2] as MonoElement)!.Tag().Replace("{replaceme}", gemSceneAId);
			string gemWaveTag = (sceneCosmos.Elements[^3] as MonoElement)!.Tag().Replace("{replaceme}", gemSceneAId);

			string gemTag2 = (sceneCosmos.Elements[^2] as MonoElement)!.Tag().Replace("{replaceme}", gemSceneAId2);
			string gemWaveTag2 = (sceneCosmos.Elements[^3] as MonoElement)!.Tag().Replace("{replaceme}", gemSceneAId2);

			for (int i = 0; i < 30; i++)
			{
				if (i == 15 || i == 14) { continue; }
				chart.ChartTiles[972].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = gemWaveTag,
					Duration = 0,
					AngleOffset = -0.001 + 64 * 180 * i,
					Opacity = 500,
					Scale = new(1)
				});
				chart.ChartTiles[972].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = gemWaveTag,
					Duration = 32d,
					AngleOffset = 64 * 180 * i,
					Opacity = 0,
					Ease = AdfEaseType.OutExpo
				});
				chart.ChartTiles[972].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = gemWaveTag,
					Duration = 64d,
					AngleOffset = 64 * 180 * i,
					Scale = new(500),
					Ease = AdfEaseType.OutCirc
				});
				chart.ChartTiles[972].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = gemTag,
					Duration = 0,
					AngleOffset = -0.001 + 64 * 180 * i,
					Opacity = 500,
					Scale = new(75)
				});
				chart.ChartTiles[972].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = gemTag,
					Duration = 64d,
					AngleOffset = 64 * 180 * i,
					Scale = new(57.5),
					Opacity = 80,
					Ease = AdfEaseType.OutExpo
				});
			}



			for (int i = 0; i < 8; i++)
			{
				chart.ChartTiles[2407].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = gemWaveTag2,
					Duration = 0,
					AngleOffset = -0.001 + 32 * 180 * i,
					Opacity = 500,
					Scale = new(1)
				});
				chart.ChartTiles[2407].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = gemWaveTag2,
					Duration = 16,
					AngleOffset = 32 * 180 * i,
					Opacity = 0,
					Ease = AdfEaseType.OutExpo
				});
				chart.ChartTiles[2407].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = gemWaveTag2,
					Duration = 32,
					AngleOffset = 32 * 180 * i,
					Scale = new(500),
					Ease = AdfEaseType.OutCirc
				});
				chart.ChartTiles[2407].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = gemTag2,
					Duration = 0,
					AngleOffset = -0.001 + 32 * 180 * i,
					Opacity = 500,
					Scale = new(75)
				});
				chart.ChartTiles[2407].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = gemTag2,
					Duration = 32,
					AngleOffset = 32 * 180 * i,
					Scale = new(57.5),
					Opacity = 80,
					Ease = AdfEaseType.OutExpo
				});
			}
			
			for (int i = 0; i < 12; i++)
			{
				chart.ChartTiles[2722].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = gemWaveTag2,
					Duration = 0,
					AngleOffset = -0.001 + 16 * 180 * i,
					Opacity = 500,
					Scale = new(1)
				});
				chart.ChartTiles[2722].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = gemWaveTag2,
					Duration = 8,
					AngleOffset = 16 * 180 * i,
					Opacity = 0,
					Ease = AdfEaseType.OutExpo
				});
				chart.ChartTiles[2722].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = gemWaveTag2,
					Duration = 16,
					AngleOffset = 16 * 180 * i,
					Scale = new(500),
					Ease = AdfEaseType.OutCirc
				});
				chart.ChartTiles[2722].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = gemTag2,
					Duration = 0,
					AngleOffset = -0.001 + 16 * 180 * i,
					Opacity = 500,
					Scale = new(75)
				});
				chart.ChartTiles[2722].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = gemTag2,
					Duration = 16,
					AngleOffset = 16 * 180 * i,
					Scale = new(57.5),
					Opacity = 80,
					Ease = AdfEaseType.OutExpo
				});
			}

			for (int i = 0; i < 3; i++)
			{
				chart.ChartTiles[2990].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = gemWaveTag2,
					Duration = 0,
					AngleOffset = -0.001 + 1.5d * 180 * i,
					Opacity = 500,
					Scale = new(1)
				});
				chart.ChartTiles[2990].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = gemWaveTag2,
					Duration = 2d,
					AngleOffset = 1.5d * 180 * i,
					Opacity = 0,
					Ease = AdfEaseType.OutExpo
				});
				chart.ChartTiles[2990].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = gemWaveTag2,
					Duration = 4d,
					AngleOffset = 1.5d * 180 * i,
					Scale = new(500),
					Ease = AdfEaseType.OutCirc
				});
				chart.ChartTiles[2990].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = gemTag2,
					Duration = 0,
					AngleOffset = -0.001 + 1.5d * 180 * i,
					Opacity = 500,
					Scale = new(75)
				});
				chart.ChartTiles[2990].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = gemTag2,
					Duration = 4d,
					AngleOffset = 1.5d * 180 * i,
					Scale = new(57.5),
					Opacity = 80,
					Ease = AdfEaseType.OutExpo
				});
			}




#pragma warning disable CA1416 // Validate platform compatibility
			chart.LyricWithTranslationWithWordByWordAppear("lyric.txt", translationYOffset: -70,
				positionYPixel: -500, inDuration: 4d, outDuration: 2d, scale: 75, translationScale: 45, intervalBeat: 0.5d, xmin: -0.3, xmax: 0.3, ymin: -1.6, ymax: -0.9);
			chart.RenderCreditRoleAndName(3068, "Chart", "NanoCRotor", -700, -200, 4, 4, 128);
			chart.RenderCreditRoleAndName(3068, "Visual", "quartrond", 700, -200, 4, 4, 128);
#pragma warning restore CA1416 // Validate platform compatibility


			File.WriteAllText(@"G:\Adofai levels\JourneysEnd\level-effect.adofai", chart.ChartJson.ToJsonString());
		}
	}
}
