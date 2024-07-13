using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions.Gimmicks
{
	internal static class OsuManiaGimmickExtension
	{
		public static void OsuManiaGimmick(this AdfChart chart, int startTile, int endTile, int railCount = 4, double dropSpeedTilePerBeat = 3, 
			double poolLineLength = 8, double railWidth = 1, double railGap = 0.1, double dropdownBeat = 4d, 
			double positionX = 0, double positionY = -2, bool lockRotation = true, bool lockScale = true)
		{
			Random random = new();
			string guid = random.Next(0, 1000000).ToString().PadLeft(6, '0');

			chart.ChartTiles[startTile].TileEvents.Add(new AdfEventAddObject()
			{
				ObjectType = AdfObjectType.Floor,
				TrackStyle = AdfTrackStyle.Minimal,
				TrackColor = new("FFFFFF"),
				Scale = new(100 * poolLineLength, 20),
				Tag = $"quartrond_osumania_{guid}_poolline_hit",
				TrackGlowEnabled = true,
				TrackGlowColor = new("FFFFFFff"),
				TrackOpacity = 0,
				Parallax = new(100, 100),
				ParallaxOffset = new(positionX, positionY),
				LockRotation = lockRotation,
				LockScale = lockScale,
				Depth = -1
			});
			chart.ChartTiles[startTile].TileEvents.Add(new AdfEventAddObject()
			{
				ObjectType = AdfObjectType.Floor,
				TrackStyle = AdfTrackStyle.Neon,
				TrackColor = new("FFFFFF"),
				Scale = new(3000, 40),
				Tag = $"quartrond_osumania_{guid}_poolline",
				TrackOpacity = 0,
				Parallax = new(100, 100),
				ParallaxOffset = new(positionX, positionY),
				LockRotation = lockRotation,
				LockScale = lockScale
			});

			chart.ChartTiles[startTile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Tag = $"quartrond_osumania_{guid}_poolline",
				Duration = dropdownBeat * 0.5d,
				Scale = new(100 * poolLineLength, 20),
				Ease = AdfEaseType.OutCirc,
				Opacity = 100
			});


			double midpoint = (railCount * railWidth + railGap * (railCount - 1)) / 2d;
			for (int i = startTile; i < endTile; i++)
			{
				int rail = random.Next(railCount);

				double offset = (rail + 1) * railWidth + railGap * rail - midpoint - railWidth / 2d;

				chart.ChartTiles[i].TileEvents.Add(new AdfEventAddObject()
				{
					ObjectType = AdfObjectType.Floor,
					TrackStyle = AdfTrackStyle.Minimal,
					TrackColor = new("FFFFFF"),
					TrackGlowEnabled = true,
					TrackGlowColor = new("FFFFFF55"),
					Scale = new(railWidth * 100),
					Tag = $"quartrond_osumania_{guid}_key_{i}",
					TrackOpacity = 0,
					Parallax = new(100, 100),
					ParallaxOffset = new(offset, positionY + dropSpeedTilePerBeat * dropdownBeat),
					LockRotation = lockRotation,
					LockScale = lockScale
				});

				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"quartrond_osumania_{guid}_key_{i}",
					Duration = dropdownBeat * 0.2,
					Opacity = 100,
					Ease = AdfEaseType.OutSine,
					AngleOffset = -180 * dropdownBeat + 0.001
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"quartrond_osumania_{guid}_key_{i}",
					Duration = dropdownBeat,
					ParallaxOffset = new(offset, positionY),
					AngleOffset = -180 * dropdownBeat
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"quartrond_osumania_{guid}_poolline_hit",
					Duration = 0,
					Opacity = 100
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"quartrond_osumania_{guid}_poolline_hit",
					Duration = dropdownBeat * 0.25,
					Opacity = 0,
					AngleOffset = 0.001
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"quartrond_osumania_{guid}_key_{i}",
					Duration = dropdownBeat * 0.2,
					Scale = new(1.2 * railWidth, 0),
					ParallaxOffset = new(offset, positionY - 0.5),
					Opacity = 0,
					Ease = AdfEaseType.OutQuad
				});
			}

			chart.ChartTiles[endTile].TileEvents.Add(new AdfEventMoveDecorations()
			{
				Tag = $"quartrond_osumania_{guid}_poolline_hit quartrond_osumania_{guid}_poolline",
				Duration = dropdownBeat * 0.2,
				Ease = AdfEaseType.OutCirc,
				Opacity = 0,
				Scale = new(poolLineLength * 100 * 0.3, 10),
				ParallaxOffset = new(positionX, positionY - 0.2)
			});
		}
	}
}
