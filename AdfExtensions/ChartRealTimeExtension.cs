using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;

namespace MagicShaper.AdfExtensions
{
    // Directly taken from my (SeanLB)'s personal macro project.
    // This is unlikely to be incorrect because the macro is very good.
    // But if 7th bug games should break gameplay code, then tell me.
    // and they can go f themselves.
    internal static class ChartRealTimeExtension
    {
        public static TimeSpan[]? CachedTimespan = null;
        /// <summary>
        /// Each <see cref="TimeSpan"/> refers to a tile in the chart. Does not support DLC.
        /// <br></br>
        /// <br></br>
        /// <strong>The first element [0] is the tile 1 in Ctrl-F view in adofai!!!</strong>
        /// </summary>
        internal static TimeSpan[] GetRealTimespans(this AdfChart chart)
        {
            if (CachedTimespan is not null) { return CachedTimespan; }

            List<TimeSpan> timespans = [];

            double currentTimestamp = 0;
            double currentBpm = chart.ChartJson["settings"]!["bpm"]!.GetValue<double>();
            bool planetRotationClockwise = true;
            for (int i = 1; i < chart.ChartTiles.Count; i++)
            {
                // NOTE(seanlb): here used to be a midspin ignore variable because a macro doesn't need to hit them.
                // I removed it but I don't know whether it will break
                timespans.Add(TimeSpan.FromMilliseconds(currentTimestamp));



                double fromAngle = 0;
                if (i > 0)
                {
                    fromAngle = chart.ChartTiles[i - 1].TargetAngle;
                }
                if (fromAngle >= 999d)
                {
                    fromAngle = chart.ChartTiles[i - 2].TargetAngle - 180;
                }

                double toAngle = chart.ChartTiles[i].TargetAngle;

                double rotatedAngle = toAngle - fromAngle - 180;
                if (chart.ChartTiles[i].TileEvents.Any(e => e is AdfEventTwirl))
                {
                    planetRotationClockwise = !planetRotationClockwise;
                }
                if (planetRotationClockwise)
                {
                    rotatedAngle = 360 - rotatedAngle;
                }
                while (rotatedAngle <= 0)
                {
                    rotatedAngle += 360;
                }
                while (rotatedAngle > 360)
                {
                    rotatedAngle -= 360;
                }

                if (toAngle >= 999d)
                {
                    rotatedAngle = 0d;
                }

                if (chart.ChartTiles[i].TileEvents.Any(e => e is AdfEventSetSpeed))
                {
                    AdfEventSetSpeed eventSetSpeed = (AdfEventSetSpeed)chart.ChartTiles[i].TileEvents.First(e => e is AdfEventSetSpeed);

                    if (eventSetSpeed.SpeedType == AdfEventSpeedType.Bpm)
                    {
                        currentBpm = eventSetSpeed.BeatsPerMinute;
                    }
                    else
                    {
                        currentBpm *= eventSetSpeed.BpmMultiplier;
                    }

                    if (eventSetSpeed.AngleOffset != 0)
                    {
                        Console.WriteLine("There is an EventSetSpeed with angleoffset!");
                    }
                }

                if (chart.ChartTiles[i].TileEvents.Any(e => e is AdfEventPause))
                {
                    AdfEventPause eventPause = (AdfEventPause)chart.ChartTiles[i].TileEvents.First(e => e is AdfEventPause);

                    rotatedAngle += 180d * eventPause.Duration;

                    if (toAngle % 360 == 180d && fromAngle % 360 == 0d)
                    {
                        rotatedAngle -= 180d;
                    }
                }


                // ms = (deg) * (min / beat) * [(beat / deg) * (ms / min)]
                // [(beat / deg) * (ms / min)] = [1 / 180 * 60,000] = 1,000 / 3
                currentTimestamp += rotatedAngle / currentBpm * 1000 / 3;
            }

            CachedTimespan = [.. timespans];
            return CachedTimespan;
        }
    }
}
