using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	internal static class CommonRandomCameraExtension
	{
		public static void RandomCamera(
			this AdfChart chart,
			double xmin,
			double xmax,
			double ymin,
			double ymax,
			double rmin,
			double rmax,
			double zmin,
			double zmax,
			int beatsMin,
			int beatsMax,
			int holdbeatMin,
			int holdbeatMax,
			double duration,
			int targetTile = 21)
		{
			double currentBeat = 0d;
			Random random = new();
			while (currentBeat < duration)
			{
				double currentDurationMove = random.NextDouble() * (beatsMax - beatsMin) + beatsMin;

				chart.ChartTiles[targetTile].TileEvents.Add(
					new AdfEventMoveCamera()
					{
						Position = new(
							random.NextDouble() * (xmax - xmin) + xmin,
							random.NextDouble() * (ymax - ymin) + ymin),
						Duration = currentDurationMove,
						AngleOffset = currentBeat * 180d,
						Ease = AdfEaseType.OutCubic,
						Rotation = random.NextDouble() * (rmax - rmin) + rmin,
						Zoom = random.NextDouble() * (zmax - zmin) + zmin,
					});

				double currentDurationHold = random.NextDouble() * (holdbeatMax - holdbeatMin) + holdbeatMin;



				currentBeat += currentDurationMove + currentDurationHold;
			}
		}

	}
}
