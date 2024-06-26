﻿using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	/// <summary>
	/// You should consider using <see cref="ModernTrackAnimationExtension"/> if applicable.
	/// </summary>
	internal static class CommonTrackAnimationExtension
	{
		public static void TrackDisappearExplosion(
			this AdfChart chart, 
			List<int> tiles,
			double duration,
			double opacityShrinkTime = 0.5d,
			double xBias = 0d, double yBias = 0d, int failProof = 100, double m = 1)
		{
			double standardBpm = chart.GetTileBpmAt(0);
			
			Random random = new();
			for (int i = 0; i < tiles.Count; i++)
			{
				for (int j = i == 0 ? tiles[0] - failProof : tiles[i - 1]; j < tiles[i]; j++)
				{
					chart.ChartTiles[tiles[i]].TileEvents.Add(
					new AdfEventMoveTrack()
					{
						StartTile = new(j, AdfTileReferenceType.Start),
						EndTile = new(j, AdfTileReferenceType.Start),
						PositionOffset = new(random.NextDouble() * 20d * m - 10d * m + xBias, random.NextDouble() * 20d * m - 10d * m + yBias),
						RotationOffset = random.NextDouble() * 90d - 45d,
						Scale = new(random.NextDouble() * 75d + 150d),
						Ease = AdfEaseType.OutExpo,
						Duration = chart.GetTileBpmAt(tiles[i]) / standardBpm * duration
					});
					chart.ChartTiles[tiles[i]].TileEvents.Add(
					new AdfEventMoveTrack()
					{
						StartTile = new(j, AdfTileReferenceType.Start),
						EndTile = new(j, AdfTileReferenceType.Start),
						Opacity = 0d,
						Ease = AdfEaseType.OutCubic,
						Duration = chart.GetTileBpmAt(tiles[i]) / standardBpm * duration * opacityShrinkTime
					});
				}
				
			}
		}

		public static void TrackAppearExplosion(
			this AdfChart chart,
			List<int> tiles,
			double duration,
			double previewBeats,
			double endOpacity = 100d,
			double endScale = 100d,
			double m = 1)
		{
			double standardBpm = chart.GetTileBpmAt(0);

			Random random = new();
			for (int i = 1; i < tiles.Count; i++)
			{
				for (int j = tiles[i - 1]; j < tiles[i]; j++)
				{
					chart.ChartTiles[tiles[i]].TileEvents.Add(
					new AdfEventMoveTrack()
					{
						StartTile = new(j, AdfTileReferenceType.Start),
						EndTile = new(j, AdfTileReferenceType.Start),
						PositionOffset = new(random.NextDouble() * 20d  * m- 10d * m, random.NextDouble() * 20d * m - 10d * m),
						RotationOffset = random.NextDouble() * 90d - 45d,
						Scale = new(random.NextDouble() * 100d + 250d),
						Opacity = 0d,
						Ease = AdfEaseType.OutExpo,
						Duration = 0d,
						AngleOffset = -114514d
					});
					chart.ChartTiles[tiles[i]].TileEvents.Add(
					new AdfEventMoveTrack()
					{
						StartTile = new(j, AdfTileReferenceType.Start),
						EndTile = new(j, AdfTileReferenceType.Start),
						PositionOffset = new(0d, 0d),
						RotationOffset = 0d,
						Scale = new(endScale),
						Opacity = endOpacity,
						Ease = AdfEaseType.OutExpo,
						Duration = chart.GetTileBpmAt(tiles[i]) / standardBpm * duration,
						AngleOffset = - chart.GetTileBpmAt(tiles[i]) / standardBpm * (previewBeats + duration) * 180
					});
				}

			}
		}

		public static void TrackAppearUplift(
			this AdfChart chart,
			int tileStart,
			int tileEnd,
			double duration,
			double previewBeats,
			double randomPercentage = 30d,
			double endOpacity = 100d, 
			double endScale = 100d)
		{
			double standardBpm = chart.GetTileBpmAt(0);

			Random random = new();
			for (int i = tileStart; i < tileEnd; i++)
			{
				chart.ChartTiles[i].TileEvents.Add(
					new AdfEventMoveTrack()
					{
						StartTile = new(i, AdfTileReferenceType.Start),
						EndTile = new(i, AdfTileReferenceType.Start),
						PositionOffset = new(random.NextDouble() * 10d - 5d, random.NextDouble() * 10d - 20d),
						RotationOffset = random.NextDouble() * 90d - 45d,
						Scale = new(random.NextDouble() * 75d + 150d),
						Opacity = 0d,
						Duration = 0d,
						AngleOffset = -114514d
					});
				chart.ChartTiles[i].TileEvents.Add(
				new AdfEventMoveTrack()
				{
					StartTile = new(i, AdfTileReferenceType.Start),
					EndTile = new(i, AdfTileReferenceType.Start),
					PositionOffset = new(0d, 0d),
					RotationOffset = 0d,
					Scale = new(endScale),
					Opacity = endOpacity,
					Ease = AdfEaseType.OutExpo,
					Duration = chart.GetTileBpmAt(i) / standardBpm * duration,
					AngleOffset = 
						(-chart.GetTileBpmAt(i) / standardBpm * (previewBeats + duration) * 180) 
						* (1 - random.NextDouble() * randomPercentage/100d)
				});

			}
		}

		public static void TrackAppearDownlift(
			this AdfChart chart,
			int tileStart,
			int tileEnd,
			double duration,
			double previewBeats,
			double randomPercentage = 30d,
			double endOpacity = 100d,
			double endScale = 100d)
		{
			double standardBpm = chart.GetTileBpmAt(0);

			Random random = new();
			for (int i = tileStart; i < tileEnd; i++)
			{
				chart.ChartTiles[i].TileEvents.Add(
					new AdfEventMoveTrack()
					{
						StartTile = new(i, AdfTileReferenceType.Start),
						EndTile = new(i, AdfTileReferenceType.Start),
						PositionOffset = new(random.NextDouble() * 10d - 5d, random.NextDouble() * 10d + 10d),
						RotationOffset = random.NextDouble() * 90d - 45d,
						Scale = new(random.NextDouble() * 75d + 150d),
						Opacity = 0d,
						Duration = 0d,
						AngleOffset = -114514d
					});
				chart.ChartTiles[i].TileEvents.Add(
				new AdfEventMoveTrack()
				{
					StartTile = new(i, AdfTileReferenceType.Start),
					EndTile = new(i, AdfTileReferenceType.Start),
					PositionOffset = new(0d, 0d),
					RotationOffset = 0d,
					Scale = new(endScale),
					Opacity = endOpacity,
					Ease = AdfEaseType.OutExpo,
					Duration = chart.GetTileBpmAt(i) / standardBpm * duration,
					AngleOffset =
						(-chart.GetTileBpmAt(i) / standardBpm * (previewBeats + duration) * 180)
						* (1 - random.NextDouble() * randomPercentage / 100d)
				});

			}
		}


		public static void TrackDisappearUplift(
			this AdfChart chart,
			int tileStart,
			int tileEnd,
			double duration,
			double randomPercentage = 30d)
		{
			double standardBpm = chart.GetTileBpmAt(0);

			Random random = new();
			for (int i = tileStart; i < tileEnd; i++)
			{
				chart.ChartTiles[i].TileEvents.Add(
				new AdfEventMoveTrack()
				{
					StartTile = new(i, AdfTileReferenceType.Start),
					EndTile = new(i, AdfTileReferenceType.Start),
					PositionOffset = new(random.NextDouble() * 10d - 5d, random.NextDouble() * 10d + 10d),
					RotationOffset = random.NextDouble() * 90d - 45d,
					Scale = new(random.NextDouble() * 75d + 150d),
					Opacity = 0d,
					Ease = AdfEaseType.InExpo,
					Duration = chart.GetTileBpmAt(i) / standardBpm * duration,
					AngleOffset = 360d + 360d * random.NextDouble() * randomPercentage / 100d
				});

			}
		}

		public static void TrackAppearScatter(
			this AdfChart chart,
			int tileStart,
			int tileEnd,
			double duration,
			double previewBeats,
			double randomPercentage = 30d,
			double endOpacity = 100d, double endScale = 100d)
		{
			double standardBpm = chart.GetTileBpmAt(0);

			Random random = new();
			for (int i = tileStart; i < tileEnd; i++)
			{
				chart.ChartTiles[i].TileEvents.Add(
					new AdfEventMoveTrack()
					{
						StartTile = new(i, AdfTileReferenceType.Start),
						EndTile = new(i, AdfTileReferenceType.Start),
						PositionOffset = new(random.NextDouble() * 20d - 10d, random.NextDouble() * 20d - 10d),
						RotationOffset = random.NextDouble() * 90d - 45d,
						Scale = new(random.NextDouble() * 150d + 250d),
						Opacity = 0d,
						Duration = 0d,
						AngleOffset = -114514d
					});
				chart.ChartTiles[i].TileEvents.Add(
				new AdfEventMoveTrack()
				{
					StartTile = new(i, AdfTileReferenceType.Start),
					EndTile = new(i, AdfTileReferenceType.Start),
					PositionOffset = new(0d, 0d),
					RotationOffset = 0d,
					Scale = new(endScale),
					Opacity = endOpacity,
					Ease = AdfEaseType.OutCubic,
					Duration = chart.GetTileBpmAt(i) / standardBpm * duration,
					AngleOffset =
						(-chart.GetTileBpmAt(i) / standardBpm * (previewBeats + duration) * 180)
						* (1 - random.NextDouble() * randomPercentage / 100d)
				});

			}
		}

		public static void TrackDisappearScatter(
			this AdfChart chart,
			int tileStart,
			int tileEnd,
			double duration,
			double randomPercentage = 30d)
		{
			double standardBpm = chart.GetTileBpmAt(0);

			Random random = new();
			for (int i = tileStart; i < tileEnd; i++)
			{
				chart.ChartTiles[i].TileEvents.Add(
				new AdfEventMoveTrack()
				{
					StartTile = new(i, AdfTileReferenceType.Start),
					EndTile = new(i, AdfTileReferenceType.Start),
					PositionOffset = new(random.NextDouble() * 20d - 10d, random.NextDouble() * 20d - 10d),
					RotationOffset = random.NextDouble() * 90d - 45d,
					Scale = new(random.NextDouble() * 150d + 250d),
					Opacity = 0d,
					Ease = AdfEaseType.InCubic,
					Duration = chart.GetTileBpmAt(i) / standardBpm * duration,
					AngleOffset = 360d + 360d * random.NextDouble() * randomPercentage / 100d
				});

			}
		}

		public static void TrackDisappearDownlift(
			this AdfChart chart,
			int tileStart,
			int tileEnd,
			double duration,
			double randomPercentage = 30d,
			double resizeMax = 200d, double resizeMin = 100d)
		{
			double standardBpm = chart.GetTileBpmAt(0);

			Random random = new();
			for (int i = tileStart; i < tileEnd; i++)
			{
				chart.ChartTiles[i].TileEvents.Add(
				new AdfEventMoveTrack()
				{
					StartTile = new(i, AdfTileReferenceType.Start),
					EndTile = new(i, AdfTileReferenceType.Start),
					PositionOffset = new(random.NextDouble() * 10d - 5d, random.NextDouble() * 10d - 20d),
					RotationOffset = random.NextDouble() * 90d - 45d,
					Scale = new(random.NextDouble() * (resizeMax - resizeMin) + resizeMin),
					Opacity = 0d,
					Ease = AdfEaseType.InExpo,
					Duration = chart.GetTileBpmAt(i) / standardBpm * duration,
					AngleOffset = 360d + 360d * random.NextDouble() * randomPercentage / 100d
				});

			}
		}

		public static void TrackDisappearComingOutOfTheScreen(
			this AdfChart chart,
			int tileStart,
			int tileEnd,
			double duration,
			double randomPercentage = 30d,
			double beatsOffset = 2d)
		{
			double standardBpm = chart.GetTileBpmAt(0);

			Random random = new();
			for (int i = tileStart; i < tileEnd; i++)
			{
				chart.ChartTiles[i].TileEvents.Add(
				new AdfEventMoveTrack()
				{
					StartTile = new(i, AdfTileReferenceType.Start),
					EndTile = new(i, AdfTileReferenceType.Start),
					PositionOffset = new(random.NextDouble() * 10d - 5d, random.NextDouble() * 10d - 13d),
					RotationOffset = random.NextDouble() * 90d - 45d,
					Scale = new(random.NextDouble() * 400d + 800d),
					Ease = AdfEaseType.InCubic,
					Duration = chart.GetTileBpmAt(i) / standardBpm * duration,
					AngleOffset = 360d + 360d * random.NextDouble() * randomPercentage / 100d
				});
				chart.ChartTiles[i].TileEvents.Add(
				new AdfEventMoveTrack()
				{
					Opacity = 0d,
					Ease = AdfEaseType.OutCubic,
					Duration = chart.GetTileBpmAt(i) / standardBpm * duration,
					AngleOffset = 360d + 180d * beatsOffset + 360d * random.NextDouble() * randomPercentage / 100d
				});
			}
		}
	}
}
