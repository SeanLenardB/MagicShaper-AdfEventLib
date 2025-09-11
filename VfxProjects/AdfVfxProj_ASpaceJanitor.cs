//using MagicShaper.AdfExtensions;
//using MagicShaper.AdfExtensions.DecoScene;
//using MagicShaper.AdofaiCore.AdfClass;
//using MagicShaper.AdofaiCore.AdfEvents;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MagicShaper.VfxProjects
//{
//	public static class AdfVfxProj_ASpaceJanitor
//	{
//		public static void ProjMain()
//		{
//			VfxMain();
//		}

//		private static void WorldMachine(this AdfChart chart, int tile, string eng, string chn, double duration)
//		{
//			Random random = new();
//			string gid = random.Next(1000000).ToString().PadLeft(6, '0');




//			double standardBpm = chart.GetTileBpmAt(0);

//#pragma warning disable CA1416 // Validate platform compatibility
//			TextRenderExtension.Convert(eng,
//				chart.FileLocation?.Parent?.FullName + $"\\manual-worldmachine-{tile}-main.png",
//				"Bahnschrift");
//			TextRenderExtension.Convert(chn,
//				chart.FileLocation?.Parent?.FullName + $"\\manual-worldmachine-{tile}-translation.png",
//				"Bahnschrift");
//#pragma warning restore CA1416 // Validate platform compatibility






//			chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
//			{
//				Duration = 0d,
//				DecorationImage = $"manual-worldmachine-{tile}-main.png",
//				Tag = $"manual-worldmachine-speech-main",
//			});
//			chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
//			{
//				Duration = 0d,
//				DecorationImage = $"manual-worldmachine-{tile}-translation.png",
//				Tag = $"manual-worldmachine-speech-translation",
//			});

//			chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
//			{
//				Duration = 1d * chart.GetTileBpmAt(tile) / standardBpm,
//				Tag = $"manual-worldmachine-darkenmask",
//				Opacity = 60d,
//			});
//			chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
//			{
//				Duration = 1d * chart.GetTileBpmAt(tile) / standardBpm,
//				Tag = $"manual-worldmachine-speech",
//				Opacity = 100d,
//			});


//			chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
//			{
//				Duration = 1d * chart.GetTileBpmAt(tile) / standardBpm,
//				Tag = $"manual-worldmachine-speech manual-worldmachine-darkenmask",
//				Opacity = 0d,
//				AngleOffset = 180d * duration * chart.GetTileBpmAt(tile) / standardBpm,
//			});



//		}

//		private static void Narrator(this AdfChart chart, int tile, string eng, string chn, double duration)
//		{
//			Random random = new();
//			string gid = random.Next(1000000).ToString().PadLeft(6, '0');




//			double standardBpm = chart.GetTileBpmAt(0);

//#pragma warning disable CA1416 // Validate platform compatibility
//			TextRenderExtension.Convert(eng,
//				chart.FileLocation?.Parent?.FullName + $"\\manual-niko-{tile}-main.png",
//				"Bahnschrift");
//			TextRenderExtension.Convert(chn,
//				chart.FileLocation?.Parent?.FullName + $"\\manual-niko-{tile}-translation.png",
//				"方正楷体_GBK");
//#pragma warning restore CA1416 // Validate platform compatibility






//			chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
//			{
//				Duration = 0d,
//				DecorationImage = $"manual-niko-{tile}-main.png",
//				Tag = $"manual-niko-speech-main",
//			});
//			chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
//			{
//				Duration = 0d,
//				DecorationImage = $"manual-niko-{tile}-translation.png",
//				Tag = $"manual-niko-speech-translation",
//			});

//			chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
//			{
//				Duration = 1d * chart.GetTileBpmAt(tile) / standardBpm,
//				Tag = $"manual-niko-darkenmask",
//				Opacity = 60d,
//			});
//			chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
//			{
//				Duration = 1d * chart.GetTileBpmAt(tile) / standardBpm,
//				Tag = $"manual-niko-speech",
//				Opacity = 100d,
//			});


//			chart.ChartTiles[tile].TileEvents.Add(new AdfEventMoveDecorations()
//			{
//				Duration = 1d * chart.GetTileBpmAt(tile) / standardBpm,
//				Tag = $"manual-niko-speech manual-niko-darkenmask",
//				Opacity = 0d,
//				AngleOffset = 180d * duration * chart.GetTileBpmAt(tile) / standardBpm,
//			});



//		}


//		private static void VfxMain()
//		{
//			AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\A Space Janitor\level-base.adofai");
//			DecoScene.DecoSceneFactory factory = new();



//			chart.AddDecorationToChart(new()
//			{
//				Tag = $"manual-worldmachine manual-worldmachine-speech manual-worldmachine-speech-main",
//				Depth = -19500,
//				LockRotation = true,
//				LockScale = true,
//				Position = new(0, 1.5),
//				Scale = new(100 * 2),
//				RelativeTo = AdfMoveDecorationRelativeToType.Camera,
//				BlendMode = AdfBlendMode.Screen,
//				Opacity = 0d,
//				Color = new("FFFFFFFF")
//			});
//			chart.AddDecorationToChart(new()
//			{
//				Tag = $"manual-worldmachine manual-worldmachine-speech manual-worldmachine-speech-translation",
//				Depth = -19500,
//				LockRotation = true,
//				LockScale = true,
//				Position = new(0, 2.5),
//				Scale = new(61.8 * 1.5),
//				RelativeTo = AdfMoveDecorationRelativeToType.Camera,
//				BlendMode = AdfBlendMode.Screen,
//				Opacity = 0d,
//				Color = new("AAAAAAFF")
//			});
//			chart.AddDecorationToChart(new()
//			{
//				Tag = $"manual-niko manual-niko-speech manual-niko-speech-main",
//				Depth = -114,
//				LockRotation = true,
//				LockScale = true,
//				Position = new(0, 8),
//				Scale = new(100),
//				RelativeTo = AdfMoveDecorationRelativeToType.Camera,
//				BlendMode = AdfBlendMode.Screen,
//				Opacity = 0d,
//				Color = new("FFFFFFFF")
//			});
//			chart.AddDecorationToChart(new()
//			{
//				Tag = $"manual-niko manual-niko-speech manual-niko-speech-translation",
//				Depth = -114,
//				LockRotation = true,
//				LockScale = true,
//				Position = new(0, 8.5),
//				Scale = new(71.8),
//				RelativeTo = AdfMoveDecorationRelativeToType.Camera,
//				BlendMode = AdfBlendMode.Screen,
//				Opacity = 0d,
//				Color = new("AAAAAAFF")
//			});

















//			var sceneSpaceStationOutside = factory.CreateScene();

//			sceneSpaceStationOutside.Elements.Add(sceneSpaceStationOutside.CreateElement<MonoElement>()
//				.Use("space.png").AsBackground(1145).WithAutofit(chart)
//				.FromFlash().ToFlashOut()
//				.FromWithMask(scale: 5000, depthMin: 1145, depthMax: 1145, duration: 24d, previewBeats: 7d,
//					rotation: 25, drotation: -5, x: 0, dx: -100));

//			sceneSpaceStationOutside.Elements.Add(sceneSpaceStationOutside.CreateElement<MassElement>()
//				.Use(["space8.png"])
//				.AsSpanParallax(1, 2, 2, -2, -2, scaleMin: 350, scaleMax: 350)
//				.FromVaryingLayer(rotationMin: 10, rotationMax: 10, opacityMin: 100, opacityMax: 100, rgbMin: 255, rgbMax: 255, parallaxXMin: 95, parallaxYMin: 98)
//				.ToFlashOut()
//				.FromWithMask(scale: 5000, depthMin: 50, depthMax: 60, duration: 24d, previewBeats: 7d,
//					rotation: 25, drotation: -5, x: 0, dx: -100));

//			sceneSpaceStationOutside.ApplyTo(chart, 5, 183);

//			chart.WorldMachine(5, "bad narrator / aephyn / hotcakeinabox / Wyntr. / Systile / z u y a", "Artist", 14d);
//			chart.WorldMachine(39, "Sean Lenard B. & NanoCRoTor", "Track", 6d);
//			chart.WorldMachine(55, "quartrond", "Visual", 8d);

			
//			chart.Narrator(127, "Visuals based on the story from \"STORYBOOK: Chapter 2\"", "特效改编自歌曲专辑中的同名故事", 16d);

//			chart.ModernTrackAppear(183, 238, 8d, 10d, -0.5, 0.5, 0.2, 0.5, -45, 45, 75, 95, 50);
//			chart.ModernTrackDisappear(183, 238, 8d,-12d, -0.2, 0.2, -0.5, 0.5, smax: 85, angleOffsetVariationProportion: 50);



//			var sceneInStation = factory.CreateScene();

//			sceneInStation.Elements.Add(sceneInStation.CreateElement<MonoElement>()
//				.Use("station.png").AsBackground(1155).WithAutofit(chart)
//				.FromFlash().ToFlashOut());

//			sceneInStation.ApplyTo(chart, 183, 320);

//			chart.Narrator(183,
//				"When humans learned they were not alone in 2200, they constructed the Aeris-Nox Terminal, an outpost where all species could meet.",
//				"当人类在2200年发现自己并不孤单时，他们建造了“Aeris-Nox”，这是一个所有物种都可以相遇的前哨站。", 30d);

//			var sceneInStationJanitor = factory.CreateScene();

//			//sceneInStationJanitor.Elements.Add(sceneInStationJanitor.CreateElement<MonoElement>()
//			//	.Use("janitor.png").AsBackground()
//			//	.WithScale(200)
//			//	.WithParallax(90, 90).WithParallaxOffset(-8, -6).WithMovement(4d, 0, 2)
//			//	.FromFade(2d, 100).ToFlash());
//			sceneInStationJanitor.Elements.Add(sceneInStationJanitor.CreateElement<MonoElement>()
//				.Use("mop.png").AsBackground(89)
//				.WithScale(200)
//				.WithParallax(90, 90).WithParallaxOffset(-5, -4).WithMovement(4d, 0, 2)
//				.FromFade(2d, 100).ToFlashOut());

//			sceneInStationJanitor.ApplyTo(chart, 212, 320);

//			chart.Narrator(212,
//				"Out of all the jobs that a person can have on a space station hub, I, Arix, am the janitor.",
//				"在太空站枢纽上所有可能的职业中，我，Arix，是一名清洁工。", 30d);

//			chart.Narrator(238,
//				"In all my years of cleaning, never had I heard the same thing come up more than once in conversation.",
//				"在我多年的清洁工作中，从未听过同样的事情在谈话中被提起超过一次。", 30d);

//			chart.Narrator(272,
//				"The name \"The Order of the Cipher\" gradually became more prominent, but also more feared as time went on.",
//				"随着时间的推移，“The Order of the Cipher”这个名字逐渐变得更加显赫，同时也更加令人畏惧。", 30d);

//			chart.Narrator(320,
//				"An organization like that wouldn't dare to attack this large and well-guarded Aeris-Nox Terminal, right?",
//				"像那样的组织不可能胆敢袭击这座规模庞大、戒备森严的前哨站吧?", 30d);









//			File.WriteAllText(@"G:\Adofai levels\A Space Janitor\level-vfx.adofai", chart.ChartJson.ToJsonString());
//		}
//	}
//}
