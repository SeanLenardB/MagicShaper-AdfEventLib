using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.DerivedClass
{
	internal class AdfObject
	{
		public int Floor { get; set; } = 0;

		public AdfObjectType ObjectType { get; set; } = AdfObjectType.Floor;

		public AdfPlanetColorType PlanetColorType { get; set; } = AdfPlanetColorType.DefaultRed;

		public AdfColor PlanetColor { get; set; } = new("FF0000");

		public AdfColor PlanetTailColor { get; set; } = new("FF0000");

		public AdfTrackType TrackType { get; set; } = AdfTrackType.Normal;

		public double TrackAngle { get; set; } = 180d;

		public AdfColor TrackColor { get; set; } = new("DEBB7B");

		public double TrackOpacity { get; set; } = 100d;

		public AdfTrackStyle TrackStyle { get; set; } = AdfTrackStyle.Standard;

		public AdfTrackIcon TrackIcon { get; set; } = AdfTrackIcon.None;

		public double TrackIconAngle { get; set; } = 0d;

		public bool TrackRedSwirl { get; set; } = false;

		public bool TrackGraySetSpeedIcon { get; set; } = false;

		public double TrackSetSpeedIconBpm { get; set; } = 100d;

		public bool TrackGlowEnabled { get; set; } = false;

		public AdfColor TrackGlowColor { get; set; } = new("FFFFFF");

		public AdfPosition Position { get; set; } = new(0d, 0d);

		public AdfMoveDecorationRelativeToType RelativeTo { get; set; } = AdfMoveDecorationRelativeToType.Tile;

		public AdfPosition PivotOffset { get; set; } = new(0d, 0d);

		public double Rotation { get; set; } = 0d;

		public bool LockRotation { get; set; } = false;

		public AdfScale Scale { get; set; } = new(100d);

		public bool LockScale { get; set; } = false;

		public int Depth { get; set; } = -1;

		public AdfPosition Parallax { get; set; } = new(0d, 0d);

		public AdfPosition ParallaxOffset { get; set; } = new(0d, 0d);

		public string Tag { get; set; } = "";
	}
}
