using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	internal static class TrackStyleExtension
	{
		public static void ChangeToGlassTrack(this AdfChart chart, int activationTile, int tileStart, int tileEnd)
		{
			chart.ChartTiles[activationTile].TileEvents.Add(new AdfEventRecolorTrack()
			{
				StartTile = new(tileStart, AdfTileReferenceType.Start),
				EndTile = new(tileEnd, AdfTileReferenceType.Start),
				
			});
		}
	}
}
