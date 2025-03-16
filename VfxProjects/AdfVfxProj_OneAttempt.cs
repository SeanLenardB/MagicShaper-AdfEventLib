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
	internal static class AdfVfxProj_OneAttempt
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\OneAttempt\level-base.adofai");

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
			.WithMovementParallax(-40, 40, 250, 500, -25, 25, 8192d)
			.FromVaryingLayer(15, 40, 95, 99, 95, 99, 180, 230, -180, 180, -50, -30)
			.ToFlashOut());

			var sceneBlackBackSmoke = factory.CreateScene();
			sceneBlackBackSmoke.Elements.Add(sceneBlackBackSmoke.CreateElement<MassElement>().Use(new()
			{
				"smoke1.png", "smoke2.png"
			}).AsTileSpan(8, -100, 100, -100, 100, 500, 800, 200, 200, 800, 1200)
			.WithMovementParallax(-20, 20, 50, 100, -15, 15, 8192d)
			.FromVaryingLayer(15, 35, 95, 99, 95, 99, 0, 50, -180, 180, 20, 30)
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
			}).AsSpanParallax(6, -20, 20, -10, 0, scaleMin: 300, scaleMax: 800)
				.WithFloor(xmin: -20, xmax: 25, ymin: -6, ymax: -2, parallaxXMin: 99, parallaxXMax: 99.9, parallaxYMin: 98, parallaxYMax: 99)
				.WithMovement(5, 20, -3, 3, -1, 1, 128d)
				.FromVaryingLayer(parallaxXMin: 99, parallaxXMax: 99.9, parallaxYMin: 98, parallaxYMax: 99, opacityMin: 25, opacityMax: 100, rgbMin: 150)
				.ToFlashOut());

			var sceneWares = factory.CreateScene();
			sceneWares.Elements.Add(sceneWares.CreateElement<MassElement>().Use(new()
			{
				"ware1.png", "ware2.png", "ware3.png", "ware4.png", "ware5.png", "ware6.png", "ware7.png", "ware8.png", "ware9.png", "ware10.png", "ware11.png", "ware12.png"
			}).AsSpanParallax(100, -30, 30, -30, 35, scaleMin: 50, scaleMax: 350)
				.WithMovementParallax(-5, -10, 5, 10, -90, 90, 128d * 64d)
				.FromVaryingLayer(25, 100, 95, 98, 97, 98, 50, 255, -180, 180)
				.ToFlashOut());

			sceneWarehouse.ApplyTo(chart, 93, 2839);
			sceneWares.ApplyTo(chart, 93, 2839);
			sceneBlackBackSmoke.ApplyTo(chart, 93, 2839);
			sceneWhiteForeSmoke.ApplyTo(chart, 93, 2839);
#pragma warning disable CA1416 // Validate platform compatibility
			chart.LyricWithTranslation("worldmachine.txt", "Bahnschrift", "方正楷体_GBK",
				0, 0, 100, 1, 1, -1145, "FFFFFFFF", "DDDDDDBB");
#pragma warning restore CA1416 // Validate platform compatibility

			chart.WorldMachine(112, "[ QR3 Finals Original Tiebreaker ]", "[ \"Sean Lenard B. - OneAttempt -Thawing-\" ]", 15d);
			chart.WorldMachine(209, "[ Simulation created by Chart Duo \"Qubic Resort\" ]", "[ 团队\"立方双晶\"制作 ]", 15d);
			chart.WorldMachine(310, "[ Respect to OneShot ]", "[ 向OneShot致敬 ]", 7d);
			chart.WorldMachine(358, "[ Produced with MagicShaper-AdfEventLib ]", "[ 使用MagicShaper-AdfEventLib制作 ]", 7d);

			chart.WorldMachine(508, "[ The Ruins ]", "[ 废墟 ]", 7d);

			chart.WorldMachine(1466, "[ The world is destablizing. Watch out. ]", "[ 这个世界开始变得不稳定了，小心点 ]", 11d);
			for (int i = 906; i < 1466; i++)
			{
				if (chart.GetInnerAngleAtTile(i) == 30 && chart.GetInnerAngleAtTile(i + 1) == 30)
				{
					foreach (var e in chart.ChartTiles[i].TileEvents)
					{
						if (e is AdfEventColorTrack)
						{
							chart.CameraRotationPulseByBeats(i, 0, 1, -2, 2, 270, 300,
								chart.GetTileBpmAt(i) / 235 * 4d);
							break;
						}
					}
				}
			}

			var sceneFirstDrop = factory.CreateScene();
			sceneFirstDrop.Elements.Add(sceneFirstDrop.CreateElement<MassElement>().Use(new()
			{
				"ware1.png", "ware2.png", "ware3.png", "ware4.png", "ware5.png", "ware6.png", "ware7.png", "ware8.png", "ware9.png", "ware10.png", "ware11.png", "ware12.png"
			}).AsSpan(250, -500, 40, 0, 120, scaleMin: 150, scaleMax: 550)
				.WithMovementParallax(-5, -10, 5, 10, -90, 90, 128d * 64d)
				.FromVaryingLayer(55, 100, -10, 30, -10, 30,
				200, 255, -180, 180, 1, 1)
				.ToFlashOut());
			sceneFirstDrop.ApplyTo(chart, 1571, 2839);

			List<int> listFirstDropKick = new();
			for (int i = 1571; i < 2052; i++)
			{
				if (chart.GetInnerAngleAtTile(i) == 30 && chart.GetInnerAngleAtTile(i + 1) == 60)
				{
					listFirstDropKick.Add(i);
				}
			}

			chart.CameraRotationPulseByTile(listFirstDropKick, -3, 3, 280, 350, 16d);
			chart.ModernTrackAppear(1571, 1896, 16d, 16d, -2, 2, -2, -0.5, smax: 95, angleOffsetVariationProportion: 50, endOpacity: 5000);
			chart.TrackDisappearExplosion(listFirstDropKick, 16d, 0.1, 1, m: 0.4);

			chart.Cubes(1618, 30, -6, -1, 0, 8, "first");
			chart.Cubes(1772, 30, 2, 16, -6, 0, "first");
			chart.Cubes(1813, 30, -8, -3, -2, 6, "first");
			chart.Cubes(2035, 30, -2, 12, -5, -1, "first");
			chart.CubesAnimate("first", 1421, 128d);

			chart.OsuManiaGimmickAdvanced(2052, 2327, (i) => chart.ChartTiles[i].TargetAngle >= 999d,
				1, 0.4d, 2d, 1d, 0.1d, 32d, 0.2d, -5d, -7.2d,
				true, true, -90, -18020);
			chart.OsuManiaGimmickAdvanced(2422, 2696, (i) => chart.ChartTiles[i].TargetAngle >= 999d,
				1, 0.4d, 2d, 1d, 0.1d, 32d, 0.2d, -5d, -7.2d,
				true, true, -90, -18020);


			chart.Cubes(2353, 20, -6, -2, -8, -2, "second");
			chart.CubesAnimate("second", 2289, 64d);
			chart.Cubes(2696, 20, -5, -2, 2, 8, "third-f");
			chart.CubesAnimate("third-f", 2628, 64d);

			chart.Cubes(2534, 20, -8, 2, -5, 3, "third-p");
			chart.CubesAnimate("third-p", 2576, 16d);

			chart.Cubes(2728, 20, -8, 2, -9, -2, "fourth-0");
			chart.Cubes(2761, 20, -2, 4, -2, 6, "fourth-a");
			chart.Cubes(2794, 20, -12, 2, -2, 3, "fourth-b");
			chart.Cubes(2817, 20, -5, 2, -2, 4, "fourth-c");
			chart.CubesAnimate("fourth-0", 2761, 16d);
			chart.CubesAnimate("fourth-a", 2795, 16d);
			chart.CubesAnimate("fourth-b", 2817, 16d);
			chart.CubesAnimate("fourth-c", 2833, 16d);

			chart.WorldMachine(2025, "[ Look down. ]", " [ 向下看 ]", 7d);








			// SECOND HALF

			sceneWares.ApplyTo(chart, 2844, 3236);
			sceneBlackBackSmoke.ApplyTo(chart, 2844, 3236);
			sceneBlackBackSmoke.ApplyTo(chart, 2844, 3236);
			sceneBlackBackSmoke.ApplyTo(chart, 2844, 3236);
			sceneWhiteForeSmoke.ApplyTo(chart, 2844, 3236);
			sceneRuins.ApplyTo(chart, 2844, 3236);


			chart.WorldMachine(2896, "[ The Ascend ]", "[ 攀升 ]", 7d);
			chart.WorldMachine(3179, "[ Everything's deteriorating faster than I predicted. ]", "[ 比我预料的恶化得更快 ]", 7d);
			chart.WorldMachine(3196, "[ I'll help you outside this world. ]", "[ 我会在这个世界外帮你 ]", 7d);


			var sceneVolcanoTwo = factory.CreateScene();

			sceneVolcanoTwo.Elements.Add(sceneVolcanoTwo.CreateElement<MonoElement>().Use("cosmos.png").AsBackground()
				.WithAutofit(chart).FromFlash(70).ToFlash());

			var sceneSecondDrop = factory.CreateScene();
			//sceneSecondDrop.Elements.Add(sceneSecondDrop.CreateElement<MassElement>().Use(new()
			//{
			//	"ware1.png", "ware2.png", "ware3.png", "ware4.png", "ware5.png", "ware6.png", "ware7.png", "ware8.png", "ware9.png", "ware10.png", "ware11.png", "ware12.png"
			//}).AsSpan(15, -40, 500, 0, 220, scaleMin: 550, scaleMax: 1500)
			//	.WithMovementParallax(-5, -10, 5, 10, -90, 90, 128d * 64d)
			//	.FromVaryingLayer(55, 100, 70, 90, 70, 90,
			//	0, 200, -180, 180, 1, 1)
			//	.ToFlashOut());
			var sceneSecondWares = factory.CreateScene();
			sceneSecondWares.Elements.Add(sceneSecondWares.CreateElement<MassElement>().Use(new()
			{
				"ware1.png", "ware2.png", "ware3.png", "ware4.png", "ware5.png", "ware6.png", "ware7.png", "ware8.png", "ware9.png", "ware10.png", "ware11.png", "ware12.png"
			}).AsSpan(150, -450, 120, -20, 160, scaleMin: 550, scaleMax: 800)
				.FromVaryingLayer(25, 100, -90, -70, -90, -70,
				0, 100, -180, 180, 4, 4)
				.ToFlashOut());
			sceneSecondWares.Elements.Add(sceneSecondWares.CreateElement<MassElement>().Use(new()
			{
				"ware1.png", "ware2.png", "ware3.png", "ware4.png", "ware5.png", "ware6.png", "ware7.png", "ware8.png", "ware9.png", "ware10.png", "ware11.png", "ware12.png"
			}).AsSpan(150, -250, 500, -20, 160, scaleMin: 150, scaleMax: 550)
				.FromVaryingLayer(25, 50, 50, 90, 50, 90,
				160, 255, -180, 180, 2, 2)
				.ToFlashOut());
			sceneSecondDrop.Elements.Add(sceneSecondDrop.CreateElement<MonoElement>().Use("peak.png")
				.AsBackground(3).WithColor(80).WithParallaxOffset(-10, -1).WithScale(500).FromFlash(100).ToFlash());
			sceneSecondDrop.Elements.Add(sceneSecondDrop.CreateElement<MassElement>().Use(new()
			{
				"smoke1.png", "smoke2.png"
			}).AsTileSpan(3, -100, 100, -100, 100, 500, 800, 200, 200, 800, 1200)
			.WithMovementParallax(-40, 40, 450, 800, -25, 25, 2048d * 4)
			.FromVaryingLayer(15, 60, 95, 99, 95, 99, 180, 230, -180, 180, -50, -30)
			.ToFlashOut());
			sceneSecondDrop.Elements.Add(sceneSecondDrop.CreateElement<MassElement>().Use(new()
			{
				"smoke1.png", "smoke2.png"
			}).AsTileSpan(8, -100, 100, -100, 100, 500, 800, 200, 200, 800, 1200)
			.WithMovementParallax(-20, 20, 150, 300, -15, 15, 2048d * 4)
			.FromVaryingLayer(15, 55, 95, 99, 95, 99, 0, 50, -180, 180, 20, 30)
			.ToFlashOut());

			sceneVolcanoTwo.ApplyTo(chart, 3259, 7504);
			sceneSecondDrop.ApplyTo(chart, 3259, 7504);
			sceneSecondWares.ApplyTo(chart, 3259, 5867);




			List<int> secondDropList = (from N in Enumerable.Range(3259, 4635 - 3259)
										where chart.GetInnerAngleAtTile(N) == 30d && (chart.GetInnerAngleAtTile(N + 1) == 60d || chart.GetInnerAngleAtTile(N + 1) == 30d)
										select N).ToList();
			Random random = new();
			foreach (var tile in secondDropList)
			{
				chart.ChartTiles[tile].TileEvents.Add(
					new AdfEventMoveCamera()
					{
						Duration = 0d,
						Zoom = 500,
						AngleOffset = -0.01d
					});
				chart.ChartTiles[tile].TileEvents.Add(
					new AdfEventMoveCamera()
					{
						Zoom = 550,
						Duration = 12d * chart.GetTileBpmAt(tile) / chart.GetTileBpmAt(0),
						Ease = AdfEaseType.OutCirc
					});
				chart.ShapeFocusOnTile("", "wave.png", tile, 0,
					4d / chart.GetTileBpmAt(0) * chart.GetTileBpmAt(tile), outSize: 3500, xRelativeToTile: -20, yRelativeToTile: -10);
			}

			int lastStart = 3259;
			for (int i = 3259; i < 4477; i++)
			{
				foreach (var e in chart.ChartTiles[i].TileEvents)
				{
					if (e is AdfEventColorTrack ee)
					{
						if (ee.TrackStyle == AdfTrackStyle.Basic) { lastStart = i; break; }
						else if (ee.TrackStyle == AdfTrackStyle.Neon)
						{
							chart.ModernTrackDisappear(lastStart, i, 8d, -12d, -5, -2, -2, -1);
							break;
						}
					}
				}
				Console.WriteLine($"Tile {i} -> recorded {lastStart}");
			}






			chart.Cubes(3308, 10, 2, 6, 3, 5, "dropsecond-first");
			chart.Cubes(3380, 10, 0, 12, -6, -4, "dropsecond-first");
			chart.Cubes(3467, 10, -3, 5, -8, -4, "dropsecond-first");
			chart.Cubes(3544, 60, -2, 18, -2, 4, "dropsecond-first");
			chart.Cubes(3730, 80, -10, 10, -9, -4, "dropsecond-first");
			chart.Cubes(3925, 10, -4, -2, -1, 1, "dropsecond-first");
			chart.CubesAnimate("dropsecond-first", 3237, 256d);



			chart.Cubes(3993, 10, 2, 4, -4, -2, "dropsecond-second");
			chart.Cubes(4065, 40, -8, 8, 6, 10, "dropsecond-second");
			chart.Cubes(4146, 60, -2, 10, -2, 6, "dropsecond-second");
			chart.Cubes(4235, 20, 2, 10, -4, -1, "dropsecond-second");
			chart.CubesAnimate("dropsecond-second", 3840, 256d);

			chart.Cubes(4383, 20, -4, 4, -6, 2, "dropsecond-third");
			chart.CubesAnimate("dropsecond-third", 4395, 32d);
			chart.Cubes(4395, 10, 2, 6, 0, 4, "dropsecond-fourth");
			chart.CubesAnimate("dropsecond-fourth", 4404, 32d);

			chart.OsuManiaGimmickAdvanced(-32 + 4635, 4859, (i) => chart.ChartTiles[i].TargetAngle >= 999d,
				1, 0.4d, 2d, 1d, 0.1d, 32d, 0.2d, -5d, -7.2d,
				true, true, -90, -18020);
			chart.OsuManiaGimmickAdvanced(-32 + 4942, 5166, (i) => chart.ChartTiles[i].TargetAngle >= 999d,
				1, 0.4d, 2d, 1d, 0.1d, 32d, 0.2d, -5d, -7.2d,
				true, true, -90, -18020);
			chart.OsuManiaGimmickAdvanced(-32 + 5251, 5474, (i) => chart.ChartTiles[i].TargetAngle >= 999d,
				1, 0.4d, 2d, 1d, 0.1d, 32d, 0.2d, -5d, -7.2d,
				true, true, -90, -18020);
			chart.OsuManiaGimmickAdvanced(-32 + 5558, 5782, (i) => chart.ChartTiles[i].TargetAngle >= 999d,
				1, 0.4d, 2d, 1d, 0.1d, 32d, 0.2d, -5d, -7.2d,
				true, true, -90, -18020);




			chart.WorldMachine(5867, "[ The Finale ]", "[ 决战 ]", 16d);

			chart.FloatingTrackBackground(5867, 1024d, "000000FF", 150, 850, 2000,
				0.3, 0.8, 75, 105, -50, 750, -500, 150, 50, 95);



			chart.Cubes(6547, 30, -10, 2, -10, -2, "secondtolast-a");
			chart.CubesAnimate("secondtolast-a", 6547, 64d, true);
			chart.Cubes(6610, 30, -10, 2, -10, -2, "secondtolast-b");
			chart.CubesAnimate("secondtolast-b", 6610, 64d, true);
			chart.Cubes(6676, 30, -10, 2, -10, -2, "secondtolast-c");
			chart.CubesAnimate("secondtolast-c", 6676, 64d, true);

			chart.Cubes(6743, 30, 3, 8, 1, 9, "singularitybreaker");
			chart.Cubes(6826, 20, -6, 6, -8, -2, "singularitybreaker");
			chart.Cubes(6936, 40, 2, 18, -1, 7, "singularitybreaker");
			chart.CubesAnimate("singularitybreaker", 6684, 64d);

			chart.Cubes(7048, 20, -20, -4, -2, 2, "lastsection-a");
			chart.CubesAnimate("lastsection-a", 7048, 32d, true);
			chart.Cubes(7083, 20, 4, 20, -6, -2, "lastsection-b");
			chart.CubesAnimate("lastsection-b", 7083, 32d, true);
			chart.Cubes(7118, 30, -12, -2, -4, 7, "lastsection-c");
			chart.CubesAnimate("lastsection-c", 7118, 32d, true);
			chart.Cubes(7171, 40, 1, 13, -5, 3, "lastsection-d");
			chart.CubesAnimate("lastsection-d", 7171, 32d, true);

			List<int> thirdDropList = (from N in Enumerable.Range(6488, 6709 - 6488)
										where chart.GetInnerAngleAtTile(N) == 30d && (chart.GetInnerAngleAtTile(N + 1) == 60d || chart.GetInnerAngleAtTile(N + 1) == 30d)
										select N).ToList();
			foreach (var tile in thirdDropList)
			{
				chart.ChartTiles[tile].TileEvents.Add(
					new AdfEventMoveCamera()
					{
						RelativeTo = AdfCameraRelativeToType.Player,
						Rotation = random.RandBetween(-3, 3),
						Duration = 0d,
						Zoom = 380,
						AngleOffset = -0.01d
					});
				chart.ChartTiles[tile].TileEvents.Add(
					new AdfEventMoveCamera()
					{
						RelativeTo = AdfCameraRelativeToType.Player,
						Rotation = 0,
						Zoom = 500,
						Duration = 12d * chart.GetTileBpmAt(tile) / chart.GetTileBpmAt(0),
						Ease = AdfEaseType.OutCirc
					});
			}

			for (int i = 7059; i < 7257; i++)
			{
				if (chart.GetInnerAngleAtTile(i) == 30)
				{
					chart.CameraRotationPulseByBeats(i, 1, 1, -4, 4, 300, 350, 4d);
					i++;
				}
			}

			chart.WorldMachine(7508, "[ Artist, Track: Sean Lenard B. (Sean) ]", "[ 作曲、采音 ]", 7d);
			chart.WorldMachine(7510, "[ Visual by quartrond (Sean) ]", "[ 特效 ]", 7d);
			chart.WorldMachine(7512, "[ Playtesters: NanoCRotor, C.O.I.N., FallenKun ]", "[ 试玩 ]", 7d);
			chart.WorldMachine(7514, "[ Thank you for joining the ride. ]", "[ 感谢游玩 ]", 7d);




			File.WriteAllText(@"G:\Adofai levels\OneAttempt\level-eff.adofai", chart.ChartJson.ToJsonString());
		}

		public static void Test()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\testcubes\Le_noeffect.adofai");









			File.WriteAllText(@"G:\Adofai levels\testcubes\level-eff.adofai", chart.ChartJson.ToJsonString());
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

		private static AdfColor[] CubeColors = [new("FFFFFFFF"), new("AAAAAAFF"), new("000000FF")];
		private static readonly double FlashPerBeat = 2d;
		private static readonly int CubeGroupInSection = 10;
		private static void Cubes(this AdfChart chart, int relativeToTile, int amount, double xmin, double xmax, double ymin, double ymax, string section)
		{
			Random random = new();
			for (int i = 0; i < amount; i++)
			{
				chart.ChartTiles[relativeToTile].TileEvents.Add(new AdfEventAddDecoration()
				{
					DecorationImage = "mask.png",
					Tag = $"quartrond-worldmachinecubes-{relativeToTile}-{i} quartrond-worldmachinecubes-{relativeToTile} " +
					$"quartrond-worldmachinecubes-section-{section} quartrond-worldmachinecubes-section-{section}-{random.Next(CubeGroupInSection)}",
					RelativeTo = AdfMoveDecorationRelativeToType.Tile,
					Floor = relativeToTile,
					Opacity = 0,
					Position = new(random.RandBetween(xmin, xmax), random.RandBetween(ymin, ymax)),
					Scale = new(random.RandBetween(20, 80)),
					Color = new("FFFFFF00")
				});
			}
		}

		private static void CubesAnimate(this AdfChart chart, string section, int animationTile, double duration, bool playsound = false)
		{
			Random random = new();
			for (int i = 0; i < duration * FlashPerBeat; i++)
			{
				for (int j = 0; j < CubeGroupInSection; j++)
				{
					chart.ChartTiles[animationTile].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Tag = $"quartrond-worldmachinecubes-section-{section}-{j}",
						PositionOffset = new(random.RandBetween(-0.1, 0.1), random.RandBetween(-0.1, 0.1)),
						Color = random.RandIn(CubeColors),
						Opacity = 100,
						Duration = 0,
						Scale = new(random.RandBetween(20, 80)),
						AngleOffset = chart.GetTileBpmAt(animationTile) / 235 * 180 / FlashPerBeat * i
					});
				}
			}
			if (playsound)
			{
				chart.ChartTiles[animationTile].TileEvents.Add(new AdfEventPlaySound()
				{
					Hitsound = AdfHitsoundType.FireTile,
				});
			}
		}
	}
}
