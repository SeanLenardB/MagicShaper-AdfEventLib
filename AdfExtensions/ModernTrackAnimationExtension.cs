using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	internal static class ModernTrackAnimationExtension
	{
		public static void ModernTrackAppear(
			this AdfChart chart,
			int tileStart,
			int tileEnd,
			double duration,
			double previewBeats,
			double xmin = -10, double xmax = 10, double ymin = -20, double ymax = -10,
			double rmin = -45, double rmax = 45,
			double smin = 75, double smax = 200,
			double angleOffsetVariationProportion = 30d,
			double endOpacity = 100d,
			double endScale = 100d,
			double opacityTimeFactor = 1d)
			=> chart.ModernTrackAppear(tileStart, tileEnd, duration, previewBeats, new() { AdfEaseType.OutExpo }, xmin, xmax, ymin, ymax, rmin, rmax, smin, smax, angleOffsetVariationProportion, endOpacity, endScale, opacityTimeFactor);

		public static void ModernTrackAppear(
			this AdfChart chart,
			int tileStart,
			int tileEnd,
			double duration,
			double previewBeats,
			List<AdfEaseType> easeTypes,
			double xmin = -10, double xmax = 10, double ymin = -20, double ymax = -10,
			double rmin = -45, double rmax = 45,
			double smin = 75, double smax = 200,
			double angleOffsetVariationProportion = 30d,
			double endOpacity = 100d,
			double endScale = 100d,
			double opacityTimeFactor = 1d)
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
						PositionOffset = new(random.RandBetween(xmin, xmax), random.RandBetween(ymin, ymax)),
						RotationOffset = random.RandBetween(rmin, rmax),
						Scale = new(random.RandBetween(smin, smax)),
						Opacity = 0d,
						Duration = 0d,
						AngleOffset = -1145140d
					});
				AdfEaseType ease = random.RandIn(easeTypes);
				double rand = random.NextDouble();
				chart.ChartTiles[i].TileEvents.Add( // Opacity
					new AdfEventMoveTrack()
					{
						StartTile = new(i, AdfTileReferenceType.Start),
						EndTile = new(i, AdfTileReferenceType.Start),
						Opacity = endOpacity,
						Ease = AdfEaseType.Linear,
						Duration = opacityTimeFactor * chart.GetTileBpmAt(i) / standardBpm * duration,
						AngleOffset =
							opacityTimeFactor * (-chart.GetTileBpmAt(i) / standardBpm * (previewBeats + duration) * 180)
							* (1 - rand * angleOffsetVariationProportion / 100d)
					});
				chart.ChartTiles[i].TileEvents.Add( // Position
					new AdfEventMoveTrack()
					{
						StartTile = new(i, AdfTileReferenceType.Start),
						EndTile = new(i, AdfTileReferenceType.Start),
						PositionOffset = new(0d, 0d),
						RotationOffset = 0d,
						Scale = new(endScale),
						Ease = ease,
						Duration = chart.GetTileBpmAt(i) / standardBpm * duration,
						AngleOffset =
							(-chart.GetTileBpmAt(i) / standardBpm * (previewBeats + duration) * 180)
							* (1 - rand * angleOffsetVariationProportion / 100d)
					});

			}
		}

		public static void ModernTrackDisappear(
			this AdfChart chart,
			int tileStart,
			int tileEnd,
			double duration,
			double postviewBeats,
			double xmin = -10, double xmax = 10, double ymin = -20, double ymax = -10,
			double rmin = -45, double rmax = 45,
			double smin = 75, double smax = 200,
			double angleOffsetVariationProportion = 30d,
			double opacityTimeFactor = 1d)
			=> chart.ModernTrackDisappear(tileStart, tileEnd, duration, postviewBeats, new() { AdfEaseType.InExpo }, xmin, xmax, ymin, ymax, rmin, rmax, smin, smax, angleOffsetVariationProportion, opacityTimeFactor);

		public static void ModernTrackDisappear(
			this AdfChart chart,
			int tileStart,
			int tileEnd,
			double duration,
			double postviewBeats,
			List<AdfEaseType> easeTypes,
			double xmin = -10, double xmax = 10, double ymin = -20, double ymax = -10,
			double rmin = -45, double rmax = 45,
			double smin = 75, double smax = 200,
			double angleOffsetVariationProportion = 30d,
			double opacityTimeFactor = 1d)
		{
			double standardBpm = chart.GetTileBpmAt(0);

			Random random = new();
			for (int i = tileStart; i < tileEnd; i++)
			{
				AdfEaseType ease = random.RandIn(easeTypes);
				double rand = random.NextDouble();
				chart.ChartTiles[i].TileEvents.Add( // Opacity
					new AdfEventMoveTrack()
					{
						StartTile = new(i, AdfTileReferenceType.Start),
						EndTile = new(i, AdfTileReferenceType.Start),
						Opacity = 0d,
						Duration = opacityTimeFactor * chart.GetTileBpmAt(i) / standardBpm * duration,
						AngleOffset =
							opacityTimeFactor * (chart.GetTileBpmAt(i) / standardBpm * (postviewBeats + duration) * 180)
							* (1 - rand * angleOffsetVariationProportion / 100d),
						Ease = AdfEaseType.Linear
					});
				chart.ChartTiles[i].TileEvents.Add( // Position
					new AdfEventMoveTrack()
					{
						StartTile = new(i, AdfTileReferenceType.Start),
						EndTile = new(i, AdfTileReferenceType.Start),
						PositionOffset = new(random.RandBetween(xmin, xmax), random.RandBetween(ymin, ymax)),
						RotationOffset = random.RandBetween(rmin, rmax),
						Scale = new(random.RandBetween(smin, smax)),
						Duration = chart.GetTileBpmAt(i) / standardBpm * duration,
						AngleOffset =
							(chart.GetTileBpmAt(i) / standardBpm * (postviewBeats + duration) * 180)
							* (1 - rand * angleOffsetVariationProportion / 100d),
						Ease = ease
					});
			}
		}

	}
}
