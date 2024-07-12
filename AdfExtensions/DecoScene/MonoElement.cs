﻿using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions.DecoScene
{
	internal class MonoElement : SceneElementBase
	{
		public MonoElement Use(string image)
		{
			Images = new() { image };

			return this;
		}



		public MonoElement AsBackground()
		{
			OnSceneBegin.Add(new AdfEventAddDecoration()
			{
				DecorationImage = Images[0],
				Parallax = new(100, 100),
				Depth = 90,
				LockRotation = true,
				LockScale = true,
				Tag = Tag(),
				Opacity = 0
			});

			return this;
		}



		public MonoElement WithFlashIn()
		{
			OnSceneBegin.Add(new AdfEventMoveDecorations()
			{
				Tag = Tag(),
				Duration = 0d,
				Opacity = 100,
			});

			return this;
		}

		public MonoElement WithFlashOut()
		{
			OnSceneEnd.Add(new AdfEventMoveDecorations()
			{
				Tag = Tag(),
				Duration = 0d,
				Opacity = 0,
			});

			return this;
		}

		public MonoElement WithFlashInOut()
		{
			return WithFlashIn().WithFlashOut();
		}

		public MonoElement WithAutofit(AdfChart chart)
		{
			EnsureImages();

			var image = Images[0];

			Mat mat = Cv2.ImRead(chart.FileLocation?.Parent?.FullName + $"\\{image}");
			double defaultCameraZoom = chart.ChartJson["settings"]!["zoom"]!.GetValue<double>();

			double widthMultiplier = (double)ExtensionSharedConstants.CanvasWidth / mat.Width * defaultCameraZoom / 100d;
			double heightMultiplier = (double)ExtensionSharedConstants.CanvasHeight / mat.Height * defaultCameraZoom / 100d;

			double scale = 100d * Math.Max(widthMultiplier, heightMultiplier);

			OnChartBegin.Add(new AdfEventMoveDecorations()
			{
				Tag = Tag(),
				Scale = new(scale),
				Duration = 0d
			});

			return this;
		}

		




	}
}
