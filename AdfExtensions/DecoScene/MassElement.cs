using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions.DecoScene
{
	internal class MassElement : SceneElementBase
	{

		private string RandomImage()
		{
			var random = new Random();
			return Images[random.Next(Images.Count)];
		}





		public MassElement Use(List<string> images)
		{
			Images = images;

			return this;
		}



		public MassElement AsSpan(int amount, double xmin = -50, double xmax = 50, double ymin = -5, double ymax = 5,
			double scaleMin = 80, double scaleMax = 120)
		{
			Random random = new();

			for (int i = 0; i < amount; i++)
			{
				OnSceneBegin.Add(new AdfEventAddDecoration()
				{
					Tag = Tag() + Tag(i),
					DecorationImage = RandomImage(),
					Position = new(random.NextDouble() * (xmax - xmin) + xmin, random.NextDouble() * (ymax - ymin) + ymin),
					Scale = new(random.NextDouble() * (scaleMax - scaleMin) + scaleMin),
					Opacity = 0,
				});
			}

			_totalAmount = amount;

			return this;
		}



		private int _totalAmount = 0;

		public MassElement WithFloor(double xmin = -10, double xmax = 10, double ymin = -5, double ymax = -3, 
			double parallaxXMin = 85, double parallaxXMax = 95, double parallaxYMin = 95, double parallaxYMax = 98)
		{
			Random random = new();

			for (int i = 0; i < _totalAmount; i++)
			{
				OnSceneBegin.Add(new AdfEventMoveDecorations()
				{
					Tag = Tag(i),
					Parallax = new(random.NextDouble() * (parallaxXMax - parallaxXMin) + parallaxXMin, random.NextDouble() * (parallaxYMax - parallaxYMin) + parallaxYMin),
					ParallaxOffset = new(random.NextDouble() * (xmax - xmin) + xmin, random.NextDouble() * (ymax - ymin) + ymin),
					Duration = 0d,
				});
			}

			return this;
		}

		public MassElement WithDepth(int depth = -80)
		{
			OnSceneBegin.Add(new AdfEventMoveDecorations() {
				Tag = Tag(),
				Duration = 0d,
				Depth = depth,
			});

			return this;
		}

		public MassElement WithFlashIn()
		{
			OnSceneBegin.Add(new AdfEventMoveDecorations()
			{
				Tag = Tag(),
				Duration = 0d,
				Opacity = 100,
			});

			return this;
		}

		public MassElement WithFlashOut()
		{
			OnSceneEnd.Add(new AdfEventMoveDecorations()
			{
				Tag = Tag(),
				Duration = 0d,
				Opacity = 0,
			});

			return this;
		}

		public MassElement WithFlashInOut()
		{
			return WithFlashIn().WithFlashOut();
		}

		public MassElement WithVariousOpacityFlashInOut()
		{
			Random random = new();

			for (int i = 0; i < _totalAmount; i++)
			{
				OnSceneBegin.Add(new AdfEventMoveDecorations()
				{
					Tag = Tag(i),
					Duration = 0d,
					Opacity = random.NextDouble() * 100
				});
			}

			WithFlashOut();

			return this;
		}
	}
}
