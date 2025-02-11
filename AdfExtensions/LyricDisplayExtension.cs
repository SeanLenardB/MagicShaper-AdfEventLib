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
			double inDuration = 2d, double outDuration = 2d, int depthOffset = 0,
			string mainColor = "FFFFFFFF", string translationColor = "88888899")
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
					Color = new(mainColor)
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
					Color = new(translationColor)
				});

				


				double standardBpm = chart.GetTileBpmAt(0);

				for (int i = 0; i < lyrics.Length; i += 3)
				{
					int tile = int.Parse(lyrics[i]);

					TextRenderExtension.Convert(lyrics[i+1], 
						chart.FileLocation?.Parent?.FullName + $"\\{ExtensionSharedConstants.LyricsTagPrefix}_{lyricFileName}_{i}_main.png", 
						mainFont);
					TextRenderExtension.Convert(lyrics[i+2], 
						chart.FileLocation?.Parent?.FullName + $"\\{ExtensionSharedConstants.LyricsTagPrefix}_{lyricFileName}_{i}_translation.png", 
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
						DecorationImage = $"{ExtensionSharedConstants.LyricsTagPrefix}_{lyricFileName}_{i}_main.png",
						Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_main",
					});
					chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Duration = 0d,
						DecorationImage = $"{ExtensionSharedConstants.LyricsTagPrefix}_{lyricFileName}_{i}_translation.png",
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
			int positionXPixel = 0, int positionYPixel = -1200, double scale = 100d, double translationScale = 61.8d,
			double inDuration = 2d, double outDuration = 2d, int depthOffset = 0,
			double xmin = -2, double xmax = 2, double ymin = -2, double ymax = -1, double rmin = -15, double rmax = 15,
			double intervalBeat = 1d, double translationYOffset = -1)
		{
			string[] lyrics = File.ReadAllLines(chart.FileLocation?.Parent?.FullName + $"\\{lyricFileName}");
			try
			{
				Random random = new();
				string gid = random.Next(1000000).ToString().PadLeft(6, '0');

				//chart.AddDecorationToChart(new()
				//{
				//	Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_main",
				//	Depth = ExtensionSharedConstants.LyricsDepth + depthOffset,
				//	LockRotation = true,
				//	LockScale = true,
				//	Position = new((double)positionXPixel / ExtensionSharedConstants.TileWidth,
				//			(double)positionYPixel / ExtensionSharedConstants.TileWidth),
				//	Scale = new(scale),
				//	RelativeTo = AdfMoveDecorationRelativeToType.Camera,
				//	Opacity = 0d,
				//	Color = new("FFFFFFFF")
				//});
				//chart.AddDecorationToChart(new()
				//{
				//	Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_translation",
				//	Depth = ExtensionSharedConstants.LyricsDepth + depthOffset + 1,
				//	LockRotation = true,
				//	LockScale = true,
				//	Position = new((double)positionXPixel / ExtensionSharedConstants.TileWidth,
				//			(double)(positionYPixel + 50) / ExtensionSharedConstants.TileWidth),
				//	Scale = new(scale * 0.6d),
				//	RelativeTo = AdfMoveDecorationRelativeToType.Camera,
				//	Opacity = 0d,
				//	Color = new("88888899")
				//});



				//float spaceWidth = TextRenderExtension.Convert("",
				//	chart.FileLocation?.Parent?.FullName + $"\\{ExtensionSharedConstants.LyricsTagPrefix}_main_trash.png",
				//	mainFont, (float)(scale / 100d)).Item1;
				float spaceWidth = 0f; // Apparently MeasureString already counts the space between words.

				for (int i = 0; i < lyrics.Length; i += 3)
				{
					if (string.IsNullOrEmpty(lyrics[i + 1])) { continue; }

					int tile = int.Parse(lyrics[i]);
					int nextTile = int.Parse(lyrics[i + 3]);

					double beatMultiplier = chart.GetTileBpmAt(tile) / chart.GetTileBpmAt(0);
					double nextBeatMultiplier = chart.GetTileBpmAt(nextTile) / chart.GetTileBpmAt(0);

					// main lyric
					float mainTotalWidth = TextRenderExtension.Convert(lyrics[i + 1],
						chart.FileLocation?.Parent?.FullName + $"\\{ExtensionSharedConstants.LyricsTagPrefix}_main_trash.png",
						mainFont, (float)(scale / 100)).Item1;
					float mainPastWidth = 0f;
					string[] mainWords = lyrics[i + 1].Split(' ');
					for (int j = 0; j < mainWords.Length; j++)
					{
						float mainWordWidth = TextRenderExtension.Convert(mainWords[j],
							chart.FileLocation?.Parent?.FullName + $"\\{ExtensionSharedConstants.LyricsTagPrefix}_{i}_main_{j}.png",
							mainFont, (float)(scale / 100)).Item1;

						double mainDesiredX = (double)(positionXPixel - mainTotalWidth / 2d + mainPastWidth + mainWordWidth / 2d) / ExtensionSharedConstants.TileWidth;
						double mainDesiredY = (double)positionYPixel / ExtensionSharedConstants.TileWidth;

						double mainXOffset = random.RandBetween(xmin, xmax);
						double mainYOffset = random.RandBetween(ymin, ymax);
						double mainROffset = random.RandBetween(rmin, rmax);
						chart.AddDecorationToChart(new()
						{
							Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_{i}_main_{j}",
							Depth = ExtensionSharedConstants.LyricsDepth + depthOffset,
							LockRotation = true,
							LockScale = true,
							Rotation = mainROffset,
							ParallaxOffset = new(mainDesiredX + mainXOffset, mainDesiredY + mainYOffset),
							Parallax = new(100, 100),
							RelativeTo = AdfMoveDecorationRelativeToType.Global,
							Opacity = 0d,
							Color = new("FFFFFFFF"),
							DecorationImage = $"{ExtensionSharedConstants.LyricsTagPrefix}_{i}_main_{j}.png"
						});

						chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
						{
							Duration = inDuration * beatMultiplier,
							Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_{i}_main_{j}",
							Opacity = 100d,
							Ease = AdfEaseType.OutCirc,
							RotationOffset = -mainROffset,
							ParallaxOffset = new(mainDesiredX, mainDesiredY),
							AngleOffset = j * intervalBeat * 180 * beatMultiplier + 0.001,
						});
						
						chart.ChartTiles[nextTile].TileEvents.Add(new AdfEventMoveDecorations()
						{
							Duration = outDuration * nextBeatMultiplier,
							Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_{i}_main_{j}",
							Ease = AdfEaseType.Linear,
							Opacity = 0,
							AngleOffset = outDuration * nextBeatMultiplier * (-180)
						});
						chart.ChartTiles[nextTile].TileEvents.Add(new AdfEventMoveDecorations()
						{
							Duration = outDuration * nextBeatMultiplier,
							Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_{i}_main_{j}",
							Ease = AdfEaseType.InCirc,
							RotationOffset = -mainROffset,
							ParallaxOffset = new(mainDesiredX - mainXOffset * 0.618, mainDesiredY - mainYOffset * 0.618),
							AngleOffset = outDuration * nextBeatMultiplier * (-180)
						});

						mainPastWidth += mainWordWidth + spaceWidth;
					}


					// translation lyric
					float translationTotalWidth = TextRenderExtension.Convert(lyrics[i + 2],
									chart.FileLocation?.Parent?.FullName + $"\\{ExtensionSharedConstants.LyricsTagPrefix}_translation_trash.png",
									translationFont, (float)(translationScale / 100)).Item1;
					string[] translationWords = lyrics[i + 2].ToCharArray().Select(x => x.ToString()).ToArray();
					float translationPastWidth = - TextRenderExtension.Convert(translationWords[0], 
									chart.FileLocation?.Parent?.FullName + $"\\{ExtensionSharedConstants.LyricsTagPrefix}_translation_trash.png",
									translationFont, (float)(translationScale / 100)).Item1; // this is very strange
					for (int j = 0; j < translationWords.Length; j++)
					{
						float translationWordWidth = TextRenderExtension.Convert(translationWords[j],
							chart.FileLocation?.Parent?.FullName + $"\\{ExtensionSharedConstants.LyricsTagPrefix}_{i}_translation_{j}.png",
							translationFont, (float)(translationScale / 100)).Item1;

						double translationDesiredX = (double)(positionXPixel - translationTotalWidth / 2d + translationPastWidth + translationWordWidth / 2d) / ExtensionSharedConstants.TileWidth;
						double translationDesiredY = (double)(positionYPixel + translationYOffset) / ExtensionSharedConstants.TileWidth;

						double translationXOffset = (j - (translationWords.Length - 1) / 2d) * 0.618;
						chart.AddDecorationToChart(new()
						{
							Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_{i}_translation_{j}",
							Depth = ExtensionSharedConstants.LyricsDepth + depthOffset,
							LockRotation = true,
							LockScale = true,
							ParallaxOffset = new(translationDesiredX + translationXOffset, translationDesiredY),
							Parallax = new(100, 100),
							RelativeTo = AdfMoveDecorationRelativeToType.Global,
							Opacity = 0d,
							Color = new("FFFFFFFF"),
							DecorationImage = $"{ExtensionSharedConstants.LyricsTagPrefix}_{i}_translation_{j}.png"
						});

						chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
						{
							Duration = inDuration * beatMultiplier * 2,
							Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_{i}_translation_{j}",
							Opacity = 100d,
							Ease = AdfEaseType.OutExpo,
							ParallaxOffset = new(translationDesiredX, translationDesiredY),
							AngleOffset = 0.001,
						});

						chart.ChartTiles[nextTile].TileEvents.Add(new AdfEventMoveDecorations()
						{
							Duration = outDuration * nextBeatMultiplier,
							Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_{i}_translation_{j}",
							Ease = AdfEaseType.Linear,
							Opacity = 0,
							AngleOffset = outDuration * nextBeatMultiplier * (-180)
						});
						chart.ChartTiles[nextTile].TileEvents.Add(new AdfEventMoveDecorations()
						{
							Duration = outDuration * nextBeatMultiplier,
							Tag = $"{ExtensionSharedConstants.LyricsTagPrefix}_{gid}_{i}_translation_{j}",
							Ease = AdfEaseType.InCirc,
							ParallaxOffset = new(translationDesiredX - translationXOffset * 0.618, translationDesiredY),
							AngleOffset = outDuration * nextBeatMultiplier * (-180)
						});

						translationPastWidth += translationWordWidth + spaceWidth;
					}







				}
			}
			catch { Console.WriteLine("LyricWithTranslation Exception thrown."); }
		}

	}
}
