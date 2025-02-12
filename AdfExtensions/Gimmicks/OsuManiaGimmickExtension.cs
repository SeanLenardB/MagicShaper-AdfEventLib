using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using MagicShaper.AdofaiCore.AdfEvents.Dlc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions.Gimmicks
{
	internal static class OsuManiaGimmickExtension
	{
		/// <summary>
		/// If the gimmicked part has holds, please make sure they are inner angle (< 180 + 360k) 
		/// This is due to the fact that I am too lazy to write a macro inside this thing
		/// Make sure everything is non-midspin, non-Uturn, non-outerangle
		/// </summary>
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
				Depth = -5
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
					ParallaxOffset = new(positionX + offset, positionY + dropSpeedTilePerBeat * dropdownBeat),
					LockRotation = lockRotation,
					LockScale = lockScale
				});

				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"quartrond_osumania_{guid}_key_{i} quartrond_osumania_{guid}_key_{i}_tail",
					Duration = dropdownBeat * 0.2,
					Opacity = 100,
					Ease = AdfEaseType.OutSine,
					AngleOffset = -180 * dropdownBeat + 0.001
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"quartrond_osumania_{guid}_key_{i}",
					Duration = dropdownBeat,
					ParallaxOffset = new(positionX + offset, positionY),
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
					ParallaxOffset = new(positionX + offset, positionY - 0.5),
					Opacity = 0,
					Ease = AdfEaseType.OutQuad
				});


				// holding beats, to be improved.
				var e = chart.ChartTiles[i].TileEvents.Find(x => x is AdfEventHold);
				if (e is not null)
				{
					var holdBeat = chart.GetInnerAngleAtTile(i) / 180d + (e as AdfEventHold)!.Duration * 2;

					chart.ChartTiles[i].TileEvents.Add(new AdfEventAddObject()
					{
						ObjectType = AdfObjectType.Floor,
						TrackStyle = AdfTrackStyle.Minimal,
						TrackColor = new("888888"),
						TrackGlowEnabled = true,
						TrackGlowColor = new("AAAAAA"),
						Scale = new(railWidth * 100, dropSpeedTilePerBeat / 0.618d * holdBeat * 100),
						Tag = $"quartrond_osumania_{guid}_key_{i}_tail",
						TrackOpacity = 0,
						Depth = 1,
						Parallax = new(100, 100),
						ParallaxOffset = new(offset, positionY + dropSpeedTilePerBeat * dropdownBeat),
						LockRotation = lockRotation,
						LockScale = lockScale,
						PivotOffset = new(0, 0.5d * 0.618d) // evil pivot offset hack
					});

					chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Tag = $"quartrond_osumania_{guid}_key_{i}_tail",
						Duration = dropdownBeat + holdBeat,
						ParallaxOffset = new(offset, positionY - dropSpeedTilePerBeat * holdBeat),
						AngleOffset = -180 * dropdownBeat
					});

					chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveDecorations()
					{
						Tag = $"quartrond_osumania_{guid}_key_{i}_tail",
						Duration = dropdownBeat * 0.2,
						Scale = new(1.2 * railWidth, 0),
						ParallaxOffset = new(offset, positionY - 0.5),
						Opacity = 0,
						Ease = AdfEaseType.OutQuad,
						AngleOffset = holdBeat * 180
					});

					i++;
				}

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

		/// <summary>
		/// This is the advanced (CBA) version of the gimmick
		/// You can put the rail horizontal. 
		/// You can also pass a predicate which determines which tiles get transposed into the gimmick.
		/// Hold not supported. I cbad.
		/// </summary>
		public static void OsuManiaGimmickAdvanced(this AdfChart chart, int startTile, int endTile, Func<int, bool> predicate,
			int railCount = 4, double dropSpeedTilePerBeat = 3,
			double poolLineLength = 8, double railWidth = 1, double railGap = 0.1, double dropdownBeat = 4d,
			double positionX = 0, double positionY = -2, bool lockRotation = true, bool lockScale = true,
			double rotation = 0)
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
				Rotation = rotation,
				LockRotation = lockRotation,
				LockScale = lockScale,
				Depth = -5
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
				Rotation = rotation,
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


			double rotationRad = rotation / 180d * Math.PI;

			double midpoint = (railCount * railWidth + railGap * (railCount - 1)) / 2d;
			for (int i = startTile; i < endTile; i++)
			{
				if (!predicate(i)) { continue; }



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
					ParallaxOffset = 
					new(positionX + offset * Math.Cos(rotationRad) - (dropSpeedTilePerBeat * dropSpeedTilePerBeat) * Math.Sin(rotationRad),
							positionY + offset * Math.Sin(rotationRad) + (dropSpeedTilePerBeat * dropdownBeat) * Math.Sin(rotationRad)),
					Rotation = rotation,
					LockRotation = lockRotation,
					LockScale = lockScale
				});

				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"quartrond_osumania_{guid}_key_{i} quartrond_osumania_{guid}_key_{i}_tail",
					Duration = dropdownBeat * 0.2,
					Opacity = 100,
					Ease = AdfEaseType.OutSine,
					AngleOffset = -180 * dropdownBeat + 0.001
				});
				chart.ChartTiles[i].TileEvents.Add(new AdfEventMoveDecorations()
				{
					Tag = $"quartrond_osumania_{guid}_key_{i}",
					Duration = dropdownBeat,
					ParallaxOffset = new(positionX + offset * Math.Cos(rotationRad), positionY + offset * Math.Sin(rotationRad)),
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
					ParallaxOffset = new(positionX + offset * Math.Cos(rotationRad) + 0.5d * Math.Sin(rotationRad), 
						positionY + offset * Math.Sin(rotationRad) - 0.5 * Math.Cos(rotationRad)),
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
				ParallaxOffset = new(positionX + 0.2 * Math.Sin(rotationRad), positionY - 0.2 * Math.Cos(rotationRad))
			});



		}
	}
}
