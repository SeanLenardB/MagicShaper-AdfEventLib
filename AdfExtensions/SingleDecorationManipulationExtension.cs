using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	internal static class SingleDecorationManipulationExtension
	{
		
		public static void DecorationFadeIn(this AdfChart chart,
			int targetTile, string fileName, int positionXPixel, int positionYPixel,
			double duration = 2d, string color = "FFFFFFFF",
			double scale = 100d, int depthOffset = 0)
		{
			Random random = new();
			string gid = random.Next(1000000).ToString().PadLeft(6, '0');

			chart.AddDecorationToChart(new()
			{
				DecorationImage = fileName,
				Tag = $"{ExtensionSharedConstants.SingleDecorationManipulationTagPrefix}_{gid}",
				Depth = ExtensionSharedConstants.SingleDecorationManipulationDepth + depthOffset,
				LockRotation = true,
				LockScale = true,
				Position = new((double)positionXPixel / ExtensionSharedConstants.TileWidth,
							(double)positionYPixel / ExtensionSharedConstants.TileWidth),
				Scale = new(scale),
				RelativeTo = AdfMoveDecorationRelativeToType.Camera,
				Opacity = 0d,
				Color = new(color)
			});

			chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Duration = duration,
				Tag = $"{ExtensionSharedConstants.SingleDecorationManipulationTagPrefix}_{gid}",
				Opacity = 100d
			});
		}


	}
}
