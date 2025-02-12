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
			.WithMovementParallax(-40, 40, 250, 500, -25, 25, 2048 * 16d)
			.FromVaryingLayer(15, 40, 95, 99, 95, 99, 180, 230, -180, 180, -50, -30)
			.ToFlashOut());

			var sceneBlackBackSmoke = factory.CreateScene();
			sceneBlackBackSmoke.Elements.Add(sceneBlackBackSmoke.CreateElement<MassElement>().Use(new()
			{
				"smoke1.png", "smoke2.png"
			}).AsTileSpan(8, -100, 100, -100, 100, 500, 800, 200, 200, 800, 1200)
			.WithMovementParallax(-20, 20, 50, 100, -15, 15, 1024d)
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

			chart.WorldMachine(112, "[ QR3 Finals Original Tiebreaker ]", "[ \"Sean Lenard B. - OneAttempt -Thawing-\" ]", 15d);
			chart.WorldMachine(209, "[ Simulation created by Chart Duo \"Qubic Resort\" ]", "[ 团队\"立方双晶\"制作 ]", 7d);
			chart.WorldMachine(256, "[ Artist, Track: Sean Lenard B. (Sean) ]", "[ 作曲、采音 ]", 3d);
			chart.WorldMachine(280, "[ Visual by quartrond (Sean) ]", "[ 特效 ]", 3d);
			chart.WorldMachine(310, "[ Respect to OneShot ]", "[ 向OneShot致敬 ]", 7d);
			chart.WorldMachine(358, "[ Produced with MagicShaper-AdfEventLib ]", "[ 使用MagicShaper-AdfEventLib制作 ]", 7d);

			chart.WorldMachine(508, "[ The Ruins ]", "[ 废墟 ]", 7d);

			chart.WorldMachine(1466, "[ The world is destablizing. Watch out. ]", "[ 这个世界开始变得不稳定了，小心点 ]", 11d);
#pragma warning restore CA1416 // Validate platform compatibility





			for (int i = 906; i < 1466; i++)
			{
				if (chart.GetInnerAngleAtTile(i) == 30 && chart.GetInnerAngleAtTile(i+1) == 30)
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
				if (chart.GetInnerAngleAtTile(i) == 30 && chart.GetInnerAngleAtTile(i+1) == 60)
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
			chart.CubesAnimate("first", 1452, 128d);



			File.WriteAllText(@"G:\Adofai levels\OneAttempt\level-eff.adofai", chart.ChartJson.ToJsonString());
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
					Position = new(random.RandBetween(xmin, xmax), random.RandBetween(ymin, ymax)),
					Scale = new(random.RandBetween(20, 80)),
					Color = random.RandIn(CubeColors)
				});
			}
		}

		private static void CubesAnimate(this AdfChart chart, string section, int animationTile, double duration)
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
						Duration = 0,
						Scale = new(random.RandBetween(20, 80)),
						AngleOffset = chart.GetTileBpmAt(animationTile) / 235 * 180 / FlashPerBeat * i
					});
				}
			}
		}
	}
}
