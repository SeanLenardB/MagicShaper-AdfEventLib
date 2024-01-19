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
	internal class AdfVfxProj_DragonheartedEX
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\Dragonhearted EX\level.adofai");

			#region INTRO_MAGICSHAPE

			chart.CameraMoveRelativeToTile(0, 0, -0.5, -0.5);
			chart.CameraTiltAndDiveTransition(1, 20d, 380d, 4d, 32d);

			// chart.ChartTiles[1].TileEvents.Add(new AdfEventHallOfMirrors() { Enabled = true });
			chart.ChartTiles[1].TileEvents.Add(new AdfEventBloom() { Threshold = 0d, Intensity = 150d });
			chart.BasicAtmosphereFilters(1, grayscaleIntensity: 100, rainIntensity: 0d);


			chart.MovingParticlesBackground(new() { "fog.png" },
				1, 128d, new("555555FF"), upliftSpeedMinTilePerBeat: 1d, upliftSpeedMaxTilePerBeat: 3d,
				imageOpacityMin: 10, imageOpacityMax: 40, imageScaleMin: 200, imageScaleMax: 800, layers: 5, directionMin: 45d, directionMax: 135d);
			chart.MovingParticlesBackground(new() { "field1.png", "field2.png", "chunk (1).png", "chunk (2).png", "chunk (3).png", "chunk (4).png" },
				1, 128d, new("000000FF"),
				imageOpacityMin: 20, imageOpacityMax: 60, imageScaleMin: 600, imageScaleMax: 1200, layers: 6, directionMin: 75d, directionMax: 105d);
			chart.MovingParticlesForeground(new() { "field1.png", "field2.png", "chunk (1).png", "chunk (2).png", "chunk (3).png", "chunk (4).png" },
				1, 128d, new("222222FF"), upliftSpeedMinTilePerBeat: 3d, upliftSpeedMaxTilePerBeat: 5d,
				imageOpacityMin: 10, imageOpacityMax: 30, imageScaleMin: 1500, imageScaleMax: 2500, layers: 4, directionMin: 80d, directionMax: 100d);


			chart.FloatingTrackBackground(1, 128d, 
				totalTracks: 150, maxSize: 250, minSize: 10, ymin: -300, ymax: 50, xmin: -80d, xmax: 80d, 
				directionMax: 100d, directionMin: 80d, opacityMax: 60d, opacityMin: 5d);

			chart.RenderTextCentered(1, "Dragonhearted EX", 0, 1100,
				inDuration: 4d, outDuration: 8d, holdDuration: 64 - 12);
			chart.RenderCreditRoleAndName(64, "Artist", "TryHardNinja", 0, 0, scale: 230d,
				inDuration: 4d, outDuration: 4d, holdDuration: 24);
			
			chart.RenderCreditRoleAndName(96, "Track", "Sean Lenard B.", -1000, 0, scale: 150d,
				inDuration: 4d, outDuration: 4d, holdDuration: 20);
			chart.RenderCreditRoleAndName(96, "Visual", "quartrond", 1000, 0, scale: 150d,
				inDuration: 4d, outDuration: 4d, holdDuration: 20);


			chart.SetupVisionLimit();
			chart.SetVisionLimitAutofit("ob1.png", 1);


			List<int> introPulseTiles = new() { 64, 80, 96, 112 };
			chart.CameraRotationPulseByTile(introPulseTiles, -5, 5, 380, 380, 16);
			
			for (int i = 0; i < introPulseTiles.Count; i++)
			{
				chart.FisheyePulseByBeat(introPulseTiles[i], 2, 1, 16);
				chart.AberrationByBeat(introPulseTiles[i], 2, 1, 16, 30);

				
			}



			chart.TrackDisappearUplift(0, 129, 16d);






			#endregion

			#region VERSE_I
			chart.MovingParticlesBackground(new() { "fog.png" },
				129, 64d, new("000000FF"), upliftSpeedMinTilePerBeat: 3d, upliftSpeedMaxTilePerBeat: 6d,
				imageOpacityMin: 10, imageOpacityMax: 40, imageScaleMin: 200, imageScaleMax: 800, layers: 5, directionMin: 45d, directionMax: 135d);
			chart.MovingParticlesBackground(new() { "field1.png", "field2.png", "chunk (1).png", "chunk (2).png", "chunk (3).png", "chunk (4).png" },
				129, 64d, new("000000FF"), upliftSpeedMinTilePerBeat: 3d, upliftSpeedMaxTilePerBeat: 5d,
				imageOpacityMin: 20, imageOpacityMax: 60, imageScaleMin: 600, imageScaleMax: 1200, layers: 6, directionMin: 75d, directionMax: 105d);
			chart.MovingParticlesForeground(new() { "field1.png", "field2.png", "chunk (1).png", "chunk (2).png", "chunk (3).png", "chunk (4).png" },
				129, 64d, new("222222FF"), upliftSpeedMinTilePerBeat: 5d, upliftSpeedMaxTilePerBeat: 8d,
				imageOpacityMin: 10, imageOpacityMax: 30, imageScaleMin: 1500, imageScaleMax: 2500, layers: 4, directionMin: 80d, directionMax: 100d);




			chart.SetupDecoBgImage();
			chart.SetDecoBgImageAutofit("castle.png", 129);
			chart.BackgroundDim(60, 129);

			// chart.CameraRandomWobble(-1, 1, -1, 1, -2, 2, 155, 165, 1, 3, 0, 0, 32, 129);
			chart.ChartTiles[129].TileEvents.Add(new AdfEventBloom() { Threshold = 0d, Intensity = 70d });
			chart.ChartTiles[129].TileEvents.Add(new AdfEventShakeScreen()
			{
				Intensity = 15,
				Strength = 5,
				Duration = 16,
				FadeOut = false
			});
			chart.BasicAtmosphereFilters(129);

			chart.CameraTiltAndDiveTransition(129, 15, 160, 4, 2);
			chart.CameraMoveRelativeToTile(129, 0d, 0, 2.5);

			


			chart.CameraTiltAndDiveTransition(143, 15, 160, 2, 2);
			chart.CameraMoveRelativeToTile(143, 0d, 0, 2.5);

			chart.BackgroundDim(20, 161, 4d);

			chart.CameraHoverAndTiltToTileTransition(163, 5d, 200, 140, 4d, 8d);
			chart.CameraMoveRelativeToPlayer(163, 2d, y: 3d);
			chart.RandomCamera(-1, 1, 1, 3, -3, 3, 180, 250, 8d, 0d, 8 * 6, 177, AdfEaseType.OutExpo);
			chart.RandomCamera(0, 0, 2, 2, 0, 0, 220, 220, 8d, 0d, 8, 273, AdfEaseType.OutExpo);
			chart.BlurByBeatOutEase(163, 8, 8, 8, 400);






			chart.TrackAppearUplift(129, 161, 4d, 2d, endOpacity: 1000);
			chart.TrackDisappearDownlift(129, 161, 6d);
			chart.TrackAppearScatter(161, 281, 2d, 2d, endOpacity: 1000);
			chart.TrackDisappearUplift(161, 281, 4d);

			#endregion

			#region VERSE_RISER_I

			chart.FloatingTrackBackground(281, 136d,
				trackColor: "000000FF",
				totalTracks: 200, maxSize: 250, minSize: 10, ymin: -300, ymax: -40, xmin: -80d, xmax: 80d,
				directionMax: 100d, directionMin: 80d, opacityMax: 60d, opacityMin: 5d);

			chart.ChartTiles[281].TileEvents.Add(new AdfEventBloom() { Threshold = 0d, Intensity = 140d, Duration = 8d });

			chart.RandomCamera(-1, 1, 1, 3, -3, 3, 120, 180, 4d, 0d, 8, 356, AdfEaseType.OutExpo);
			chart.BlurByBeatOutEase(356, 2, 4, 4, 400);


			chart.TrackAppearUplift(281, 374, 4d, 2d, endOpacity: 1000);
			chart.TrackDisappearUplift(281, 374, 4d);
			
			chart.ChartTiles[281].TileEvents.Add(new AdfEventShakeScreen() { 
				Duration = 8d, Ease = AdfEaseType.InCubic, FadeOut = false, Strength = 150d, Intensity = 100d
			});

			chart.BackgroundDim(0, 289, 0d);
			chart.ChartTiles[289].TileEvents.Add(new AdfEventShakeScreen() { 
				Duration = 2d, Ease = AdfEaseType.OutCubic, FadeOut = false, Strength = 450d, Intensity = 300d
			});

			#endregion




			#region RISER_I
			chart.SetDecoBgImageAutofit("castle2.png", 374);
			chart.BackgroundDim(75, 374);
			
			chart.TrackAppearUplift(374, 534, 4d, 2d, endOpacity: 1000);
			chart.TrackDisappearUplift(374, 534, 4d);

			chart.FisheyePulseByBeat(374, 16, 4d, 8d);
			chart.FisheyePulseByBeat(474, 16, 2d, 8d);
			chart.FisheyePulseByBeat(541, 16, 2d, 8d, 46);
			chart.FisheyePulseByBeat(571, 24, 1d, 8d, 45);
			chart.FisheyePulseByBeat(643, 1, 1d, 4d, 40);
			chart.FisheyePulseByTile(new() { 420, 470 }, 8d);

			List<int> threeKeys_riserI = new() { 420, 424, 470, 474, 534, 538 };

			chart.CameraTiltAndDiveTransition(374, -15, 230, 8, 32);
			chart.CameraRotationPulseByTile(threeKeys_riserI, -15, 15, 230, 230, 16);




			
			foreach (var tile in threeKeys_riserI)
			{
				chart.BackgroundDim(25, tile);
				chart.BackgroundDim(75, tile, 8d);
			}
			chart.BackgroundDim(0, 571, 24);




			List<int> tracksToExplode_riserI = new();
			for (int i = 571; i < 644; i += 6)
			{
				tracksToExplode_riserI.Add(i);
			}
			chart.TrackDisappearExplosion(tracksToExplode_riserI, 2);

			#endregion



			#region HIGH_I
			chart.MovingParticlesBackground(new() { "fog.png" },
				648, 4*128d, new("555555AA"), upliftSpeedMinTilePerBeat: 0.2d, upliftSpeedMaxTilePerBeat: 0.8d,
				imageOpacityMin: 10, imageOpacityMax: 40, imageScaleMin: 200, imageScaleMax: 800, layers: 5, directionMin: 45d, directionMax: 135d);
			chart.MovingParticlesBackground(new() { "field1.png", "field2.png", "chunk (1).png", "chunk (2).png", "chunk (3).png", "chunk (4).png" },
				648, 4*128d, new("000000FF"),
				imageOpacityMin: 20, imageOpacityMax: 60, imageScaleMin: 600, imageScaleMax: 1200, layers: 6, directionMin: 75d, directionMax: 105d);
			chart.MovingParticlesForeground(new() { "field1.png", "field2.png", "chunk (1).png", "chunk (2).png", "chunk (3).png", "chunk (4).png" },
				648, 4*128d, new("222222FF"), upliftSpeedMinTilePerBeat: 3d, upliftSpeedMaxTilePerBeat: 5d,
				imageOpacityMin: 10, imageOpacityMax: 30, imageScaleMin: 1500, imageScaleMax: 2500, layers: 4, directionMin: 80d, directionMax: 100d);

			chart.ChartTiles[648].TileEvents.Add(new AdfEventBloom() { Threshold = 0d, Intensity = 40d, Duration = 0d });


			chart.CameraTiltAndDiveTransition(648, 5, 280, 8, 32);

			chart.SetDecoBgImageAutofit("thunder.png", 648);
			chart.BackgroundDimPulseMultipleByBeat(0, 100, 648, 64, 8, 6);



			List<int> tiles_highIA = new()
			{
				648, 659, 670, 682, 693, 703, 713, 724
			};
			List<int> tiles_highIB = new()
			{
				996, 1008, 1020, 1033, 1045, 1057, 1069, 1082
			};
			List<int> tiles_highIC = new()
			{
				1290, 1302, 1314, 1321, 1328, 1335, 1342, 1349, 1356, 1362, 1369, 1382, 1394
			};
			List<int> tempI = new();

			for (int i = 0; i < 4; i++)
			{
				foreach (var tile in tiles_highIA)
				{
					tempI.Add(tile + i * (735-648));
				}
			}
			for (int i = 0; i < 3; i++)
			{
				foreach (var tile in tiles_highIB)
				{
					tempI.Add(tile + i * (1094-996));
				}
			}
			foreach (var item in tiles_highIC)
			{
				tempI.Add(item);
			}

			chart.TrackDisappearExplosion(tempI, 4d, yBias: 2d, opacityShrinkTime: 0.2d);
			chart.TrackAppearExplosion(tempI, 2d, 2d, endOpacity: 1000);

			chart.FloatingTrackBackground(648, 4 * 128 * 2 * 4,
				trackColor: "000000FF", upliftSpeedMaxTilePerBeat: 1, upliftSpeedMinTilePerBeat: 0.5,
				totalTracks: 400, maxSize: 250, minSize: 10, ymin: -300, ymax: 50, xmin: -80d, xmax: 80d,
				directionMax: 120d, directionMin: 60d, opacityMax: 60d, opacityMin: 5d,
				depthOffset: 19);



			chart.FisheyePulseByBeat(648, 64, 8, 16, 45);
			chart.AberrationByBeat(648, 64, 8, 16, 40);


			chart.RandomCamera(-3, 3, 0, 2, -3, 3, 250, 330, 12, 20, 16 * 16 * 2, 648, AdfEaseType.OutExpo);
			chart.BlurByBeatOutEase(648, 8 * 2, 32, 24);

			#endregion



			#region VERSE_II
			chart.MovingParticlesBackground(new() { "fog.png" },
				1266+129, 64d, new("000000FF"), upliftSpeedMinTilePerBeat: 3d, upliftSpeedMaxTilePerBeat: 6d,
				imageOpacityMin: 10, imageOpacityMax: 40, imageScaleMin: 200, imageScaleMax: 800, layers: 5, directionMin: 45d, directionMax: 135d);
			chart.MovingParticlesBackground(new() { "field1.png", "field2.png", "chunk (1).png", "chunk (2).png", "chunk (3).png", "chunk (4).png" },
				1266+129, 64d, new("000000FF"), upliftSpeedMinTilePerBeat: 3d, upliftSpeedMaxTilePerBeat: 5d,
				imageOpacityMin: 20, imageOpacityMax: 60, imageScaleMin: 600, imageScaleMax: 1200, layers: 6, directionMin: 75d, directionMax: 105d);
			chart.MovingParticlesForeground(new() { "field1.png", "field2.png", "chunk (1).png", "chunk (2).png", "chunk (3).png", "chunk (4).png" },
				1266+129, 64d, new("222222FF"), upliftSpeedMinTilePerBeat: 5d, upliftSpeedMaxTilePerBeat: 8d,
				imageOpacityMin: 10, imageOpacityMax: 30, imageScaleMin: 1500, imageScaleMax: 2500, layers: 4, directionMin: 80d, directionMax: 100d);




			chart.SetupDecoBgImage();
			chart.SetDecoBgImageAutofit("castle.png", 1266 + 129);
			chart.BackgroundDim(60, 1266 + 129);

			// chart.CameraRandomWobble(-1, 1, -1, 1, -2, 2, 155, 165, 1, 3, 0, 0, 32, 129);
			chart.ChartTiles[1266 + 129].TileEvents.Add(new AdfEventBloom() { Threshold = 0d, Intensity = 70d });
			chart.ChartTiles[1266 + 129].TileEvents.Add(new AdfEventShakeScreen()
			{
				Intensity = 15,
				Strength = 5,
				Duration = 16,
				FadeOut = false
			});
			chart.BasicAtmosphereFilters(1266 + 129);

			chart.CameraTiltAndDiveTransition(1266 + 129, 15, 160, 4, 2);
			chart.CameraMoveRelativeToTile(1266 + 129, 0d, 0, 2.5);




			chart.CameraTiltAndDiveTransition(1266 + 143, -15, 160, 2, 2);
			chart.CameraMoveRelativeToTile(1266 + 143, 0d, 0, 2.5);

			chart.BackgroundDim(20, 1266 + 161, 4d);

			chart.CameraHoverAndTiltToTileTransition(1266 + 163, 5d, 200, 140, 4d, 8d);
			chart.CameraMoveRelativeToPlayer(1266 + 163, 2d, y: 3d);
			chart.RandomCamera(-1, 1, 1, 3, -3, 3, 180, 250, 8d, 0d, 8 * 6, 1266 + 177, AdfEaseType.OutExpo);
			chart.RandomCamera(0, 0, 2, 2, 0, 0, 220, 220, 8d, 0d, 8, 1266 + 273, AdfEaseType.OutExpo);
			chart.BlurByBeatOutEase(1266 + 163, 8, 8, 8, 400);






			chart.TrackAppearUplift(1266 + 129, 1266 + 161, 4d, 2d, endOpacity: 1000);
			chart.TrackDisappearDownlift(1266 + 129, 1266 + 161, 6d);
			chart.TrackAppearScatter(1266 + 161, 1266 + 281, 2d, 2d, endOpacity: 1000);
			chart.TrackDisappearUplift(1266 + 161, 1266 + 281, 4d);

			#endregion

			#region VERSE_RISER_II

			chart.FloatingTrackBackground(1266 + 281, 136d,
				trackColor: "000000FF",
				totalTracks: 200, maxSize: 250, minSize: 10, ymin: -300, ymax: -40, xmin: -80d, xmax: 80d,
				directionMax: 100d, directionMin: 80d, opacityMax: 60d, opacityMin: 5d);

			chart.ChartTiles[1266 + 281].TileEvents.Add(new AdfEventBloom() { Threshold = 0d, Intensity = 140d, Duration = 8d });

			chart.RandomCamera(-1, 1, 1, 3, -3, 3, 120, 180, 4d, 0d, 8, 1266 + 356, AdfEaseType.OutExpo);
			chart.BlurByBeatOutEase(1266 + 356, 2, 4, 4, 400);


			chart.TrackAppearUplift(1266 + 281, 1266 + 374, 4d, 2d, endOpacity: 1000);
			chart.TrackDisappearUplift(1266 + 281, 1266 + 374, 4d);

			chart.ChartTiles[1266 + 281].TileEvents.Add(new AdfEventShakeScreen()
			{
				Duration = 8d,
				Ease = AdfEaseType.InCubic,
				FadeOut = false,
				Strength = 150d,
				Intensity = 100d
			});

			chart.BackgroundDim(0, 1266 + 289, 0d);
			chart.ChartTiles[1266 + 289].TileEvents.Add(new AdfEventShakeScreen()
			{
				Duration = 2d,
				Ease = AdfEaseType.OutCubic,
				FadeOut = false,
				Strength = 450d,
				Intensity = 300d
			});

			#endregion

			#region RISER_II
			chart.SetDecoBgImageAutofit("castle2.png", 1266 + 374);
			chart.BackgroundDim(75, 1266 + 374);

			chart.TrackAppearUplift(1266 + 374, 1266 + 534, 4d, 2d, endOpacity: 1000);
			chart.TrackDisappearUplift(1266 + 374, 1266 + 534, 4d);

			chart.FisheyePulseByBeat(1266 + 374, 16, 4d, 8d);
			chart.FisheyePulseByBeat(1266 + 474, 16, 2d, 8d);
			chart.FisheyePulseByBeat(1266+541, 16, 2d, 8d, 46);
			chart.FisheyePulseByBeat(1266+571, 24, 1d, 8d, 45);
			chart.FisheyePulseByBeat(1266 + 643, 1, 1d, 4d, 40);
			chart.FisheyePulseByTile(new() { 1266 + 420, 1266 + 470 }, 8d);

			List<int> threeKeys_riserII = new() { 1266 + 420, 1266+424, 1266+470, 1266+474, 1266+534, 1266+538 };

			chart.CameraTiltAndDiveTransition(1266 + 374, 15, 230, 8, 32);
			chart.CameraRotationPulseByTile(threeKeys_riserII, -15, 15, 230, 230, 16);





			foreach (var tile in threeKeys_riserII)
			{
				chart.BackgroundDim(25, tile);
				chart.BackgroundDim(75, tile, 8d);
			}
			chart.BackgroundDim(0, 1266 + 571, 24);




			List<int> tracksToExplode_riserII = new();
			for (int i = 1266 + 571; i < 1266 + 644; i += 6)
			{
				tracksToExplode_riserII.Add(i);
			}
			chart.TrackDisappearExplosion(tracksToExplode_riserII, 2);

			#endregion

			#region HIGH_II
			chart.MovingParticlesBackground(new() { "fog.png" },
				1266 + 648, 4 * 128d, new("555555AA"), upliftSpeedMinTilePerBeat: 0.2d, upliftSpeedMaxTilePerBeat: 0.8d,
				imageOpacityMin: 10, imageOpacityMax: 40, imageScaleMin: 200, imageScaleMax: 800, layers: 5, directionMin: 45d, directionMax: 135d);
			chart.MovingParticlesBackground(new() { "field1.png", "field2.png", "chunk (1).png", "chunk (2).png", "chunk (3).png", "chunk (4).png" },
				1266 + 648, 4 * 128d, new("000000FF"),
				imageOpacityMin: 20, imageOpacityMax: 60, imageScaleMin: 600, imageScaleMax: 1200, layers: 6, directionMin: 75d, directionMax: 105d);
			chart.MovingParticlesForeground(new() { "field1.png", "field2.png", "chunk (1).png", "chunk (2).png", "chunk (3).png", "chunk (4).png" },
				1266 + 648, 4 * 128d, new("222222FF"), upliftSpeedMinTilePerBeat: 3d, upliftSpeedMaxTilePerBeat: 5d,
				imageOpacityMin: 10, imageOpacityMax: 30, imageScaleMin: 1500, imageScaleMax: 2500, layers: 4, directionMin: 80d, directionMax: 100d);

			chart.ChartTiles[1266 + 648].TileEvents.Add(new AdfEventBloom() { Threshold = 0d, Intensity = 40d, Duration = 0d });


			chart.CameraTiltAndDiveTransition(1266 + 648, 5, 280, 8, 32);

			chart.SetDecoBgImageAutofit("thunder.png", 1266 + 648);
			chart.BackgroundDimPulseMultipleByBeat(0, 100, 1266 + 648, 64, 8, 6);



			List<int> tiles_highIIA = new()
			{
				648, 659, 670, 682, 693, 703, 713, 724
			};
			List<int> tiles_highIIB = new()
			{
				2262, 2276, 2287, 2302, 2313, 2326, 2336, 2350
			};
			List<int> tiles_highIIC = new()
			{
				2559, 2573, 2584, 2591, 2598, 2605, 2612, 2619, 2626, 2632, 2639, 2653, 2664
			};
			List<int> tempII = new();

			for (int i = 0; i < 4; i++)
			{
				foreach (var tile in tiles_highIIA)
				{
					tempII.Add(1266 + tile + i * (735 - 648));
				}
			}
			for (int i = 0; i < 3; i++)
			{
				foreach (var tile in tiles_highIIB)
				{
					tempII.Add(tile + i * (2361 - 2262));
				}
			}
			foreach (var item in tiles_highIIC)
			{
				tempII.Add(item);
			}

			chart.TrackDisappearExplosion(tempII, 4d, yBias: 2d, opacityShrinkTime: 0.2d);
			chart.TrackAppearExplosion(tempII, 2d, 2d, endOpacity: 1000);

			chart.FloatingTrackBackground(1266 + 648, 4 * 128 * 2 * 4,
				trackColor: "000000FF", upliftSpeedMaxTilePerBeat: 1, upliftSpeedMinTilePerBeat: 0.5,
				totalTracks: 400, maxSize: 250, minSize: 10, ymin: -300, ymax: 50, xmin: -80d, xmax: 80d,
				directionMax: 120d, directionMin: 60d, opacityMax: 60d, opacityMin: 5d,
				depthOffset: 19);



			chart.FisheyePulseByBeat(1266 + 648, 64, 8, 16, 45);
			chart.AberrationByBeat(1266 + 648, 64, 8, 16, 40);


			chart.RandomCamera(-3, 3, 0, 2, -3, 3, 250, 330, 12, 20, 16 * 16 * 2, 1266 + 648, AdfEaseType.OutExpo);
			chart.BlurByBeatOutEase(1266 + 648, 8 * 2, 32, 24);


			#endregion


			#region BRIDGE
			chart.CameraTiltAndDiveTransition(2664, 15, 240, 8, 32);
			chart.CameraMoveRelativeToPlayer(2664, 0, y: 3);

			chart.SetDecoBgImageAutofit("bridge.png", 2664);
			chart.BackgroundDim(75, 2664);


			chart.FisheyePulseByBeat(2664, 16, 4, 8);
			chart.FisheyePulseByBeat(2710, 1, 4, 8);
			chart.FisheyePulseByBeat(2760, 1, 4, 8);

			chart.FisheyePulseByBeat(1024 +1266 + 474, 16, 2d, 8d);
			chart.FisheyePulseByBeat(1024 +1266 + 541, 16, 2d, 8d, 46);
			chart.FisheyePulseByBeat(1024 +1266 + 571, 24, 1d, 8d, 45);
			chart.FisheyePulseByBeat(1024 +1266 + 643, 1, 1d, 4d, 40);

			List<int> tracksToExplode_riserIII = new();
			for (int i = 1024 + 1266 + 571; i < 1024 + 1266 + 644; i += 6)
			{
				tracksToExplode_riserIII.Add(i);
			}
			chart.TrackDisappearExplosion(tracksToExplode_riserIII, 2);


			List<int> threeKeys_riserIII = new() { 1024+1266 + 420, 1024+1266 + 424, 1024+1266 + 470, 1024+1266 + 474, 1024+1266 + 534, 1024+1266 + 538 };
			foreach (var tile in threeKeys_riserIII)
			{
				chart.BackgroundDim(25, tile);
				chart.BackgroundDim(75, tile, 8d);
			}
			chart.BackgroundDim(0, 1024+ 1266 + 571, 24);


			chart.FloatingPlanetsBackground(2664, 4 * 8 * 3,
				totalPlanets: 15, minSize: 120, maxSize: 300, ymin: -80, ymax: -40, xmin: -60, xmax: 30,
				planetColor: "FFFFFFFF",
				directionMin: 135, directionMax: 180);

			#endregion



			#region HIGH_III
			chart.MovingParticlesBackground(new() { "fog.png" },
				1024+1266 + 648, 4 * 128d, new("555555AA"), upliftSpeedMinTilePerBeat: 0.2d, upliftSpeedMaxTilePerBeat: 0.8d,
				imageOpacityMin: 10, imageOpacityMax: 40, imageScaleMin: 200, imageScaleMax: 800, layers: 5, directionMin: 45d, directionMax: 135d);
			chart.MovingParticlesBackground(new() { "field1.png", "field2.png", "chunk (1).png", "chunk (2).png", "chunk (3).png", "chunk (4).png" },
				1024 + 1266 + 648, 4 * 128d, new("000000FF"),
				imageOpacityMin: 20, imageOpacityMax: 60, imageScaleMin: 600, imageScaleMax: 1200, layers: 6, directionMin: 75d, directionMax: 105d);
			chart.MovingParticlesForeground(new() { "field1.png", "field2.png", "chunk (1).png", "chunk (2).png", "chunk (3).png", "chunk (4).png" },
				1024 + 1266 + 648, 4 * 128d, new("222222FF"), upliftSpeedMinTilePerBeat: 3d, upliftSpeedMaxTilePerBeat: 5d,
				imageOpacityMin: 10, imageOpacityMax: 30, imageScaleMin: 1500, imageScaleMax: 2500, layers: 4, directionMin: 80d, directionMax: 100d);

			chart.ChartTiles[1024 + 1266 + 648].TileEvents.Add(new AdfEventBloom() { Threshold = 0d, Intensity = 40d, Duration = 0d });


			chart.CameraTiltAndDiveTransition(1024 + 1266 + 648, 5, 280, 8, 32);

			chart.SetDecoBgImageAutofit("thunder.png", 1024 + 1266 + 648);
			chart.BackgroundDimPulseMultipleByBeat(0, 100, 1024 + 1266 + 648, 64, 8, 6);



			List<int> tiles_highIIIA = new()
			{
				648, 659, 670, 682, 693, 703, 713, 724
			};
			List<int> tiles_highIIIB = new()
			{
				2262, 2276, 2287, 2302, 2313, 2326, 2336, 2350
			};
			List<int> tiles_highIIIC = new()
			{
				2559, 2573, 2584, 2591, 2598, 2605, 2612, 2619, 2626, 2632, 2639, 2653, 2664
			};
			List<int> tempIII = new();

			for (int i = 0; i < 4; i++)
			{
				foreach (var tile in tiles_highIIIA)
				{
					tempIII.Add(1024 + 1266 + tile + i * (735 - 648));
				}
			}
			for (int i = 0; i < 3; i++)
			{
				foreach (var tile in tiles_highIIIB)
				{
					tempIII.Add(1024 + tile + i * (2361 - 2262));
				}
			}
			foreach (var item in tiles_highIIIC)
			{
				tempIII.Add(1024 + item);
			}

			chart.TrackDisappearExplosion(tempIII, 4d, yBias: 2d, opacityShrinkTime: 0.2d);
			chart.TrackAppearExplosion(tempIII, 2d, 2d, endOpacity: 1000);

			chart.FloatingTrackBackground(1024 + 1266 + 648, 4 * 128 * 2 * 4,
				trackColor: "000000FF", upliftSpeedMaxTilePerBeat: 1, upliftSpeedMinTilePerBeat: 0.5,
				totalTracks: 400, maxSize: 250, minSize: 10, ymin: -300, ymax: 50, xmin: -80d, xmax: 80d,
				directionMax: 120d, directionMin: 60d, opacityMax: 60d, opacityMin: 5d,
				depthOffset: 19);



			chart.FisheyePulseByBeat(1024 + 1266 + 648, 64, 8, 16, 45);
			chart.AberrationByBeat(1024 + 1266 + 648, 64, 8, 16, 40);


			chart.RandomCamera(-3, 3, 0, 2, -3, 3, 250, 330, 12, 20, 16 * 16 * 2, 1024 + 1266 + 648, AdfEaseType.OutExpo);
			chart.BlurByBeatOutEase(1024 + 1266 + 648, 8 * 2, 32, 24);


			#endregion


			#region OUTRO_MAGICSHAPE

			chart.CameraMoveRelativeToTile(3687+0, 0, 0.5, -0.5);
			chart.CameraTiltAndDiveTransition(3687 + 1, 20d, 380d, 4d, 32d);

			// chart.ChartTiles[1].TileEvents.Add(new AdfEventHallOfMirrors() { Enabled = true });
			chart.ChartTiles[3687 + 1].TileEvents.Add(new AdfEventBloom() { Threshold = 0d, Intensity = 150d });
			chart.ChartTiles[3687 + 1].TileEvents.Add(new AdfEventHallOfMirrors() { Enabled = true });
			chart.BasicAtmosphereFilters(3687 + 1, grayscaleIntensity: 100, rainIntensity: 0d);


			chart.MovingParticlesBackground(new() { "fog.png" },
				3687 + 1, 128d, new("555555FF"), upliftSpeedMinTilePerBeat: 1d, upliftSpeedMaxTilePerBeat: 3d,
				imageOpacityMin: 10, imageOpacityMax: 20, imageScaleMin: 200, imageScaleMax: 800, layers: 5, directionMin: 45d, directionMax: 135d);
			chart.MovingParticlesBackground(new() { "field1.png", "field2.png", "chunk (1).png", "chunk (2).png", "chunk (3).png", "chunk (4).png" },
				3687+1, 128d, new("000000FF"),
				imageOpacityMin: 20, imageOpacityMax: 60, imageScaleMin: 600, imageScaleMax: 1200, layers: 6, directionMin: 75d, directionMax: 105d);
			chart.MovingParticlesForeground(new() { "field1.png", "field2.png", "chunk (1).png", "chunk (2).png", "chunk (3).png", "chunk (4).png" },
				3687+1, 128d, new("222222FF"), upliftSpeedMinTilePerBeat: 3d, upliftSpeedMaxTilePerBeat: 5d,
				imageOpacityMin: 10, imageOpacityMax: 30, imageScaleMin: 1500, imageScaleMax: 2500, layers: 4, directionMin: 80d, directionMax: 100d);


			chart.FloatingTrackBackground(3687 + 1, 128d,
				totalTracks: 200, maxSize: 250, minSize: 10, ymin: -300, ymax: 50, xmin: -80d, xmax: 80d,
				directionMax: 100d, directionMin: 80d, opacityMax: 60d, opacityMin: 5d);

			chart.RenderTextCentered(3687 + 1, "Dragonhearted EX", 0, 1100,
				inDuration: 4d, outDuration: 8d, holdDuration: 128-12);
			chart.RenderCreditRoleAndName(3687 + 64, "Artist", "TryHardNinja", 0, -1000, scale: 230d,
				inDuration: 4d, outDuration: 4d, holdDuration: 64-8);

			chart.RenderCreditRoleAndName(3687 + 96, "Track", "Sean Lenard B.", -1000, 0, scale: 150d,
				inDuration: 4d, outDuration: 4d, holdDuration: 32-8);
			chart.RenderCreditRoleAndName(3687 + 96, "Visual", "quartrond", 1000, 0, scale: 150d,
				inDuration: 4d, outDuration: 4d, holdDuration: 32-8);



			chart.TrackDisappearUplift(3687 + 0, 3687 + 128, 16d);






			#endregion


			#region LYRICS
			chart.LyricWithTranslation("lyric.txt", inDuration: 1, outDuration: 1);
			#endregion


			#region VISUAL_CUES
			Random random = new();
			foreach (var item in tempII)
			{
				chart.ShapeFocusOnTile("", "wave.png", item, 8, 12);
			}
			foreach (var item in tempIII)
			{
				chart.ShapeFocusOnTile("cue.png", "wave.png", item, 8, 12, inSize: 100, outSize: 400,
					inRotation: 80 * random.NextDouble() - 40);
			}


			#endregion

			File.WriteAllText(@"G:\Adofai levels\Dragonhearted EX\final.adofai", chart.ChartJson.ToJsonString());
		}
	}
}
