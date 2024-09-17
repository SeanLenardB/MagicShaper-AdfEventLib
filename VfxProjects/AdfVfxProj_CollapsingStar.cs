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
	public class AdfVfxProj_CollapsingStar
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\CollapsingStar\CollapsingStar\level-loweffect.adofai");

			chart.SetupVisionLimit();
			chart.SetVisionLimitAutofit("banner.png", 0);

			DecoScene.DecoSceneFactory factory = new();

			var sceneVolcano = factory.CreateScene();

			sceneVolcano.Elements.Add(sceneVolcano.CreateElement<MonoElement>().Use("volcano.png").AsBackground()
				.WithAutofit(chart).FromFlash(20).ToFlash());

			sceneVolcano.Elements.Add(sceneVolcano.CreateElement<MassElement>().Use(new() { "volcano1.png", "volcano2.png", "volcano3.png", "volcano4.png" })
				.AsSpan(3, -200, 200, -120, -90, 800, 1200).WithVaryingDepth(5, 10)
				.FromVaryingLayer(20, 50, 90, 100, 95, 100, 225, 255).ToFlashOut());

			sceneVolcano.Elements.Add(sceneVolcano.CreateElement<MassElement>().Use(new()
			{
				"smoke1.png", "smoke2.png"
			}).AsTiled(5, 150, 250, -250, 250, -500, 0, scaleMin: 850, scaleMax: 1200)
				.WithMovement(40, 200, 250, 510, duration: 64d)
				.FromVaryingLayer(20, 50, rgbMin: 140, rgbMax: 255).ToFlashOut());

			sceneVolcano.Elements.Add(sceneVolcano.CreateElement<MassElement>().Use(new()
			{
				"shard1.png", "shard2.png", "shard3.png", "shard4.png", "shard5.png", "shard6.png", "shard7.png", "shard8.png"
			}).AsSpan(70, -300, 300, -400, 400, 30, 300)
			.WithMovement(-20, 20, 100, 150, -100, 100, 64d)
			.WithFlashingOnBeat(0.514, durationInterval: 4)
			.FromVaryingLayer(0, 75, rgbMin: 0, rgbMax: 0).ToFlashOut());

			sceneVolcano.ApplyTo(chart, 1, 235);

			chart.CameraTiltAndDiveTransition(1, 35, 250, 4, 8);
			chart.ModernTrackAppear(0, 235, 4d, 2d, ymin: 5, ymax: 10, endOpacity: 500, endScale: 90);
			chart.ModernTrackDisappear(0, 235, 4d, 1d, ymin: 2, ymax: 5, smin: 150);

			for (int i = 0; i < chart.ChartTiles.Count - 1; i++)
			{
				int flag = 0;
				foreach (var e in chart.ChartTiles[i].TileEvents)
				{
					if (e is AdfEventSetSpeed se)
					{
						flag = se.BpmMultiplier > 1 ? 1 : 2; break;
					}
				}

				if (flag > 0)
				{
					chart.ChartTiles[i].TileEvents.Add(new AdfEventRecolorTrack()
					{
						TrackColor = new("FFFFFF"),
						SecondaryTrackColor = new(flag == 1 ? "FF00000" : "0000FF"),
						TrackGlowIntensity = 0,
						TrackColorPulse = AdfTrackColorPulseType.Forward,
						TrackColorAnimDuration = .2d,
						TrackPulseLength = 15,
						TrackStyle = AdfTrackStyle.NeonLight,
						TrackColorType = AdfTrackColorType.Glow,
						AngleOffset = -114514
					});
				}
			}

			chart.CameraRotationPulseByTile(new() { 32, 34, 37, 39, 42, 44, 47, 49, 52, 55, 58, 60 },
				-5, 5, 220, 250, 2d);

			chart.CameraRotationPulseByBeats(62, 8d, 16,
				-8, 8, 200, 250, 16d);


			chart.MultipleTrack(235, 411, 10, -9, 3, "AAAAAA", 90, 200, 80, 80, AdfTrackStyle.NeonLight);
			chart.MultipleTrack(235, 411, 9, 8, 5, "FFFFFF", 80, 200, 50, 70, AdfTrackStyle.NeonLight);
			chart.MultipleTrack(235, 411, -1, -5, -3, "666666", 30, 200, -10, -30, AdfTrackStyle.NeonLight);
			chart.MultipleTrack(235, 411, 8, 1, 1, "999999", 50, 200, 50, 60, AdfTrackStyle.NeonLight);

			File.WriteAllText(@"G:\Adofai levels\CollapsingStar\CollapsingStar\level-effect.adofai", chart.ChartJson.ToJsonString());
		}
	}
}
