using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects
{
	internal class AdfVfxProj_IAmMe
	{
		////chart.ChartTiles[1].TileEvents
		////	.Add(new AdfEventMoveCamera("",
		////					   0d,
		////					   new(AdfEaseType.InOutSine, 16d),
		////					   new(null, null),
		////					   AdfEventMoveCamera.AdfCameraRelativeToType.Player,
		////					   5d,
		////					   250d));
		//chart.TrackDisappearAnimation(
		//	new(1, 101), 
		//	new(4, 8), 
		//	new(-5, 5), 
		//	new(-10, -8), 
		//	new(-30, 30), 
		//	new(180, 270), 
		//	new(0, 0), 
		//	new(90, 100), 
		//	new() { AdfEaseType.InCubic, AdfEaseType.InQuart, AdfEaseType.InQuint, AdfEaseType.InCirc });
		//chart.TrackAppearAnimation(
		//	new(1, 101), 
		//	new(4, 8), 
		//	new(-5, 5), 
		//	new(8, 10), 
		//	new(-30, 30),
		//	new(0, 180), 
		//	new(0, 0),
		//	new(105, 100), 
		//	new() { AdfEaseType.OutCubic, AdfEaseType.OutQuart, AdfEaseType.OutQuint, AdfEaseType.OutCirc });

		//chart.DecorationFlashEffect(
		//	"white",
		//	new(15, 50),
		//	new(0, 1024),
		//	new(0.125, 2),
		//	new() { AdfEaseType.OutCubic, AdfEaseType.OutQuad, AdfEaseType.InCubic, AdfEaseType.InQuad, AdfEaseType.OutSine, AdfEaseType.InSine },
		//	new(300, 320));
		//chart.CameraWobbleEffect(
		//	new(-4, 4),
		//	new(new(-0.8, -0.5), new(0.8, 0.5)),
		//	new(0, 1024),
		//	new(8, 16),
		//	new() { AdfEaseType.InOutSine, AdfEaseType.InOutQuad },
		//	2);

		//chart.TrackExplodeDisappearAnimation(
		//	new(118, 215),
		//	new() { 128, 143, 154, 166, 177, 192, 202 },
		//	new(28, 32),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);
		//chart.TrackExplodeDisappearAnimation(
		//	new(235, 334),
		//	new() { 245, 260, 271, 283, 294, 309, 321 },
		//	new(28, 32),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);
		//chart.TrackExplodeDisappearAnimation(
		//	new(351, 452),
		//	new() { 361, 376, 387, 399, 410, 425, 437 },
		//	new(28, 32),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);
		//chart.TrackExplodeDisappearAnimation(
		//	new(468, 574),
		//	new() { 480, 495, 508, 522, 535, 549, 561 },
		//	new(28, 32),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);

		//foreach (int i in new List<int>() { 575, 652, 724 })
		//{
		//	chart.TrackExplodeDisappearAnimation(
		//	new(i, 627 - 575 + i),
		//	new() { 584 - 575 + i, 594 - 575 + i, 604 - 575 + i, 614 - 575 + i, 620 - 575 + i, 624 - 575 + i },
		//	new(12, 16),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true, aberrationEffectDuration: 4, fisheyeEffectDuration: 6);
		//}

		//chart.TrackDisappearAnimation(
		//	new(802, 875),
		//	new(16, 24),
		//	new(-5, 5),
		//	new(-10, -8),
		//	new(-30, 30),
		//	new(360, 540),
		//	new(0, 0),
		//	new(90, 100),
		//	new() { AdfEaseType.InCubic, AdfEaseType.InQuad, AdfEaseType.InCirc });

		//chart.TrackExplodeDisappearAnimation(
		//	new(879, 1101),
		//	new() { 890, 905, 918, 932, 945, 959, 971, 985, 996, 1011, 1024, 1038, 1051, 1065, 1077, 1091 },
		//	new(14, 16),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);

		//chart.TrackDisappearAnimation(
		//	new(1102, 1111),
		//	new(28, 32),
		//	new(-3, 3),
		//	new(14, 17),
		//	new(-30, 30),
		//	new(360, 540),
		//	new(0, 0),
		//	new(150, 180),
		//	new() { AdfEaseType.OutCubic, AdfEaseType.OutQuad, AdfEaseType.OutQuart });

		//chart.TrackExplodeDisappearAnimation(
		//	new(1112, 1130),
		//	new() { 1118 },
		//	new(14, 16),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);

		//chart.TrackDisappearAnimation(
		//	new(1131, 1140),
		//	new(28, 32),
		//	new(-3, 3),
		//	new(14, 17),
		//	new(-30, 30),
		//	new(360, 540),
		//	new(0, 0),
		//	new(150, 180),
		//	new() { AdfEaseType.OutCubic, AdfEaseType.OutQuad, AdfEaseType.OutQuart });

		//chart.TrackExplodeDisappearAnimation(
		//	new(1141, 1184),
		//	new() { 1146, 1159, 1173 },
		//	new(14, 16),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);

		//chart.TrackDisappearAnimation(
		//	new(1185, 1202),
		//	new(28, 32),
		//	new(-3, 3),
		//	new(14, 17),
		//	new(-30, 30),
		//	new(360, 540),
		//	new(0, 0),
		//	new(150, 180),
		//	new() { AdfEaseType.OutCubic, AdfEaseType.OutQuad, AdfEaseType.OutQuart });

		//chart.TrackExplodeDisappearAnimation(
		//	new(1203, 1308),
		//	new() { 1214, 1229, 1242, 1256, 1269, 1283, 1295 },
		//	new(14, 16),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);











		//chart.TrackDisappearAnimation(
		//	new(1309, 1354),
		//	new(4, 8),
		//	new(-5, 5),
		//	new(-10, -8),
		//	new(-30, 30),
		//	new(180, 270),
		//	new(0, 0),
		//	new(90, 100),
		//	new() { AdfEaseType.InCubic, AdfEaseType.InQuart, AdfEaseType.InQuint, AdfEaseType.InCirc });
		//chart.TrackAppearAnimation(
		//	new(1309, 1354),
		//	new(4, 8),
		//	new(-5, 5),
		//	new(8, 10),
		//	new(-30, 30),
		//	new(0, 180),
		//	new(0, 0),
		//	new(105, 100),
		//	new() { AdfEaseType.OutCubic, AdfEaseType.OutQuart, AdfEaseType.OutQuint, AdfEaseType.OutCirc });

		//chart.TrackExplodeDisappearAnimation(
		//	new(1372, 1471),
		//	new() { 1382, 1397, 1408, 1420, 1431, 1446, 1458 },
		//	new(28, 32),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);
		//chart.TrackExplodeDisappearAnimation(
		//	new(1489, 1588),
		//	new() { 1501, 1516, 1527, 1539, 1550, 1565, 1575 },
		//	new(28, 32),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);
		//chart.TrackExplodeDisappearAnimation(
		//	new(1606, 1705),
		//	new() { 1616, 1631, 1642, 1654, 1665, 1680, 1692 },
		//	new(28, 32),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);
		//chart.TrackExplodeDisappearAnimation(
		//	new(1722, 1826),
		//	new() { 1732, 1747, 1760, 1774, 1787, 1801, 1813 },
		//	new(28, 32),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);

		//foreach (int i in new List<int>() { 1827, 1900, 1979 })
		//{
		//	chart.TrackExplodeDisappearAnimation(
		//	new(i, 627 - 575 + i),
		//	new() { 584 - 575 + i, 594 - 575 + i, 604 - 575 + i, 614 - 575 + i, 620 - 575 + i, 624 - 575 + i },
		//	new(12, 16),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true, aberrationEffectDuration: 4, fisheyeEffectDuration: 6);
		//}
		//chart.TrackDisappearAnimation(
		//	new(2056, 2129),
		//	new(16, 24),
		//	new(-5, 5),
		//	new(-10, -8),
		//	new(-30, 30),
		//	new(360, 540),
		//	new(0, 0),
		//	new(90, 100),
		//	new() { AdfEaseType.InCubic, AdfEaseType.InQuad, AdfEaseType.InCirc });

		//chart.TrackExplodeDisappearAnimation(
		//	new(2133, 2336),
		//	new() { 2143, 2155, 2167, 2180, 2190, 2204, 2215, 2228, 2238, 2252, 2264, 2278, 2289, 2302, 2313, 2326 },
		//	new(14, 16),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);

		//chart.TrackDisappearAnimation(
		//	new(2337, 2346),
		//	new(28, 32),
		//	new(-3, 3),
		//	new(14, 17),
		//	new(-30, 30),
		//	new(360, 540),
		//	new(0, 0),
		//	new(150, 180),
		//	new() { AdfEaseType.OutCubic, AdfEaseType.OutQuad, AdfEaseType.OutQuart });

		//chart.TrackExplodeDisappearAnimation(
		//	new(2347, 2362),
		//	new() { 2352 },
		//	new(14, 16),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);

		//chart.TrackDisappearAnimation(
		//	new(2363, 2372),
		//	new(28, 32),
		//	new(-3, 3),
		//	new(14, 17),
		//	new(-30, 30),
		//	new(360, 540),
		//	new(0, 0),
		//	new(150, 180),
		//	new() { AdfEaseType.OutCubic, AdfEaseType.OutQuad, AdfEaseType.OutQuart });

		//chart.TrackExplodeDisappearAnimation(
		//	new(2373, 2414),
		//	new() { 2378, 2390, 2404 },
		//	new(14, 16),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);

		//chart.TrackDisappearAnimation(
		//	new(2415, 2432),
		//	new(28, 32),
		//	new(-3, 3),
		//	new(14, 17),
		//	new(-30, 30),
		//	new(360, 540),
		//	new(0, 0),
		//	new(150, 180),
		//	new() { AdfEaseType.OutCubic, AdfEaseType.OutQuad, AdfEaseType.OutQuart });

		//chart.TrackExplodeDisappearAnimation(
		//	new(2433, 2531),
		//	new() { 2444, 2457, 2469, 2482, 2494, 2508, 2519 },
		//	new(14, 16),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);









		//chart.TrackDisappearAnimation(
		//	new(2532, 2809),
		//	new(6, 8),
		//	new(-5, 5),
		//	new(-10, -8),
		//	new(-30, 30),
		//	new(360, 540),
		//	new(0, 0),
		//	new(210, 250),
		//	new() { AdfEaseType.InCubic, AdfEaseType.InQuad, AdfEaseType.InCirc });
		//chart.TrackAppearAnimation(
		//	new(2532, 2809),
		//	new(6, 8),
		//	new(-5, 5),
		//	new(8, 10),
		//	new(-30, 30),
		//	new(360, 540),
		//	new(0, 0),
		//	new(210, 250),
		//	new() { AdfEaseType.OutCubic, AdfEaseType.OutQuad, AdfEaseType.OutCirc },
		//	finalOpacity: 1000d);

		//foreach (int i in new List<int>() { 2537, 2553, 2570, 2587, 2606, 2622, 2639, 2656, 2674, 2692, 2710, 2733, 2749, 2766, 2782, 2800 })
		//{
		//	chart.AberrationCombo(i, 35, 8);
		//	chart.FisheyeCombo(i, 47, 8);
		//}



		//chart.TrackAppearAnimation(
		//	new(2810, 3249),
		//	new(6, 8),
		//	new(-12, 12),
		//	new(-10, -8),
		//	new(-30, 30),
		//	new(360, 540),
		//	new(0, 0),
		//	new(210, 250),
		//	new() { AdfEaseType.OutCubic, AdfEaseType.OutQuad, AdfEaseType.OutCirc },
		//	finalOpacity: 1000d);
		//chart.TrackDisappearAnimation(
		//	new(2810, 3249),
		//	new(6, 8),
		//	new(-12, 12),
		//	new(-10, -8),
		//	new(-30, 30),
		//	new(360, 540),
		//	new(0, 0),
		//	new(300, 400),
		//	new() { AdfEaseType.InCubic, AdfEaseType.InQuad, AdfEaseType.InCirc });

		//foreach (int i in new List<int>() { 2810, 2824, 2840, 2852, 2864, 2876, 2888, 2900, 2914, 2926, 2938, 2950, 2962, 2976, 2990, 3002, 3016, 3026, 3038, 3050, 3062, 3072, 3084, 3096, 3110, 3126, 3146, 3162, 3178, 3194, 3212, 3226, 3228, 3238, 3248 })
		//{
		//	chart.AberrationCombo(i, 35, 8);
		//	chart.FisheyeCombo(i, 47, 8);
		//}








		//chart.TrackDisappearAnimation(
		//	new(3250, 3355),
		//	new(4, 8),
		//	new(-5, 5),
		//	new(-10, -8),
		//	new(-30, 30),
		//	new(180, 270),
		//	new(0, 0),
		//	new(90, 100),
		//	new() { AdfEaseType.InCubic, AdfEaseType.InQuart, AdfEaseType.InQuint, AdfEaseType.InCirc });
		//chart.TrackAppearAnimation(
		//	new(3250, 3355),
		//	new(4, 8),
		//	new(-5, 5),
		//	new(8, 10),
		//	new(-30, 30),
		//	new(0, 180),
		//	new(0, 0),
		//	new(105, 100),
		//	new() { AdfEaseType.OutCubic, AdfEaseType.OutQuart, AdfEaseType.OutQuint, AdfEaseType.OutCirc },
		//	finalOpacity: 500);




		//chart.TrackExplodeDisappearAnimation(
		//	new(3356, 3361),
		//	new() { },
		//	new(14, 16),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);

		//chart.TrackDisappearAnimation(
		//	new(3362, 3389),
		//	new(28, 32),
		//	new(-3, 3),
		//	new(14, 17),
		//	new(-30, 30),
		//	new(360, 540),
		//	new(0, 0),
		//	new(150, 180),
		//	new() { AdfEaseType.OutCubic, AdfEaseType.OutQuad, AdfEaseType.OutQuart });

		//chart.TrackExplodeDisappearAnimation(
		//	new(3390, 3418),
		//	new() { 3402, 3413 },
		//	new(14, 16),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);

		//chart.TrackDisappearAnimation(
		//	new(3419, 3437),
		//	new(28, 32),
		//	new(-3, 3),
		//	new(14, 17),
		//	new(-30, 30),
		//	new(360, 540),
		//	new(0, 0),
		//	new(150, 180),
		//	new() { AdfEaseType.OutCubic, AdfEaseType.OutQuad, AdfEaseType.OutQuart });

		//chart.TrackExplodeDisappearAnimation(
		//	new(3438, 3470),
		//	new() { 3443, 3454, 3465 },
		//	new(14, 16),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);

		//chart.TrackDisappearAnimation(
		//	new(3471, 3489),
		//	new(28, 32),
		//	new(-3, 3),
		//	new(14, 17),
		//	new(-30, 30),
		//	new(360, 540),
		//	new(0, 0),
		//	new(150, 180),
		//	new() { AdfEaseType.OutCubic, AdfEaseType.OutQuad, AdfEaseType.OutQuart });

		//chart.TrackExplodeDisappearAnimation(
		//	new(3490, 3573),
		//	new() { 3495, 3507, 3519, 3530, 3541, 3552, 3563 },
		//	new(14, 16),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);

		//chart.TrackDisappearAnimation(
		//	new(3574, 3583),
		//	new(28, 32),
		//	new(-3, 3),
		//	new(14, 17),
		//	new(-30, 30),
		//	new(360, 540),
		//	new(0, 0),
		//	new(150, 180),
		//	new() { AdfEaseType.OutCubic, AdfEaseType.OutQuad, AdfEaseType.OutQuart });

		//chart.TrackExplodeDisappearAnimation(
		//	new(3584, 3599),
		//	new() { 3589 },
		//	new(14, 16),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);

		//chart.TrackDisappearAnimation(
		//	new(3600, 3609),
		//	new(28, 32),
		//	new(-3, 3),
		//	new(14, 17),
		//	new(-30, 30),
		//	new(360, 540),
		//	new(0, 0),
		//	new(150, 180),
		//	new() { AdfEaseType.OutCubic, AdfEaseType.OutQuad, AdfEaseType.OutQuart });

		//chart.TrackExplodeDisappearAnimation(
		//	new(3610, 3649),
		//	new() { 3615, 3627, 3639 },
		//	new(14, 16),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);

		//chart.TrackDisappearAnimation(
		//	new(3650, 3667),
		//	new(28, 32),
		//	new(-3, 3),
		//	new(14, 17),
		//	new(-30, 30),
		//	new(360, 540),
		//	new(0, 0),
		//	new(150, 180),
		//	new() { AdfEaseType.OutCubic, AdfEaseType.OutQuad, AdfEaseType.OutQuart });

		//chart.TrackExplodeDisappearAnimation(
		//	new(3668, 3763),
		//	new() { 3670, 3690, 3702, 3708, 3714, 3718, 3724, 3730, 3734, 3740, 3746, 3752, 3758, 3763 },
		//	new(14, 16),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);






		//chart.TrackExplodeDisappearAnimation(
		//	new(3764, 4125),
		//	new() { 3778, 3794, 3806, 3818, 3830, 3842, 3854, 3868, 3884, 3902, 3916, 3930, 3946, 3962, 3976, 3994, 4008, 4028, 4044, 4060, 4072, 4088, 4104 },
		//	new(14, 16),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(90, 110),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);
		//chart.TrackAppearAnimation(
		//	new(3764, 4125),
		//	new(6, 8),
		//	new(-10, 10),
		//	new(8, 10),
		//	new(-30, 30),
		//	new(0, 180),
		//	new(0, 0),
		//	new(300, 500),
		//	new() { AdfEaseType.OutCubic, AdfEaseType.OutQuart, AdfEaseType.OutQuint, AdfEaseType.OutCirc },
		//	finalOpacity: 500);

		//chart.TrackExplodeDisappearAnimation(
		//	new(4126, 4223),
		//	new() { 4136, 4143, 4150, 4159, 4164, 4171, 4186, 4193, 4200, 4209, 4213, 4217, 4221 },
		//	new(14, 16),
		//	new(-10, 10),
		//	new(-7, 7),
		//	new(-45, 45),
		//	new(0, 0),
		//	new(150, 200),
		//	new() { AdfEaseType.OutCirc, AdfEaseType.OutQuint, AdfEaseType.OutQuart, AdfEaseType.OutExpo },
		//	aberrationEffect: true, fisheyeEffect: true);




		//chart.ScreenBottomSwitchLyrics(new()
		//{
		//	new(102, 2),
		//	new(192, 8),
		//	new(309, 8),
		//	new(425, 8),
		//	new(561, 8),
		//	new(647, 4),
		//	new(721, 4),
		//	new(802, 8),
		//	new(834, 8),
		//	new(873, 4),
		//	new(909, 8),
		//	new(945, 8),
		//	new(1002, 8),
		//	new(1072, 8),
		//	new(1112, 8),
		//	new(1141, 8),
		//	new(1195, 18),
		//	new(1242, 8),
		//	new(1324, 2),
		//	new(1356, 2),
		//	new(1452, 8),
		//	new(1565, 8),
		//	new(1686, 8),
		//	new(1819, 8),
		//	new(1891, 4),
		//	new(1988, 8),
		//	new(2053, 4),
		//	new(2088, 8),
		//	new(2127, 4),
		//	new(2161, 8),
		//	new(2196, 8),
		//	new(2244, 8),
		//	new(2302, 8),
		//	new(2347, 8),
		//	new(2373, 8),
		//	new(2425, 18),
		//	new(2477, 8),
		//	new(2810, 8),
		//	new(2914, 8),
		//	new(3016, 8),
		//	new(3110, 8),
		//	new(3282, 2),
		//	new(3307, 2),
		//	new(3328, 2),
		//	new(3337, 2),
		//	new(3351, 2),
		//	new(3396, 8),
		//	new(3428, 16),
		//	new(3490, 8),
		//	new(3547, 8),
		//	new(3584, 8),
		//	new(3610, 8),
		//	new(3660, 18),
		//	new(3708, 8),
		//	new(3764, 8),
		//	new(3868, 8),
		//	new(3994, 8),
		//	new(4136, 8),
		//	new(4223, 8),
		//}, "lyric", AdfEaseType.InOutCubic);

		//File.WriteAllText(@"G:\Adofai levels\I am me\level-output.adofai", chart.ChartJson.ToJsonString());
	}
}
