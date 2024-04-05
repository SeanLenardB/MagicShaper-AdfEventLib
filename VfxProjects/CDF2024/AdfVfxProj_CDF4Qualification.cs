using MagicShaper.AdfExtensions;
using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects.CDF2024
{
	[SupportedOSPlatform("windows")]
	internal class AdfVfxProj_CDF4Qualification
	{
		internal static void ProjMain()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\CDF4_quartrond\Katastrofi.adofai");

			#region INTRO
			chart.SetupDecoBgImage();
			chart.SetDecoBgImageAutofit("background.jpg", 4);
			chart.BackgroundDim(75d, 4);

			chart.CameraTiltAndDiveTransition(4, 15d, 220d, 2d, 4d);
			chart.ChartTiles[4].TileEvents.Add(new AdfEventBloom() { Threshold = 0d, Intensity = 80d, Color = new("3333FFFF") });

			chart.BasicAtmosphereFilters(4, grayscaleIntensity: 50d, rainIntensity: -15d);
			
			chart.SetupVisionLimit();
			chart.SetVisionLimitAutofit("ob2.png", 4);
			chart.SetVisionLimitAutofit("ob1.png", 92);
			chart.ChartTiles[92].TileEvents.Add(new AdfEventFlash()
			{
				StartColor = new("000000FF"),
				EndColor = new("000000FF"),
				StartOpacity = 100,
				EndOpacity = 0,
				Plane = AdfFlashPlaneType.Foreground,
				Duration = 1d,
				Ease = AdfEaseType.OutSine
			});
			chart.ChartTiles[92].TileEvents.Add(new AdfEventFlash()
			{
				StartColor = new("000000FF"),
				EndColor = new("000000FF"),
				StartOpacity = 0,
				EndOpacity = 100,
				Plane = AdfFlashPlaneType.Foreground,
				Duration = 2d,
				Ease = AdfEaseType.InSine,
				AngleOffset = -360d
			});


			chart.MovingParticlesBackground(new() { "fog.png" }, 
				4, 97d, new("555555FF"), upliftSpeedMinTilePerBeat: 1d, upliftSpeedMaxTilePerBeat: 3d,
				imageOpacityMin: 10, imageOpacityMax: 40, imageScaleMin: 200, imageScaleMax: 800, layers: 5, directionMin: 45d, directionMax: 80d);
			// chart.CameraRandomWobble(0, 0, 0, 0, -2d, 2d, 180d, 220d, 8d, 12d, 2d, 4d, 96d, 9);
			chart.MovingParticlesBackground(new() { "field1.png", "field2.png", "chunk (1).png", "chunk (2).png", "chunk (3).png", "chunk (4).png" }, 
				4, 97d, new("000000FF"), 
				imageOpacityMin: 20, imageOpacityMax: 60, imageScaleMin: 300, imageScaleMax: 800, layers: 6, directionMin: 75d, directionMax: 85d);
			chart.MovingParticlesForeground(new() { "field1.png", "field2.png", "chunk (1).png", "chunk (2).png", "chunk (3).png", "chunk (4).png" }, 
				4, 97d, new("222222FF"), upliftSpeedMinTilePerBeat: 3d, upliftSpeedMaxTilePerBeat: 5d,
				imageOpacityMin: 10, imageOpacityMax: 30, imageScaleMin: 1000, imageScaleMax: 1500, layers: 4, directionMin: 80d, directionMax: 90d);


			chart.FloatingTrackBackground(4, 64d, totalTracks: 150);


			chart.CameraMoveToTileRandomOutEase(new() { 4, 11, 18,  }, -1d, 1d, 2d, 3d, -2d, 2d, 160d, 210d, 4d, 4d);
			chart.CameraMoveToTileRandomInEase(new() { 23 }, -1d, 1d, 2d, 3d, -2d, 2d, 160d, 210d, 4d, 4d);
			chart.CameraMoveToTileRandomOutEase(new() { 32, 37, 44, 49 }, -1d, 1d, 2d, 3d, -2d, 2d, 160d, 210d, 4d, 4d);

			chart.CameraTiltOnThreePt(new() { 53, 54, 55 }, 3d, 8d, 1.5d);
			chart.CameraTiltOnThreePt(new() { 57, 58, 59 }, 3d, 8d, 1.5d);
			

			chart.CameraMoveToTileRandomOutEase(new() { 61, 66 }, -1d, 0d, 4d, 5d, -2d, 2d, 190d, 220d, 4d, 4d);
			chart.CameraMoveToTileRandomInEase(new() { 72 }, -1d, 0d, 4d, 5d, -2d, 2d, 190d, 220d, 8d, 8d);
			chart.CameraMoveToTileRandomOutEase(new() { 83 }, -1d, 0d, 1d, 1d, 0d, 0d, 160d, 160d, 8d, 8d);

			chart.CameraHoverAndTiltToTileTransition(92, -10, 190, 120, 2d, 4d);

			//chart.CameraMoveToTileRandomOutEase(new() { 92 }, 1d, 2d, 2d, 3d, -2d, 2d, 190d, 210d, 4d, 4d);
			chart.CameraMoveToTileRandomOutEase(new() { 98 }, 1d, 2d, 2d, 3d, -2d, 2d, 190d, 210d, 2d, 2d);
			chart.CameraHoverAndTiltToTileTransition(105, 15, 220, 150, 2d, 4d);
			chart.CameraMoveToTileRandomOutEase(new() { 111 }, 1d, 2d, 2d, 3d, -2d, 2d, 170d, 180d, 4d, 4d);

			chart.CameraHoverAndTiltToTileTransition(129, 15, 210, 130, 12d, 3d);

			chart.CameraMoveToTileRandomOutEase(new() { 133, 136 }, -2d, -1d, 2d, 3d, -2d, 2d, 210d, 220d, 2d, 2d);

			chart.CameraHoverAndTiltToTileTransition(158, -10, 230, 150, 16d, 2d);
			chart.CameraMoveRelativeToPlayer(160, 2d);



			chart.ShapeFocusOnTile("cue.png", "wave.png", 4, 4, 8, inSize: 100, outSize: 500, inRotation: 120);
			
			chart.ShapeFocusOnTile("cue.png", "wave.png", 92, 4, 6, inSize: 150, outSize: 500);
			chart.SneakImageVision("background-7632549.jpg", "wavesolid.png", 92, 6, outSize: 500, imageOpacity: 25, imageScale: 40d);


			chart.BackgroundDim(0, 142);
			chart.BackgroundDim(100, 142, duration: 16);
			#endregion

			#region GALLOP I
			chart.BasicAtmosphereFilters(4, grayscaleIntensity: 50d, rainIntensity: 0d);

			chart.SetDecoBgImageAutofit("background-7632549.jpg", 161);
			chart.BackgroundDim(100d, 161);
			chart.BackgroundDim(25d, 161, duration: 2d);
			chart.ShapeFocusOnTile("cue.png", "wave.png", 161, 4, 8, inSize: 50, outSize: 700, 
				xRelativeToTile: 2, yRelativeToTile: 3);
			//chart.SneakImageVision("background-7632549.jpg", "wavesolid.png", 161, 8, outSize: 700, imageOpacity: 90, imageScale: 80d, 
			//	xMaskRelativeToTile: 2, yMaskRelativeToTile: 3);
			chart.ChartTiles[158].TileEvents.Add(new AdfEventBloom() { Threshold = 0d, Intensity = 160d, Color = new("AA33FFFF"), Duration = 4d });

			chart.MovingParticlesBackground(new() { "fog.png" },
				161, 252d, new("BBBBBBFF"), upliftSpeedMinTilePerBeat: 0.25d, upliftSpeedMaxTilePerBeat: 1d,
				imageOpacityMin: 10, imageOpacityMax: 40, imageScaleMin: 400, imageScaleMax: 1200, layers: 5, directionMin: 45d, directionMax: 80d);
			// chart.CameraRandomWobble(0, 0, 0, 0, -2d, 2d, 180d, 220d, 8d, 12d, 2d, 4d, 96d, 9);
			chart.MovingParticlesBackground(new() { "field1.png", "field2.png", "chunk (1).png", "chunk (2).png", "chunk (3).png", "chunk (4).png" },
				161, 252d, new("AAAAAAFF"),
				imageOpacityMin: 20, imageOpacityMax: 60, imageScaleMin: 500, imageScaleMax: 1200, layers: 6, directionMin: 75d, directionMax: 85d);
			chart.MovingParticlesForeground(new() { "field1.png", "field2.png", "chunk (1).png", "chunk (2).png", "chunk (3).png", "chunk (4).png" },
				161, 252d, new("FFFFFFFF"), upliftSpeedMinTilePerBeat: 3d, upliftSpeedMaxTilePerBeat: 5d,
				imageOpacityMin: 10, imageOpacityMax: 30, imageScaleMin: 1300, imageScaleMax: 1900, layers: 4, directionMin: 80d, directionMax: 90d);


			List<int> pseudosGI = new() 
			{ 
				161, 166, 169, 174, 178, 182, 185, 190, 195, 199, 203, 206, 211, 214, 219, 224, 226, 228, 230, 232, 235
			};
			// gallop snail is 238
			chart.FisheyePulseByTile(pseudosGI, 4d);
			chart.AberrationByBeat(161, 16, 4d, 8d, 45d);

			pseudosGI.RemoveAt(pseudosGI.Count - 1);
			pseudosGI.RemoveAt(pseudosGI.Count - 1);
			chart.CameraRotationPulseByTile(pseudosGI, -7d, 7d, 230, 230, 4d);
			chart.CameraHoverAndTiltToTileTransition(238, 5d, 170d, 120d, 2d, 2d);
			chart.BackgroundDim(95, 232, 4d);
			#endregion

			#region STOP I
			chart.ChartTiles[238].TileEvents.Add(new AdfEventBloom() { Threshold = 0d, Intensity = 100d, Color = new("3333FFFF"), Duration = 1d });


			List<int> pseudosSI = new()
			{
				242, 246, 249, 252, 256, 260, 263, 266, 269, 272, 275, 278, 280, 282, 286, 291, 293
			};
			chart.FisheyePulseByBeat(238, 16, 2d, 2d);
			chart.AberrationByBeat(238, 16, 2d, 4d, 45d);
			chart.CameraRotationPulseByTile(pseudosSI, -12d, 12d, 170, 170, 4d);
			chart.CameraMoveRelativeToPlayer(238, 4d);



			#endregion

			#region GALLOP II

			chart.ShapeFocusOnTile("cue.png", "wave.png", 297, 6, 8, inSize: 150, outSize: 500);
			chart.BackgroundDim(100d, 297);
			chart.BackgroundDim(25d, 297, duration: 2d);
			chart.SneakImageVision("background-7632549.jpg", "wavesolid.png", 297, 8, outSize: 500, imageOpacity: 25, imageScale: 40d);
			chart.SetDecoBgImageAutofit("background-7632549.jpg", 267);
			chart.ChartTiles[297].TileEvents.Add(new AdfEventBloom() { Threshold = 0d, Intensity = 160d, Color = new("AA33FFFF"), Duration = 4d });


			List<int> pseudosGII = new()
			{
				332, 336, 340, 344, 348, 350, 352, 355, 358, 360, 362, 365, 367, 369, 371, 373, 375
			};
			chart.RandomCamera(-5, -4, 1, 2, -3, 0, 240, 260, 8, 0, 16, 297);
			//chart.RandomCamera(0, 0, 0, 0, 0, 0, 230, 230, 4, 0, 4, 324);
			chart.CameraHoverAndTiltToTileTransition(324, 15d, 220, 180, 12d, 4d);
			chart.CameraMoveRelativeToPlayer(324, 4d);
			chart.CameraRotationPulseByTile(pseudosGII, -12d, 12d, 230, 230, 4d);

			chart.BackgroundDim(100, 373, 4d);
			#endregion

			#region STOP II
			List<int> pseudosSII = new()
			{
				377, 381, 385, 388, 390, 394, 398
			};
			chart.CameraRotationPulseByTile(pseudosSII, -15d, 15d, 150, 180, 4d);
			chart.SetDecoBgImage("background.jpg", 377);
			chart.BackgroundDim(70, 377, 2d);

			chart.ShapeFocusOnTile("cue.png", "wave.png", 377, 3, 4, inSize: 150, outSize: 500);
			chart.ChartTiles[403].TileEvents.Add(new AdfEventBloom() { Threshold = 0d, Intensity = 160d, Color = new("FF0000FF"), Duration = 4d });


			chart.CameraMoveToTileRandomOutEase(new() { 403 }, 8, 8, 3, 3, 0, 0, 220, 220, 8, 8);
			chart.CameraHoverAndTiltToTileTransition(420, 15d, 200, 100, 8, 3);
			chart.CameraMoveRelativeToTile(425, 3d);
			chart.CameraMoveRelativeToTile(430, 3d);
			chart.CameraMoveRelativeToTile(435, 2d);
			chart.CameraHoverAndTiltToTileTransition(455, 15d, 200, 70, 0.125, 1);
			chart.ShapeFocusOnTile("cue.png", "wave.png", 455, 0.5, 1, inSize: 500, outSize: 500);


			#endregion

			#region TRACK ANIMATION
			chart.TrackAppearUplift(4, 142, 8, 4, endOpacity: 200);
			chart.TrackDisappearDownlift(0, 142, 4);
			List<int> pseudosGIT = new()
			{
				161, 166, 169, 174, 178, 182, 185, 190, 195, 199, 203, 206, 211, 214, 219, 224, 226, 228, 230, 232, 235, 238
			};
			List<int> pseudosSIT = new()
			{
				238, 242, 246, 249, 252, 256, 260, 263, 266, 269, 272, 275, 278, 280, 282, 286, 291, 293, 297
			};
			List<int> pseudosGIIT = new()
			{
				332, 336, 340, 344, 348, 350, 352, 355, 358, 360, 362, 365, 367, 369, 371, 373, 375, 377
			};
			List<int> pseudosSIIT = new()
			{
				377, 381, 385, 388, 390, 394, 398
			};
			chart.TrackAppearExplosion(pseudosGIT, 2d, 4d);
			chart.TrackDisappearExplosion(pseudosGIT, 4d);

			chart.TrackAppearScatter(pseudosSIT[0], pseudosSIT[^1], 2d, 4d, endOpacity: 200);
			chart.TrackDisappearExplosion(pseudosSIT, 4d);

			chart.TrackAppearUplift(297, 332, 1d, 2d);
			chart.TrackDisappearUplift(297, 332, 1d);

			chart.TrackAppearScatter(pseudosGIIT[0], pseudosGIIT[^1], 2d, 4d);
			chart.TrackDisappearExplosion(pseudosGIIT, 4d);

			chart.TrackAppearScatter(pseudosSIIT[0], pseudosSIIT[^1], 2d, 4d);
			chart.TrackDisappearExplosion(pseudosSIIT, 4d);

			chart.TrackDisappearExplosion(new() { 455 }, 8d, xBias: 10d);
			#endregion

			#region CREDITS
			chart.ChartTiles[455].TileEvents.Add(new AdfEventSetFilter()
			{
				Filter = AdfFilter.Drawing,
				Intensity = 5
			});
			chart.ChartTiles[455].TileEvents.Add(new AdfEventSetFilter()
			{
				Filter = AdfFilter.Rain,
				Intensity = -15
			});

			chart.CameraMoveToTileRandomOutEase(new() { 456 }, 10, 10, 1, 1, 0, 0, 200, 200, 0.5, 0.5);



			chart.MovingParticlesBackground(new() { "fog.png" },
				455, 252d, new("888888FF"), upliftSpeedMinTilePerBeat: 7d, upliftSpeedMaxTilePerBeat: 8d,
				imageOpacityMin: 10, imageOpacityMax: 40, imageScaleMin: 400, imageScaleMax: 1200, layers: 5, directionMin: 45d, directionMax: 80d);
			// chart.CameraRandomWobble(0, 0, 0, 0, -2d, 2d, 180d, 220d, 8d, 12d, 2d, 4d, 96d, 9);
			chart.MovingParticlesBackground(new() { "field1.png", "field2.png", "chunk (1).png", "chunk (2).png", "chunk (3).png", "chunk (4).png" },
				455, 252d, new("222222FF"), upliftSpeedMinTilePerBeat: 5d, upliftSpeedMaxTilePerBeat: 8d,
				imageOpacityMin: 20, imageOpacityMax: 60, imageScaleMin: 500, imageScaleMax: 1200, layers: 6, directionMin: 75d, directionMax: 85d);
			chart.MovingParticlesForeground(new() { "field1.png", "field2.png", "chunk (1).png", "chunk (2).png", "chunk (3).png", "chunk (4).png" },
				455, 252d, new("222222FF"), upliftSpeedMinTilePerBeat: 12d, upliftSpeedMaxTilePerBeat: 15d,
				imageOpacityMin: 10, imageOpacityMax: 30, imageScaleMin: 1300, imageScaleMax: 1900, layers: 4, directionMin: 80d, directionMax: 90d);

			chart.ShapeFocusOnTile("cue.png", "wave.png", 456, 0, 1, inSize: 0, outSize: 1000);
			chart.RenderTextCentered(456, "Katastrofi", 500, 700, 0.5, scale: 150, font: "Alegreya", color: "BBBBFFFF");
			chart.RenderCreditRoleAndName(456, "Artist", "ORTAL", 200, 150, 0.5);
			chart.RenderCreditRoleAndName(456, "Track", "SarouA", 800, 150, 0.5);
			chart.RenderCreditRoleAndName(456, "Visual", "quartrond", 500, -200, 0.5);
			chart.DecorationFadeIn(456, "CDF4_logo_1.png", -650, 0, 0.5, scale: 35d);
			chart.DecorationFadeIn(456, "CDF4_logo_2.png", -600, 0, 0.5, scale: 35d);

			chart.FloatingTrackBackground(455, 16d, totalTracks: 150, upliftSpeedMinTilePerBeat: 4, upliftSpeedMaxTilePerBeat: 8);
			#endregion

			File.WriteAllText(@"G:\Adofai levels\CDF4_quartrond\level.adofai", chart.ChartJson.ToJsonString());

		}
	}
}
