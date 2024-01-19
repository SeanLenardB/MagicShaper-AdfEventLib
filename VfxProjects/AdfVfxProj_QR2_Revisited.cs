using MagicShaper.AdfExtensions;
using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects
{
	[Obsolete]
	internal class AdfVfxProj_QR2_Revisited
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.ParseChart(File.ReadAllText(@"G:\Adofai levels\QR2 Remake\noneffect.adofai"));

			foreach (var tile in chart.ChartTiles)
			{
				IAdfEvent? ee = null;
				foreach (var e in tile.TileEvents)
				{
					if (e is AdfEventAnimateTrack)
					{
						ee = e;
					}
				}
				if (ee is not null)
				{
					tile.TileEvents.Remove(ee);
				}
			}

			chart.TrackDisappearExplosion(new() { 22 }, 2d);
			chart.TrackAppearUplift(1, 22, 2d, 2d);

			chart.TrackDisappearDownlift(22, 93, 1d);

			chart.TrackDisappearComingOutOfTheScreen(93, 309, 1d, 20d, 1d);
			chart.TrackDisappearComingOutOfTheScreen(333, 358, 1d, 20d, 1d);
			chart.TrackDisappearExplosion(new() { 333 }, 3d);
			chart.TrackAppearScatter(22, 333, 2d, 4d);
			

			chart.TrackDisappearExplosion(new() { 366, 376, 390, 400, 411, 424, 438, 462 }, 2d);
			chart.TrackAppearExplosion(new() { 366, 376, 390, 400, 411, 424, 438, 462 }, 2d, 6d);

			chart.CameraRotationPulseByTile(new() { 366, 376, 379, 382, 390, 400, 411, 414, 417, 424, 438, 462 }, 
				15d, 10d, 300d, 250d, 4d);


			//chart.RandomCamera(-5d, 5d, -3d, 3d, -8d, 8d, 300d, 350d, 20d, 20d, 12d, 12d, 32d * 8, 474);
			//chart.RandomCamera(0d, 0d, 0d, 0d, 0d, 0d, 300d, 300d, 4d, 4d, 0d, 0d, 4d, 803);

			List<int> listOfKicksInFirstSpeedcore = new()
				{ 474, 483, 492, 501, 510, 519, 528, 533, 538, 543, 548, 553, 558, 567, 576,
				585, 588, 585+6, 588+6, 585+12, 588+12, 585+18, 588+18, 585+24, 
				618, 627, 636, 645, 650, 655, 660, 665, 674, 683, 688, 693, 696, 699, 702, 
				705, 710, 715, 718, 721, 724, 727, 732, 737, 740, 743, 746,
				749, 751, 753, 755, 757, 759, 761, 763, 765, 768, 
				771, 774,
				749+28, 751+28, 753+28, 755+28, 757+28, 759+28, 761+28, 763+28,
				793, 798, 803};
			chart.TrackDisappearExplosion(listOfKicksInFirstSpeedcore, 2d);
			chart.FisheyePulseByTile(listOfKicksInFirstSpeedcore, 16d);
			chart.TrackAppearExplosion(listOfKicksInFirstSpeedcore, 1d, 2d);

			chart.ChartTiles[474].TileEvents.Add(
				new AdfEventFlash() { 
					Plane = AdfFlashPlaneType.Background,
					StartColor = new("000000ff"),
					EndColor = new("003e71ff"),
					StartOpacity = 30d,
					EndOpacity = 10d,
					Duration = 32d,
					Ease = AdfEaseType.OutCubic
				});
			chart.ChartTiles[803].TileEvents.Add(
				new AdfEventFlash() { 
					Plane = AdfFlashPlaneType.Background,
					StartColor = new("ffffff"),
					EndColor = new("ffffff"),
					StartOpacity = 100d,
					EndOpacity = 0d,
					Duration = 2d,
					Ease = AdfEaseType.OutCubic
				});

			chart.TrackDisappearDownlift(803, 940, 3d, 50d, 300d, 200d);
			chart.TrackAppearUplift(803, 940, 3d, 5d, 50d);

			List<int> dubstepKicks = new() 
			{
				940, 945, 954, 959, 969, 974, 983, 988, 999, 1004, 1013, 1018, 1028, 1033, 1042, 1047, 1058
			};
			List<int> dubstepKicksForTrackAnim = new() 
			{
				945, 954, 959, 969, 974, 983, 988, 999, 1004, 1013, 1018, 1028, 1033, 1042, 1047, 1058
			};

			chart.TrackDisappearExplosion(dubstepKicksForTrackAnim, 2d);
			chart.FisheyePulseByTile(dubstepKicks, 8d);
			chart.TrackAppearExplosion(dubstepKicks, 1d, 2d);

			List<int> extratoneBeats = new()
			{
				1058, 1080, 1102, 1127, 1146, 1171, 1182, 1193, 1199, 1205, 1217, 1225, 1241
			};
			chart.TrackDisappearExplosion(extratoneBeats, 2d);
			chart.FisheyePulseByTile(extratoneBeats, 8d, 48.5d);
			chart.TrackAppearExplosion(extratoneBeats, 1d, 2d);
			extratoneBeats.RemoveAt(extratoneBeats.Count - 1);
			chart.CameraRotationPulseByTile(extratoneBeats, 25d, -25d, 300d, 220d, 16d);
			
			chart.CameraRotationPulseByTile(new(1241), -30d, -15d, 300d, 300d, 8d);


			chart.TrackDisappearDownlift(1241, 1325, 3d, 50d, 300d, 200d);
			chart.TrackAppearUplift(1241, 1325, 3d, 5d, 50d);

			chart.RandomCamera(-3d, 3d, -1d, 3d, -4d, 4d, 275d, 325d, 6d, 6d, 2d, 2d, 8d * 7, 1252);
			chart.RandomCamera(-3d, 3d, 2d, 5d, -5d, 5d, 300d, 335d, 6d*3, 6d*3, 2d*3, 2d*3, 3*8d*8, 1325);


			chart.TrackDisappearUplift(1325, 1512, 2d);
			chart.TrackAppearScatter(1325, 1512, 2d, 4d);




			List<int> themeFirstList = new()
			{
				1560, 1616, 1671, 1735, 1797, 1853, 1908, 1972, 
				2029, 2089, 2141, 2210, 2280
			};

			chart.TrackDisappearExplosion(themeFirstList, 2d);
			// chart.FisheyePulse(extratoneBeats, 8d, 48.5d);
			chart.TrackAppearExplosion(themeFirstList, 2d, 5d);
			// chart.FisheyePulseByBeat(1560, 8 * 12, 4d, 4d, 45d);
			chart.AberrationByBeat(1560, 8 * 12, 4d, 4d, 45d);
			chart.BlurByBeatOutEase(1560, 12, 32d, 16d);

			themeFirstList.RemoveAt(themeFirstList.Count - 1);
			chart.RandomCamera(-5d, 5d, 0d, 4d, -8d, 8d, 290d, 390d, 18d, 18d, 14d, 14d, 32 * 12d, 1560);

			// final kicks
			chart.RandomCamera(3d, 3d, 1d, 1d, 15d, 15d, 300d, 300d, 8d, 8d, 0d, 0d, 8d, 2280);

			chart.TrackDisappearUplift(2280, 2426, 1d, 50d);
			chart.TrackAppearScatter(2280, 2630, 1d, 3d, 50d, 300d);
			chart.FisheyePulseByBeat(2598, 1, 114514d, 32d, 30d);
			chart.CameraRotationPulseByTile(new() { 2630 }, 30d, 25d, 300d, 300d, 16d);
			//chart.RandomCamera(0d, 0d, 0d, 0d, 0d, 0d, 300d, 300d, 4d, 4d, 0d, 0d, 4d, 2630);

			//chart.FisheyePulseByBeat(2280, 4 * 16, 2d, 2d, 45d);
			chart.ChartTiles[2280].TileEvents.Add(
				new AdfEventFlash()
				{
					Plane = AdfFlashPlaneType.Background,
					StartColor = new("000000ff"),
					EndColor = new("d2a0ffff"),
					StartOpacity = 30d,
					EndOpacity = 10d,
					Duration = 32d,
					Ease = AdfEaseType.OutCubic
				});
			chart.ChartTiles[2630].TileEvents.Add(
				new AdfEventFlash()
				{
					Plane = AdfFlashPlaneType.Background,
					StartColor = new("ffffff"),
					EndColor = new("ffffff"),
					StartOpacity = 100d,
					EndOpacity = 0d,
					Duration = 2d,
					Ease = AdfEaseType.OutCubic
				});
			chart.AberrationByBeat(2280, 4 * 16, 2d, 2d, 40d);


			chart.FisheyePulseByTile(new() { 2348, 2394, 2406 }, 12d);

			chart.FisheyePulseByBeat(2426, 24, 2d, 12d, 48d);

			List<int> fastKicksListOne = new();
			for (int i = 0; i < 20; i++)
			{
				fastKicksListOne.Add(2432 + i * 6);
			}
			fastKicksListOne.Add(2522);
			fastKicksListOne.Add(2526);
			fastKicksListOne.Add(2532);
			for (int i = 0; i < 6; i++)
			{
				fastKicksListOne.Add(2536 + i * 6);
			}
			for (int i = 0; i < 16; i++)
			{
				fastKicksListOne.Add(2568 + i * 2);
			}
			fastKicksListOne.Add(2630);
			chart.TrackDisappearExplosion(fastKicksListOne, 2d);







			chart.TrackDisappearDownlift(2630, 2845, 3d, 50d, 300d, 200d);
			chart.TrackAppearUplift(2630, 2845, 3d, 5d, 50d);

			chart.RandomCamera(-3d, 3d, -1d, 3d, -4d, 4d, 275d, 325d, 12d, 12d, 4d, 4d, 16d * 7, 2651);
			chart.RandomCamera(0d, 0d, 4d, 4d, 0d, 0d, 300d, 300d, 32d, 32d, 0d, 0d, 32d, 2845);

			chart.TrackDisappearUplift(2845, 3152, 1d);
			chart.TrackAppearScatter(2845, 3152, 1.5d, 1.5d, 15d);

			// chart.TrackDisappearExplosion(new() { 3152 }, 1d);

			chart.TrackDisappearDownlift(3152, 3282, 4d);
			chart.TrackAppearUplift(3152, 3282, 4d, 4d);


			chart.TrackDisappearUplift(3282, 3672, 2d);
			chart.TrackAppearScatter(3282, 3756, 2d, 4d);

			chart.CameraRandomWobble(-1d, 1d, 0d, 2d, -4d, 4d, 280d, 350d, 24d, 32d, 12d, 18d, 8 * 6 * 8d, 3282);




			// final part!!!
			List<int> themeSecondList = new()
			{
				3756, 3812, 3867, 3931, 4010, 4071, 4127, 4189, 
				4263, 4323, 4375, 4444, 4526
			};

			chart.TrackDisappearExplosion(themeSecondList, 2d);

			chart.TrackAppearExplosion(themeSecondList, 2d, 5d);

			chart.AberrationByBeat(3756, 8 * 12, 4d, 4d, 45d);
			chart.BlurByBeatOutEase(3756, 12, 32d, 16d);

			themeSecondList.RemoveAt(themeSecondList.Count - 1);
			chart.RandomCamera(-5d, 5d, 0d, 4d, -8d, 8d, 290d, 390d, 18d, 18d, 14d, 14d, 32 * 12d, 3756);

			// final kicks
			chart.RandomCamera(-3d, -3d, 1d, 1d, 5d, 5d, 300d, 300d, 8d, 8d, 0d, 0d, 8d, 4526);

			chart.TrackDisappearUplift(4526, 4692, 1d, 50d);
			chart.TrackAppearScatter(4526, 5000, 1d, 3d, 50d, 300d);
;
			chart.ChartTiles[4526].TileEvents.Add(
				new AdfEventFlash()
				{
					Plane = AdfFlashPlaneType.Background,
					StartColor = new("000000ff"),
					EndColor = new("d2a0ffff"),
					StartOpacity = 30d,
					EndOpacity = 10d,
					Duration = 32d,
					Ease = AdfEaseType.OutCubic
				});
			chart.ChartTiles[4999].TileEvents.Add(
				new AdfEventFlash()
				{
					Plane = AdfFlashPlaneType.Background,
					StartColor = new("ffffff"),
					EndColor = new("ffffff"),
					StartOpacity = 100d,
					EndOpacity = 0d,
					Duration = 2d,
					Ease = AdfEaseType.OutCubic
				});
			chart.AberrationByBeat(4526, 4 * 16, 2d, 2d, 40d);


			chart.FisheyePulseByTile(new() { 4614, 4660, 4672 }, 12d);

			chart.FisheyePulseByBeat(4692, 32, 2d, 12d, 48d);


			List<int> fastKicksListTwo = new();
			for (int i = 0; i < 20; i++)
			{
				fastKicksListTwo.Add(4698 + i * 6);
			}
			fastKicksListTwo.Add(4812);
			fastKicksListTwo.Add(4816);
			fastKicksListTwo.Add(4822);
			for (int i = 0; i < 10; i++)
			{
				fastKicksListTwo.Add(4826 + i * 6);
			}
			for (int i = 0; i < 16; i++)
			{
				fastKicksListTwo.Add(4882 + i * 2);
			}
			fastKicksListTwo.Add(4944);
			fastKicksListTwo.Add(4968);
			chart.TrackDisappearExplosion(fastKicksListTwo, 2d);

			chart.RandomCamera(-8d, -8d, 6d, 6d, 6d, 6d, 350d, 350d, 16d, 0d, 16d, 4880);
			chart.CameraRotationPulseByTile(new() { 4999 }, 6d, 6d, 350d, 350d, 64d);

			File.WriteAllText(@"G:\Adofai levels\QR2 Remake\low effect.adofai", chart.ChartJson.ToJsonString());


		}
	}
}
