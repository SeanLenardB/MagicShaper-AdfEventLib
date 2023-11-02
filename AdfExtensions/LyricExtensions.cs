using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	internal static class LyricExtensions
	{
		public static void ScreenBottomSwitchLyrics(
			this AdfChart chart,
			List<Tuple<int, double>> switchLyricTilesAndRespectiveDuration,
			string lyricDecoTag,
			AdfEaseType easeType,
			
			double bottomYPivot = -9,
			double topYPivot = -7,
			string tag = "")
		{
			for (int i = 0; i < switchLyricTilesAndRespectiveDuration.Count; i++)
			{
				//chart.ChartTiles[switchLyricTilesAndRespectiveDuration[i].Item1].TileEvents.Add(new AdfEventMoveDecorations(
				//	tag,
				//	lyricDecoTag,
				//	-switchLyricTilesAndRespectiveDuration[i].Item2 * 180,
				//	new(easeType, switchLyricTilesAndRespectiveDuration[i].Item2),
				//	new(0, 0),
				//	new(0, 0),
				//	new(100, 100),
				//	new(0, bottomYPivot),
				//	new(100, 100),
				//	0,
				//	100,
				//	true,
				//	AdfEventMoveDecorations.AdfMoveDecorationRelativeToType.Tile,
				//	$"{i - 1}.png",
				//	-6,
				//	new("ffffffff")));
				//chart.ChartTiles[switchLyricTilesAndRespectiveDuration[i].Item1].TileEvents.Add(new AdfEventMoveDecorations(
				//	tag,
				//	lyricDecoTag,
				//	0,
				//	new(easeType, switchLyricTilesAndRespectiveDuration[i].Item2),
				//	new(0, 0),
				//	new(0, 0),
				//	new(100, 100),
				//	new(0, topYPivot),
				//	new(100, 100),
				//	0,
				//	100,
				//	true,
				//	AdfEventMoveDecorations.AdfMoveDecorationRelativeToType.Tile,
				//	$"{i}.png",
				//	-6,
				//	new("ffffffff")));
			}
		}

	}
}
