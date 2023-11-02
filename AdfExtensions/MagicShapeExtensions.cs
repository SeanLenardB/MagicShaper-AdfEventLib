using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MagicShaper.AdofaiCore.AdfEvents.AdfEventSetSpeed;

namespace MagicShaper.AdfExtensions
{
    internal static class MagicShapeExtensions
    {
        public static void MagicShape(this AdfChart chart, double bpm, bool innerCircle = true)
        {
            bool isLHS = true;

            var tiles = chart.ChartTiles;
            for (int i = 0; i < tiles.Count - 1; i++)
            {
                foreach (var action in tiles[i + 1].TileEvents)
                {
                    if (action is AdfEventTwirl) { isLHS = !isLHS; break; }
                }
                double alpha = tiles[i].TargetAngle;
                double beta = tiles[i + 1].TargetAngle;

                double realAngle = 180d - alpha + beta;
                if (realAngle > 360d)
                {
                    realAngle -= 360d;
                }
                if (realAngle < 0d)
                {
                    realAngle += 360d;
                }

                if (isLHS)
                {
                    realAngle = 360d - realAngle;
                }

                if (innerCircle)
                {
                    if (realAngle > 180d)
                    {
                        realAngle = 360d - realAngle;
                        isLHS = !isLHS;
                        tiles[i + 1].TileEvents.Add(new AdfEventTwirl());
                    }
                }
                else
                {
                    if (realAngle < 180d)
                    {
                        realAngle = 360d - realAngle;
                        isLHS = !isLHS;
                        tiles[i + 1].TileEvents.Add(new AdfEventTwirl());
                    }
                }

                tiles[i + 1].TileEvents.Add(new AdfEventSetSpeed()
                {
                    SpeedType = AdfEventSpeedType.Bpm,
                    BeatsPerMinute = realAngle / 180d * bpm
                });

            }


        }

    }
}
