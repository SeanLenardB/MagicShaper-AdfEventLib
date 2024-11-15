using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions.DecoScene
{
	internal class DecoScene
	{
		public List<ISceneElement> Elements { get; set; } = new();

		public int Id { get; } = -1;

		/// <returns>The apply id of this operation. You may use it outside, together with 
		/// <see cref="MonoElement.Tag"/></returns>
		public string ApplyTo(AdfChart chart, int tileBegin, int tileEnd)
		{
			Random random = new();
			string applyId = random.Next(0, 999).ToString().PadLeft(3, '0');
			foreach (var element in Elements)
			{
				chart.ChartTiles[0].TileEvents.AddRange(element.OnChartBegin.Select(e => FixEventFloor(e, tileBegin, tileEnd, applyId)));
				chart.ChartTiles[^1].TileEvents.AddRange(element.OnChartEnd.Select(e => FixEventFloor(e, tileBegin, tileEnd, applyId)));

				foreach (var e in element.OnSceneBegin)
				{
					chart.ChartTiles[tileBegin].TileEvents.Add(FixEventFloor(e, tileBegin, tileEnd, applyId));
				}
				foreach (var e in element.OnSceneEnd)
				{
					chart.ChartTiles[tileEnd].TileEvents.Add(FixEventFloor(e, tileBegin, tileEnd, applyId));
				}

				for (int i = tileBegin; i < tileEnd; i++)
				{
					foreach (var del in element.OnTile)
					{
						IAdfEvent? item = del(i - tileBegin);
						if (item is null)
						{
							continue;
						}
						
						chart.ChartTiles[i].TileEvents.Add(FixEventFloor(item, tileBegin, tileEnd, applyId));
					}
				}
			}
			return applyId;
		}

		private IAdfEvent FixEventFloor(IAdfEvent e, int tileBegin, int tileEnd, string applyId)
		{
			if (e is AdfEventAddDecoration ea1o)
			{
				#region COPY
				var ea1 = new AdfEventAddDecoration()
				{
					Floor = ea1o.Floor,
					DecorationImage = ea1o.DecorationImage,
					Position = new AdfPosition(ea1o.Position.X, ea1o.Position.Y),
					RelativeTo = ea1o.RelativeTo,
					PivotOffset = new AdfPosition(ea1o.PivotOffset.X, ea1o.PivotOffset.Y),
					Rotation = ea1o.Rotation,
					LockRotation = ea1o.LockRotation,
					Scale = new AdfScale(ea1o.Scale.X, ea1o.Scale.Y),
					LockScale = ea1o.LockScale,
					Tile = new AdfScale(ea1o.Tile.X, ea1o.Tile.Y),
					Color = new AdfColor(ea1o.Color.ToString()),
					Opacity = ea1o.Opacity,
					Depth = ea1o.Depth,
					Parallax = new AdfPosition(ea1o.Parallax.X, ea1o.Parallax.Y),
					ParallaxOffset = new AdfPosition(ea1o.ParallaxOffset.X, ea1o.ParallaxOffset.Y),
					Tag = ea1o.Tag,
					ImageSmoothing = ea1o.ImageSmoothing,
					MaskingType = ea1o.MaskingType,
					UseMaskingDepth = ea1o.UseMaskingDepth,
					MaskingFrontDepth = ea1o.MaskingFrontDepth,
					MaskingBackDepth = ea1o.MaskingBackDepth,
					BlendMode = ea1o.BlendMode,
					Hitbox = ea1o.Hitbox,
					HitboxEventTag = ea1o.HitboxEventTag,
					FailHitboxType = ea1o.FailHitboxType,
					FailHitboxScale = new AdfScale(ea1o.FailHitboxScale.X, ea1o.FailHitboxScale.Y),
					FailHitboxOffset = new AdfPosition(ea1o.FailHitboxOffset.X, ea1o.FailHitboxOffset.Y),
					FailHitboxRotation = ea1o.FailHitboxRotation,
					Components = ea1o.Components
				};
				#endregion COPY

				ea1.Floor += tileBegin;
				ea1.Tag = ea1.Tag.Replace("{replaceme}", $"{applyId}");
				return ea1;
			}
			if (e is AdfEventAddObject ea2o)
			{
				#region COPY
				var ea2 = new AdfEventAddObject()
				{
					Floor = ea2o.Floor,
					ObjectType = ea2o.ObjectType,
					PlanetColorType = ea2o.PlanetColorType,
					PlanetColor = new AdfColor(ea2o.PlanetColor.ToString()),
					PlanetTailColor = new AdfColor(ea2o.PlanetTailColor.ToString()),
					TrackType = ea2o.TrackType,
					TrackAngle = ea2o.TrackAngle,
					TrackColor = new AdfColor(ea2o.TrackColor.ToString()),
					TrackOpacity = ea2o.TrackOpacity,
					TrackStyle = ea2o.TrackStyle,
					TrackIcon = ea2o.TrackIcon,
					TrackIconAngle = ea2o.TrackIconAngle,
					TrackRedSwirl = ea2o.TrackRedSwirl,
					TrackGraySetSpeedIcon = ea2o.TrackGraySetSpeedIcon,
					TrackSetSpeedIconBpm = ea2o.TrackSetSpeedIconBpm,
					TrackGlowEnabled = ea2o.TrackGlowEnabled,
					TrackGlowColor = new AdfColor(ea2o.TrackGlowColor.ToString()),
					Position = new AdfPosition(ea2o.Position.X, ea2o.Position.Y),
					RelativeTo = ea2o.RelativeTo,
					PivotOffset = new AdfPosition(ea2o.PivotOffset.X, ea2o.PivotOffset.Y),
					Rotation = ea2o.Rotation,
					LockRotation = ea2o.LockRotation,
					Scale = new AdfScale(ea2o.Scale.X, ea2o.Scale.Y),
					LockScale = ea2o.LockScale,
					Depth = ea2o.Depth,
					Parallax = new AdfPosition(ea2o.Parallax.X, ea2o.Parallax.Y),
					ParallaxOffset = new AdfPosition(ea2o.ParallaxOffset.X, ea2o.Parallax.Y),
					Tag = ea2o.Tag
				};
				#endregion COPY

				ea2.Floor += tileBegin;
				ea2.Tag = ea2.Tag.Replace("{replaceme}", $"{applyId}");
				return ea2;
			}
			if (e is AdfEventMoveDecorations ea3o)
			{
				#region COPY
				var ea3 = new AdfEventMoveDecorations()
				{
					EventTag = ea3o.EventTag,
					Tag = ea3o.Tag,
					AngleOffset = ea3o.AngleOffset,
					Ease = ea3o.Ease,
					Duration = ea3o.Duration,
					PositionOffset = ea3o.PositionOffset != null
						? new AdfPosition(ea3o.PositionOffset.X, ea3o.PositionOffset.Y)
						: null,
					ParallaxOffset = ea3o.ParallaxOffset != null
						? new AdfPosition(ea3o.ParallaxOffset.X, ea3o.ParallaxOffset.Y)
						: null,
					Parallax = ea3o.Parallax != null
						? new AdfPosition(ea3o.Parallax.X, ea3o.Parallax.Y)
						: null,
					PivotOffset = ea3o.PivotOffset != null
						? new AdfPosition(ea3o.PivotOffset.X, ea3o.PivotOffset.Y)
						: null,
					Scale = ea3o.Scale != null
						? new AdfScale(ea3o.Scale.X, ea3o.Scale.Y)
						: null,
					RotationOffset = ea3o.RotationOffset,
					Opacity = ea3o.Opacity,
					Visible = ea3o.Visible,
					RelativeTo = ea3o.RelativeTo,
					DecorationImage = ea3o.DecorationImage,
					Depth = ea3o.Depth,
					Color = ea3o.Color != null
						? new AdfColor(ea3o.Color.ToString())
						: null
				};
				#endregion COPY


				ea3.Tag = ea3.Tag.Replace("{replaceme}", $"{applyId}");
				return ea3;
			}
			return e;
		}
		



		private int _guid = 0;

		public T CreateElement<T>() where T : ISceneElement, new()
		{
			var element = new T
			{
				SceneId = Id,
				Guid = _guid++.ToString()
			};

			return element;
		}









		private DecoScene(int id)
		{
			Id = id;	
		}

		internal class DecoSceneFactory
		{
			private int _sceneIndex = 0;

			public DecoScene CreateScene()
			{
				return new(_sceneIndex++);
			}

		}


	}

}
