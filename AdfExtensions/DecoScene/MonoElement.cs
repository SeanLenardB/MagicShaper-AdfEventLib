using MagicShaper.AdofaiCore.AdfClass;
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



		public MonoElement AsForeground(int depth = -90, bool lockRotation = true, bool lockScale = true)
		{
			OnSceneBegin.Add(new AdfEventAddDecoration()
			{
				Floor = 0,
				DecorationImage = Images[0],
				Parallax = new(100, 100),
				Depth = depth,
				LockRotation = lockRotation,
				LockScale = true,
				Tag = Tag(),
				Opacity = 0
			});

			return this;
		}
		
		public MonoElement AsBackground(int depth = 90, bool lockRotation = true, bool lockScale = true)
		{
			OnSceneBegin.Add(new AdfEventAddDecoration()
			{
				Floor = 0,
				DecorationImage = Images[0],
				Parallax = new(100, 100),
				Depth = depth,
				LockRotation = lockRotation,
				LockScale = lockScale,
				Tag = Tag(),
				Opacity = 0
			});

			return this;
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

		public MonoElement WithScale(double scale = 100)
		{
			OnSceneBegin.Add(new AdfEventMoveDecorations()
			{
				Tag = Tag(),
				Scale = new(scale),
				Duration = 0d
			});

			return this;
		}

		public MonoElement WithPivotOffset(double x = 0, double y = 0)
		{
			OnSceneBegin.Add(new AdfEventMoveDecorations()
			{
				Tag = Tag(),
				PivotOffset = new(x, y),
				Duration = 0d
			});

			return this;
		}

		public MonoElement WithParallaxOffset(double x = 0, double y = 0)
		{
			OnSceneBegin.Add(new AdfEventMoveDecorations()
			{
				Tag = Tag(),
				ParallaxOffset = new(x, y),
				Duration = 0d
			});

			return this;
		}

		public MonoElement WithParallax(double x = 0, double y = 0)
		{
			OnSceneBegin.Add(new AdfEventMoveDecorations()
			{
				Tag = Tag(),
				Parallax = new(x, y),
				Duration = 0d
			});

			return this;
		}

		public MonoElement WithColor(double color = 255)
		{
			OnSceneBegin.Add(new AdfEventMoveDecorations()
			{
				Tag = Tag(),
				Color = new("FFFFFF") { R = (byte)color, G = (byte)color, B = (byte)color },
				Duration = 0d
			});

			return this;
		}




		public MonoElement FromFlash(double opacity = 100)
		{
			OnSceneBegin.Add(new AdfEventMoveDecorations()
			{
				Tag = Tag(),
				Duration = 0d,
				Opacity = opacity,
				AngleOffset = -0.001
			});

			return this;
		}






		public MonoElement ToFlash()
		{
			OnSceneEnd.Add(new AdfEventMoveDecorations()
			{
				Tag = Tag(),
				Duration = 0d,
				Opacity = 0,
			});

			return this;
		}


	}
}
