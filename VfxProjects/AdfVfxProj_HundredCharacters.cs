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
	public class AdfVfxProj_HundredCharacters
	{
		public static void ProjMain()
		{
			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\Tsubasa\level loweff.adofai");

			DecoScene.DecoSceneFactory factory = new();

			var sceneForest = factory.CreateScene();

			sceneForest.Elements.Add(sceneForest.CreateElement<MonoElement>().Use("forest.png")
				.AsBackground().WithAutofit(chart)
				.FromFlash(80).ToFlashOut());



			var sceneGrass = factory.CreateScene();
			sceneGrass.Elements.Add(sceneGrass.CreateElement<MassElement>().Use(new()
			{
				"grass1.png", "grass3.png"
			}).AsSpan(20, scaleMin: 150, scaleMax: 280)
				.WithFloor(xmin: -16, xmax: 16, ymin: -6.5, ymax: -5)
				.FromVaryingLayer().ToFlashOut());
			sceneGrass.Elements.Add(sceneGrass.CreateElement<MassElement>().Use(new()
			{
				"grass2.png"
			}).AsTileSpan(3, scaleMin: 150, scaleMax: 350, tileXMin: 30, tileXMax: 50)
				.WithFloor(xmin: -16, xmax: 16, ymin: -6, ymax: -4)
				.FromVaryingLayer().ToFlashOut());


			var sceneTrees = factory.CreateScene();

			sceneTrees.Elements.Add(sceneTrees.CreateElement<MassElement>().Use(new()
			{
				"tree1.png", "tree2.png", "tree3.png", "tree4.png", "tree5.png"
			}).AsSpan(10, scaleMin: 720, scaleMax: 900)
			.WithFloor(xmin: -80, xmax: 80, ymin: -10, ymax: -5)
			.FromVaryingLayer().ToFlashOut());

			sceneTrees.ApplyTo(chart, 0, 88);
			sceneForest.ApplyTo(chart, 0, 88);
			sceneGrass.ApplyTo(chart, 0, 88);


			for (int i = 1; i < 312; i++)
			{
				int flag = 0;
				foreach (var e in chart.ChartTiles[i].TileEvents)
				{
					if (e is AdfEventSetSpeed se)
					{
						if (Math.Abs(chart.GetTileBpmAt(i) / chart.GetTileBpmAt(i - 1) - 1) < 0.1) { break; }
						flag = chart.GetTileBpmAt(i) / chart.GetTileBpmAt(i - 1) > 1 ? 1 : 2; break;
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
			


			Random random = new();
			for (int i = 191; i < 312; i++)
			{
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					Duration = chart.GetTileBpmAt(i) / 960 * 4d,
					Opacity = 0,
					StartTile = new(0, AdfTileReferenceType.ThisTile),
					EndTile = new(0, AdfTileReferenceType.ThisTile)
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
                    PositionOffset = new(random.NextDouble() * 10 - 5, random.NextDouble() * 2),
					RotationOffset = random.NextDouble() * 90 - 45,
					Opacity = 100,
					Duration = 0,
					StartTile = new(0, AdfTileReferenceType.ThisTile),
                    EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = chart.GetTileBpmAt(i) / 960 * (12 * 180)
                });
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
					Duration = chart.GetTileBpmAt(i) / 960 * (random.NextDouble() * 12d + 4d),
					RotationOffset = 0,
					Opacity = 50,
					Ease = AdfEaseType.OutBack,
					PositionOffset = new(0, 0),
                    StartTile = new(0, AdfTileReferenceType.ThisTile),
                    EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = chart.GetTileBpmAt(i) / 960 * (12 * 180 + 0.00001)
                });
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveTrack()
				{
                    Duration = chart.GetTileBpmAt(i) / 960 * 4d,
					Ease = AdfEaseType.OutQuad,
					Opacity = 0,
					StartTile = new(0, AdfTileReferenceType.ThisTile),
                    EndTile = new(0, AdfTileReferenceType.ThisTile),
					AngleOffset = chart.GetTileBpmAt(i) / 960 * (30 * 180)
                });
			}

			chart.MultipleTrack(191, 312, 5, 2, "FFFFFFFF", 90, 150, 80, 90);
			chart.MultipleTrack(191, 312, 1, -2, "FFFFFFFF", 60, 150, 50, 70);
			chart.MultipleTrack(191, 312, -6, -1, "FFFFFFFF", 80, 150, 30, 50);
			chart.MultipleTrack(191, 312, 2, 3, "FFFFFFFF", 50, 150, 60, 20);

			File.WriteAllText(@"G:\Adofai levels\Tsubasa\level effect.adofai", chart.ChartJson.ToString());
		}
	}
}
