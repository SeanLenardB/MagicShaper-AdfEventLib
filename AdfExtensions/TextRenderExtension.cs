using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	[SupportedOSPlatform("windows")]
	internal static class TextRenderExtension
	{


		/// <summary>
		/// <paramref name="positionXPixel"/> and <paramref name="positionYPixel"/> are considered as follows:
		/// <para>
		/// The center of the screen is (0, 0).
		/// <br></br>X axis positive is right, Y axis positive is up.
		/// </para>
		/// <para>Feel free to test numbers.</para>
		/// </summary>
		public static void RenderTextCentered(this AdfChart chart,
			int targetTile, string text, int positionXPixel, int positionYPixel,
			double inDuration = 2d, double outDuration = 2d, double holdDuration = 4d, string color = "FFFFFFFF",
			double scale = 100d, string font = "Bahnschrift", int depthOffset = 0)
		{
			Random random = new();
			string gid = random.Next(1000000).ToString().PadLeft(6, '0');

			Convert(text, chart.FileLocation?.Parent?.FullName + $"\\{ExtensionSharedConstants.TextRenderTagPrefix}_{gid}.png", font);

			chart.AddDecorationToChart(new()
			{
				DecorationImage = $"{ExtensionSharedConstants.TextRenderTagPrefix}_{gid}.png",
				Tag = $"{ExtensionSharedConstants.TextRenderTagPrefix}_{gid}",
				Depth = ExtensionSharedConstants.TextRenderDepth + depthOffset,
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
				Duration = inDuration,
				Tag = $"{ExtensionSharedConstants.TextRenderTagPrefix}_{gid}",
				Opacity = 100d
			});
			chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Duration = outDuration,
				Tag = $"{ExtensionSharedConstants.TextRenderTagPrefix}_{gid}",
				Opacity = 0d,
				AngleOffset = 180d * (inDuration + holdDuration)
			});

		}


		public static void RenderCreditRoleAndName(this AdfChart chart,
			int targetTile, string role, string name,
			int positionXPixel, int positionYPixel,
			double inDuration = 2d, double outDuration = 2d, double holdDuration = 4d,
			double scale = 100d, string font = "Bahnschrift")
		{
			chart.RenderTextCentered(targetTile, role, positionXPixel, positionYPixel + 100, 
				inDuration, outDuration, holdDuration, "88888899", scale * 0.6d, font, 1);
			chart.RenderTextCentered(targetTile, name, positionXPixel, positionYPixel, 
				inDuration, outDuration, holdDuration, "FFFFFFFF", scale, font);
		}














		private const int ImgWidth = 4000;
		private const int ImgHeight = 300;
		public static void Convert(string str, string dst, string fontS)
		{
			Image image = new Bitmap(ImgWidth, ImgHeight);

			Font font = new(fontS, 60f, FontStyle.Bold);
			Graphics graphics = Graphics.FromImage(image);

			graphics.DrawString(str,
						  font,
						  new SolidBrush(Color.FromArgb(255, 255, 255, 255)),
						  new PointF(ImgWidth / 2f, (ImgHeight - 60f) / 2f),
						  new StringFormat() { Alignment = StringAlignment.Center });


			image.Save(dst);
		}
	}
}
