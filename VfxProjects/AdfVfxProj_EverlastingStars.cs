using MagicShaper.AdfExtensions;
using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects
{
    internal class AdfVfxProj_EverlastingStars
    {
        public static void ProjMain()
        {
            AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\The Everlasting Star of Yearning\level-noeffect.adofai");

            chart.JudgementLimit()
                .SetImages("j4.png", "j3.png", "j2.png", "j1.png")
                .SetDisplayType(JudgementLimitDisplayType.Images)
                .GetBuilder()
                .Limit(0, JudgementLimitWindowType.Normal)
                .Limit(24, JudgementLimitWindowType.PurePerfect)
                .Limit(72, JudgementLimitWindowType.Perfects)
                .Limit(695, JudgementLimitWindowType.NoMiss)
                .Limit(735, JudgementLimitWindowType.Perfects)
                .Limit(791, JudgementLimitWindowType.NoMiss)
                .BuildDisplay(0, 300, 150)
                .BuildLimit();


            File.WriteAllText(@"G:\Adofai levels\The Everlasting Star of Yearning\level-effect.adofai", chart.ChartJson.ToJsonString());

        }
    }
}
