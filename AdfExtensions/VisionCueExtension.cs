using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	internal static class VisionCueExtension
	{


		public static void ShapeFocusOnTile(this AdfChart chart,
			string inImageName, string outImageName,
			int targetTile, double inBeats, double outBeats,
			double inRotation = -120d, double outRotation = 60d,
			double inSize = 200d, double outSize = 200d,
			double xRelativeToTile = 0d, double yRelativeToTile = 0d)
		{
			Random random = new();
			string gid = random.Next(1000000).ToString().PadLeft(6, '0');

			chart.AddDecorationToChart(new()
			{
				DecorationImage = inImageName,
				Rotation = inRotation,
				Scale = new(inSize),
				Opacity = 0d,
				Tag = $"{ExtensionSharedConstants.ShapeFocusOnTileTagPrefix}_{gid}_in",
				RelativeTo = AdfMoveDecorationRelativeToType.Tile,
				Position = new(xRelativeToTile, yRelativeToTile),
				Floor = targetTile,
				Depth = ExtensionSharedConstants.ShapeFocusOnTileDepth
			});
			chart.AddDecorationToChart(new()
			{
				DecorationImage = outImageName,
				Opacity = 0d,
				Tag = $"{ExtensionSharedConstants.ShapeFocusOnTileTagPrefix}_{gid}_out",
				RelativeTo = AdfMoveDecorationRelativeToType.Tile,
				Position = new(xRelativeToTile, yRelativeToTile),
				Floor = targetTile,
				Depth = ExtensionSharedConstants.ShapeFocusOnTileDepth
			});

			chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Ease = AdfEaseType.InCubic,
				RotationOffset = -inRotation,
				Scale = new(0d),
				Duration = inBeats,
				AngleOffset = -180d * inBeats,
				Opacity = 100d,
				Tag = $"{ExtensionSharedConstants.ShapeFocusOnTileTagPrefix}_{gid}_in"
			});
			chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Duration = 0d,
				Opacity = 100d,
				Tag = $"{ExtensionSharedConstants.ShapeFocusOnTileTagPrefix}_{gid}_out"
			});
			chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Ease = AdfEaseType.OutCubic,
				RotationOffset = outRotation,
				Scale = new(outSize),
				Duration = outBeats,
				Opacity = 0d,
				Tag = $"{ExtensionSharedConstants.ShapeFocusOnTileTagPrefix}_{gid}_out"
			});
		}



		/// <summary>
		/// It uses a mask to mask another image. Similar effect as <see cref="ShapeFocusOnTile(AdfChart, string, string, int, double, double, double, double, double, double, double, double)"/>
		/// <br></br>
		/// You should consider calling this method and the method above at the same time.
		/// </summary>
		public static void SneakImageVision(this AdfChart chart,
			string imageName, string maskImageName,
			int targetTile, double outBeats,
			double outRotation = 60d, double outSize = 200d,
			double xMaskRelativeToTile = 0d, double yMaskRelativeToTile = 0d,
			double xImageRelativeToTile = 0d, double yImageRelativeToTile = 0d,
			double imageOpacity = 50d, double imageScale = 100d)
		{
			Random random = new();
			string gid = random.Next(1000000).ToString().PadLeft(6, '0');

			chart.AddDecorationToChart(new()
			{
				DecorationImage = maskImageName,
				Opacity = 0d,
				Tag = $"{ExtensionSharedConstants.SneakImageVisionTagPrefix}_{gid}_mask",
				RelativeTo = AdfMoveDecorationRelativeToType.Tile,
				Floor = targetTile,
				Position = new(xMaskRelativeToTile, yMaskRelativeToTile),
				MaskingType = AdfMaskingType.Mask,
				Depth = ExtensionSharedConstants.SneakImageVisionDepth
			});
			chart.AddDecorationToChart(new()
			{
				DecorationImage = imageName,
				Opacity = 0d,
				Tag = $"{ExtensionSharedConstants.SneakImageVisionTagPrefix}_{gid}_img",
				RelativeTo = AdfMoveDecorationRelativeToType.Tile,
				Position = new(xImageRelativeToTile, yImageRelativeToTile),
				Scale = new(imageScale),
				Floor = targetTile,
				MaskingType = AdfMaskingType.VisibleInsideMask,
				Depth = ExtensionSharedConstants.SneakImageVisionDepth
			});

			chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Duration = 0d,
				Opacity = 100d,
				Tag = $"{ExtensionSharedConstants.SneakImageVisionTagPrefix}_{gid}_mask"
			});
			chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Duration = 0d,
				Opacity = imageOpacity,
				Tag = $"{ExtensionSharedConstants.SneakImageVisionTagPrefix}_{gid}_img"
			});
			chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Ease = AdfEaseType.OutCubic,
				RotationOffset = outRotation,
				Scale = new(outSize),
				Duration = outBeats,
				Opacity = 0d,
				Tag = $"{ExtensionSharedConstants.SneakImageVisionTagPrefix}_{gid}_mask"
			});
			chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Ease = AdfEaseType.OutCubic,
				Duration = outBeats,
				Opacity = 0d,
				Tag = $"{ExtensionSharedConstants.SneakImageVisionTagPrefix}_{gid}_img"
			});

			chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Duration = 0d,
				AngleOffset = outBeats * 180d,
				Scale = new(0d),
				Tag = $"{ExtensionSharedConstants.SneakImageVisionTagPrefix}_{gid}_img {ExtensionSharedConstants.SneakImageVisionTagPrefix}_{gid}_mask"
			});
		}


	}
}
