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




		public MassElement AsTiled(int amount = 10, int tileX = 114, int tileY = 51,
			double startXMin = -50, double startXMax = 0, double startYMin = -100, double startYMax = 0,
			double scaleMin = 80, double scaleMax = 120)
		{
			Random random = new();

			for (int i = 0; i < amount; i++)
			{
				var scale = random.NextDouble() * (scaleMax - scaleMin) + scaleMin;

				OnSceneBegin.Add(new AdfEventAddDecoration()
				{
					Floor = 0,
					DecorationImage = Images[0],
					Tag = Tag() + Tag(i),
					Opacity = 0,
					Depth = 30,
					Parallax = new(95, 95),
					Tile = new(tileX, tileY),
					Scale = new(tileX * scale, tileY * scale),
					Position = new(random.NextDouble() * (startXMax - startXMin) + startXMin, random.NextDouble() * (startYMax - startYMin) + startYMin)
				});
			}

			_totalAmount = amount;

			return this;
		}

		public MassElement AsSpan(int amount = 10, double xmin = -50, double xmax = 50, double ymin = -5, double ymax = 5,
			double scaleMin = 80, double scaleMax = 120)
		{
			Random random = new();

			for (int i = 0; i < amount; i++)
			{
				OnSceneBegin.Add(new AdfEventAddDecoration()
				{
					Floor = 0,
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

		/// <summary>
		/// Make sure you call <see cref="FromVaryingLayer(double, double, double, double, double, double, double, double, double, double, int, int)"/> or such
		/// so these images don't stuck at 100% parallax
		/// </summary>
		public MassElement AsSpanParallax(int amount = 10, double xmin = -50, double xmax = 50, double ymin = -5, double ymax = 5,
			double scaleMin = 80, double scaleMax = 120)
		{
			Random random = new();

			for (int i = 0; i < amount; i++)
			{
				OnSceneBegin.Add(new AdfEventAddDecoration()
				{
					Floor = 0,
					Tag = Tag() + Tag(i),
					DecorationImage = RandomImage(),
					Parallax = new(100, 100),
					ParallaxOffset = new(random.NextDouble() * (xmax - xmin) + xmin, random.NextDouble() * (ymax - ymin) + ymin),
					Scale = new(random.NextDouble() * (scaleMax - scaleMin) + scaleMin),
					Opacity = 0,

				});
			}

			_totalAmount = amount;

			return this;
		}

		public MassElement AsTileSpan(int amount = 10, double xmin = -50, double xmax = 50, double ymin = -5, double ymax =5,
			double scaleMin = 80, double scaleMax = 120,
			int tileXMin = 5, int tileXMax = 10, int tileYMin = 1, int tileYMax = 2)
		{
			Random random = new();

			for (int i = 0; i < amount; i++)
			{
				var scale = random.NextDouble() * (scaleMax - scaleMin) + scaleMin;
				int xtile = random.Next(tileXMin, tileXMax);
				int ytile = random.Next(tileYMin, tileYMax);
				OnSceneBegin.Add(new AdfEventAddDecoration()
				{
					Floor = 0,
					Tag = Tag() + Tag(i),
					DecorationImage = RandomImage(),
					Position = new(random.NextDouble() * (xmax - xmin) + xmin, random.NextDouble() * (ymax - ymin) + ymin),
					Scale = new(scale * xtile, scale * ytile),
					Opacity = 0,
					Tile = new(xtile, ytile)
				});
			}

			_totalAmount = amount;

			return this;
		}





		private int _totalAmount = 0;

		public MassElement WithFloor(double xmin = -10, double xmax = 10, double ymin = -5, double ymax = -3, 
			double parallaxXMin = 75, double parallaxXMax = 95, double parallaxYMin = 80, double parallaxYMax = 95)
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

		public MassElement WithVaryingDepth(int depthMin = -20, int depthMax = 20)
		{
			Random random = new();

			for (int i = 0; i < _totalAmount; i++)
			{
				OnSceneBegin.Add(new AdfEventMoveDecorations()
				{
					Tag = Tag(i),
					Duration = 0d,
					Depth = random.Next(depthMin, depthMax),
				});
			}

			return this;
		}

		public MassElement WithMovement(double xmin = 100, double xmax = 150, double ymin = 200, double ymax = 300,
			double rotationMin = -2, double rotationMax = 2, double duration = 32d)
		{
			Random random = new();

			for (int i = 0; i < _totalAmount; i++)
			{
				OnSceneBegin.Add(new AdfEventMoveDecorations()
				{
					Tag = Tag(i),
					Duration = duration,
					PositionOffset = new(random.NextDouble() * (xmax - xmin) + xmin, random.NextDouble() * (ymax - ymin) + ymin),
					RotationOffset = random.NextDouble() * (rotationMax - rotationMin) + rotationMin,
				});
			}

			return this;
		}

		public MassElement WithMovementParallax(double xmin = 100, double xmax = 150, double ymin = 200, double ymax = 300,
			double rotationMin = -2, double rotationMax = 2, double duration = 32d)
		{
			Random random = new();

			for (int i = 0; i < _totalAmount; i++)
			{
				OnSceneBegin.Add(new AdfEventMoveDecorations()
				{
					Tag = Tag(i),
					Duration = duration,
					ParallaxOffset = new(random.NextDouble() * (xmax - xmin) + xmin, random.NextDouble() * (ymax - ymin) + ymin),
					RotationOffset = random.NextDouble() * (rotationMax - rotationMin) + rotationMin,
					AngleOffset = 0.0001
				});
			}

			return this;
		}

		public MassElement WithFlashingOnBeat(double proportion = 0.145, double durationInterval = 2d, double flashDuration = 8d, int repeat = 32,
			string flashingColor = "FFFFFF", string normalColor = "000000")
		{
			Random random = new();

			for (int i = 0; i < repeat; i++)
			{
				for (int j = 0; j < _totalAmount; j++)
				{
					if (random.NextDouble() < proportion)
					{
						OnSceneBegin.Add(new AdfEventMoveDecorations()
						{
							Tag = Tag(j),
							Duration = 0,
							Color = new AdfColor(flashingColor),
							AngleOffset = i * durationInterval * 180d - 0.001d
						});
						OnSceneBegin.Add(new AdfEventMoveDecorations()
						{
							Tag = Tag(j),
							Duration = flashDuration,
							Color = new AdfColor(normalColor),
							AngleOffset = i * durationInterval * 180d,
							Ease = AdfEaseType.OutExpo
						});
					}
				}
			}

			return this;
		}






		public MassElement FromFlash()
		{
			OnSceneBegin.Add(new AdfEventMoveDecorations()
			{
				Tag = Tag(),
				Duration = 0d,
				Opacity = 100,
				AngleOffset = -0.001
			});

			return this;
		}

		public MassElement FromVaryingLayer(double opacityMin = 50, double opacityMax = 100,
			double parallaxXMin = 85, double parallaxXMax = 95, double parallaxYMin = 95, double parallaxYMax = 98,
			double rgbMin = 0, double rgbMax = 255, double rotationMin = -2, double rotationMax = 2, int depthMin = 50, int depthMax = 60)
		{
			Random random = new();

			for (int i = 0; i < _totalAmount; i++)
			{
				double frontToBack = random.NextDouble(); // 0.0 -> front, 1.0 -> back.
														  // front has blacker, blurrier (to be implemented using opencv), less opaque, less parallax image
														  // back has whiter, clearer, more opaque, more parallax image.
														  // front is negative depth, back is positive.

				

				OnSceneBegin.Add(new AdfEventMoveDecorations()
				{
					Tag = Tag(i),
					Duration = 0d,
					Color = new("FFFFFF")
					{ R = (byte)(frontToBack * (rgbMax - rgbMin) + rgbMin), G = (byte)(frontToBack * (rgbMax - rgbMin) + rgbMin), B = (byte)(frontToBack * (rgbMax - rgbMin) + rgbMin) },
					Opacity = frontToBack * (opacityMax - opacityMin) + opacityMin,
					Parallax = new(frontToBack * (parallaxXMax - parallaxXMin) + parallaxXMin, frontToBack * (parallaxYMax - parallaxYMin) + parallaxYMin),
					RotationOffset = frontToBack * (rotationMax - rotationMin) + rotationMin,
					Depth = (int)(frontToBack * (depthMax - depthMin)) + depthMin,
					AngleOffset = -0.001
				});
			}

			return this;
		}




		public MassElement ToFlashOut()
		{
			OnSceneEnd.Add(new AdfEventMoveDecorations()
			{
				Tag = Tag(),
				Duration = 0d,
				Opacity = 0,
			});

			return this;
		}

		public MassElement ToFlyOut(double duration = 4d, double flyX = 0, double flyY = -20)
		{
			OnSceneEnd.Add(new AdfEventMoveDecorations()
			{
				Tag = Tag(),
				Duration = duration,
				Opacity = 0,
				ParallaxOffset = new(flyX, flyY),
				Ease = AdfEaseType.OutCubic
			});

			return this;
		}


	}
}
