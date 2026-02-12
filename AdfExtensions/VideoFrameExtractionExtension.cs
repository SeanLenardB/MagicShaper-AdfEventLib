using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FFMpegCore;
using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;

namespace MagicShaper.AdfExtensions
{
    internal static class VideoFrameExtractionExtension
    {
        internal static void AddVideoFramesToChart(this AdfChart chart, string videoFile, int tileStart, double durationBeats, double framePerBeat = 1, string decorationTag = "", double offsetSeconds = 0d)
        {
            Debug.Assert(tileStart > 0, "You should not put anything on the 0th tile because 7bg hates humanity and limits your ability to make stuff happen.");

            TimeSpan extractInterval = TimeSpan.FromMilliseconds(60000d / chart.GetTileBpmAt(tileStart) / framePerBeat);
            TimeSpan startTime = chart.GetRealTimespans()[tileStart - 1] + TimeSpan.FromSeconds(offsetSeconds);
            TimeSpan endTime = startTime + (extractInterval * durationBeats * framePerBeat) + TimeSpan.FromMilliseconds(5);  // We add 5ms for fear of precision loss.

            FFMpegArguments
                .FromFileInput(chart.FileLocation.Parent?.FullName + $"\\{videoFile}", true, options => options
                    .Seek(startTime)
                    .EndSeek(endTime))
                .OutputToFile(chart.FileLocation.Parent?.FullName + $"\\quartrond-f{tileStart}l%05d.png", true,
                    argument => argument.WithFramerate(1d / extractInterval.TotalSeconds))
                .ProcessSynchronously();

            for (int i = 0; i < durationBeats * framePerBeat; i++)
            {
                chart.ChartTiles[tileStart].TileEvents.Add(new AdfEventMoveDecorations()
                {
                    DecorationImage = $"quartrond-f{tileStart}l{i + 1:D5}.png",  // This is because ffmpeg output start at 1.
                    Tag = decorationTag,
                    AngleOffset = i * 180d / framePerBeat
                });
            }
        }
    }
}
