using MagicShaper.AdfExtensions;
using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects
{
	[SupportedOSPlatform("windows")]
	internal class AdfVfxProj_ACC2024Final
	{
		public static void ProjMain()
		{
			VFX();
		}

		public static void Snowflake()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\ACC2024 Final\level-loweffect.adofai");

			// chart.MagicShape(420, true, 25, 61);
			// chart.MagicShape(960, false, 582, 621);
			// chart.MagicShape(960, true, 3097, 3337);

			// chart.SetupVisionLimit();
			// chart.SetVisionLimitAutofit("banner.png", 0);

			// chart.SetupDecoBgImage();
			// chart.SetDecoBgImageAutofit("00024.png", 0);
			File.WriteAllText(@"G:\Adofai levels\ACC2024 Final\level-magicshape-loweffect.adofai", chart.ChartJson.ToJsonString());
		}

		public static void VFX()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\ACC2024 Final\level-loweffect.adofai");

			AddAutoCues(chart);

			#region BACKGROUND
			chart.BackgroundDim(40, 0);
			chart.BackgroundDimPulseMultipleByBeat(60, 40, 13, 7, 12d, 8d);
			chart.BackgroundDimPulse(0, 60, 105, 8d);
			chart.BackgroundDimPulse(0, 40, 201, 8d);
			chart.BackgroundDimPulse(0, 30, 508, 8d);
			chart.BackgroundDimPulse(0, 60, 868, 4d);
			chart.BackgroundDim(20, 1708, 0);
			chart.BackgroundDim(60, 2166);
			chart.BackgroundDimPulse(0, 60, 2487, 8d);
			chart.BackgroundDimPulse(0, 20, 2783, 8d);
			chart.BackgroundDim(60, 3076, 16d);
			chart.BackgroundDimPulseMultipleByBeat(0, 60, 3100, 31, 8d * 135 / 180, 4d);
			chart.BackgroundDimPulse(0, 30, 3416, 8d);
			chart.BackgroundDimPulse(-100, 0, 3851, 32d);
			#endregion



			#region BACKGROUND_TRACK

			chart.FloatingTrackBackground(105, 64d, "FFFFFFFF", maxSize: 150, ymin: -150, ymax: 20);
			chart.FloatingTrackBackground(508, 256d, "FFFFFFFF", minSize: 125, maxSize: 175, 
				xmin: -60, xmax: 40, ymin: -250, ymax: 20, upliftSpeedMinTilePerBeat: 0.25, upliftSpeedMaxTilePerBeat: 0.75);
			
			chart.FloatingTrackBackground(2487, 256d, "FFFFFFFF", minSize: 125, maxSize: 175, 
				xmin: -50, xmax: 70, ymin: -250, ymax: 20, upliftSpeedMinTilePerBeat: 0.25, upliftSpeedMaxTilePerBeat: 0.75);
			#endregion



			#region TRACK
			chart.TrackAppearUplift(0, 13, 8d, 12d);
			chart.TrackDisappearUplift(0, 105, 8d);
			chart.TrackAppearUplift(49, 105, 8d, 12d);

			chart.TrackAppearUplift(105, 201, 8d, 12d, endOpacity: 200);
			chart.TrackDisappearUplift(105, 201, 8d);

			chart.ModernTrackAppear(201, 406, 6d, 12d, xmin: -30, xmax: 30, ymin: -10, ymax: -5, endOpacity: 120);
			chart.ModernTrackDisappear(201, 406, 4d, 1d, xmin: -30, xmax: 30, ymin: 10, ymax: 15);

			List<int> list1 = new();
			for (int i = 0; i < 7; i++)
			{
				list1.Add(406 + 14 * i);
			}
			chart.TrackAppearExplosion(list1, 8d, 8d);
			chart.TrackDisappearExplosion(list1, 8d, yBias: 10);


			chart.ModernTrackDisappear(493, 868, 4d, 0d, ymax: 10, ymin: 5, smin: 150, smax: 250);
			chart.ModernTrackAppear(493, 508, 8d, 8d, endOpacity: 125);
			for (int i = 0; i < 4; i++)
			{
				
				int p = i % 2 == 0 ? 1 : -1;
				chart.ModernTrackAppear(508 + 19 * i, 527 + 19 * i, 8d, 8d, xmin: -20 * p, xmax: -10 * p, ymin: -5, ymax: -2, 
					rmin: -90 * p, rmax: -30 * p, smin: 150, smax: 200, endOpacity: 125);
			}
			chart.TrackAppearExplosion(new() { 584, 646 }, 8d, 16d, endOpacity: 200);

			chart.ModernTrackAppear(868, 1210, 8d, 12d, xmin: -20, xmax: -10, ymin: -5, ymax: -2, rmin: -120, rmax: -90, smin: 50, smax: 75, endOpacity: 150);
			chart.ModernTrackDisappear(868, 1210, 8d, -6d, xmin: 10, xmax: 20, ymin: 2, ymax: 5, rmin: 40, rmax: 60, smin: 50, smax: 75);

			chart.ModernTrackAppear(1210, 1708, 8d, 4d, endOpacity: 200);
			chart.ModernTrackDisappear(1210, 1708, 8d, -8d);

			List<int> list9 = new();
			for (int i = 1219; i < 1667; i++)
			{
				foreach (var e in chart.ChartTiles[i].TileEvents)
				{
					if (e is AdfEventColorTrack ee && ee.TrackStyle == AdfTrackStyle.Neon)
					{
						list9.Add(i);
					}
				}
			}
			for (int i = 0; i < list9.Count / 2; i++)
			{
				for (int j = list9[i * 2]; j < list9[i * 2 + 1]; j++)
				{
					chart.ChartTiles[j].TileEvents.Add(new AdfEventRecolorTrack() { TrackGlowIntensity = 0, TrackStyle = AdfTrackStyle.NeonLight, Duration = 2d });
				}
			}




			chart.ModernTrackAppear(1708, 1768, 4d, 8d, -2, 2, -2, -1, -30, 30, 50, 80, endOpacity: 200);
			chart.ModernTrackDisappear(1708, 1768, 4d, 0d, -2, 2, 1, 2, -30, 30, 110, 130);

			chart.ModernTrackAppear(1768, 1926, 8d, 4d, 3, 5, 1, 2, 50, 60, 120, 150, endOpacity: 200);
			chart.ModernTrackDisappear(1768, 1926, 6d, -4d, 3, 5, 1, 2, 50, 60, 120, 150);

			chart.ModernTrackAppear(1926, 2112, 4d, 8d, -0.5, 0.5, 0.5, 1, -15, 15, 75, 95);
			chart.ModernTrackDisappear(1926, 2112, 4d, -4d, -0.5, 0.5, -1, -0.5, -15, 15, 75, 95);

			chart.ModernTrackAppear(2166, 2487, 8d, 8d, -5, 5, -2, -1, -30, 30, 50, 80);
			chart.ModernTrackDisappear(2166, 2487, 8d, -8d, -5, 5, 1, 2, -30, 30, 110, 130);

			List<int> list11 = new();
			for (int i = 2487; i < 2773; i++)
			{
				if (chart.GetInnerAngleAtTile(i) == 30d)
				{
					list11.Add(i); i++;
				}
			}
			list11.Add(2773);
			chart.TrackAppearExplosion(list11, 2d, 12d, m: 0.3);
			chart.TrackDisappearExplosion(list11, 3d, yBias: 3, m: 0.3);


			chart.ModernTrackAppear(2773, 3100, 8d, 8d, 10, 15, 5, 8, 45, 60, 150, 250);
			chart.ModernTrackDisappear(2773, 3100, 8d, -6d, -20, -15, 5, 8, 45, 60, 150, 250);


			chart.TrackAppearExplosion(new() { 3100, 3428 }, 8d, 72d);

			List<int> list12 = new();
			for (int i = 3099; i < 3404; i++)
			{
				if (chart.ChartTiles[i + 1].TargetAngle == 999)
				{
					list12.Add(i);
				}
			}
			list12.Add(3404);
			chart.TrackDisappearExplosion(list12, 4d, yBias: 5);

			chart.ModernTrackAppear(3404, 3851, 4d, 12d);
			chart.ModernTrackDisappear(3404, 3851, 2d, 0d, ymin: 10, ymax: 20);
			#endregion



			#region CAMERA
			chart.CameraMoveRelativeToPlayer(0, 0d, 0, 0);
			chart.CameraTiltAndDiveTransition(1, 30, 300, 4d, 8d);

			chart.CameraMoveRelativeToTile(13, 12d, -1, 0);

			chart.CameraHoverAndTiltToTileTransition(49, -10, 300, 175, 12d, 16d);
			for (int i = 0; i < 6; i++)
			{
				chart.CameraMoveRelativeToTile(56 + 7 * i, 12d, 0, -4);
			}
			chart.CameraMoveRelativeToPlayer(98, 12d, 0, -5);
			chart.CameraRandomWobble(-2, 2, -4, -2, -5, 5, 230, 300, 8d, 12d, 0d, 4d, 60d, 105);

			chart.CameraRandomWobble(-5, 5, -4, -1, -5, 5, 280, 370, 12d, 12d, 4d, 4d, 128d - 6d, 201, AdfEaseType.OutCubic);

			for (int i = 0; i < 4; i++)
			{
				chart.CameraHoverAndTiltToTileTransition(342 + i * 16, 10 * (i % 2 == 1 ? -1 : 1), 270, 180, 4d, 12d);
				chart.CameraMoveRelativeToTile(350 + i * 16, 4d, 0, -2, ease: AdfEaseType.OutCirc);
			}
			chart.CameraMoveRelativeToPlayer(406, 4d, 0, -2);;

			chart.CameraHoverAndTiltToTileTransition(584, -5, 300, 150, 16d, 16d, 0.5, -3);
			chart.CameraMoveRelativeToPlayer(648, 16d, y: -3, ease: AdfEaseType.OutCirc);

			chart.CameraHoverAndTiltToTileTransition(789, 5, 400, 250, 16d, 16d, finaly: -8, outEase: AdfEaseType.OutCirc);
			chart.CameraMoveRelativeToTile(807, 16d, y: -8, ease: AdfEaseType.OutCirc);
			chart.CameraMoveRelativeToTile(825, 16d, y: -6, ease: AdfEaseType.OutCirc);
			chart.CameraHoverAndTiltToTileTransition(868, -5, 300, 50, 8d, 16d, finaly: -3, outEase: AdfEaseType.OutBack);
			chart.CameraMoveRelativeToPlayer(868, 16d, ease: AdfEaseType.OutCubic, y: -3);

			chart.RandomCamera(-4, 4, -5, -2, -8, 8, 250, 350, 20d, 12d, 256d - 32d, 911, ease: AdfEaseType.OutCubic);

			List<int> list2 = new();
			for (int i = 0; i < 4; i++)
			{
				list2.Add(1210 + i * 25);
			}
			List<int> list3 = new();
			for (int i = 0; i < 4; i++)
			{
				list3.Add(1310 + i * 25);
			}
			List<int> list4 = new();
			for (int i = 0; i < 4; i++)
			{
				list4.Add(1410 + i * 25);
			}
			List<int> list5 = new();
			for (int i = 0; i < 7; i++)
			{
				list5.Add(1510 + i * 26);
			}
			// list5.Add(1687);
			chart.CameraMoveToTileRandomOutEase(list2, -3, 3, -7, -5, -5, 5, 250, 320,
				8d, 8d, true, blurIntensity: 500);
			chart.CameraMoveToTileRandomOutEase(list3, -3, 3, -7, -5, -3, 3, 280, 370,
				16d, 16d, true, blurIntensity: 500);
			chart.CameraMoveToTileRandomOutEase(list4, 6, 9, -7, -5, -3, 3, 280, 370,
				16d, 16d, true, blurIntensity: 500);
			chart.CameraMoveToTileRandomOutEase(list5, -2, 2, -7, -5, -3, 3, 280, 370,
				16d, 16d, true, blurIntensity: 500);

			chart.CameraTiltAndDiveTransition(1708, -25, 200, 4d, 4d);
			List<int> list6 = new();
			for (int i = 1712; i < 1761; i++)
			{
				foreach (var e in chart.ChartTiles[i].TileEvents)
				{
					if (e is AdfEventColorTrack ee && ee.TrackStyle == AdfTrackStyle.Neon)
					{
						list6.Add(i);
					}
				}
			}
			chart.CameraMoveToTileRandomOutEase(list6, 0, 0, -2, -2, 0, 0, 200, 250, 4d, 4d, true, 300);
			chart.CameraMoveRelativeToPlayer(1761, 4d, y: -2);


			List<int> list7 = new();
			for (int i = 1768; i < 1926; i++)
			{
				foreach (var e in chart.ChartTiles[i].TileEvents)
				{
					if (e is AdfEventColorTrack ee && ee.TrackStyle == AdfTrackStyle.Neon)
					{
						list7.Add(i);
					}
				}
			}
			chart.CameraRotationPulseByTile(list7, -25, 25, 230, 300, 8d);

			chart.CameraRandomWobble(-1, 1, -3, -2, -5, 5, 260, 320, 18, 24, 0, 0, 64d, 1926);

			chart.CameraRotationPulseByTile(new() { 2100 }, -25, -25, 200, 350, 8d);

			for (int i = 2112; i < 2166; i++)
			{
				chart.CameraMoveRelativeToTile(i, 0, y: -3);
			}

			List<int> list8 = new();
			for (int i = 2167; i < 2487; i++)
			{
				foreach (var e in chart.ChartTiles[i].TileEvents)
				{
					if (e is AdfEventColorTrack ee && ee.TrackStyle == AdfTrackStyle.NeonLight)
					{
						list8.Add(i);
					}
				}
			}
			chart.CameraTiltAndDiveTransition(2166, 50, 300, 8d, 16d, inEase: AdfEaseType.InExpo);
			chart.CameraMoveRelativeToPlayer(2166, 0d, y: -3);
			chart.CameraRotationPulseByTile(list8, -15, 15, 220, 300, 16d);

			List<int> list10 = new();
			for (int i = 2487; i < 2773; i++)
			{
				if (chart.GetInnerAngleAtTile(i) == 30d)
				{
					list10.Add(i); i++;
				}
			}
			chart.CameraRotationPulseByTile(list10, -5, 5, 280, 300, 6d);

			chart.CameraRandomWobble(2, 7, -3, -1, -10, 10, 270, 450, 12d, 12d, 20d, 20d, 256d, 2783, AdfEaseType.OutCubic);

			chart.CameraHoverAndTiltToTileTransition(3100, -50, 400, 1, 16d, 64d, 0.5, 0, AdfEaseType.InExpo);

			chart.CameraTiltAndDiveTransition(3404, -15, 350, 16d, 16d, AdfEaseType.InExpo);
			chart.CameraMoveRelativeToPlayer(3404, 16d, y: -5);
			#endregion






			#region FILTERS
			chart.BlurByBeatOutEase(201, 8, 16d, 12d);
			FilterComboDurate(chart, 342, 16d, 4);
			for (int i = 0; i < 7; i++)
			{
				FilterCombo(chart, 406 + 14 * i);
			}
			FilterComboDurate(chart, 527, 32d, 8, 2);
			FilterCombo(chart, 508);

			chart.BlurByBeatOutEase(868, 8, 32d, 24d);

			chart.ChartTiles[1708].TileEvents.Add(new AdfEventSetFilter() { Filter = AdfFilter.VHS, Intensity = 15 });
			chart.ChartTiles[1768].TileEvents.Add(new AdfEventSetFilter() { Filter = AdfFilter.VHS, Enabled = false });

			FilterComboDurate(chart, 1768, 16d, 8);

			FilterComboDurate(chart, 2322, 32d, 4, 4);
			FilterComboDurate(chart, 2487, 16d, 32, 2);

			chart.BlurByBeatOutEase(2783, 8, 32d, 20d, 1000);

			FilterComboDurate(chart, 3100, 8d * 135 / 180, 32);

			FilterComboDurate(chart, 3428, 8d, 32, m: 1.5);
			#endregion



			#region CUES
			for (int i = 1926; i < 2111; i++)
			{
				if (chart.GetInnerAngleAtTile(i) == 90d)
				{
					chart.ShapeFocusOnTile("", "wave.png", i, 16d * chart.GetTileBpmAt(i) / 960d, 8d * chart.GetTileBpmAt(i) / 960d, inSize: 700, outSize: 400);
					i++;
				}
			}

			for (int i = 3099; i < 3404; i++)
			{
				if (chart.ChartTiles[i + 1].TargetAngle == 999)
				{
					chart.ShapeFocusOnTile("cue.png", "wave.png", i, 8d * chart.GetTileBpmAt(i) / 960d, 8d * chart.GetTileBpmAt(i) / 960d);
					chart.ChartTiles[i].TileEvents.Add(new AdfEventColorTrack() { TrackTexture = "t.png", TrackStyle = AdfTrackStyle.Neon, TrackColor = new("ffffff"), TrackGlowIntensity = 0 });
					chart.ChartTiles[i + 1].TileEvents.Add(new AdfEventColorTrack() { TrackTexture = "t.png", TrackStyle = AdfTrackStyle.NeonLight, TrackColor = new("ffffff"), TrackGlowIntensity = 0 });
				}
			}


			#endregion

			#region TEXTRENDER
			

			chart.RenderCreditRoleAndName(3851, "Track", "Sean Lenard B.", -720, -960, 64, 64, 1024, 200, font: "Gotham Bold");
			chart.RenderCreditRoleAndName(3851, "Visual", "quartrond", 720, -960, 64, 64, 1024, 200, font: "Gotham Bold");


			#endregion


			File.WriteAllText(@"G:\Adofai levels\ACC2024 Final\level-effect.adofai", chart.ChartJson.ToJsonString());
		}

		private static void AddAutoCues(AdfChart chart)
		{
			int starter = -1;
			for (int i = 0; i < chart.ChartTiles.Count; i++)
			{
				int ev = 0;
				
				foreach (var e in chart.ChartTiles[i].TileEvents)
				{
					if (e is AdfEventAutoPlayTiles ee)
					{
						if (ee.Enabled)
						{
							starter = i;
							ev = 1;
						}
						else
						{
							ev = 2;
						}
					}
				}
				if (ev == 1)
				{
					chart.ChartTiles[i].TileEvents.Add(new AdfEventSetHitsound() { Hitsound = AdfHitsoundType.VehiclePositive });
					chart.ChartTiles[i + 1].TileEvents.Add(new AdfEventSetHitsound() { Hitsound = AdfHitsoundType.Kick, HitsoundVolume = 50 });
					chart.ChartTiles[i + 2].TileEvents.Add(new AdfEventSetHitsound() { Hitsound = AdfHitsoundType.Kick, HitsoundVolume = 50, GameSound = AdfGameSoundType.Midspin });
				}
				else if (ev == 2)
				{
					chart.ChartTiles[i - 1].TileEvents.Add(new AdfEventSetHitsound() { Hitsound = AdfHitsoundType.VehicleNegative });
					chart.ChartTiles[i].TileEvents.Add(new AdfEventSetHitsound() { Hitsound = AdfHitsoundType.Kick, HitsoundVolume = 50 });
					chart.ChartTiles[i + 1].TileEvents.Add(new AdfEventSetHitsound() { Hitsound = AdfHitsoundType.Kick, HitsoundVolume = 50, GameSound = AdfGameSoundType.Midspin });



					// auto icon
					chart.AddDecorationToChart(new() { 
						Opacity = 0, DecorationImage = "", Tag = $"quartrond_otto_{i}", 
						RelativeTo = AdfMoveDecorationRelativeToType.Camera, Position = new(0, 6), Scale = new(200),
						LockRotation = true, LockScale = true
					});

					bool isOttoLeft = true;
					chart.ChartTiles[starter].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Tag = $"quartrond_otto_{i}",
						AngleOffset = -180d * 8 / 160 * chart.GetTileBpmAt(starter),
						DecorationImage = "otto_off.png",
						Duration = 4d / 160 * chart.GetTileBpmAt(starter),
						Opacity = 30
					});

					for (int j = starter; j < i - 1; j++)
					{
						chart.ChartTiles[j].TileEvents.Add(new AdfEventMoveDecorations()
						{
							Tag = $"quartrond_otto_{i}",
							DecorationImage = $"otto_{(isOttoLeft ? "left" : "right")}.png",
							Opacity = 100
						});
						isOttoLeft = !isOttoLeft;
					}
					chart.ChartTiles[i - 1].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Tag = $"quartrond_otto_{i}",
						DecorationImage = "otto_off.png",
						Opacity = 30,
						Duration = 0
					});
					chart.ChartTiles[i - 1].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Tag = $"quartrond_otto_{i}",
						AngleOffset = 180d * 4 / 160 * chart.GetTileBpmAt(i - 1),
						Opacity = 0,
						Duration = 4d / 160 * chart.GetTileBpmAt(i - 1)
					});

				}
			}





			for (int i = 3104; i < 3404; i++)
			{
				if (chart.ChartTiles[i + 1].TargetAngle == 999)
				{
					chart.ChartTiles[i].TileEvents.Add(new AdfEventSetHitsound() { Hitsound = AdfHitsoundType.KickChroma });
					chart.ChartTiles[i + 1].TileEvents.Add(new AdfEventSetHitsound() { Hitsound = AdfHitsoundType.Kick, HitsoundVolume = 50, GameSound = AdfGameSoundType.Midspin });
					chart.ChartTiles[i + 2].TileEvents.Add(new AdfEventSetHitsound() { Hitsound = AdfHitsoundType.Kick, HitsoundVolume = 50 });
				}
			}

		}

		private static void FilterCombo(AdfChart chart, int tile)
		{
			chart.ChartTiles[tile].TileEvents.Add(new AdfEventSetFilter() { Filter = AdfFilter.Aberration, Duration = 0, Intensity = 70 });
			chart.ChartTiles[tile].TileEvents.Add(new AdfEventSetFilter() { Filter = AdfFilter.Aberration, Duration = 16, Intensity = 52, Ease = AdfEaseType.OutExpo });
			chart.ChartTiles[tile].TileEvents.Add(new AdfEventSetFilter() { Filter = AdfFilter.MotionBlur, Duration = 0, Intensity = 1000 });
			chart.ChartTiles[tile].TileEvents.Add(new AdfEventSetFilter() { Filter = AdfFilter.MotionBlur, Duration = 16, Intensity = 0, Ease = AdfEaseType.OutExpo });
			chart.ChartTiles[tile].TileEvents.Add(new AdfEventSetFilter() { Filter = AdfFilter.Fisheye, Duration = 0, Intensity = 70 });
			chart.ChartTiles[tile].TileEvents.Add(new AdfEventSetFilter() { Filter = AdfFilter.Fisheye, Duration = 16, Intensity = 50, Ease = AdfEaseType.OutExpo });
			chart.ChartTiles[tile].TileEvents.Add(new AdfEventFlash() { Plane = AdfFlashPlaneType.Foreground, Duration = 16, StartOpacity = 10, EndOpacity = 0, Ease = AdfEaseType.OutExpo });
		}

		private static void FilterComboDurate(AdfChart chart, int tile, double intervalBeats, int repetition, double m = 1)
		{
			for (int i = 0; i < repetition; i++)
			{
				chart.ChartTiles[tile].TileEvents.Add(new AdfEventSetFilter() { AngleOffset = 180d * intervalBeats * i, Filter = AdfFilter.Aberration, Duration = 0, Intensity = 70 });
				chart.ChartTiles[tile].TileEvents.Add(new AdfEventSetFilter() { AngleOffset = 180d * intervalBeats * i, Filter = AdfFilter.Aberration, Duration = 16 * m, Intensity = 52, Ease = AdfEaseType.OutExpo });
				chart.ChartTiles[tile].TileEvents.Add(new AdfEventSetFilter() { AngleOffset = 180d * intervalBeats * i, Filter = AdfFilter.MotionBlur, Duration = 0, Intensity = 1000 });
				chart.ChartTiles[tile].TileEvents.Add(new AdfEventSetFilter() { AngleOffset = 180d * intervalBeats * i, Filter = AdfFilter.MotionBlur, Duration = 16 * m, Intensity = 0, Ease = AdfEaseType.OutExpo });
				chart.ChartTiles[tile].TileEvents.Add(new AdfEventSetFilter() { AngleOffset = 180d * intervalBeats * i, Filter = AdfFilter.Fisheye, Duration = 0, Intensity = 70 });
				chart.ChartTiles[tile].TileEvents.Add(new AdfEventSetFilter() { AngleOffset = 180d * intervalBeats * i, Filter = AdfFilter.Fisheye, Duration = 16 * m, Intensity = 50, Ease = AdfEaseType.OutExpo });
				chart.ChartTiles[tile].TileEvents.Add(new AdfEventFlash() { AngleOffset = 180d * intervalBeats * i, Plane = AdfFlashPlaneType.Foreground, Duration = 16 * m, StartOpacity = 10, EndOpacity = 0, Ease = AdfEaseType.OutExpo });
			}
		}
	}
}
