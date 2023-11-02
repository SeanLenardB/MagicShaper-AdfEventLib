using MagicShaper.AdfExtensions;
using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects
{
	internal class AdfVfxProj_IGotNoTime
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.ParseChart(File.ReadAllText(@"G:\Adofai levels\Five Nights at Freddy's\level.adofai"));
            // vfx
            Console.WriteLine(chart.GetEvents());
            foreach (var i in new List<int>() { 0, 73, 146, 219 })
			{
				chart.TrackExplosion(new()
				{
					i+21, i+29, i+39, i+48, i+58, i+66, i+76, i+84
				});
			}







			File.WriteAllText(@"G:\Adofai levels\Five Nights at Freddy's\level vfx.adofai", chart.ChartJson.ToJsonString());




		}


	}
}
