using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions.DecoScene
{
	internal class MonoElement : SceneElementBase
	{
		public string ImageName { get; set; } = "";

		public AdfPosition Parallax { get; set; } = new(0, 0);

		public AdfScale Scale { get; set; } = new(100);

        public int Depth { get; set; } = 0;

		public bool LockRotation { get; set; } = false;

		public bool LockScale { get; set; } = false;

		public double Opacity { get; set; } = 100;

		public double InDuration { get; set; } = 0d;
		public double OutDuration { get; set; } = 0d;







        public MonoElement AsBackground(AdfChart chart, string imageName)
		{
			this.ImageName = imageName;
			this.Parallax = new(100, 100);
			this.Depth = DecoSceneConstants.MonoElementAsBackgroundDepth;
			this.LockRotation = true;
			this.LockScale = true;
			
			if (chart is not null)
			{
				Mat mat = Cv2.ImRead(chart.FileLocation?.Parent?.FullName + $"\\{imageName}");
				double defaultCameraZoom = chart.ChartJson["settings"]!["zoom"]!.GetValue<double>();

				double widthMultiplier = (double)ExtensionSharedConstants.CanvasWidth / mat.Width * defaultCameraZoom / 100d;
				double heightMultiplier = (double)ExtensionSharedConstants.CanvasHeight / mat.Height * defaultCameraZoom / 100d;

				double scale = 100d * Math.Max(widthMultiplier, heightMultiplier);

				this.Scale = new(scale);
			}

			return this;
		}






		public override List<IAdfEvent> OnChartBegin()
		{
			return new()
			{
				new AdfEventAddDecoration()
				{
					LockRotation = this.LockRotation,
					LockScale = this.LockScale,
					Tag = this.Tag(),
					Parallax = this.Parallax,
					Depth = this.Depth,
					Scale = this.Scale,
					Opacity = 0,
					DecorationImage = this.ImageName
				}
			};
		}

		public override List<IAdfEvent> OnSceneBegin()
		{
			return new()
			{
				new AdfEventMoveDecorations()
				{
					Tag = this.Tag(),
					Opacity = this.Opacity,
					Duration = InDuration,
				}
			};
		}

		public override List<IAdfEvent> OnSceneEnd()
		{
			return new()
			{
				new AdfEventMoveDecorations()
				{
					Tag = this.Tag(),
					Opacity = 0,
					Duration = OutDuration,
				}
			};
		}
	}
}
