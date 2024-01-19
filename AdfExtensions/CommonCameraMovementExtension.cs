using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	internal static class CommonCameraMovementExtension
	{
		public static void RandomCamera(
			this AdfChart chart,
			double xmin,
			double xmax,
			double ymin,
			double ymax,
			double rmin,
			double rmax,
			double zmin,
			double zmax,
			double beatsMin,
			double beatsMax,
			double holdbeatMin,
			double holdbeatMax,
			double duration,
			int targetTile = 21,
			AdfEaseType ease = AdfEaseType.OutCubic)
		{
			double currentBeat = 0d;
			Random random = new();
			while (currentBeat < duration)
			{
				double currentDurationMove = random.NextDouble() * (beatsMax - beatsMin) + beatsMin;

				chart.ChartTiles[targetTile].TileEvents.Add(
					new AdfEventMoveCamera()
					{
						Position = new(
							random.NextDouble() * (xmax - xmin) + xmin,
							random.NextDouble() * (ymax - ymin) + ymin),
						Duration = currentDurationMove,
						AngleOffset = currentBeat * 180d,
						Ease = ease,
						Rotation = random.NextDouble() * (rmax - rmin) + rmin,
						Zoom = random.NextDouble() * (zmax - zmin) + zmin,
					});

				double currentDurationHold = random.NextDouble() * (holdbeatMax - holdbeatMin) + holdbeatMin;



				currentBeat += currentDurationMove + currentDurationHold;
			}
		}

		public static void RandomCamera(
			this AdfChart chart,
			double xmin,
			double xmax,
			double ymin,
			double ymax,
			double rmin,
			double rmax,
			double zmin,
			double zmax,
			double movebeat,
			double holdbeat,
			double duration,
			int targetTile = 21,
			AdfEaseType ease = AdfEaseType.OutCubic)
			=> RandomCamera(chart, xmin, xmax, ymin, ymax, rmin, rmax, zmin, zmax, 
				movebeat, movebeat, holdbeat, holdbeat, duration, targetTile, ease);

		public static void CameraRandomWobble(
			this AdfChart chart,
			double xmin,
			double xmax,
			double ymin,
			double ymax,
			double rmin,
			double rmax,
			double zmin,
			double zmax,
			double beatsMin,
			double beatsMax,
			double holdbeatMin,
			double holdbeatMax,
			double duration,
			int targetTile)
		{
			double currentBeat = 0d;
			Random random = new();
			while (currentBeat < duration)
			{
				double currentDurationMove = random.NextDouble() * (beatsMax - beatsMin) + beatsMin;

				chart.ChartTiles[targetTile].TileEvents.Add(
					new AdfEventMoveCamera()
					{
						Position = new(
							random.NextDouble() * (xmax - xmin) + xmin,
							random.NextDouble() * (ymax - ymin) + ymin),
						Duration = currentDurationMove,
						AngleOffset = currentBeat * 180d,
						Ease = AdfEaseType.InOutSine,
						Rotation = random.NextDouble() * (rmax - rmin) + rmin,
						Zoom = random.NextDouble() * (zmax - zmin) + zmin,
					});

				double currentDurationHold = random.NextDouble() * (holdbeatMax - holdbeatMin) + holdbeatMin;



				currentBeat += currentDurationMove + currentDurationHold;
			}
		}

		public static void CameraMoveToTileRandomOutEase(
			this AdfChart chart,
			List<int> targetTiles,
			double xmin, double xmax, double ymin, double ymax,
			double rmin, double rmax, double zmin, double zmax,
			double beatPerMoveMin, double beatPerMoveMax,
			bool togetherWithBlur = true)
		{
			Random random = new();
			for (int i = 0; i < targetTiles.Count; i++)
			{
				double thisMove = random.NextDouble() * (beatPerMoveMax - beatPerMoveMin) + beatPerMoveMin;

				chart.ChartTiles[targetTiles[i]].TileEvents.Add(
					new AdfEventMoveCamera()
					{
						Position = new(
							random.NextDouble() * (xmax - xmin) + xmin,
							random.NextDouble() * (ymax - ymin) + ymin),
						Duration = thisMove,
						Ease = AdfEaseType.OutCubic,
						Rotation = random.NextDouble() * (rmax - rmin) + rmin,
						Zoom = random.NextDouble() * (zmax - zmin) + zmin,
					});
				if (i == 0)
				{
					(chart.ChartTiles[targetTiles[i]].TileEvents[^1] as AdfEventMoveCamera)!.RelativeTo = AdfCameraRelativeToType.Tile;
				}
				if (togetherWithBlur)
				{
					chart.BlurByBeatOutEase(targetTiles[i], 1, 114514, thisMove, 200);
				}
			}
		}

		public static void CameraMoveToTileRandomInEase(
			this AdfChart chart,
			List<int> targetTiles,
			double xmin, double xmax, double ymin, double ymax,
			double rmin, double rmax, double zmin, double zmax,
			double beatPerMoveMin, double beatPerMoveMax,
			bool togetherWithBlur = true)
		{
			Random random = new();
			for (int i = 0; i < targetTiles.Count; i++)
			{
				double thisMove = random.NextDouble() * (beatPerMoveMax - beatPerMoveMin) + beatPerMoveMin;

				chart.ChartTiles[targetTiles[i]].TileEvents.Add(
					new AdfEventMoveCamera()
					{
						Position = new(
							random.NextDouble() * (xmax - xmin) + xmin,
							random.NextDouble() * (ymax - ymin) + ymin),
						Duration = thisMove,
						Ease = AdfEaseType.InCubic,
						Rotation = random.NextDouble() * (rmax - rmin) + rmin,
						Zoom = random.NextDouble() * (zmax - zmin) + zmin,
					});
				if (i == 0)
				{
					(chart.ChartTiles[targetTiles[i]].TileEvents[^1] as AdfEventMoveCamera)!.RelativeTo = AdfCameraRelativeToType.Tile;
				}
				if (togetherWithBlur)
				{
					chart.BlurByBeatInEase(targetTiles[i], 1, 114514, thisMove, 200);
				}
			}
		}


		/// <summary>
		/// Add this camera effect once per group of 3pt!<br></br>
		/// 3pt refers to a group of (270-270-180), (135-135-135-135-90-90), etc.<br></br>
		/// <paramref name="ptDuration"/> refers to 1.5d (270), 0.75d (135) in the example above.
		/// <paramref name="threePtTiles"/> includes the 180, 90 in the example above. Only include one.<br></br>
		/// 
		/// </summary>
		public static void CameraTiltOnThreePt(
			this AdfChart chart,
			List<int> threePtTiles,
			double firstPtRotation, double lastPtRotation,
			double ptDuration, double finalRotation = 0d)
		{
			for (int i = 0; i < threePtTiles.Count - 1; i++)
			{
				chart.ChartTiles[threePtTiles[i]].TileEvents.Add(new AdfEventMoveCamera()
				{
					Ease = AdfEaseType.OutCubic,
					Duration = ptDuration * 2 / 3,
					Rotation = (firstPtRotation * (threePtTiles.Count - i - 2) + lastPtRotation * i) / (threePtTiles.Count - 2)
				});
				chart.ChartTiles[threePtTiles[i]].TileEvents.Add(new AdfEventMoveCamera()
				{
					Ease = AdfEaseType.InCubic,
					Duration = ptDuration / 3,
					Rotation = (firstPtRotation * (threePtTiles.Count - i - 2 + 0.5d) + lastPtRotation * (i - 0.5d)) / (threePtTiles.Count - 2),
					AngleOffset = ptDuration * 180 * 2 / 3
				});
			}

			chart.ChartTiles[threePtTiles[^1]].TileEvents.Add(new AdfEventMoveCamera()
			{
				Ease = AdfEaseType.OutCubic,
				Duration = ptDuration / 3 * 2 / 3,
				Rotation = lastPtRotation
			});
			chart.ChartTiles[threePtTiles[^1]].TileEvents.Add(new AdfEventMoveCamera()
			{
				Ease = AdfEaseType.InCubic,
				Duration = ptDuration * 2 / 3 * 2 / 3,
				Rotation = 0,
				AngleOffset = ptDuration * 180 * 2 / 3 / 3
			});
		}


		public static void CameraTiltAndDiveTransition(this AdfChart chart,
			int transitionTile, double tiltMaxAngle, double finalZoom,
			double tiltBeats, double scaleBeats)
		{
			chart.ChartTiles[transitionTile].TileEvents.Add(new AdfEventMoveCamera()
			{
				AngleOffset = -180d * tiltBeats,
				Duration = tiltBeats,
				Ease = AdfEaseType.InQuad,
				Rotation = tiltMaxAngle,
				Zoom = 5d
			});
			chart.ChartTiles[transitionTile].TileEvents.Add(new AdfEventMoveCamera()
			{
				Duration = scaleBeats,
				Ease = AdfEaseType.OutExpo,
				Zoom = finalZoom,
				Rotation = 0d
			});

			chart.ChartTiles[transitionTile].TileEvents.Add(new AdfEventFlash()
			{
				StartColor = new("000000ff"),
				EndColor = new("000000ff"),
				StartOpacity = 0d,
				EndOpacity = 100d,
				AngleOffset = -180d * tiltBeats,
				Duration = tiltBeats,
				Ease = AdfEaseType.InQuad,
				Plane = AdfFlashPlaneType.Foreground
			});
			chart.ChartTiles[transitionTile].TileEvents.Add(new AdfEventFlash()
			{
				StartColor = new("000000ff"),
				EndColor = new("000000ff"),
				StartOpacity = 100d,
				EndOpacity = 0d,
				Duration = scaleBeats,
				Ease = AdfEaseType.OutSine,
				Plane = AdfFlashPlaneType.Foreground
			});
		}

		public static void CameraHoverAndTiltToTileTransition(this AdfChart chart,
			int transitionTile, double tiltMaxAngle, double finalZoom, double minZoom,
			double tiltBeats, double scaleBeats)
		{
			chart.ChartTiles[transitionTile].TileEvents.Add(new AdfEventMoveCamera()
			{
				AngleOffset = -180d * tiltBeats,
				Duration = tiltBeats,
				Ease = AdfEaseType.InQuad,
				Rotation = tiltMaxAngle,
				RelativeTo = AdfCameraRelativeToType.Tile,
				Position = new(0, 0),
				Zoom = minZoom
			});
			chart.ChartTiles[transitionTile].TileEvents.Add(new AdfEventMoveCamera()
			{
				Duration = scaleBeats,
				Ease = AdfEaseType.OutExpo,
				Zoom = finalZoom,
				Rotation = 0d
			});


		}

		public static void CameraMoveRelativeToPlayer(this AdfChart chart, int targetTile, double duration,
			double x = 0, double y = 0)
		{
			chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveCamera()
			{
				Duration = duration,
				Ease = AdfEaseType.OutCubic,
				RelativeTo = AdfCameraRelativeToType.Player,
				Position = new(x, y)
			});
		}

		public static void CameraMoveRelativeToTile(this AdfChart chart, int targetTile, double duration, 
			double x = 0, double y = 0)
		{
			chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveCamera()
			{
				Duration = duration,
				Ease = AdfEaseType.OutCubic,
				RelativeTo = AdfCameraRelativeToType.Tile,
				Position = new(x, y)
			});
		}
	}
}
