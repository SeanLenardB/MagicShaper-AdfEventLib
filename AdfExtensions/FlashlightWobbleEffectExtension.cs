using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	internal static class FlashlightWobbleEffectExtension
	{
		public static void FlashlightWobbleEffect(
			this AdfChart chart,
			string flashlightDecoTag,
			int xmin,
			int xmax,
			int ymin,
			int ymax,
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
					new AdfEventMoveDecorations()
					{
						ParallaxOffset = new(
							random.NextDouble() * (xmax - xmin) + xmin,
							random.NextDouble() * (ymax - ymin) + ymin),
						Duration = currentDurationMove,
						AngleOffset = currentBeat * 180d,
						Ease = AdfEaseType.OutBack,
						Tag = flashlightDecoTag,
					});

				double currentDurationHold = random.NextDouble() * (holdbeatMax - holdbeatMin) + holdbeatMin;

				

				currentBeat += currentDurationMove + currentDurationHold;
			}
		}


	}
}
