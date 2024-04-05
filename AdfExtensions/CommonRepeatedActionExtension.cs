using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	internal static class CommonRepeatedActionExtension
	{
		public static void CameraRotationPulseByTile(
			this AdfChart chart, 
			List<int> tiles,
			double minRotation, double maxRotation,
			double minZoom, double maxZoom,
			double pulseTime)
		{
			Random random = new();
			foreach (var tile in tiles)
			{
				chart.ChartTiles[tile].TileEvents.Add(
					new AdfEventMoveCamera()
					{
						Rotation = (random.NextDouble() > 0.5d ? 1d : -1d) 
							* (random.NextDouble() * (maxRotation - minRotation) + minRotation),
						Duration = 0d,
						Zoom = random.NextDouble() * (maxZoom - minZoom) + minZoom,
						AngleOffset = -0.01d
					});
				chart.ChartTiles[tile].TileEvents.Add(
					new AdfEventMoveCamera()
					{
						Rotation = 0d,
						Zoom = maxZoom,
						Duration = pulseTime,
						Ease = AdfEaseType.OutCubic
					});
			}
		}

		public static void FisheyePulseByTile(
			this AdfChart chart,
			List<int> tiles,
			double eachDuration,
			double minParam = 47d)
		{
			foreach (var tile in tiles)
			{
				chart.ChartTiles[tile].TileEvents.Add(
					new AdfEventSetFilter()
					{
						Filter = AdfFilter.Fisheye,
						Duration = 0d,
						Intensity = minParam,
						AngleOffset = -0.01d
					});
				chart.ChartTiles[tile].TileEvents.Add(
					new AdfEventSetFilter()
					{
						Filter = AdfFilter.Fisheye,
						Intensity = 50d,
						Duration = eachDuration,
						Ease = AdfEaseType.OutCubic
					});
			}
		}

		public static void FisheyePulseByBeat(
			this AdfChart chart,
			int startTile,
			int repetition,
			double intervalBeats,
			double eachDuration,
			double minParam = 47d)
		{
			for (int i = 0; i < repetition; i++)
			{
				chart.ChartTiles[startTile].TileEvents.Add(
					new AdfEventSetFilter()
					{
						Filter = AdfFilter.Fisheye,
						Duration = 0d,
						Intensity = minParam,
						AngleOffset = -0.01d + i * 180d * intervalBeats
					});
				chart.ChartTiles[startTile].TileEvents.Add(
					new AdfEventSetFilter()
					{
						Filter = AdfFilter.Fisheye,
						Intensity = 50d,
						Duration = eachDuration,
						Ease = AdfEaseType.OutCubic,
						AngleOffset = i * 180d * intervalBeats
					});
			}
		}

		public static void AberrationByBeat(
			this AdfChart chart,
			int startTile,
			int repetition,
			double intervalBeats,
			double eachDuration,
			double minParam = 47d)
		{
			for (int i = 0; i < repetition; i++)
			{
				chart.ChartTiles[startTile].TileEvents.Add(
					new AdfEventSetFilter()
					{
						Filter = AdfFilter.Aberration,
						Duration = 0d,
						Intensity = minParam,
						AngleOffset = -0.01d + i * 180d * intervalBeats
					});
				chart.ChartTiles[startTile].TileEvents.Add(
					new AdfEventSetFilter()
					{
						Filter = AdfFilter.Aberration,
						Intensity = 50d,
						Duration = eachDuration,
						Ease = AdfEaseType.OutCubic,
						AngleOffset = i * 180d * intervalBeats
					});
			}
		}

		public static void AberrationByTile(
			this AdfChart chart,
			List<int> tiles,
			double eachDuration,
			double minParam = 47d)
		{
			foreach (var tile in tiles)
			{
				chart.ChartTiles[tile].TileEvents.Add(
					new AdfEventSetFilter()
					{
						Filter = AdfFilter.Aberration,
						Duration = 0d,
						Intensity = minParam,
						AngleOffset = -0.01d
					});
				chart.ChartTiles[tile].TileEvents.Add(
					new AdfEventSetFilter()
					{
						Filter = AdfFilter.Aberration,
						Intensity = 50d,
						Duration = eachDuration,
						Ease = AdfEaseType.OutCubic
					});
			}
		}

		public static void BlurByBeatOutEase(
			this AdfChart chart,
			int startTile,
			int repetition,
			double intervalBeats,
			double eachDuration,
			double maxParam = 600d)
		{
			for (int i = 0; i < repetition; i++)
			{
				chart.ChartTiles[startTile].TileEvents.Add(
					new AdfEventSetFilter()
					{
						Filter = AdfFilter.GaussianBlur,
						Duration = 0d,
						Intensity = maxParam,
						AngleOffset = -0.0001d + i * 180d * intervalBeats
					});
				chart.ChartTiles[startTile].TileEvents.Add(
					new AdfEventSetFilter()
					{
						Filter = AdfFilter.GaussianBlur,
						Intensity = 0d,
						Duration = eachDuration,
						Ease = AdfEaseType.OutCubic,
						AngleOffset = i * 180d * intervalBeats
					});
			}
		}

		public static void BlurByBeatInEase(
			this AdfChart chart,
			int startTile,
			int repetition,
			double intervalBeats,
			double eachDuration,
			double maxParam = 600d)
		{
			for (int i = 0; i < repetition; i++)
			{
				
				chart.ChartTiles[startTile].TileEvents.Add(
					new AdfEventSetFilter()
					{
						Filter = AdfFilter.GaussianBlur,
						Intensity = maxParam,
						Duration = eachDuration,
						Ease = AdfEaseType.InCubic,
						AngleOffset = i * 180d * intervalBeats
					});
				chart.ChartTiles[startTile].TileEvents.Add(
					new AdfEventSetFilter()
					{
						Filter = AdfFilter.GaussianBlur,
						Duration = 0d,
						Intensity = 0d,
						AngleOffset = eachDuration * 180d + i * 180d * intervalBeats - 0.0001d
					});
			}
		}
	}
}
