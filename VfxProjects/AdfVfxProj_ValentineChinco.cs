using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using MagicShaper.AdfExtensions;
using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;

namespace MagicShaper.VfxProjects
{
    [SupportedOSPlatform("windows")]
    public static class AdfVfxProj_ValentineChinco
    {
        private static readonly Random Random = new();
        public static void ProjMain()
        {

			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\Valentine Chinco\level-base.adofai");
            chart.Decorations[0].DecorationImage = ""; // @nocheckin

            AutoSoundEvents(chart);
            AutoCameraShakeEvents(chart);
            chart.LyricWithTranslationImproved("lyric.txt", "Microsoft Yahei", "Microsoft Yahei", 0, 1650, 100, 
                4, 2, -50, "FFFFFF", "CCCCCCFF", -110);

            chart.ModernTrackAppear(0, 280, 4d, 12d, -0.2, 0.2, 0, 0.3, -10, 10, 90, 99, 50);
            chart.ModernTrackDisappear(0, 280, 4d, -2d, -0.1, 0.1, 0, 0.2, -10, 10, 90, 99, 50);

            CustomWobblyVideoFrames(chart, 127, 128d - 32d, 0.5d);

			ChorusFunction(chart);

			CustomWobblyVideoFrames(chart, 955, 32d, 2d, 235);
            chart.ModernTrackAppear(879, 1053, 4d, 12d, -0.2, 0.2, 0, 0.3, -10, 10, 90, 99, 50);
            chart.ModernTrackDisappear(879, 1053, 4d, -2d, -0.1, 0.1, 0, 0.2, -10, 10, 90, 99, 50);

			CustomWobblyVideoFrames(chart, 1654, 42d, 1d, 250);
            chart.ModernTrackAppear(1654, 2014, 4d, 12d, -0.2, 0.2, 0, 0.3, -10, 10, 90, 99, 50);
            chart.ModernTrackDisappear(1654, 2014, 4d, -2d, -0.1, 0.1, 0, 0.2, -10, 10, 90, 99, 50);

            for (int j = 0; j < 11; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    int midspinTile = 1729 + (j * 15) + (i * 2);
                    chart.ChartTiles[midspinTile].TileEvents.Add(new AdfEventMoveTrack()
                    {
                        Duration = 4d,
                        Ease = AdfEaseType.OutBack,
                        AngleOffset = 8 * -180d,
                        PositionOffset = new(0, -(0.2 * i) - 0.2)
                    });
                    chart.ChartTiles[midspinTile].TileEvents.Add(new AdfEventMoveTrack()
                    {
                        Duration = 2,
                        Ease = AdfEaseType.InBack,
                        AngleOffset = 2 * -180d,
                        PositionOffset = new(0, 0)
                    });
                    chart.ChartTiles[midspinTile].TileEvents.Add(new AdfEventRecolorTrack()
                    {
                        AngleOffset = -114514,
                        TrackStyle = AdfTrackStyle.NeonLight,
                        TrackColor = new("ffeaeeff"),
                    });
                }
            }
            for (int j = 0; j < 32; j++)
            {
                int startingTile = 2014 + (j * 11);
                for (int i = 0; i < 5; i++)
                {
                    int midspinTile = startingTile + (i * 2);
                    chart.ChartTiles[midspinTile].TileEvents.Add(new AdfEventMoveTrack()
                    {
                        Duration = 4d,
                        Ease = AdfEaseType.OutBack,
                        AngleOffset = 8 * -180d,
                        PositionOffset = new(0, -(0.8 * i) - 0.8),
                        RotationOffset = i * 15,
                        Scale = new(100 + (10 * i))
                    });
                    chart.ChartTiles[midspinTile].TileEvents.Add(new AdfEventMoveTrack()
                    {
                        Duration = 2,
                        Ease = AdfEaseType.InBack,
                        AngleOffset = 2 * -180d,
                        PositionOffset = new(0, 0),
                        RotationOffset = - i * 15,
                        Scale = new(100)
                    });
                    chart.ChartTiles[midspinTile].TileEvents.Add(new AdfEventRecolorTrack()
                    {
                        AngleOffset = -114514,
                        TrackStyle = AdfTrackStyle.NeonLight,
                        TrackColor = new("ffeaeeff"),
                    });
                }
            }

            CustomWobblyVideoFrames(chart, 2014, 128d, 1d, 250);
            chart.ModernTrackAppear(3100, 3594, 4d, 12d, -0.2, 0.2, 0, 0.3, -10, 10, 90, 99, 50);
            chart.ModernTrackDisappear(3100, 3594, 4d, -2d, -0.1, 0.1, 0, 0.2, -10, 10, 90, 99, 50);
            chart.FloatingTrackBackground(3282, 256d, "FFCE84FF", 250, 25, 60, 0.2, 0.8, 88, 92,
                -70, 20, -100, -30, 10, 80, depthOffset: -69);

			CustomWobblyVideoFrames(chart, 3370, 128d + 12d, 0.5d, 220);

            chart.RenderCreditRoleAndName(3593, "Track", "Sean Lenard B.", -1100, -1350, 0, 0, 999, 100);
            chart.RenderCreditRoleAndName(3593, "Visual", "quartrond", -600, -1350, 0, 0, 999, 100);

			File.WriteAllText(@"G:\Adofai levels\Valentine Chinco\level-fulleffect.adofai", chart.ChartJson.ToJsonString());
        }

        private static void AutoSoundEvents(AdfChart chart)
        {
            for (int i = 5; i < 121; i++)
            {
                if (chart.GetInnerAngleAtTile(i) <= 30d)
                {
                    chart.ChartTiles[i].TileEvents.Add(new AdfEventPlaySound()
                    {
                        Hitsound = AdfHitsoundType.KickChroma
                    });
					i++;
                }
            }
            for (int i = 0; i < 33; i++)  // this is 33 because the first beat is technically before the first bar
            {
                chart.ChartTiles[3].TileEvents.Add(new AdfEventPlaySound()
                {
                    Hitsound = AdfHitsoundType.SnareAcoustic2,
                    AngleOffset = i * 360 * 2
                });
            }
			for (int i = 183; i < 275; i++)
			{
				if (chart.GetInnerAngleAtTile(i) <= 30d)
				{
                    chart.ChartTiles[i].TileEvents.Add(new AdfEventPlaySound()
                    {
                        Hitsound = AdfHitsoundType.KickChroma,
                    });
					i++;
                }
            }
            for (int i = 3501; i < 3594; i++)
            {
                if (chart.GetInnerAngleAtTile(i) <= 30d)
                {
                    chart.ChartTiles[i].TileEvents.Add(new AdfEventPlaySound()
                    {
                        Hitsound = AdfHitsoundType.KickChroma
                    });
					i++;
                }
            }
            for (int i = 0; i < 14; i++)
            {
                chart.ChartTiles[3501].TileEvents.Add(new AdfEventPlaySound()
                {
                    Hitsound = AdfHitsoundType.SnareAcoustic2,
                    AngleOffset = (i * 360 * 2) + 360
                });
            }
        }

        private static void AutoCameraShakeEvents(AdfChart chart)
        {
            chart.CameraRotationPulseByBeats(8, 4d, 8, -3, 3, 190, 200, 8d);
            chart.CameraRotationPulseByBeats(65, 4d, 24, -3, 3, 220, 240, 8d);

			List<int> pulseTiles = [];
			for (int i = 183; i < 275; i++)
			{
				if (chart.GetInnerAngleAtTile(i) <= 30d)
				{
					pulseTiles.Add(i);
					i++;
				}
			}
            chart.CameraRotationPulseByTile(pulseTiles, -5, 5, 240, 255, 8d);
			pulseTiles.Clear();

			chart.CameraRotationPulseByBeats(3282, 2d, 8, -5, 5, 230, 250, 4d);
			for (int i = 3306; i < 3370; i++)
			{
				if (chart.GetInnerAngleAtTile(i) != 60d && chart.ChartTiles[i].TileEvents.Any(e => e is AdfEventPlaySound))
				{
					pulseTiles.Add(i);
				}
			}
            chart.CameraRotationPulseByTile(pulseTiles, -5, 5, 240, 260, 8d);
			pulseTiles.Clear();

            chart.CameraRotationPulseByBeats(3504, 4d, 8, -3, 3, 190, 220, 8d);
            chart.CameraRotationPulseByBeats(3559, 4d, 6, -3, 3, 190, 220, 8d);
        }

		private static void ChorusFunction(AdfChart chart)
		{
			// (1) 280-766-879
			for (int i = 0; i < 7; i++)
			{
				int midspinTile = 280 + (i * 2);
				chart.ChartTiles[midspinTile].TileEvents.Add(new AdfEventMoveTrack()
				{
					Duration = 4d,
					Ease = AdfEaseType.OutBack,
					AngleOffset = 8 * -180d,
                    PositionOffset = new(0, (0.4 * i) + 0.4)
				});
				chart.ChartTiles[midspinTile].TileEvents.Add(new AdfEventMoveTrack()
				{
					Duration = 2,
					Ease = AdfEaseType.InBack,
					AngleOffset = 2 * -180d,
					PositionOffset = new(0, 0)
				});
			}
			List<int> fireTiles = [];
			for (int i = 280; i < 766; i++)
			{
				bool isFireTile = false;
				foreach (var e in chart.ChartTiles[i].TileEvents)
				{
					if (e is AdfEventPlaySound eps && eps.Hitsound == AdfHitsoundType.KickChroma)
					{
						isFireTile = true;
					}
				}
				if (!isFireTile) { continue; }

				// map 280 <- 294, which is i-14
				fireTiles.Add(i - 14);
				chart.CameraRotationPulseByBeats(i - 14, 4d, 1, -2, 2, 230, 260, 8d);
				for (int j = 0; j < 7; j++)
				{
                    chart.ChartTiles[i - 14 + (2 * j)].TileEvents.Add(new AdfEventRecolorTrack()
                    {
                        AngleOffset = -114514,
                        TrackStyle = AdfTrackStyle.NeonLight,
                        TrackColor = new("ff4669ff")
                    });
                }
            }
			fireTiles.Add(766);
			chart.TrackDisappearExplosion(fireTiles, 4d, m: 0.2);
			fireTiles.Clear();
			chart.ModernTrackAppear(766, 879, 4d, 8d, -0.3, 0.3, -0.5, -0.2, -4, 4, 80, 95, 30);
			chart.ModernTrackDisappear(766, 879, 4d, -4d, -0.3, 0.3, 0.2, 0.5, -4, 4, 80, 95, 50);
			CustomWobblyVideoFrames(chart, 276, 4 + 64, 0.5d);
			CustomWobblyVideoFrames(chart, 781, 64d, 0.5d, 230d);
			for (int i = 0; i < 30; i++)
			{
				chart.ChartTiles[781].TileEvents.Add(new AdfEventPlaySound()
				{
					Hitsound = AdfHitsoundType.HatHouse,
					AngleOffset = (360 * i) + 180
				});
            }
            chart.ShapeFocusOnTileImproved("cue.png", 785, 2d, 29, 2d, 0, 500, -12, -10);
            for (int i = 766; i < 879; i++) {
				if (chart.GetInnerAngleAtTile(i) == 20d)
				{
					chart.CameraRotationPulseByBeats(i, 4d, 1, -5, 5, 225, 250, 4d);
					chart.ChartTiles[i].TileEvents.Add(new AdfEventPlaySound()
					{
						Hitsound = AdfHitsoundType.KickChroma
					});
					i++;
				}
			}

			// (1) 280-766-879
            // (2) 1053-1539-1654
            for (int i = 0; i < 7; i++)
            {
                int midspinTile = 1053 + (i * 2);
                chart.ChartTiles[midspinTile].TileEvents.Add(new AdfEventMoveTrack()
                {
                    Duration = 4d,
                    Ease = AdfEaseType.OutBack,
                    AngleOffset = 8 * -180d,
                    PositionOffset = new(0, (0.4 * i) + 0.4)
                });
                chart.ChartTiles[midspinTile].TileEvents.Add(new AdfEventMoveTrack()
                {
                    Duration = 2,
                    Ease = AdfEaseType.InBack,
                    AngleOffset = 2 * -180d,
                    PositionOffset = new(0, 0)
                });
                chart.ChartTiles[1053 + (2 * i)].TileEvents.Add(new AdfEventRecolorTrack()
                {
                    AngleOffset = -114514,
                    TrackStyle = AdfTrackStyle.Minimal,
                    TrackColor = new("ff4669ff"),
                });
            }
            for (int i = 0; i < 7; i++)
            {
                int midspinTile = 1053 + 16 + (i * 2);
                chart.ChartTiles[midspinTile].TileEvents.Add(new AdfEventMoveTrack()
                {
                    Duration = 4d,
                    Ease = AdfEaseType.OutBack,
                    AngleOffset = 8 * -180d,
                    PositionOffset = new(0, (0.3 * i) + 0.3)
                });
                chart.ChartTiles[midspinTile].TileEvents.Add(new AdfEventMoveTrack()
                {
                    Duration = 2,
                    Ease = AdfEaseType.InBack,
                    AngleOffset = 2 * -180d,
                    PositionOffset = new(0, 0)
                });
                chart.ChartTiles[1053 + (2 * i)].TileEvents.Add(new AdfEventRecolorTrack()
                {
                    AngleOffset = -114514,
                    TrackStyle = AdfTrackStyle.Minimal,
                    TrackColor = new("bb1116ff"),
                });
            }
            for (int i = 0; i < 7; i++)
            {
                int midspinTile = 1053 + 32 + (i * 2);
                chart.ChartTiles[midspinTile].TileEvents.Add(new AdfEventMoveTrack()
                {
                    Duration = 4d,
                    Ease = AdfEaseType.OutBack,
                    AngleOffset = 8 * -180d,
                    PositionOffset = new(0, (0.1 * i) + 0.1)
                });
                chart.ChartTiles[midspinTile].TileEvents.Add(new AdfEventMoveTrack()
                {
                    Duration = 2,
                    Ease = AdfEaseType.InBack,
                    AngleOffset = 2 * -180d,
                    PositionOffset = new(0, 0)
                });
                chart.ChartTiles[1053 + (2 * i)].TileEvents.Add(new AdfEventRecolorTrack()
                {
                    AngleOffset = -114514,
                    TrackStyle = AdfTrackStyle.Minimal,
                    TrackColor = new("330204ff"),
                });
            }
            for (int i = 1053; i < 1539; i++)
            {
                bool isFireTile = false;
                foreach (var e in chart.ChartTiles[i].TileEvents)
                {
                    if (e is AdfEventPlaySound eps && eps.Hitsound == AdfHitsoundType.KickChroma)
                    {
                        isFireTile = true;
                    }
                }
                if (!isFireTile) { continue; }

                fireTiles.Add(i - 14);
                chart.CameraRotationPulseByBeats(i - 14, 4d, 1, -2, 2, 230, 260, 8d);
            }
            fireTiles.Add(1539);
            chart.TrackDisappearExplosion(fireTiles, 4d, m: 0.2);
            fireTiles.Clear();
            chart.ModernTrackAppear(1539, 1654, 4d, 8d, -0.3, 0.3, -0.5, -0.2, -4, 4, 80, 95, 30);
            chart.ModernTrackDisappear(1539, 1654, 4d, -4d, -0.3, 0.3, 0.2, 0.5, -4, 4, 80, 95, 50);
            CustomWobblyVideoFrames(chart, 1041, 4 + (64 * 4), 0.25d);
            CustomWobblyVideoFrames(chart, 1554, 64d, 0.5d, 230d);
            for (int i = 0; i < 30; i++)
            {
                chart.ChartTiles[1554].TileEvents.Add(new AdfEventPlaySound()
                {
                    Hitsound = AdfHitsoundType.HatHouse,
                    AngleOffset = (360 * i) + 180
                });
            }
            chart.ShapeFocusOnTileImproved("cue.png", 1558, 2d, 29, 2d, 0, 500, -12, -10);
            for (int i = 1539; i < 1654; i++)
            {
                if (chart.GetInnerAngleAtTile(i) == 20d)
                {
                    chart.CameraRotationPulseByBeats(i, 4d, 1, -5, 5, 225, 250, 4d);
                    chart.ChartTiles[i].TileEvents.Add(new AdfEventPlaySound()
                    {
                        Hitsound = AdfHitsoundType.KickChroma
                    });
                    i++;
                }
            }

			// (3)
            for (int i = 0; i < 28; i++)
            {
                chart.ChartTiles[3370].TileEvents.Add(new AdfEventPlaySound()
                {
                    Hitsound = AdfHitsoundType.HatHouse,
                    AngleOffset = (360 * i) + 180
                });
            }
            chart.ShapeFocusOnTileImproved("cue.png", 3372, 2d, 29, 2d, 0, 500, -12, -10);
            for (int i = 3370; i < 3458; i++)
            {
                if (chart.GetInnerAngleAtTile(i) == 20d)
                {
                    chart.CameraRotationPulseByBeats(i, 4d, 1, -5, 5, 225, 250, 4d);
                    chart.ChartTiles[i].TileEvents.Add(new AdfEventPlaySound()
                    {
                        Hitsound = AdfHitsoundType.KickChroma
                    });
                    i++;
                }
            }
        }


        private static void LyricWithTranslationImproved(this AdfChart chart,
			string lyricFileName, string mainFont = "Bahnschrift", string translationFont = "方正楷体_GBK",
			int positionXPixel = 0, int positionYPixel = -1200, double scale = 100d,
			double inDuration = 2d, double outDuration = 2d, int depthOffset = 0,
			string mainColor = "FFFFFFFF", string translationColor = "88888899",
			int translationYOffset = 50)
		{
			string[] lyrics = File.ReadAllLines(chart.FileLocation?.Parent?.FullName + $"\\{lyricFileName}");
			try
			{
				string gid = "chinco";  // We can set this because this is a fixed project, avoiding polluting my workspace.

				chart.AddDecorationToChart(new()
				{
					Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_main",
					Depth = ExtensionSharedConstants.LyricsDepth + depthOffset,
					LockRotation = true,
					LockScale = true,
					Position = new((double)positionXPixel / ExtensionSharedConstants.TileWidth,
							(double)positionYPixel / ExtensionSharedConstants.TileWidth),
					Scale = new(scale),
					RelativeTo = AdfMoveDecorationRelativeToType.Camera,
					Opacity = 0d,
					Color = new(mainColor)
				});
				chart.AddDecorationToChart(new()
				{
					Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_translation",
					Depth = ExtensionSharedConstants.LyricsDepth + depthOffset + 1,
					LockRotation = true,
					LockScale = true,
					Position = new((double)positionXPixel / ExtensionSharedConstants.TileWidth,
							(double)(positionYPixel + translationYOffset)/ ExtensionSharedConstants.TileWidth),
					Scale = new(scale * 0.6d),
					RelativeTo = AdfMoveDecorationRelativeToType.Camera,
					Opacity = 0d,
					Color = new(translationColor)
				});

				


				double standardBpm = chart.GetTileBpmAt(0);

				for (int i = 0; i < lyrics.Length; i += 3)
				{
					int tile = int.Parse(lyrics[i]);

					TextRenderExtension.Convert(lyrics[i+1], 
						chart.FileLocation?.Parent?.FullName + $"\\z-{ExtensionSharedConstants.LyricsTagPrefix}_{lyricFileName}_{i}_main.png", 
						mainFont);
					TextRenderExtension.Convert(lyrics[i+2], 
						chart.FileLocation?.Parent?.FullName + $"\\z-{ExtensionSharedConstants.LyricsTagPrefix}_{lyricFileName}_{i}_translation.png", 
						translationFont);





					chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Duration = outDuration * chart.GetTileBpmAt(tile) / standardBpm,
						Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_main {ExtensionSharedConstants.LyricsTagPrefix}_{gid}_translation",
						Opacity = 0d,
						AngleOffset = -180d * outDuration * chart.GetTileBpmAt(tile) / standardBpm
					});
					chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Duration = outDuration * chart.GetTileBpmAt(tile) / standardBpm,
						Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_main {ExtensionSharedConstants.LyricsTagPrefix}_{gid}_translation",
						PositionOffset = new(0, 1),
						AngleOffset = -180d * outDuration * chart.GetTileBpmAt(tile) / standardBpm,
						Ease = AdfEaseType.InCirc
					});
					
					
					chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Duration = 0d,
						DecorationImage = $"z-{ExtensionSharedConstants.LyricsTagPrefix}_{lyricFileName}_{i}_main.png",
						Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_main",
					});
					chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Duration = 0d,
						DecorationImage = $"z-{ExtensionSharedConstants.LyricsTagPrefix}_{lyricFileName}_{i}_translation.png",
						Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_translation",
					});
					
					chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Duration = inDuration * chart.GetTileBpmAt(tile) / standardBpm,
						Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_main {ExtensionSharedConstants.LyricsTagPrefix}_{gid}_translation",
						Opacity = 100d,
					});
					chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Duration = inDuration * chart.GetTileBpmAt(tile) / standardBpm,
						Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_main {ExtensionSharedConstants.LyricsTagPrefix}_{gid}_translation",
						PositionOffset = new(0, -1),
						Ease = AdfEaseType.OutBack
					});
				}
			}
			catch { Console.WriteLine("LyricWithTranslation Exception thrown."); }
		}
		private static void CustomWobblyVideoFrames(AdfChart chart, int tileStart, double durationBeats, double framePerBeat, double scale = 300)
		{
            chart.AddVideoFramesToChart("video dont include.mp4", tileStart, durationBeats, framePerBeat, "video", 1.245);
            for (int i = 0; i < durationBeats * framePerBeat; i++) {
				byte randomGB = (byte)Random.RandBetween(240, 256);
                chart.ChartTiles[tileStart].TileEvents.Add(new AdfEventMoveDecorations()
                {
                    Tag = "video",
                    Duration = 0,
                    RotationOffset = Random.RandBetween(-2, 2),
                    Scale = new(Random.RandBetween(scale, scale + 20)),
                    AngleOffset = i * 180 / framePerBeat,
                    Color = new("FFFFFF") { B = randomGB, G = randomGB }
                });
            }
		}
		private static void ShapeFocusOnTileImproved(this AdfChart chart,
            string outImageName, int targetTile, double outBeats,
			int repeatTimes, double intervalBeats,
            double outRotation = 60d, double outSize = 200d,
			double xRelativeToScreen = 0d, double yRelativeToScreen = 0d)
		{
			Random random = new();
			string gid = random.Next(1000000).ToString().PadLeft(6, '0');

			chart.AddDecorationToChart(new()
			{
				DecorationImage = outImageName,
				Opacity = 0d,
				Tag = $"{ExtensionSharedConstants.ShapeFocusOnTileTagPrefix}_{gid}_out",
				RelativeTo = AdfMoveDecorationRelativeToType.Camera,
				Position = new(xRelativeToScreen, yRelativeToScreen),
				Floor = targetTile,
				Depth = 1,
				Scale = new(0)
			});

            for (int i = 0; i < repeatTimes; i++)
            {
                chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
                {
                    Duration = 0d,
                    Opacity = 100,
                    Tag = $"{ExtensionSharedConstants.ShapeFocusOnTileTagPrefix}_{gid}_out",
					AngleOffset = i * intervalBeats * 180d
                });
                chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
                {
                    Ease = AdfEaseType.OutCubic,
                    RotationOffset = outRotation,
                    Scale = new(outSize),
                    Duration = outBeats,
                    Opacity = 0,
                    Tag = $"{ExtensionSharedConstants.ShapeFocusOnTileTagPrefix}_{gid}_out",
					AngleOffset = i * intervalBeats * 180d
                });
				chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Duration = 0d,
					Opacity = 0,
					Scale = new(0),
                    Tag = $"{ExtensionSharedConstants.ShapeFocusOnTileTagPrefix}_{gid}_out",
					AngleOffset = (i * intervalBeats * 180d) + (outBeats * 180d)
				});
            }
        }
    }
}
