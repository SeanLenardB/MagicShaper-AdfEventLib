using MagicShaper.AdfExtensions;
using MagicShaper.AdfExtensions.DecoScene;
using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects
{
	internal class AdfVfxProj_JourneysEnd
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\JourneysEnd\level-loweffect.adofai");

			chart.SetupVisionLimit();
			chart.SetVisionLimitAutofit("banner.png", 0);

			DecoScene.DecoSceneFactory factory = new();

			var sceneCrystalCave = factory.CreateScene();
			sceneCrystalCave.Elements.Add(sceneCrystalCave.CreateElement<MonoElement>().Use("crystal.png")
				.AsBackground().WithAutofit(chart).FromFlash(50).ToFlash());






			sceneCrystalCave.ApplyTo(chart, 0, 968);





			File.WriteAllText(@"G:\Adofai levels\JourneysEnd\level-effect.adofai", chart.ChartJson.ToJsonString());
		}
	}
}
