using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	internal static class LyricDisplayExtension
	{
		public static void FadeInOutLyric(this AdfChart chart, List<int> tiles, double duration, string lyricDecoTag)
		{
			double standardBpm = chart.GetTileBpmAt(0);

			for (int i = 0; i < tiles.Count; i++)
			{
				chart.ChartTiles[tiles[i]].TileEvents.Add(
					new AdfEventMoveDecorations()
					{
						Opacity = 0d,
						Duration = chart.GetTileBpmAt(tiles[i]) / standardBpm * duration,
						Ease = AdfEaseType.OutCubic,
						AngleOffset = - chart.GetTileBpmAt(tiles[i]) / standardBpm * duration * 180d,
						Tag = lyricDecoTag
					});
				chart.ChartTiles[tiles[i]].TileEvents.Add(
					new AdfEventMoveDecorations()
					{
						Opacity = 100d,
						Duration = chart.GetTileBpmAt(tiles[i]) / standardBpm * duration,
						Ease = AdfEaseType.OutCubic,
						DecorationImage = $"{i}.png",
						Tag = lyricDecoTag
					});
			}
		}

	}
}
