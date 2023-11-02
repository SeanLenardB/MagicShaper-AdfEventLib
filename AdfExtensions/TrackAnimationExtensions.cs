using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	internal static class TrackAnimationExtensions
	{
		public static void TrackDisappearAnimation(
			this AdfChart chart,
			Tuple<int, int> tileRange,
			Tuple<double, double> durationBeatsRange,
			Tuple<double, double> xRange,
			Tuple<double, double> yRange,
			Tuple<double, double> rotationRange,
			Tuple<double, double> angleOffsetRange,
			Tuple<double, double> opacityRange,
			Tuple<double, double> scaleRange,
			List<AdfEaseType> eases,
			string tag = ""
			)
		{
			Random random = new();
			for (int i = tileRange.Item1; i <= tileRange.Item2; i++)
			{
				//chart.ChartTiles[i].TileEvents.Add(
				//	new AdfEventMoveTrack(
				//		tag,
				//		new(eases[random.Next(eases.Count)], random.NextDouble() * (durationBeatsRange.Item2 - durationBeatsRange.Item1) + durationBeatsRange.Item1),
				//		random.NextDouble() * (angleOffsetRange.Item2 - angleOffsetRange.Item1) + angleOffsetRange.Item1,
				//		new(i, AdfTileReferenceType.Start),
				//		new(i, AdfTileReferenceType.Start),
				//		0,
				//		new(random.NextDouble() * (xRange.Item2 - xRange.Item1) + xRange.Item1, random.NextDouble() * (yRange.Item2 - yRange.Item1) + yRange.Item1),
				//		random.NextDouble() * (rotationRange.Item2 - rotationRange.Item1) + rotationRange.Item1,
				//		new(random.NextDouble() * (scaleRange.Item2 - scaleRange.Item1) + scaleRange.Item1),
				//		random.NextDouble() * (opacityRange.Item2 - opacityRange.Item1) + opacityRange.Item1));
			}
		}

		public static void TrackAppearAnimation(
			this AdfChart chart,
			Tuple<int, int> tileRange,
			Tuple<double, double> durationBeatsRange,
			Tuple<double, double> xRange,
			Tuple<double, double> yRange,
			Tuple<double, double> rotationRange,
			Tuple<double, double> angleOffsetRange,
			Tuple<double, double> opacityRange,
			Tuple<double, double> scaleRange,
			List<AdfEaseType> eases,
			string tag = "",
			double finalOpacity = 100d
			)
		{
			//Random random = new();
			//for (int i = tileRange.Item1; i <= tileRange.Item2; i++)
			//{
			//	chart.ChartTiles[i].TileEvents.Add(
			//		new AdfEventMoveTrack(
			//			tag,
			//			new(AdfEaseType.Linear, 0),
			//			-114514,
			//			new(i, AdfTileReferenceType.Start),
			//			new(i, AdfTileReferenceType.Start),
			//			0,
			//			new(random.NextDouble() * (xRange.Item2 - xRange.Item1) + xRange.Item1, random.NextDouble() * (yRange.Item2 - yRange.Item1) + yRange.Item1),
			//			random.NextDouble() * (rotationRange.Item2 - rotationRange.Item1) + rotationRange.Item1,
			//			new(random.NextDouble() * (scaleRange.Item2 - scaleRange.Item1) + scaleRange.Item1),
			//			random.NextDouble() * (opacityRange.Item2 - opacityRange.Item1) + opacityRange.Item1));
			//	double inDuration = random.NextDouble() * (durationBeatsRange.Item2 - durationBeatsRange.Item1) + durationBeatsRange.Item1;
			//	chart.ChartTiles[i].TileEvents.Add(
			//		new AdfEventMoveTrack(
			//			tag,
			//			new(eases[random.Next(eases.Count)], inDuration),
			//			- (random.NextDouble() * (angleOffsetRange.Item2 - angleOffsetRange.Item1) + angleOffsetRange.Item1) - inDuration * 360,
			//			new(i, AdfTileReferenceType.Start),
			//			new(i, AdfTileReferenceType.Start),
			//			0,
			//			new(0, 0),
			//			0,
			//			new(100),
			//			finalOpacity));
			//}
		}

		public static void TrackExplodeDisappearAnimation(
			this AdfChart chart,
			Tuple<int, int> tileRange,
			List<int> explodeEffectTileIndex,
			Tuple<double, double> durationBeatsRange,
			Tuple<double, double> xRange,
			Tuple<double, double> yRange,
			Tuple<double, double> rotationRange,
			Tuple<double, double> opacityRange,
			Tuple<double, double> scaleRange,
			List<AdfEaseType> eases,

			bool aberrationEffect = false,
			double aberrationEffectStartValue = 35d,
			double aberrationEffectDuration = 12d,

			bool fisheyeEffect = false,
			double fisheyeEffectStartValue = 48.5d,
			double fisheyeEffectDuration = 12d,

			string tag = "")
		{
			//Random random = new();
			
			//for (int i = 0; i <= explodeEffectTileIndex.Count; i++)
			//{
			//	int startIndex = i == 0 ? tileRange.Item1 : explodeEffectTileIndex[i - 1];
			//	int endIndex = i == explodeEffectTileIndex.Count ? tileRange.Item2 : explodeEffectTileIndex[i] - 1;

			//	for (int j = startIndex; j <= endIndex; j++)
			//	{
			//		chart.ChartTiles[endIndex].TileEvents.Add(new AdfEventMoveTrack(
			//			tag,
			//			new(eases[random.Next(eases.Count)], random.NextDouble() * (durationBeatsRange.Item2 - durationBeatsRange.Item1) + durationBeatsRange.Item1),
			//			180,
			//			new(j, AdfTileReferenceType.Start),
			//			new(j, AdfTileReferenceType.Start),
			//			0,
			//			new(random.NextDouble() * (xRange.Item2 - xRange.Item1) + xRange.Item1,
			//				random.NextDouble() * (yRange.Item2 - yRange.Item1) + yRange.Item1),
			//			random.NextDouble() * (rotationRange.Item2 - rotationRange.Item1) + rotationRange.Item1,
			//			new(random.NextDouble() * (scaleRange.Item2 - scaleRange.Item1) + scaleRange.Item1),
			//			random.NextDouble() * (opacityRange.Item2 - opacityRange.Item1) + opacityRange.Item1
			//			));
			//	}

			//	if (aberrationEffect)
			//	{
			//		chart.AberrationCombo(startIndex, aberrationEffectStartValue, aberrationEffectDuration, tag);
			//	}
			//	if (fisheyeEffect)
			//	{
			//		chart.FisheyeCombo(startIndex, fisheyeEffectStartValue, fisheyeEffectDuration, tag);
			//	}
			//}
		}
	}
}
