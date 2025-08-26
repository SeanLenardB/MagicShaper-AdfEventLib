using MagicShaper.AdfExtensions.DecoScene;
using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects
{
	internal class AdfVfxProj_OurLife
	{
		public static void ProjMain()
		{
			MagicShape();
		}

		public static void VfxMain()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\our life\level-base.adofai");
			DecoScene.DecoSceneFactory factory = new();











			File.WriteAllText(@"G:\Adofai levels\our life\level-vfx.adofai", chart.ChartJson.ToJsonString());

		}

		public static void MagicShape()
		{

			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\our life\level-noeffect.adofai");











			File.WriteAllText(@"G:\Adofai levels\our life\level-noeffect-magic.adofai", chart.ChartJson.ToJsonString());

		}
	}
}
