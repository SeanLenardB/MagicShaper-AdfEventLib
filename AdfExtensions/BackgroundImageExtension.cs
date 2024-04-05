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
	internal static class BackgroundImageExtension
	{



		public static void SetupDecoBgImage(this AdfChart chart)
		{
			chart.AddDecorationToChart(new() 
			{ 
				LockRotation = true,
				LockScale = true,
				Tag = ExtensionSharedConstants.DecoBgImageTagPrefix,
				Parallax = new(100, 100),
				Depth = ExtensionSharedConstants.DecoBgImageDepth,
			});
		}

		/// <summary>
		/// If you want to set it, call <see cref="SetupBackgroundImage(AdfChart)"/> before you do that.
		/// </summary>
		public static void SetDecoBgImage(this AdfChart chart, string imageFileName, int targetTile, 
			double scale = 100d)
		{
			chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Tag = ExtensionSharedConstants.DecoBgImageTagPrefix,
				DecorationImage = imageFileName,
				Scale = new(scale),
				Duration = 0d
			});
		}


		/// <summary>
		/// This method automatically fits the image to the canvas. The exceeding parts will be cut out.<br></br>
		/// Use <see cref="SetDecoBgImage(AdfChart, string, int, double)"/> to decide the image scale manually.<br></br>
		/// <paramref name="imageFileName"/> should be the name of the image file, not the <see cref="DirectoryInfo"/>.<br></br>
		/// Call <see cref="SetupDecoBgImage(AdfChart)"/> before you call this.
		/// </summary>
		public static void SetDecoBgImageAutofit(this AdfChart chart, string imageFileName, int targetTile)
		{
			Mat mat = Cv2.ImRead(chart.FileLocation?.Parent?.FullName + $"\\{imageFileName}");
			double defaultCameraZoom = chart.ChartJson["settings"]!["zoom"]!.GetValue<double>();

			double widthMultiplier = (double) ExtensionSharedConstants.CanvasWidth / mat.Width * defaultCameraZoom / 100d;
			double heightMultiplier = (double) ExtensionSharedConstants.CanvasHeight / mat.Height  * defaultCameraZoom / 100d;

			double scale = 100d * Math.Max(widthMultiplier, heightMultiplier);

			chart.SetDecoBgImage(imageFileName, targetTile, scale);
		}

		/// <summary>
		/// Consider calling this only if you have called <see cref="SetupDecoBgImage(AdfChart)"/>.<br></br>
		/// Otherwise, edit background flash manually.
		/// </summary>
		public static void BackgroundDim(this AdfChart chart, double blackPercentage, int targetTile, double duration = 0d)
		{
			chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Tag = ExtensionSharedConstants.DecoBgImageTagPrefix,
				Duration = duration,
				Color = new("000000ff") 
				{ 
					R = (byte)(255d * (1d - (blackPercentage / 100d))), 
					G = (byte)(255d * (1d - (blackPercentage / 100d))), 
					B = (byte)(255d * (1d - (blackPercentage / 100d))), 
				}
			});
		}

		/// <summary>
		/// Consider calling this only if you have called <see cref="SetupDecoBgImage(AdfChart)"/>.<br></br>
		/// Otherwise, edit background flash manually.
		/// </summary>
		public static void BackgroundOpacity(this AdfChart chart, double opacityPercentage, int targetTile, double duration = 0d)
		{
			chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Tag = ExtensionSharedConstants.DecoBgImageTagPrefix,
				Duration = duration,
				Opacity = opacityPercentage,
			});
		}

		/// <summary>
		/// Consider calling this only if you have called <see cref="SetupDecoBgImage(AdfChart)"/>.<br></br>
		/// Otherwise, edit background flash manually.
		/// </summary>
		public static void BackgroundDimPulse(this AdfChart chart,
			double startBlackPercentage, double endBlackPercentage, int targetTile,
			double duration = 0d)
		{
			chart.BackgroundDim(startBlackPercentage, targetTile, 0);
			chart.BackgroundDim(endBlackPercentage, targetTile, duration);
		}

		/// <summary>
		/// Consider calling this only if you have called <see cref="SetupDecoBgImage(AdfChart)"/>.<br></br>
		/// Otherwise, edit background flash manually.
		/// </summary>
		public static void BackgroundOpacityPulse(this AdfChart chart,
			double startOpacityPercentage, double endOpacityPercentage, int targetTile,
			double duration = 0d)
		{
			chart.BackgroundOpacity(startOpacityPercentage, targetTile, 0);
			chart.BackgroundOpacity(endOpacityPercentage, targetTile, duration);
		}

		/// <summary>
		/// Consider calling this only if you have called <see cref="SetupDecoBgImage(AdfChart)"/>.<br></br>
		/// Otherwise, edit background flash manually.
		/// </summary>
		public static void BackgroundDimPulseMultipleByBeat(this AdfChart chart,
			double startBlackPercentage, double endBlackPercentage, int targetTile, int repetitions, double interval,
			double eachDuration = 0d)
		{
			for (int i = 0; i < repetitions; i++)
			{
				chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = ExtensionSharedConstants.DecoBgImageTagPrefix,
					Duration = 0,
					Color = new("000000ff")
					{
						R = (byte)(255d * (1d - (startBlackPercentage / 100d))),
						G = (byte)(255d * (1d - (startBlackPercentage / 100d))),
						B = (byte)(255d * (1d - (startBlackPercentage / 100d))),
					},
					AngleOffset = 180d * i * interval
				});
				chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = ExtensionSharedConstants.DecoBgImageTagPrefix,
					Duration = eachDuration,
					Color = new("000000ff")
					{
						R = (byte)(255d * (1d - (endBlackPercentage / 100d))),
						G = (byte)(255d * (1d - (endBlackPercentage / 100d))),
						B = (byte)(255d * (1d - (endBlackPercentage / 100d))),
					},
					AngleOffset = 180d * i * interval
				});
			}
		}
	}
}
