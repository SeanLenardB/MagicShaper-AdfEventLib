using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	internal static class CommonTrackAnimationExtension
	{
		public static void TrackExplosion(
			this AdfChart chart, 
			List<int> tiles)
		{
			Random random = new();
			for (int i = 0; i < tiles.Count; i++)
			{
				chart.ChartTiles[tiles[i]].TileEvents.Add(
					new AdfEventMoveTrack()
					{
						StartTile = new(i == 0 ? 0 : tiles[i - 1], AdfTileReferenceType.Start),
						EndTile = new(tiles[i] - 1, AdfTileReferenceType.Start),
						PositionOffset = new(random.NextDouble() * 20d - 10d, random.NextDouble() * 20d - 10d),
						RotationOffset = random.NextDouble() * 90d - 45d,
						Scale = new(random.NextDouble() * 50d + 100d),
						Opacity = 0d,
						Ease = AdfEaseType.OutCubic
					});
			}
		}


	}
}
