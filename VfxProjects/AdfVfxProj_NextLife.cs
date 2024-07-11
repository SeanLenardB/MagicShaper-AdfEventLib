using MagicShaper.AdfExtensions.DecoScene;
using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.VfxProjects
{
	internal class AdfVfxProj_NextLife
	{
		internal static void ProjMain()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\Next Life\level-track.adofai");

			DecoScene.DecoSceneFactory factory = new();

			var scene = factory.CreateScene();

			scene.TileBegin = 0; scene.TileEnd = 114;
			scene.Elements.Add(new MonoElement().AsBackground(chart, "bg1.png"));

			scene.ApplyTo(chart);

			File.WriteAllText(@"G:\Adofai levels\Next Life\level-vfx.adofai", chart.ChartJson.ToJsonString());
		}
	}
}
