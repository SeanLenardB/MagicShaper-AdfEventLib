using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MagicShaper.AdfExtensions
{
	[SupportedOSPlatform("windows")]
	internal static class LyricDisplayExtension
	{
		/// <summary>
		/// The <paramref name="lyricFileName"/> file should be formatted as following:
		/// <para></para>
		/// target tile 1<br></br>
		/// main lyric 1<br></br>
		/// translation 1<br></br>
		/// target tile 2<br></br>
		/// ...
		/// <para></para>
		/// Use 3 empty lines to wipe lyrics.
		/// </summary>
		public static void LyricWithTranslation(this AdfChart chart,
			string lyricFileName, string mainFont = "Bahnschrift", string translationFont = "方正楷体_GBK",
			int positionXPixel = 0, int positionYPixel = -1200, double scale = 100d,
			double inDuration = 2d, double outDuration = 2d, int depthOffset = 0)
		{
			string[] lyrics = File.ReadAllLines(chart.FileLocation?.Parent?.FullName + $"\\{lyricFileName}");
			try
			{
				Random random = new();
				string gid = random.Next(1000000).ToString().PadLeft(6, '0');

				chart.AddDecorationToChart(new()
				{
					Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_main",
					Depth = ExtensionSharedConstants.LyricsDepth + depthOffset,
					LockRotation = true,
					LockScale = true,
					Position = new((double)positionXPixel / ExtensionSharedConstants.TileWidth,
							(double)positionYPixel / ExtensionSharedConstants.TileWidth),
					Scale = new(scale),
					RelativeTo = AdfMoveDecorationRelativeToType.Camera,
					Opacity = 0d,
					Color = new("FFFFFFFF")
				});
				chart.AddDecorationToChart(new()
				{
					Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_translation",
					Depth = ExtensionSharedConstants.LyricsDepth + depthOffset + 1,
					LockRotation = true,
					LockScale = true,
					Position = new((double)positionXPixel / ExtensionSharedConstants.TileWidth,
							(double)(positionYPixel + 50)/ ExtensionSharedConstants.TileWidth),
					Scale = new(scale * 0.6d),
					RelativeTo = AdfMoveDecorationRelativeToType.Camera,
					Opacity = 0d,
					Color = new("88888899")
				});

				


				double standardBpm = chart.GetTileBpmAt(0);

				for (int i = 0; i < lyrics.Length; i += 3)
				{
					int tile = int.Parse(lyrics[i]);

					TextRenderExtension.Convert(lyrics[i+1], 
						chart.FileLocation?.Parent?.FullName + $"\\{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_{i}_main.png", 
						mainFont);
					TextRenderExtension.Convert(lyrics[i+2], 
						chart.FileLocation?.Parent?.FullName + $"\\{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_{i}_translation.png", 
						translationFont);





					chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Duration = outDuration * chart.GetTileBpmAt(tile) / standardBpm,
						Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_main {ExtensionSharedConstants.LyricsTagPrefix}_{gid}_translation",
						Opacity = 0d,
						AngleOffset = -180d * outDuration * chart.GetTileBpmAt(tile) / standardBpm
					});
					
					
					chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Duration = 0d,
						DecorationImage = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_{i}_main.png",
						Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_main",
					});
					chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Duration = 0d,
						DecorationImage = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_{i}_translation.png",
						Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_translation",
					});
					
					chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Duration = inDuration * chart.GetTileBpmAt(tile) / standardBpm,
						Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_main {ExtensionSharedConstants.LyricsTagPrefix}_{gid}_translation",
						Opacity = 100d,
					});




					
				}
			}
			catch { Console.WriteLine("LyricWithTranslation Exception thrown."); }
		}


		/// <summary>
		/// The <paramref name="lyricFileName"/> file should be formatted as following:
		/// <para></para>
		/// target tile 1<br></br>
		/// main lyric 1<br></br>
		/// translation 1<br></br>
		/// target tile 2<br></br>
		/// ...
		/// <para></para>
		/// Use 3 empty lines to wipe lyrics.
		/// </summary>
		public static void LyricWithTranslationWithWordByWordAppear(this AdfChart chart,
			string lyricFileName, string mainFont = "Bahnschrift", string translationFont = "方正楷体_GBK",
			int positionXPixel = 0, int positionYPixel = -1200, double scale = 100d,
			double inDuration = 2d, double outDuration = 2d, int depthOffset = 0)
		{
			string[] lyrics = File.ReadAllLines(chart.FileLocation?.Parent?.FullName + $"\\{lyricFileName}");
			try
			{
				Random random = new();
				string gid = random.Next(1000000).ToString().PadLeft(6, '0');

				chart.AddDecorationToChart(new()
				{
					Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_main",
					Depth = ExtensionSharedConstants.LyricsDepth + depthOffset,
					LockRotation = true,
					LockScale = true,
					Position = new((double)positionXPixel / ExtensionSharedConstants.TileWidth,
							(double)positionYPixel / ExtensionSharedConstants.TileWidth),
					Scale = new(scale),
					RelativeTo = AdfMoveDecorationRelativeToType.Camera,
					Opacity = 0d,
					Color = new("FFFFFFFF")
				});
				chart.AddDecorationToChart(new()
				{
					Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_translation",
					Depth = ExtensionSharedConstants.LyricsDepth + depthOffset + 1,
					LockRotation = true,
					LockScale = true,
					Position = new((double)positionXPixel / ExtensionSharedConstants.TileWidth,
							(double)(positionYPixel + 50) / ExtensionSharedConstants.TileWidth),
					Scale = new(scale * 0.6d),
					RelativeTo = AdfMoveDecorationRelativeToType.Camera,
					Opacity = 0d,
					Color = new("88888899")
				});




				double standardBpm = chart.GetTileBpmAt(0);

				for (int i = 0; i < lyrics.Length; i += 3)
				{
					int tile = int.Parse(lyrics[i]);

					TextRenderExtension.Convert(lyrics[i + 1],
						chart.FileLocation?.Parent?.FullName + $"\\{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_{i}_main.png",
						mainFont);
					TextRenderExtension.Convert(lyrics[i + 2],
						chart.FileLocation?.Parent?.FullName + $"\\{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_{i}_translation.png",
						translationFont);





					chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Duration = outDuration * chart.GetTileBpmAt(tile) / standardBpm,
						Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_main {ExtensionSharedConstants.LyricsTagPrefix}_{gid}_translation",
						Opacity = 0d,
						AngleOffset = -180d * outDuration * chart.GetTileBpmAt(tile) / standardBpm
					});


					chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Duration = 0d,
						DecorationImage = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_{i}_main.png",
						Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_main",
					});
					chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Duration = 0d,
						DecorationImage = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_{i}_translation.png",
						Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_translation",
					});

					chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Duration = inDuration * chart.GetTileBpmAt(tile) / standardBpm,
						Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_main {ExtensionSharedConstants.LyricsTagPrefix}_{gid}_translation",
						Opacity = 100d,
					});





				}
			}
			catch { Console.WriteLine("LyricWithTranslation Exception thrown."); }
		}

	}
}
