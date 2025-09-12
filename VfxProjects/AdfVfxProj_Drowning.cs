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
	public static class AdfVfxProj_Drowning
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\Drowning\level-base.adofai");
			chart.AddDecorationToChart(new()
			{
				Tag = $"manual-worldmachine manual-worldmachine-speech manual-worldmachine-speech-main",
				Depth = -19500,
				LockRotation = true,
				LockScale = true,
				Position = new(0, 1.5),
				Scale = new(100),
				RelativeTo = AdfMoveDecorationRelativeToType.Camera,
				Opacity = 0d,
				Color = new("FFFFFFFF")
			});
			chart.AddDecorationToChart(new()
			{
				Tag = $"manual-worldmachine manual-worldmachine-speech manual-worldmachine-speech-translation",
				Depth = -19500,
				LockRotation = true,
				LockScale = true,
				Position = new(0, 2),
				Scale = new(61.8),
				RelativeTo = AdfMoveDecorationRelativeToType.Camera,
				Opacity = 0d,
				Color = new("DDDDDDBB")
			});








			DecoScene.DecoSceneFactory factory = new();

			var sceneSpaceStationOutside = factory.CreateScene();
			sceneSpaceStationOutside.Elements.Add(sceneSpaceStationOutside.CreateElement<MonoElement>()
				.Use("space.png").AsBackground(85).WithScale(500).WithParallax(98, 98)
				.FromFlash().ToFlashOut());
			sceneSpaceStationOutside.Elements.Add(sceneSpaceStationOutside.CreateElement<MassElement>()
				.Use(["space8.png"])
				.AsSpanParallax(1, 2, 2, -2, -2, scaleMin: 350, scaleMax: 350)
				.FromVaryingLayer(rotationMin: 10, rotationMax: 10, opacityMin: 100, opacityMax: 100, 
					rgbMin: 255, rgbMax: 255, parallaxXMin: 95, parallaxYMin: 98, depthMin: 82, depthMax: 82)
				.ToFlashOut());
			sceneSpaceStationOutside.FromWithMask(scale: 6000, depthMin: 81, depthMax: 85, duration: 2d, previewBeats: 0.5d, rotation: 25, drotation: -45, x: 0, dx: -120);

			sceneSpaceStationOutside.ApplyTo(chart, 8, 14);
			chart.FloatingTrackBackground(8, 12d, trackColor: "FFFFFFFF", totalTracks: 200, maxSize: 250, xmax: 350, style: AdfTrackStyle.Neon);


			var sceneCosmos = factory.CreateScene();
			sceneCosmos.Elements.Add(sceneCosmos.CreateElement<MonoElement>().Use("space.png")
				.WithAutofit(chart).AsBackground(80).FromFlash(100).ToFlashOut());
			sceneCosmos.Elements.Add(sceneCosmos.CreateElement<MassElement>().Use(new()
			{
				"nebula1.png",
				"nebula3.png",
				"nebula4.png",
				"nebula5.png",
				"nebula6.png"
			}).AsSpanParallax(15, -30, 40, -40, 60, 650, 1400, lockRotation: false)
			.FromVaryingLayer(10, 50, 95, 98, 98, 99.5, 
				180, 255, -5, 5, 72, 78)
			.ToFlashOut());
			sceneCosmos.Elements.Add(sceneCosmos.CreateElement<MonoElement>().Use("dim.jpg")
				.WithAutofit(chart).AsBackground(71).FromFlash(30).ToFlashOut());
			sceneCosmos.FromWithMask(scale: 6000, depthMin: 71, depthMax: 80, duration: 32d, previewBeats: 12d, rotation: 25, drotation: -5, x: 0, dx: -120);

			sceneCosmos.ApplyTo(chart, 12, 970);

			chart.ModernTrackAppear(12, 192, 4d, 7d, -1, 1, -0.5, -0.2);
			chart.ModernTrackDisappear(12, 192, 4d, -4d, -1, 1, -0.5, -0.2);






			chart.WorldMachine(446, "A sea of stars", "星辰大海", 7d);


			chart.MultipleTrack(466, 957, -20, -15, opacity: 75, scale: 240, parallaxX: 40, parallaxY: 35, hideIcons: true, depth: 50);
			chart.MultipleTrack(466, 957, -10, 5, scale: 100, parallaxX: 60, parallaxY: 45, hideIcons: true, depth: 40);




			chart.TrackDisappearExplosion(
				Enumerable.Range(466, 958 - 466).Where(i => chart.GetInnerAngleAtTile(i) == 20 && chart.GetInnerAngleAtTile(i + 1) == 20).ToList(), 
				4d, 1d, m: 1);
			Random random = new();
			for (int i = 466; i < 957; i++)
			{
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					RotationOffset = random.NextDouble() * 90 - 45,
                    PositionOffset = new(random.NextDouble() * 2 - 4, random.NextDouble() * 2),
					Duration = 0,
					Opacity = 0,
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = -114514
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					RotationOffset = 0,
					PositionOffset = new(0, 0),
					Duration = chart.GetTileBpmAt(i) / 1060 * 14d,
					Opacity = 100,
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = -chart.GetTileBpmAt(i) / 1060 * (14 * 180) * 2,
					Ease = AdfEaseType.OutBack
				});
			}






			var sceneStablization = factory.CreateScene();
			sceneStablization.Elements.Add(sceneStablization.CreateElement<MonoElement>()
				.Use("space2.png").AsBackground(70).WithScale(500).WithParallax(98, 98)
				.FromFlash().ToFlashOut());
			sceneStablization.Elements.Add(sceneStablization.CreateElement<MassElement>()
				.Use([
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
					])
				.AsSpanParallax(200, -40, 20, -50, 230, 50, 1500, false, false)
				.FromVaryingLayer(50, 100, 85, 95, -70, 70, 0, 0,
				-180, 180, 61, 70)
				.ToFlashOut());
			sceneStablization.FromWithMask(depthMin: 61, depthMax: 70, duration: 8d, previewBeats: 0d, scale: 4500, y: -20, dx: -45, rotation: 45);
			sceneStablization.ApplyTo(chart, 957, 2397);


			chart.WorldMachine(1192, "The shuttle is tearing itself apart.", "航天飞机正在解体。", 6d);

			chart.CameraRotationPulseByTile(
				Enumerable.Range(1210, 1671 - 1210).Where(i => chart.ChartTiles[i].TileEvents.Any(x => x is AdfEventEditorComment)).ToList(),
				-10, 10, 250, 350, 24d);

			chart.TrackAppearExplosion(
				Enumerable.Range(1210, 1671 - 1210).Where(i => chart.ChartTiles[i].TileEvents.Any(x => x is AdfEventEditorComment)).ToList(),
				4d, 8d, m: 0.5);
			chart.ModernTrackDisappear(1210, 2043, 4d, -3d, -1, 1, -6, -1, smin: 25, smax: 75);
			chart.ModernTrackAppear(1670, 2043, 4d, 8d, -1, 1, 1, 6, smin: 25, smax: 75);
			

			chart.ModernTrackDisappear(2043, 2423, 4d, -3d, -1, 1, -6, -1, smin: 25, smax: 75);
			chart.ModernTrackAppear(2043, 2423, 4d, 8d, -1, 1, 1, 6, smin: 25, smax: 75);

			chart.WorldMachine(2401, "Please save me", "请救救我", 4d);






			var sceneSaveMe = factory.CreateScene();
			sceneSaveMe.Elements.Add(sceneSaveMe.CreateElement<MonoElement>()
				.Use("space4.png").AsBackground(1000).WithScale(1000).WithParallax(90, 95)
				.FromFlash(30).ToFlashOut());
			sceneSaveMe.Elements.Add(sceneSaveMe.CreateElement<MassElement>()
				.Use([
					"smoke1.png", "smoke2.png"
					])
				.AsTileSpan(2, -50, 50, -500, -200, 1000, 5000, 10, 20, 300, 400)
				.WithMovement(-50, 50, 100, 300, -180, 180, 256 * 7, AdfEaseType.Linear)
				.FromFlash(20).ToFlashOut());
			sceneSaveMe.Elements.Add(sceneSaveMe.CreateElement<MonoElement>()
				.Use("nebula4.png")
				.AsBackground(999, false, false)
				.WithScale(800)
				.WithParallax(90, 90)
				.WithParallaxOffset(-5, 3)
				.FromFlash(25)
				.ToFlashOut());
			sceneSaveMe.ApplyTo(chart, 2423, 3550);


			chart.CameraRandomWobble(1, 5, 1, 4, -5, 5, 350, 420, 24d, 24d, 8d, 8d,
				31 * 7, 2423);

			chart.FloatingTrackBackground(2423, 64 * 7, "FFFFFFFF", 500, 10, 40,
				0.2, 0.8, 45, 75, -280, 160, -280, 60,
				50, 100, 20, 60, -10, AdfTrackStyle.Gems);

			for (int i = 2423; i < 3432; i++)
			{
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					RotationOffset = random.NextDouble() * 90 - 45,
                    PositionOffset = new(random.NextDouble() * 4 - 2, random.NextDouble() * 2),
					Duration = 0,
					Opacity = 0,
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = -114514
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					RotationOffset = 0,
					PositionOffset = new(0, 0),
					Duration = chart.GetTileBpmAt(i) / 1060 * 14d,
					Opacity = 100,
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = -chart.GetTileBpmAt(i) / 1060 * (14 * 180) * 2,
					Ease = AdfEaseType.OutBack
				});
			}
			chart.TrackDisappearExplosion(
				Enumerable.Range(2423, 3433 - 2423).ToList(),
				4d, xBias: -3, yBias: -5, m: 0.5);
			FilterComboDurate(chart, 2436, 4d, 52, m: 0.5);

			chart.CameraRotationPulseByTile(
				Enumerable.Range(3304, 3406 - 3304).Where(i => chart.ChartTiles[i].TileEvents.Any(x => x is AdfEventEditorComment)).ToList(),
				-5, 5, 250, 400, 12d);

			FilterComboDurate(chart, 3073, 4d, 48, m: 0.5);


			var sceneDamageShuttle = factory.CreateScene();
			sceneDamageShuttle.Elements.Add(sceneDamageShuttle.CreateElement<MonoElement>()
				.Use("space2.png").AsBackground(70).WithScale(500).WithParallax(98, 98)
				.FromFlash().ToFlashOut());
			sceneDamageShuttle.Elements.Add(sceneDamageShuttle.CreateElement<MassElement>()
				.Use([
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
					])
				.AsSpanParallax(200, -40, 20, -50, 230, 50, 1500, false, false)
				.FromVaryingLayer(50, 100, 85, 95, -70, 70, 0, 0,
				-180, 180, 61, 70)
				.ToFlashOut());
			sceneDamageShuttle.FromWithMask(depthMin: 61, depthMax: 70, duration: 8d, previewBeats: 0d, scale: 5500, y: -30, dx: 60, rotation: 45);
			sceneDamageShuttle.ApplyTo(chart, 3554, 3776);


			chart.WorldMachine(3776, "I'm losing hope", "我越来越绝望了", 4d);


			var sceneLosingHope = factory.CreateScene();
			sceneLosingHope.Elements.Add(sceneLosingHope.CreateElement<MonoElement>()
				.Use("space4.png").AsBackground(1000).WithScale(1000).WithParallax(90, 95)
				.FromFlash(30).ToFlashOut());
			sceneLosingHope.Elements.Add(sceneLosingHope.CreateElement<MassElement>()
				.Use([
					"smoke1.png", "smoke2.png"
					])
				.AsTileSpan(2, -50, 50, -500, -200, 1000, 5000, 10, 20, 300, 400)
				.WithMovement(-50, 50, 100, 300, -180, 180, 256 * 7, AdfEaseType.Linear)
				.FromFlash(20).ToFlashOut());
			sceneLosingHope.Elements.Add(sceneLosingHope.CreateElement<MonoElement>()
				.Use("nebula4.png")
				.AsBackground(999, false, false)
				.WithScale(800)
				.WithParallax(90, 90)
				.WithParallaxOffset(-5, 3)
				.FromFlash(25)
				.ToFlashOut());


			sceneLosingHope.Elements.Add(sceneLosingHope.CreateElement<MonoElement>()
				.Use("laser.png")
				.AsBackground(900)
				.WithScale(200)
				.WithParallax(98, 100)
				.WithParallaxOffset(0, 0)
				.FromFlash().ToFlashOut());
			sceneLosingHope.Elements.Add(sceneLosingHope.CreateElement<MassElement>()
				.Use([
					"shard1.png",
					"shard2.png",
					"shard3.png",
					"shard4.png",
					"shard5.png",
					"shard6.png",
					"shard7.png",
					"shard8.png",
					])
				.AsSpanParallax(100, -80, 50, 5, 15, 80, 150, false, false)
				.FromVaryingLayer(80, 100, 90, 95, 99, 99,
					0, 50, -180, 180, 901, 950)
				.WithMovementParallax(80, 120, -1, 1, -180, 180, 7 * 256, AdfEaseType.Linear)
				.ToFlashOut());
			sceneLosingHope.Elements.Add(sceneLosingHope.CreateElement<MassElement>()
				.Use([
					"shard1.png",
					"shard2.png",
					"shard3.png",
					"shard4.png",
					"shard5.png",
					"shard6.png",
					"shard7.png",
					"shard8.png",
					])
				.AsSpanParallax(200, -50, 250, 5, 15, 150, 250, false, false)
				.FromVaryingLayer(50, 80, 60, 80, 99, 99,
					200, 255, -180, 180, 850, 899)
				.WithMovementParallax(-50, -80, -1, 1, -180, 180, 7 * 256, AdfEaseType.Linear)
				.ToFlashOut());
			sceneLosingHope.ApplyTo(chart, 3802, 5526);


			chart.FloatingTrackBackground(3802, 64 * 7, "FFFFFFFF", 500, 10, 40,
				0.2, 0.8, 45, 75, -280, 160, -280, 60,
				50, 100, 20, 60, -10, AdfTrackStyle.Gems);


			chart.MultipleTrack(3802, 4693, -1, 0, "FFFFFFFF", 100, 100, 0.0001, 0.0001,
				AdfTrackStyle.Minimal, true, 1);

			chart.TrackAppearExplosion(Enumerable.Range(3802, 5892 - 3802).ToList(), 4d, 4d, m: 0.5);
			chart.TrackDisappearExplosion(Enumerable.Range(3802, 5892 - 3802).ToList(), 4d, 0.5, -5, -3, 100, m: 0.5);

			for (int i = 3816; i < 5484; i++)
			{
				if (chart.GetInnerAngleAtTile(i) == 30 || chart.GetInnerAngleAtTile(i) == 20)
				{
					chart.CameraRotationPulseByTile([i], -5, 5, 350, 400, chart.GetTileBpmAt(i) / 265 * 2d);
					FilterComboDurate(chart, i, 4d, 1, chart.GetTileBpmAt(i) / 265 / 8);
				}
			}
			






			for (int i = 5518; i < 5892; i++)
			{
				if (i >= 5602 && i < 5622) { continue; }
				if (i >= 5660 && i < 5680) { continue; }

				if (chart.GetInnerAngleAtTile(i) == 30 || chart.GetInnerAngleAtTile(i) == 20)
				{
					chart.CameraRotationPulseByTile([i], -5, 5, 350, 400, chart.GetTileBpmAt(i) / 265 * 2d);
					FilterComboDurate(chart, i, 4d, 1, chart.GetTileBpmAt(i) / 265 / 8);
				}
			}

			sceneCosmos.ApplyTo(chart, 5518, 5559);
			sceneDamageShuttle.ApplyTo(chart, 5549, 5602);
			sceneSaveMe.ApplyTo(chart, 5602, 5660);
			sceneLosingHope.ApplyTo(chart, 5660, 5922);


			var sceneAsteroidCrashedInto = factory.CreateScene();
			sceneAsteroidCrashedInto.Elements.Add(sceneAsteroidCrashedInto.CreateElement<MonoElement>()
				.Use("space2.png").AsBackground(50).WithScale(500).WithParallax(98, 98)
				.FromFlash().ToFlashOut());
			sceneAsteroidCrashedInto.Elements.Add(sceneAsteroidCrashedInto.CreateElement<MassElement>()
				.Use([
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
					])
				.AsSpanParallax(200, -20, 80, -50, 100, 50, 1500, false, false)
				.FromVaryingLayer(50, 100, 85, 95, -70, 70, 0, 0,
				-180, 180, 41, 50)
				.ToFlashOut());
			sceneAsteroidCrashedInto.FromWithMask(depthMin: 41, depthMax: 50, duration: 8d, previewBeats: 0d, scale: 6500, y: -20, dx: -65, rotation: 45);

			sceneAsteroidCrashedInto.ApplyTo(chart, 5892, 7823);



			chart.WorldMachine(6303, "It's too late", "太晚了", 4d);

			for (int i = 6818; i < 7085; i++)
			{
				if (chart.GetInnerAngleAtTile(i) == 30 || chart.GetInnerAngleAtTile(i) == 20)
				{
					chart.CameraRotationPulseByTile([i], -5, 5, 350, 400, chart.GetTileBpmAt(i) / 265 * 2d);
					FilterComboDurate(chart, i, 4d, 1, chart.GetTileBpmAt(i) / 265 / 8);
				}
			}



			chart.ModernTrackDisappear(5892, 7137, 4d, -3d, -1, 1, -6, -1, smin: 25, smax: 75);
			chart.ModernTrackAppear(5892, 7137, 4d, 8d, -1, 1, 1, 6, smin: 25, smax: 75);


			chart.ModernTrackAppear(7137, 8036, 4d, 8d, -5, -2, 1, 2, smin: 25, smax: 50);
			chart.ModernTrackDisappear(7137, 8036, 4d, -3d, 2, 5, 1, 2, smin: 25, smax: 50);


			var sceneFarewell = factory.CreateScene();
			sceneFarewell.Elements.Add(sceneFarewell.CreateElement<MonoElement>().Use("space.png")
				.WithAutofit(chart).AsBackground(80).FromFlash(100).ToFlashOut());
			sceneFarewell.Elements.Add(sceneFarewell.CreateElement<MassElement>().Use(new()
			{
				"nebula1.png",
				"nebula3.png",
				"nebula4.png",
				"nebula5.png",
				"nebula6.png"
			}).AsSpanParallax(15, -30, 40, -40, 60, 650, 1400, lockRotation: false)
			.FromVaryingLayer(10, 50, 95, 98, 98, 99.5, 
				180, 255, -5, 5, 72, 78)
			.ToFlashOut());
			sceneFarewell.Elements.Add(sceneFarewell.CreateElement<MonoElement>().Use("dim.jpg")
				.WithAutofit(chart).AsBackground(71).FromFlash(30).ToFlashOut());

			sceneFarewell.ApplyTo(chart, 7823, 8036);





#pragma warning disable CA1416 // Validate platform compatibility
			chart.RenderCreditRoleAndName(7137, "JinoBeats", "Drowning in a Sea of Stars", 480, -360,
				8d, 8d, 96d, 200);
			chart.RenderCreditRoleAndName(7319, "Chart", "Chart Duo \"Qubic Resort\"", 480, -360,
				8d, 8d, 96d, 200);

			chart.RenderCreditRoleAndName(7475, "Track", "Sean Lenard B.", 480, -120,
				8d, 8d, 96d, 200);
			chart.RenderCreditRoleAndName(7475, "Visual", "quartrond", 480, -540,
				8d, 8d, 96d, 200);

			chart.RenderCreditRoleAndName(7657, "Produced with", "MagicShaper-AdfEventLib", 480, -360,
				8d, 8d, 96d, 200);

			chart.LyricWithTranslation("lyric.txt");
#pragma warning restore CA1416 // Validate platform compatibility
			File.WriteAllText(@"G:\Adofai levels\Drowning\level-vfx.adofai", chart.ChartJson.ToString());
		}

		private static void WorldMachine(this AdfChart chart, int tile, string eng, string chn, double duration)
		{
			Random random = new();
			string gid = random.Next(1000000).ToString().PadLeft(6, '0');




			double standardBpm = chart.GetTileBpmAt(0);

#pragma warning disable CA1416 // Validate platform compatibility
			TextRenderExtension.Convert(eng,
				chart.FileLocation?.Parent?.FullName + $"\\manual-worldmachine-{tile}-main.png",
				"Bahnschrift");
			TextRenderExtension.Convert(chn,
				chart.FileLocation?.Parent?.FullName + $"\\manual-worldmachine-{tile}-translation.png",
				"方正楷体_GBK");
#pragma warning restore CA1416 // Validate platform compatibility






			chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Duration = 0d,
				DecorationImage = $"manual-worldmachine-{tile}-main.png",
				Tag = $"manual-worldmachine-speech-main",
			});
			chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Duration = 0d,
				DecorationImage = $"manual-worldmachine-{tile}-translation.png",
				Tag = $"manual-worldmachine-speech-translation",
			});

			chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Duration = 1d * chart.GetTileBpmAt(tile) / standardBpm,
				Tag = $"manual-worldmachine-darkenmask",
				Opacity = 60d,
			});
			chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Duration = 1d * chart.GetTileBpmAt(tile) / standardBpm,
				Tag = $"manual-worldmachine-speech",
				Opacity = 100d,
			});


			chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Duration = 1d * chart.GetTileBpmAt(tile) / standardBpm,
				Tag = $"manual-worldmachine-speech manual-worldmachine-darkenmask",
				Opacity = 0d,
				AngleOffset = 180d * duration * chart.GetTileBpmAt(tile) / standardBpm
			});



		}
		private static void FilterComboDurate(AdfChart chart, int tile, double intervalBeats, int repetition, double m = 1)
		{
			for (int i = 0; i < repetition; i++)
			{
				chart.ChartTiles[tile].TileEvents.Add(new AdfEventSetFilter() { AngleOffset = 180d * intervalBeats * i, Filter = AdfFilter.Aberration, Duration = 0, Intensity = 70 });
				chart.ChartTiles[tile].TileEvents.Add(new AdfEventSetFilter() { AngleOffset = 180d * intervalBeats * i, Filter = AdfFilter.Aberration, Duration = 16 * m, Intensity = 52, Ease = AdfEaseType.OutExpo });
				chart.ChartTiles[tile].TileEvents.Add(new AdfEventSetFilter() { AngleOffset = 180d * intervalBeats * i, Filter = AdfFilter.BlurFocus, Duration = 0, Intensity = 30 });
				chart.ChartTiles[tile].TileEvents.Add(new AdfEventSetFilter() { AngleOffset = 180d * intervalBeats * i, Filter = AdfFilter.BlurFocus, Duration = 16 * m, Intensity = 0, Ease = AdfEaseType.OutExpo });
				chart.ChartTiles[tile].TileEvents.Add(new AdfEventSetFilter() { AngleOffset = 180d * intervalBeats * i, Filter = AdfFilter.Fisheye, Duration = 0, Intensity = 70 });
				chart.ChartTiles[tile].TileEvents.Add(new AdfEventSetFilter() { AngleOffset = 180d * intervalBeats * i, Filter = AdfFilter.Fisheye, Duration = 16 * m, Intensity = 50, Ease = AdfEaseType.OutExpo });
				chart.ChartTiles[tile].TileEvents.Add(new AdfEventFlash() { AngleOffset = 180d * intervalBeats * i, Plane = AdfFlashPlaneType.Foreground, StartColor = new("000000FF"), EndColor = new("000000FF"), Duration = 16 * m, StartOpacity = 10, EndOpacity = 0, Ease = AdfEaseType.OutExpo });
			}
		}
	}
}