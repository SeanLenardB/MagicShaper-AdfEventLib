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
	public static class AdfVfxProj_Drowning
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\Drowning\level-base.adofai");
			DecoScene.DecoSceneFactory factory = new();

			var sceneSpaceStationOutside = factory.CreateScene();
			sceneSpaceStationOutside.Elements.Add(sceneSpaceStationOutside.CreateElement<MonoElement>()
				.Use("space.png").AsBackground(85).WithScale(500).WithParallax(98, 98)
				.FromFlash().ToFlashOut());
			sceneSpaceStationOutside.Elements.Add(sceneSpaceStationOutside.CreateElement<MassElement>()
				.Use(["space8.png"])
				.AsSpanParallax(1, 2, 2, -2, -2, scaleMin: 350, scaleMax: 350)
				.FromVaryingLayer(rotationMin: 10, rotationMax: 10, opacityMin: 100, opacityMax: 100, 
					rgbMin: 255, rgbMax: 255, parallaxXMin: 95, parallaxYMin: 98, depthMin: 82, depthMax: 82)
				.ToFlashOut());
			sceneSpaceStationOutside.FromWithMask(scale: 6000, depthMin: 81, depthMax: 85, duration: 2d, previewBeats: 0.5d, rotation: 25, drotation: -45, x: 0, dx: -120);

			sceneSpaceStationOutside.ApplyTo(chart, 8, 14);


			var sceneCosmos = factory.CreateScene();
			sceneCosmos.Elements.Add(sceneCosmos.CreateElement<MonoElement>().Use("space.png")
				.WithAutofit(chart).AsBackground(80).FromFlash(40).ToFlashOut());
			sceneCosmos.Elements.Add(sceneCosmos.CreateElement<MassElement>().Use(new()
			{
				"nebula1.png",
				"nebula3.png",
				"nebula4.png",
				"nebula5.png",
				"nebula6.png"
			}).AsSpanParallax(15, -30, 40, -40, 60, 650, 1400, lockRotation: false)
			.FromVaryingLayer(10, 50, 95, 98, 98, 99.5, 
				180, 255, -5, 5, 72, 78)
			.ToFlashOut());
			sceneCosmos.Elements.Add(sceneCosmos.CreateElement<MonoElement>().Use("dim.jpg")
				.WithAutofit(chart).AsBackground(71).FromFlash(50).ToFlashOut());
			sceneCosmos.FromWithMask(scale: 6000, depthMin: 71, depthMax: 80, duration: 32d, previewBeats: 12d, rotation: 25, drotation: -5, x: 0, dx: -120);

			sceneCosmos.ApplyTo(chart, 12, 1000); //tbd




			chart.ModernTrackAppear(12, 192, 4d, 7d, -1, 1, -0.5, -0.2);
			chart.ModernTrackDisappear(12, 192, 4d, -4d, -1, 1, -0.5, -0.2);





#pragma warning disable CA1416 // Validate platform compatibility
			chart.LyricWithTranslation("lyric.txt");
#pragma warning restore CA1416 // Validate platform compatibility





			File.WriteAllText(@"G:\Adofai levels\Drowning\level-vfx.adofai", chart.ChartJson.ToString());
		}
	}
} 