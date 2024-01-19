using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	internal static class AtmosphereExtension
	{


		public static void MovingParticlesBackground(this AdfChart chart, List<string> particleImages, 
			int targetTile, double durationBeats, AdfColor color,
			double upliftSpeedMinTilePerBeat = 1.5d, double upliftSpeedMaxTilePerBeat = 2.5d,
			double directionMin = 75d, double directionMax = 90d, 
			double imageScaleMin = 100d, double imageScaleMax = 400d,
			double imageOpacityMin = 50d, double imageOpacityMax = 100d,
			int layers = 3)
		{
			Random random = new();
			string gid = random.Next(1000000).ToString().PadLeft(6, '0');

			for (int i = 0; i < layers; i++)
			{
				double thisScale = random.NextDouble() * (imageScaleMax - imageScaleMin) + imageScaleMin;
				
				chart.AddDecorationToChart(new()
				{
					Tag = $"{ExtensionSharedConstants.UpliftParticlesBackgroundTagPrefix}_{gid}_{i}",
					Opacity = 0,
					Depth = ExtensionSharedConstants.UpliftParticlesBackgroundDepth,
					Tile = new(100, 2000),
					Scale = new(100 * thisScale, 2000 * thisScale),
					DecorationImage = particleImages[random.Next(0, particleImages.Count)],
					Color = color
				});
			}
			
			for (int i = 0; i < layers; i++)
			{
				double thisOpacity = random.NextDouble() * (imageOpacityMax - imageOpacityMin) + imageOpacityMin;
				chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"{ExtensionSharedConstants.UpliftParticlesBackgroundTagPrefix}_{gid}_{i}",
					Opacity = thisOpacity,
					Duration = 0
				});

				double thisSpeed = random.NextDouble() * (upliftSpeedMaxTilePerBeat - upliftSpeedMinTilePerBeat) + upliftSpeedMinTilePerBeat;
				double thisAngle = random.NextDouble() * (directionMax - directionMin) + directionMin;
				chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"{ExtensionSharedConstants.UpliftParticlesBackgroundTagPrefix}_{gid}_{i}",
					PositionOffset = new(thisSpeed * Math.Cos(thisAngle / 180d * Math.PI) * durationBeats, 
						thisSpeed * Math.Sin(thisAngle / 180d * Math.PI) * durationBeats),
					Duration = durationBeats
				});
				chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"{ExtensionSharedConstants.UpliftParticlesBackgroundTagPrefix}_{gid}_{i}",
					Duration = 0,
					Opacity = 0,
					AngleOffset = durationBeats * 180d
				});
			}
		}

		public static void MovingParticlesForeground(this AdfChart chart, List<string> particleImages,
			int targetTile, double durationBeats, AdfColor color,
			double upliftSpeedMinTilePerBeat = 1.5d, double upliftSpeedMaxTilePerBeat = 2.5d,
			double directionMin = 75d, double directionMax = 90d,
			double imageScaleMin = 100d, double imageScaleMax = 400d,
			double imageOpacityMin = 50d, double imageOpacityMax = 100d,
			int layers = 3)
		{
			Random random = new();
			string gid = random.Next(1000000).ToString().PadLeft(6, '0');

			for (int i = 0; i < layers; i++)
			{
				double thisScale = random.NextDouble() * (imageScaleMax - imageScaleMin) + imageScaleMin;

				chart.AddDecorationToChart(new()
				{
					Tag = $"{ExtensionSharedConstants.UpliftParticlesForegroundTagPrefix}_{gid}_{i}",
					Opacity = 0,
					Depth = ExtensionSharedConstants.UpliftParticlesForegroundDepth,
					Tile = new(100, 2000),
					Scale = new(100 * thisScale, 2000 * thisScale),
					DecorationImage = particleImages[random.Next(0, particleImages.Count)],
					Color = color
				});
			}

			for (int i = 0; i < layers; i++)
			{
				double thisOpacity = random.NextDouble() * (imageOpacityMax - imageOpacityMin) + imageOpacityMin;
				chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"{ExtensionSharedConstants.UpliftParticlesForegroundTagPrefix}_{gid}_{i}",
					Opacity = thisOpacity,
					Duration = 0
				});

				double thisSpeed = random.NextDouble() * (upliftSpeedMaxTilePerBeat - upliftSpeedMinTilePerBeat) + upliftSpeedMinTilePerBeat;
				double thisAngle = random.NextDouble() * (directionMax - directionMin) + directionMin;
				chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"{ExtensionSharedConstants.UpliftParticlesForegroundTagPrefix}_{gid}_{i}",
					PositionOffset = new(thisSpeed * Math.Cos(thisAngle / 180d * Math.PI) * durationBeats,
						thisSpeed * Math.Sin(thisAngle / 180d * Math.PI) * durationBeats),
					Duration = durationBeats
				});
				chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"{ExtensionSharedConstants.UpliftParticlesForegroundTagPrefix}_{gid}_{i}",
					Duration = 0,
					Opacity = 0,
					AngleOffset = durationBeats * 180d
				});
			}
		}


		public static void BasicAtmosphereFilters(this AdfChart chart, int targetTile,
			double grainIntensity = 25d, double grayscaleIntensity = -50d, double staticIntensity = -3d, double rainIntensity = -10d)
		{
			chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventSetFilter()
			{
				Filter = AdfFilter.Grain,
				Intensity = grainIntensity
			});
			chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventSetFilter()
			{
				Filter = AdfFilter.Grayscale,
				Intensity = grayscaleIntensity
			});
			chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventSetFilter()
			{
				Filter = AdfFilter.Static,
				Intensity = staticIntensity
			});
			chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventSetFilter()
			{
				Filter = AdfFilter.Rain,
				Intensity = rainIntensity
			});
		}


		public static void FloatingTrackBackground(this AdfChart chart, int targetTile, double durationBeats,
			string trackColor = "000000FF",
			int totalTracks = 50, double minSize = 50, double maxSize = 80,
			double upliftSpeedMinTilePerBeat = 1.5d, double upliftSpeedMaxTilePerBeat = 2.5d,
			double directionMin = 75d, double directionMax = 90d,
			double xmin = -50, double xmax = 50, double ymin = -90, double ymax = 90,
			double opacityMin = 10, double opacityMax = 60,
			int parallaxMin = 45, int parallaxMax = 60, int depthOffset = 0)
		{
			Random random = new();
			string gid = random.Next(1000000).ToString().PadLeft(6, '0');

			for (int i = 0; i < totalTracks; i++)
			{
				chart.AddObjectToChart(new()
				{
					ObjectType = AdfObjectType.Floor,
					Parallax = new(random.NextDouble() * (parallaxMax - parallaxMin) + parallaxMax, 
						random.NextDouble() * (parallaxMax - parallaxMin) + parallaxMax),
					Depth = ExtensionSharedConstants.FloatingTrackBackgroundDepth + depthOffset,
					Tag = $"{ExtensionSharedConstants.FloatingTrackBackgroundTagPrefix}_{gid}_{i}",
					Scale = new(random.NextDouble() * (maxSize - minSize) + minSize),
					TrackOpacity = 0d,
					Position = new(random.NextDouble() * (xmax - xmin) + xmin,
						random.NextDouble() * (ymax - ymin) + ymin),
					TrackStyle = AdfTrackStyle.Minimal,
					TrackColor = new(trackColor),
					RelativeTo = AdfMoveDecorationRelativeToType.Tile,
					Floor = targetTile,
					TrackAngle = random.NextDouble() * 360d,
					Rotation = random.NextDouble() * 360d,
				});

				double thisSpeed = random.NextDouble() * (upliftSpeedMaxTilePerBeat - upliftSpeedMinTilePerBeat) + upliftSpeedMinTilePerBeat;
				double thisAngle = random.NextDouble() * (directionMax - directionMin) + directionMin;

				chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"{ExtensionSharedConstants.FloatingTrackBackgroundTagPrefix}_{gid}_{i}",
					Duration = 0d,
					Opacity = random.NextDouble() * (opacityMax - opacityMin) + opacityMin
				});
				chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"{ExtensionSharedConstants.FloatingTrackBackgroundTagPrefix}_{gid}_{i}",
					Duration = durationBeats,
					PositionOffset = new(thisSpeed * Math.Cos(thisAngle / 180d * Math.PI) * durationBeats,
						thisSpeed * Math.Sin(thisAngle / 180d * Math.PI) * durationBeats),
				});
				chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"{ExtensionSharedConstants.FloatingTrackBackgroundTagPrefix}_{gid}_{i}",
					Duration = 0d,
					Opacity = 0d,
					AngleOffset = 180 * durationBeats,
					PositionOffset = new(0, 0),
					Visible = false
				});
			}

		}

		public static void FloatingPlanetsBackground(this AdfChart chart, int targetTile, double durationBeats,
		string planetColor = "000000FF",
		int totalPlanets = 50, double minSize = 50, double maxSize = 80,
		double upliftSpeedMinTilePerBeat = 1.5d, double upliftSpeedMaxTilePerBeat = 2.5d,
		double directionMin = 75d, double directionMax = 90d,
		double xmin = -50, double xmax = 50, double ymin = -90, double ymax = 90,
		int parallaxMin = 45, int parallaxMax = 60, int depthOffset = 0,
		double xhideOffset = 100, double yhideOffset = 100)
		{
			Random random = new();
			string gid = random.Next(1000000).ToString().PadLeft(6, '0');

			for (int i = 0; i < totalPlanets; i++)
			{
				chart.AddObjectToChart(new()
				{
					ObjectType = AdfObjectType.Planet,
					Parallax = new(random.NextDouble() * (parallaxMax - parallaxMin) + parallaxMax,
						random.NextDouble() * (parallaxMax - parallaxMin) + parallaxMax),
					Depth = ExtensionSharedConstants.FloatingPlanetBackgroundDepth + depthOffset,
					Tag = $"{ExtensionSharedConstants.FloatingPlanetBackgroundTagPrefix}_{gid}_{i}",
					Scale = new(random.NextDouble() * (maxSize - minSize) + minSize),
					
					Position = new(random.NextDouble() * (xmax - xmin) + xmin + xhideOffset,
						random.NextDouble() * (ymax - ymin) + ymin + yhideOffset),
					
					PlanetColorType = AdfPlanetColorType.Custom,
					PlanetColor = new(planetColor),
					PlanetTailColor = new(planetColor),
					RelativeTo = AdfMoveDecorationRelativeToType.Tile,
					Floor = targetTile,
				});

				double thisSpeed = random.NextDouble() * (upliftSpeedMaxTilePerBeat - upliftSpeedMinTilePerBeat) + upliftSpeedMinTilePerBeat;
				double thisAngle = random.NextDouble() * (directionMax - directionMin) + directionMin;

				chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"{ExtensionSharedConstants.FloatingPlanetBackgroundTagPrefix}_{gid}_{i}",
					Duration = 0d,
					PositionOffset = new(-xhideOffset, -yhideOffset),
					AngleOffset = -0.0001d
				});
				chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"{ExtensionSharedConstants.FloatingPlanetBackgroundTagPrefix}_{gid}_{i}",
					Duration = durationBeats,
					PositionOffset = new(thisSpeed * Math.Cos(thisAngle / 180d * Math.PI) * durationBeats,
						thisSpeed * Math.Sin(thisAngle / 180d * Math.PI) * durationBeats),
				});
				chart.ChartTiles[targetTile].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"{ExtensionSharedConstants.FloatingPlanetBackgroundTagPrefix}_{gid}_{i}",
					Duration = 0d,
					AngleOffset = 180 * durationBeats,
					PositionOffset = new(0, 0),
					Visible = false
				});
			}

		}
	}
}
