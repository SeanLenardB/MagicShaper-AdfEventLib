using MagicShaper.AdfExtensions.DecoScene;
using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects
{
	public class AdfVfxProj_CollapsingStar
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\CollapsingStar\CollapsingStar\level-loweffect.adofai");

			DecoScene.DecoSceneFactory factory = new();

			var sceneVolcano = factory.CreateScene();

			sceneVolcano.Elements.Add(sceneVolcano.CreateElement<MonoElement>().Use("volcano.png").AsBackground().WithAutofit(chart).FromFlash().ToFlash());

			sceneVolcano.Elements.Add(sceneVolcano.CreateElement<MassElement>().Use(new() { "volcano1.png", "volcano2.png", "volcano3.png" })
				.AsSpan(4, -100, 100, -120, -90, 800, 1200).WithVaryingDepth(-5, 5)
				.FromVaryingLayer(100, 100, 50, 100, 95, 100, 225, 255).ToFlashOut());

			sceneVolcano.ApplyTo(chart, 0, 235);

			File.WriteAllText(@"G:\Adofai levels\CollapsingStar\CollapsingStar\level-effect.adofai", chart.ChartJson.ToJsonString());
		}
	}
}
