using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	internal static class ProjectorEffectExtensions
	{
		//public static void DecorationFlashEffect(
		//	this AdfChart chart,
		//	string decoTag,
		//	Tuple<double, double> opacityRange,
		//	Tuple<double, double> effectBeatsRange,
		//	Tuple<double, double> eachAnimationBeatsRange,
		//	List<AdfEaseType> easeList,
		//	AdfScale decoScale,
		//	int targetTileIndex = 1,
		//	string eventTag = "",
		//	string whitePngLocation = "white.png",
		//	string colorStr = "fff2aaff",
		//	double interval = 0.01d)
		//{
		//	double currentBeat = effectBeatsRange.Item1;
		//	Random random = new();

		//	while (currentBeat < effectBeatsRange.Item2)
		//	{
		//		double thisEffectDuration = random.NextDouble() * (eachAnimationBeatsRange.Item2 - eachAnimationBeatsRange.Item1) + eachAnimationBeatsRange.Item1;
		//		chart.ChartTiles[targetTileIndex].TileEvents.Add(new AdfEventMoveDecorations(
		//			eventTag,
		//			decoTag,
		//			currentBeat * 180d,
		//			new(easeList[random.Next(easeList.Count)], thisEffectDuration),
		//			new(null, null),
		//			new(null, null),
		//			new(100, 100),
		//			new(null, null),
		//			decoScale,
		//			0d,
		//			random.NextDouble() * (opacityRange.Item2 - opacityRange.Item1) + opacityRange.Item1,
		//			true,
		//			AdfEventMoveDecorations.AdfMoveDecorationRelativeToType.LastPosition,
		//			whitePngLocation,
		//			10,
		//			new(colorStr)));
		//		currentBeat += thisEffectDuration + interval;
		//	}
		//}

		//public static void CameraWobbleEffect(
		//	this AdfChart chart,
		//	Tuple<double, double> rotationRange,
		//	Tuple<AdfPosition, AdfPosition> positionRange,
		//	Tuple<double, double> effectBeatsRange,
		//	Tuple<double, double> eachAnimationBeatsRange,
		//	List<AdfEaseType> easeList,
		//	int targetTileIndex = 1,
		//	string eventTag = "",
		//	double interval = 0.01d)
		//{
		//	double currentBeat = effectBeatsRange.Item1;
		//	Random random = new();

		//	while (currentBeat < effectBeatsRange.Item2)
		//	{
		//		double thisEffectDuration = random.NextDouble() * (eachAnimationBeatsRange.Item2 - eachAnimationBeatsRange.Item1) + eachAnimationBeatsRange.Item1;
		//		chart.ChartTiles[targetTileIndex].TileEvents.Add(new AdfEventMoveCamera(
		//			eventTag,
		//			currentBeat * 180d,
		//			new(easeList[random.Next(easeList.Count)], thisEffectDuration),
		//			new(random.NextDouble() * (positionRange.Item2.X - positionRange.Item1.X) + positionRange.Item1.X, 
		//			random.NextDouble() * (positionRange.Item2.Y - positionRange.Item1.Y) + positionRange.Item1.Y),
		//			AdfEventMoveCamera.AdfCameraRelativeToType.Player,
		//			random.NextDouble() * (rotationRange.Item2 - rotationRange.Item1) + rotationRange.Item1,
		//			250));
		//		currentBeat += thisEffectDuration + interval;
		//	}
		//}

	}
}
