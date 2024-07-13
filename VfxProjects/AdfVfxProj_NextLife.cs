using MagicShaper.AdfExtensions;
using MagicShaper.AdfExtensions.DecoScene;
using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
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
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\Next Life\level-base.adofai");

			DecoScene.DecoSceneFactory factory = new();






			// First Part
			var sceneOne = factory.CreateScene();

			sceneOne.TileBegin = 0; sceneOne.TileEnd = 114;
			sceneOne.Elements.Add(sceneOne.CreateElement<MonoElement>().Use("bg1.png").AsBackground().WithScale(230).WithParallaxOffset(0, -2).WithFlashInOut());
			sceneOne.Elements.Add(sceneOne.CreateElement<MassElement>().Use(new()
			{
				"grass1.png", "grass3.png"
			}).AsSpan(20, scaleMin: 60, scaleMax: 180).WithFloor(xmin: -8, xmax: 8, ymin: -3.5, ymax: -2.8).WithVaryingLayer());
			sceneOne.Elements.Add(sceneOne.CreateElement<MassElement>().Use(new()
			{
				"grass2.png"
			}).AsTileSpan(10, scaleMin: 200, scaleMax: 350).WithFloor(xmin: -8, xmax: 8, ymin: -3, ymax: -1.2).WithVaryingLayer());
			//sceneOne.Elements.Add(sceneOne.CreateElement<MassElement>().Use(new()
			//{
			//	"cloud1.png", "cloud2.png", "cloud3.png", "cloud4.png", "cloud5.png"
			//}).AsSpan(8, scaleMin: 100, scaleMax: 150).WithFloor(xmin: -20, xmax: 20, ymin: 4, ymax: 5).WithVariousOpacityFlashInOut());
			sceneOne.ApplyTo(chart);






			 

			File.WriteAllText(@"G:\Adofai levels\Next Life\level-vfx.adofai", chart.ChartJson.ToJsonString());
		}
	}
}
