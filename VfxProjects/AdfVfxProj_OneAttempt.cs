using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects
{
	internal class AdfVfxProj_OneAttempt
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\OneAttempt\level-noeff.adofai");


			File.WriteAllText(@"G:\Adofai levels\OneAttempt\level-eff.adofai", chart.ChartJson.ToJsonString());
		}

	}
}
