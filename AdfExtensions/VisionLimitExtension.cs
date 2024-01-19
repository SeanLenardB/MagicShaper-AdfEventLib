using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	internal static class VisionLimitExtension
	{


		public static void SetupVisionLimit(this AdfChart chart)
		{
			chart.AddDecorationToChart(new()
			{
				LockRotation = true,
				LockScale = true,
				Tag = ExtensionSharedConstants.VisionLimitTagPrefix,
				Parallax = new(100, 100),
				Depth = ExtensionSharedConstants.VisionLimitDepth,
			});
		}

		/// <summary>
		/// If you want to set it, call <see cref="SetupVisionLimit(AdfChart)"/> before you do that.
		/// </summary>
		public static void SetVisionLimit(this AdfChart chart, string imageFileName, int tile,
			double xScale, double yScale) 
		{
			chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Tag = ExtensionSharedConstants.VisionLimitTagPrefix,
				DecorationImage = imageFileName,
				Scale = new(xScale, yScale),
				Duration = 0d
			});
		}

		/// <summary>
		/// This method automatically fits the image to the canvas. The exceeding parts will be cut out.<br></br>
		/// Use <see cref="SetVisionLimit(AdfChart, string, int, double, double)"/> to decide the image scale manually.<br></br>
		/// <paramref name="imageFileName"/> should be the name of the image file, not the <see cref="DirectoryInfo"/>.<br></br>
		/// Call <see cref="SetupVisionLimit(AdfChart)"/> before you call this.
		/// </summary>
		public static void SetVisionLimitAutofit(this AdfChart chart, string imageFileName, int tile)
		{
			Mat mat = Cv2.ImRead(chart.FileLocation?.Parent?.FullName + $"\\{imageFileName}");
			double defaultCameraZoom = chart.ChartJson["settings"]!["zoom"]!.GetValue<double>();

			double widthMultiplier = (double)ExtensionSharedConstants.CanvasWidth / mat.Width * defaultCameraZoom / 100d;
			double heightMultiplier = (double)ExtensionSharedConstants.CanvasHeight / mat.Height * defaultCameraZoom / 100d;

			double scale = 100d * Math.Max(widthMultiplier, heightMultiplier);

			chart.SetVisionLimit(imageFileName, tile, scale, scale);
		}
	}
}
