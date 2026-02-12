using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicShaper.AdfExtensions;
using MagicShaper.AdofaiCore.AdfClass;

namespace MagicShaper.VfxProjects
{
    public static class AdfVfxProj_ValentineChinco
    {
        public static void ProjMain()
        {
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\Valentine Chinco\level-base.adofai");

            chart.AddVideoFramesToChart("video dont include.mp4", 125, 128d, 0.5d, "video", 1.265);

			File.WriteAllText(@"G:\Adofai levels\Valentine Chinco\level-fulleffect.adofai", chart.ChartJson.ToJsonString());
        }
    }
}
