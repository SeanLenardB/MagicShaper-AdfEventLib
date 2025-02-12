using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using MagicShaper.AdofaiCore.DerivedClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
    internal static class AdfDecoEventTransposeExtension
    {
        public static AdfDecoration GetDeco(this AdfEventAddDecoration e)
        {
            return new()
            {
                Floor = e.Floor,
                Locked = e.Locked,
                DecorationImage = e.DecorationImage,
                Position = e.Position,
                RelativeTo = e.RelativeTo,
                PivotOffset = e.PivotOffset,
                Rotation = e.Rotation,
                LockRotation = e.LockRotation,
                Scale = e.Scale,
                LockScale = e.LockScale,
                Tile = e.Tile,
                Color = e.Color,
                Opacity = e.Opacity,
                Depth = e.Depth,
                Parallax = e.Parallax,
                ParallaxOffset = e.ParallaxOffset,
                Tag = e.Tag,
                ImageSmoothing = e.ImageSmoothing,
                MaskingType = e.MaskingType,
                UseMaskingDepth = e.UseMaskingDepth,
                MaskingFrontDepth = e.MaskingFrontDepth,
                MaskingBackDepth = e.MaskingBackDepth,
                BlendMode = e.BlendMode,
                Hitbox = e.Hitbox,
                HitboxEventTag = e.HitboxEventTag,
                FailHitboxType = e.FailHitboxType,
                FailHitboxScale = e.FailHitboxScale,
                FailHitboxOffset = e.FailHitboxOffset,
                FailHitboxRotation = e.FailHitboxRotation,
                Components = e.Components
            };
        }

        public static AdfEventAddDecoration ToEvent(this AdfDecoration d)
        {
            return new()
            {
                Floor = d.Floor,
                Locked = d.Locked,
                DecorationImage = d.DecorationImage,
                Position = d.Position,
                RelativeTo = d.RelativeTo,
                PivotOffset = d.PivotOffset,
                Rotation = d.Rotation,
                LockRotation = d.LockRotation,
                Scale = d.Scale,
                LockScale = d.LockScale,
                Tile = d.Tile,
                Color = d.Color,
                Opacity = d.Opacity,
                Depth = d.Depth,
                Parallax = d.Parallax,
                ParallaxOffset = d.ParallaxOffset,
                Tag = d.Tag,
                ImageSmoothing = d.ImageSmoothing,
                MaskingType = d.MaskingType,
                UseMaskingDepth = d.UseMaskingDepth,
                MaskingFrontDepth = d.MaskingFrontDepth,
                MaskingBackDepth = d.MaskingBackDepth,
                BlendMode = d.BlendMode,
                Hitbox = d.Hitbox,
                HitboxEventTag = d.HitboxEventTag,
                FailHitboxType = d.FailHitboxType,
                FailHitboxScale = d.FailHitboxScale,
                FailHitboxOffset = d.FailHitboxOffset,
                FailHitboxRotation = d.FailHitboxRotation,
                Components = d.Components
            };
        }

        public static void AddDecorationToChart(this AdfChart c, AdfDecoration d)
        {
            c.ChartTiles[d.Floor].TileEvents.Add(d.ToEvent());
        }

        public static void AddDecorationsToChart(this AdfChart c, IEnumerable<AdfDecoration> ds)
        {
            foreach (var d in ds) { c.AddDecorationToChart(d); }
        }
        
        public static AdfObject GetObject(this AdfEventAddObject e)
        {
            return new()
            {
                Floor = e.Floor,
                Locked = e.Locked,
                Position = e.Position,
                RelativeTo = e.RelativeTo,
                PivotOffset = e.PivotOffset,
                Rotation = e.Rotation,
                LockRotation = e.LockRotation,
                Scale = e.Scale,
                LockScale = e.LockScale,
                Depth = e.Depth,
                Parallax = e.Parallax,
                ParallaxOffset = e.ParallaxOffset,
                Tag = e.Tag,
                
                ObjectType = e.ObjectType,
                PlanetColor = e.PlanetColor,
                PlanetColorType = e.PlanetColorType,
                PlanetTailColor = e.PlanetTailColor,
                TrackAngle = e.TrackAngle,
                TrackColor = e.TrackColor,
                TrackGlowColor = e.TrackGlowColor,
                TrackGlowEnabled = e.TrackGlowEnabled,
                TrackGraySetSpeedIcon = e.TrackGraySetSpeedIcon,
                TrackIcon = e.TrackIcon,
                TrackIconAngle = e.TrackIconAngle,
                TrackOpacity = e.TrackOpacity,
                TrackRedSwirl = e.TrackRedSwirl,
                TrackSetSpeedIconBpm = e.TrackSetSpeedIconBpm,
                TrackStyle = e.TrackStyle,
                TrackType = e.TrackType
            };
        }

        public static AdfEventAddObject ToEvent(this AdfObject o)
        {
            return new()
            {
				Floor = o.Floor,
                Locked = o.Locked,
				Position = o.Position,
				RelativeTo = o.RelativeTo,
				PivotOffset = o.PivotOffset,
				Rotation = o.Rotation,
				LockRotation = o.LockRotation,
				Scale = o.Scale,
				LockScale = o.LockScale,
				Depth = o.Depth,
				Parallax = o.Parallax,
				ParallaxOffset = o.ParallaxOffset,
				Tag = o.Tag,

				ObjectType = o.ObjectType,
				PlanetColor = o.PlanetColor,
				PlanetColorType = o.PlanetColorType,
				PlanetTailColor = o.PlanetTailColor,
				TrackAngle = o.TrackAngle,
				TrackColor = o.TrackColor,
				TrackGlowColor = o.TrackGlowColor,
				TrackGlowEnabled = o.TrackGlowEnabled,
				TrackGraySetSpeedIcon = o.TrackGraySetSpeedIcon,
				TrackIcon = o.TrackIcon,
				TrackIconAngle = o.TrackIconAngle,
				TrackOpacity = o.TrackOpacity,
				TrackRedSwirl = o.TrackRedSwirl,
				TrackSetSpeedIconBpm = o.TrackSetSpeedIconBpm,
				TrackStyle = o.TrackStyle,
				TrackType = o.TrackType
			};
        }

        public static void AddObjectToChart(this AdfChart c, AdfObject o)
        {
            c.ChartTiles[o.Floor].TileEvents.Add(o.ToEvent());
        }

        public static void AddObjectsToChart(this AdfChart c, IEnumerable<AdfObject> os)
        {
            foreach (var o in os) { c.AddObjectToChart(o); }
        }





    }
}
