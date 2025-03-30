using MagicShaper.AdfExtensions;
using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects
{
	internal class AdfVfxProj_BydReaches
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\BYD Reaches\level-base.adofai");


			chart.ModernTrackAppear(0, 117, 4d, 8d, 0.5, 2, 0.5, 1.5, endOpacity: 1000);
			chart.ModernTrackDisappear(0, 117, 4d, -2d, -2, -0.5, -1.5, -0.5);

			chart.ModernTrackAppear(117, 740, 8d, 12d, -3, 3, -2, 2, endOpacity: 1000);
			chart.ModernTrackDisappear(117, 740, 4d, -4d, -3, 3, -2, 2, smax: 75, smin: 25, opacityTimeFactor: 0.8);

			chart.ModernTrackAppear(740, 1038, 4d, 8d, 0.5, 2, 0.5, 1.5, endOpacity: 1000);
			chart.ModernTrackDisappear(740, 1038, 4d, 0d, -2, -0.5, -0.5, 0.5);

			chart.ModernTrackAppear(1038, 1703, 8d, 12d, -3, 3, -2, 2, endOpacity: 1000);
			chart.ModernTrackDisappear(1038, 1703, 4d, -4d, -3, 3, -2, 2, smax: 75, smin: 25, opacityTimeFactor: 0.8);

			chart.ModernTrackAppear(1703, 1936,  4d, 8d, 0.5, 2, 0.5, 1.5, endOpacity: 1000);
			chart.ModernTrackDisappear(1703, 1936, 4d, -2d, -2, -0.5, -1.5, -0.5);

			chart.ModernTrackAppear(1936, 3261, 8d, 12d, -3, 3, -2, 2, endOpacity: 1000);
			chart.ModernTrackDisappear(1936, 3261, 4d, -4d, -3, 3, -2, 2, smax: 75, smin: 25, opacityTimeFactor: 0.8);



			var builder = chart.JudgementLimit()
				.SetDisplayType(JudgementLimitDisplayType.Images)
				.SetImages("j4.png", "j3.png", "j2.png", "j1.png")
				.GetBuilder();

			builder.Limit(7, JudgementLimitWindowType.Normal);
			builder.Limit(88, JudgementLimitWindowType.Perfects);
			builder.Limit(341, JudgementLimitWindowType.NoMiss);
			builder.Limit(491, JudgementLimitWindowType.Perfects);
			builder.Limit(740, JudgementLimitWindowType.PurePerfect);
			builder.Limit(936, JudgementLimitWindowType.Perfects);
			builder.Limit(1038, JudgementLimitWindowType.NoMiss);
			builder.Limit(1118, JudgementLimitWindowType.Perfects);
			builder.Limit(1214, JudgementLimitWindowType.NoMiss);
			builder.Limit(1415, JudgementLimitWindowType.Perfects);
			builder.Limit(1585, JudgementLimitWindowType.NoMiss);
			builder.Limit(1657, JudgementLimitWindowType.Perfects);
			builder.Limit(1703, JudgementLimitWindowType.Normal);
			builder.Limit(1823, JudgementLimitWindowType.Perfects);
			builder.Limit(1887, JudgementLimitWindowType.NoMiss);
			builder.Limit(2018, JudgementLimitWindowType.Perfects);
			builder.Limit(2078, JudgementLimitWindowType.NoMiss);
			builder.Limit(2447, JudgementLimitWindowType.Perfects);
			builder.Limit(2611, JudgementLimitWindowType.PurePerfect);
			builder.Limit(2721, JudgementLimitWindowType.NoMiss);
			builder.Limit(2898, JudgementLimitWindowType.PurePerfect);
			builder.Limit(2990, JudgementLimitWindowType.Perfects);
			builder.Limit(3131, JudgementLimitWindowType.PurePerfect);
			builder.Limit(3260, JudgementLimitWindowType.Normal);


			builder.BuildDisplay(0, 1960, 100, 8);

			File.WriteAllText(@"G:\Adofai levels\BYD Reaches\level-eff-100Judgement.adofai", chart.ChartJson.ToJsonString());

			builder.BuildLimit();




			File.WriteAllText(@"G:\Adofai levels\BYD Reaches\level-eff-judgementlimit.adofai", chart.ChartJson.ToJsonString());
		}

	}
}
