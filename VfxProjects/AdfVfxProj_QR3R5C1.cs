using MagicShaper.AdfExtensions;
using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects
{
	[SupportedOSPlatform("windows")]
	internal class AdfVfxProj_QR3R5C1
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\anni\level.adofai");


			#region INTRO
			chart.CameraTiltAndDiveTransition(1, 45, 160, 2d, 2d);

			chart.FloatingTrackBackground(1, 4d, minSize: 20, maxSize: 150, trackColor: "666666", totalTracks: 20,
				upliftSpeedMaxTilePerBeat: 6, upliftSpeedMinTilePerBeat: 3, xmax: 25, xmin: -25, ymax: 10, ymin: -25);

			//chart.RandomBackgroundSplash("circle.png", 5, 6, 16d, rotation: 0);
			//chart.RandomBackgroundSplash("circle.png", 12, 13, 32d, rotation: 0);
			//chart.RandomBackgroundSplash("circle.png", 20, 21, 16d, rotation: 0);
			//chart.RandomBackgroundSplash("circle.png", 27, 28, 32d, rotation: 0);
			//chart.RandomBackgroundSplash("circle.png", 35, 36, 16d, rotation: 0);
			//chart.RandomBackgroundSplash("circle.png", 42, 43, 32d, rotation: 0);
			//chart.RandomBackgroundSplash("circle.png", 50, 51, 16d, rotation: 0);
			//chart.RandomBackgroundSplash("circle.png", 57, 58, 32d, rotation: 0);
			chart.RandomBackgroundSplash("circle.png", 5, 58, 16d, rotation: 0, sizeMin: 70, sizeMax: 400);

			List<int> hardKicks = new() { 68, 71, 77, 80, 86, 89, 95, 98, 105, 108, 110, 113, 116, 119, 121, 124, 127 };
			chart.CameraRotationPulseByTile(hardKicks, -8, 8, 130, 150, 2d);
			for (int i = 0; i < hardKicks.Count; i++)
			{
				chart.ShapeFocusOnTile("ccue.png", "ccircle.png", hardKicks[i], 4d, 4d, inSize: 100);
			}

			chart.TrackAppearUplift(5, 61, 8d, 4d, endOpacity: 2000, endScale: 95);
			chart.TrackDisappearDownlift(5, 61, 8d);

			chart.TrackDisappearExplosion(hardKicks, 4d);
			#endregion

			#region FIRST
			chart.RenderTextCentered(127, "∀nnihilation", 0, -500, inDuration: 1d, outDuration: 0.5d, holdDuration: 0.5d, scale: 160, font: "Consolas");

			chart.TrackAppearScatter(143, 163, 4d, 4d, endOpacity: 70);
			chart.TrackAppearScatter(199, 228, 4d, 4d, endOpacity: 70);
			chart.TrackDisappearDownlift(143, 163, 6d);
			chart.TrackDisappearDownlift(199, 228, 6d);

			List<int> redKicks = new();
			for (int i = 256; i < 325; i+=2)
			{
				redKicks.Add(i);
				if (i < 322)
				{
					chart.FloatingTrackBackground(i, 2d, totalTracks: 3, 
						upliftSpeedMinTilePerBeat: 4, upliftSpeedMaxTilePerBeat: 8, maxSize: 250, minSize: 160,
						xmax: 25, xmin: -25, ymax: 9, ymin: -19);
				}
			}


			chart.TrackDisappearExplosion(redKicks, 4d);
			chart.CameraRotationPulseByTile(redKicks, -10, 10, 130, 165, 2d);
			chart.FisheyePulseByTile(redKicks, 2d);
			chart.AberrationByTile(redKicks, 2d);


			#endregion


			#region WHITE
			chart.FloatingTrackBackground(324, 40d, xmin: -40, xmax: 30, ymin: -15, ymax: 25, totalTracks: 25,
				upliftSpeedMaxTilePerBeat: 0, upliftSpeedMinTilePerBeat: 0, minSize: 40, maxSize: 230, opacityMax: 30, opacityMin: 5);
			chart.FloatingTrackBackground(425, 32d, xmin: -40, xmax: 30, ymin: -15, ymax: 25, totalTracks: 25,
				upliftSpeedMaxTilePerBeat: 0, upliftSpeedMinTilePerBeat: 0, minSize: 40, maxSize: 230, opacityMax: 30, opacityMin: 5);

			

			chart.TrackDisappearExplosion(new() { 370, 425, 460 }, 8d);
			chart.TrackDisappearExplosion(new() { 531 }, 16d, xBias: 15, yBias: 5);


			#endregion

			#region INTERVAL

			chart.FloatingPlanetsBackground(544, 18d, planetColor: "FFFFFFFF", totalPlanets: 10, maxSize: 250,
				xmin: -60, xmax: -35, ymin: -45, ymax: -15, upliftSpeedMinTilePerBeat: 5, upliftSpeedMaxTilePerBeat: 9, 
				directionMin: 25, directionMax: 55);

			chart.RenderTextCentered(567, "There's no turning back", 0, 500, inDuration: 1.5d, outDuration: 0.5d, holdDuration: 0.5d, scale: 160);




			#endregion

			#region REVENGE


			List<int> threepts = new();
			for (int i = 570; i < 708; i++)
			{
				if (chart.GetInnerAngleAtTile(i) == 30)
				{
					threepts.Add(i);
				}
			}

			chart.AberrationByTile(threepts, 4d, 70);
			chart.FisheyePulseByTile(threepts, 4d, 48);
			chart.CameraRotationPulseByTile(threepts, -10, 10, 190, 200, 4d);


			int annihilateImageMax = 6;
			Random random = new();
			chart.SetupDecoBgImage();
			chart.BackgroundDim(15, 0);
			int lastan = 0;
			foreach (var tile in threepts)
			{
				int thisan = random.Next(annihilateImageMax) + 1;
				while (thisan == lastan)
				{
					thisan = random.Next(annihilateImageMax) + 1;
				}
				chart.SetDecoBgImage($"an{thisan}.png", tile);
				chart.BackgroundOpacityPulse(100, 0, tile, 4d);
			}
			threepts.Add(708);
			chart.TrackAppearExplosion(threepts, 4d, 8d, endScale: 95);
			chart.TrackDisappearExplosion(threepts, 8d, xBias: 10, yBias: 2);



			#endregion

			#region RISER
			List<int> threepts2 = new();
			for (int i = 708; i < 889; i++)
			{
				if (chart.GetInnerAngleAtTile(i) == 30)
				{
					threepts2.Add(i);
				}
			}
			threepts2.Add(889);
			chart.AberrationByTile(threepts2, 4d, 35);
			chart.FisheyePulseByTile(threepts2, 4d, 47);
			chart.CameraRotationPulseByTile(threepts2, -5, 5, 170, 200, 4d);

			chart.TrackAppearExplosion(threepts2, 4d, 8d, endScale: 90, endOpacity: 1000);
			chart.TrackDisappearExplosion(threepts2, 3d, yBias: 2);



			#endregion

			#region HIGHLANDS
			chart.SetupVisionLimit();
			chart.SetVisionLimitAutofit("ob1.png", 905);

			chart.CameraTiltAndDiveTransition(905, 15, 230, 6d, 8d);
			chart.FloatingTrackBackground(905, 600d, maxSize: 250, xmin: -50, xmax: 50, ymin: -15, ymax: 85, totalTracks: 100,
				opacityMin: 40, opacityMax: 70, upliftSpeedMaxTilePerBeat: 0.2, upliftSpeedMinTilePerBeat: 0.05);

			chart.CameraHoverAndTiltToTileTransition(1018, -5, 350, 120, 4d, 9d);
			chart.CameraMoveRelativeToTile(1018, 9d, 4, 3);

			chart.CameraHoverAndTiltToTileTransition(1039, 5, 350, 120, 4d, 9d);
			chart.CameraMoveRelativeToTile(1039, 9d, -4, 3);

			chart.CameraHoverAndTiltToTileTransition(1060, -5, 350, 120, 4d, 9d);
			chart.CameraMoveRelativeToPlayer(1060, 6d, 0, 3);


			chart.TrackAppearScatter(1018, 1027, 2d, 6d);
			chart.TrackDisappearScatter(1018, 1027, 4d);

			chart.TrackAppearScatter(1027, 1039, 2d, 6d, endOpacity: 1000, endScale: 200);
			chart.TrackDisappearScatter(1027, 1039, 4d);

			chart.TrackAppearScatter(1039, 1048, 2d, 6d);
			chart.TrackDisappearScatter(1039, 1048, 4d);

			chart.TrackAppearScatter(1048, 1060, 2d, 6d, endOpacity: 1000, endScale: 200);
			chart.TrackDisappearScatter(1048, 1060, 4d);

			chart.TrackAppearScatter(1060, 1210, 2d, 6d);
			chart.TrackDisappearScatter(1060, 1210, 4d);

			chart.TrackAppearScatter(1210, 1218, 2d, 6d, endScale: 200);
			chart.TrackDisappearScatter(1210, 1218, 4d);

			chart.AberrationByBeat(905, 64, 1d, 4d);
			chart.FisheyePulseByBeat(905, 64, 1d, 4d, 49);

			chart.CameraHoverAndTiltToTileTransition(1218, 30, 300, 150, 4d, 8d);

			#endregion

			#region FINAL
			chart.TrackAppearScatter(1218, 1386, 2d, 12d);
			chart.TrackDisappearDownlift(1218, 1386, 4d);

			chart.RenderTextCentered(1382, "∀nnihilation", 0, 1100,
				inDuration: 4d, outDuration: 8d, holdDuration: 128);
			chart.RenderCreditRoleAndName(1382, "Artist", "Riya", 0, -1200, scale: 180d,
				inDuration: 4d, outDuration: 4d, holdDuration: 128);

			chart.RenderCreditRoleAndName(1382, "Track", "NanoCRoTor", -1000, 1200, scale: 150d,
				inDuration: 4d, outDuration: 4d, holdDuration: 128);
			chart.RenderCreditRoleAndName(1382, "Visual", "Qubic Resort", 1000, 1200, scale: 150d,
				inDuration: 4d, outDuration: 4d, holdDuration: 128);

			#endregion

			File.WriteAllText(@"G:\Adofai levels\anni\final.adofai", chart.ChartJson.ToJsonString());
		}
	}
}