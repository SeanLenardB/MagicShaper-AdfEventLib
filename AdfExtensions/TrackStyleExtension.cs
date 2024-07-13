using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using MagicShaper.AdofaiCore.DerivedClass;
using OpenCvSharp;
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
	internal static class TrackStyleExtension
	{
		public static void SetLineTrackStyle(this AdfChart chart, int start, int end,
			double yScale = 300d, double nodeScale = 130d, double twirlNodeScale = 200d, bool hideTrack = true, string tag = "")
		{
			if (hideTrack)
			{
				chart.ChartTiles[start].TileEvents.Add(new AdfEventRecolorTrack()
				{
					TrackColor = new("FFFFFF00"),
					TrackStyle = AdfTrackStyle.Neon,
					TrackGlowIntensity = 0,
					AngleOffset = -114514,
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(end - start - 1, AdfTileReferenceType.ThisTile)
				});
			}

			GetLineImage(chart);
			GetNodeImage(chart);
			for (int i = start; i < end; i++)
			{
				AdfColor nodeColor = new("FFFFFFFF");

				bool isTwirl = false;
				foreach (var e in chart.ChartTiles[i].TileEvents)
				{
					if (e is AdfEventTwirl)
					{
						isTwirl = true;
					}
					if (e is AdfEventSetSpeed ee)
					{
						if (ee.SpeedType == AdfEventSpeedType.Multiplier && ee.BpmMultiplier > 1)
						{
							nodeColor = new("FF0000FF");
						}
						if (ee.SpeedType == AdfEventSpeedType.Multiplier && ee.BpmMultiplier < 1)
						{
							nodeColor = new("0000FFFF");
						}
						if (ee.SpeedType == AdfEventSpeedType.Bpm && ee.BeatsPerMinute > chart.GetTileBpmAt(i - 1))
						{
							nodeColor = new("FF0000FF");
						}
						if (ee.SpeedType == AdfEventSpeedType.Bpm && ee.BeatsPerMinute < chart.GetTileBpmAt(i - 1))
						{
							nodeColor = new("0000FFFF");
						}
					}
				}
				if (isTwirl)
				{
					chart.AddDecorationToChart(new()
					{
						RelativeTo = AdfMoveDecorationRelativeToType.Tile,
						Floor = i,
						DecorationImage = "quartrond_circleImage.png",
						Scale = new(twirlNodeScale),
						Depth = ExtensionSharedConstants.LineTrackDepth,
						Color = new("DF90D3FF"),
						Tag = tag
					});
				}


				double alpha = chart.ChartTiles[i - 1].TargetAngle;
				double beta = chart.ChartTiles[i].TargetAngle;
				chart.AddDecorationToChart(new() 
				{ 
					RelativeTo = AdfMoveDecorationRelativeToType.Tile, 
					Floor = i,
					DecorationImage = "quartrond_lineImage.png",
					Rotation = alpha,
					Scale = new(50 + 0.5, yScale + 0.5),
					Position = new(
						0.25d * Math.Cos(alpha / 180d * Math.PI - Math.PI), 
						0.25d * Math.Sin(alpha / 180d * Math.PI - Math.PI)),
					Depth = ExtensionSharedConstants.LineTrackDepth,
					Tag = tag
				});
				chart.AddDecorationToChart(new() 
				{ 
					RelativeTo = AdfMoveDecorationRelativeToType.Tile, 
					Floor = i,
					DecorationImage = "quartrond_lineImage.png",
					Rotation = beta,
					Scale = new(50 + 0.5, yScale + 0.5),
					Position = new(
						0.25d * Math.Cos(beta / 180d * Math.PI), 
						0.25d * Math.Sin(beta / 180d * Math.PI)),
					Depth = ExtensionSharedConstants.LineTrackDepth,
					Tag = tag
				});
				chart.AddDecorationToChart(new() 
				{ 
					RelativeTo = AdfMoveDecorationRelativeToType.Tile, 
					Floor = i,
					DecorationImage = "quartrond_circleImage.png",
					Scale = new(nodeScale),
					Depth = ExtensionSharedConstants.LineTrackDepth - 1,
					Color = nodeColor, 
					Tag = tag
				});
			}
		}

		private static void GetLineImage(AdfChart chart)
		{
			Image image = new Bitmap(150, 100);

			Graphics graphics = Graphics.FromImage(image);
			graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			graphics.DrawLine(new Pen(Color.White, 20f), new(0, 50), new(150, 50));
			
			image.Save(chart.FileLocation?.Parent?.FullName + $"\\quartrond_lineImage.png");
		}

		private static void GetNodeImage(AdfChart chart)
		{
			Image image = new Bitmap(50, 50);

			Graphics graphics = Graphics.FromImage(image);
			graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			graphics.FillEllipse(new SolidBrush(Color.White), new(10, 10, 30, 30));

			image.Save(chart.FileLocation?.Parent?.FullName + $"\\quartrond_circleImage.png");
		}
	}
}
