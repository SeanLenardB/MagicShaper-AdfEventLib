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






			// First Part
			var sceneOne = factory.CreateScene();

			sceneOne.TileBegin = 0; sceneOne.TileEnd = 114;
			sceneOne.Elements.Add(sceneOne.CreateElement<MonoElement>().Use("bg1.png").AsBackground().WithAutofit(chart).WithFlashInOut());
			sceneOne.Elements.Add(sceneOne.CreateElement<MassElement>().Use(new()
			{
				"grass1.png", "grass2.png", "grass2.png", "grass2.png", "grass3.png"
			}).AsSpan(20, scaleMin: 200, scaleMax: 300).WithFloor(xmin: -20, xmax: 20, ymin: -8, ymax: -7).WithFlashInOut().WithDepth());
			sceneOne.Elements.Add(sceneOne.CreateElement<MassElement>().Use(new()
			{
				"cloud1.png", "cloud2.png", "cloud3.png", "cloud4.png", "cloud5.png"
			}).AsSpan(8, scaleMin: 200, scaleMax: 300).WithFloor(xmin: -20, xmax: 20, ymin: 6, ymax: 12).WithVariousOpacityFlashInOut());
			sceneOne.ApplyTo(chart);






			 

			File.WriteAllText(@"G:\Adofai levels\Next Life\level-vfx.adofai", chart.ChartJson.ToJsonString());
		}
	}
}
