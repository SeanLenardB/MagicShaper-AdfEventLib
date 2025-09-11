using MagicShaper.AdofaiCore.AdfClass;

namespace MagicShaper.AdofaiCore.AdfEvents
{
    internal class AdfEventAddDecoration : AdfEventBase
    {
		public override string EventType => "AddDecoration";

		public int Floor { get; set; } = 0;

		public bool Locked { get; set; } = true;

		public string DecorationImage { get; set; } = "";

		public AdfPosition Position { get; set; } = new(0d, 0d);

		public AdfMoveDecorationRelativeToType RelativeTo { get; set; } = AdfMoveDecorationRelativeToType.Tile;

		public AdfPosition PivotOffset { get; set; } = new(0d, 0d);

		public double Rotation { get; set; } = 0d;

        public bool LockRotation { get; set; } = false;

        public AdfScale Scale { get; set; } = new(100d);

        public bool LockScale { get; set; } = false;

        public AdfScale Tile { get; set; } = new(1d);

        public AdfColor Color { get; set; } = new("ffffff");

        public double Opacity { get; set; } = 100d;

        public int Depth { get; set; } = -1;

        public AdfPosition Parallax { get; set; } = new(0d, 0d);

        public AdfPosition ParallaxOffset { get; set; } = new(0d, 0d);

        public string Tag { get; set; } = "";

        public bool ImageSmoothing { get; set; } = true;

        public AdfMaskingType MaskingType { get; set; } = AdfMaskingType.None;

        public bool UseMaskingDepth { get; set; } = false;

        public int MaskingFrontDepth { get; set; } = -1;

        public int MaskingBackDepth { get; set; } = -1;

        public AdfBlendMode BlendMode { get; set; } = AdfBlendMode.None;

        public AdfHitbox Hitbox { get; set; } = AdfHitbox.None;

        public string HitboxEventTag { get; set; } = "";

        public AdfHitboxType FailHitboxType { get; set; } = AdfHitboxType.Box;

        public AdfScale FailHitboxScale { get; set; } = new(100d);

        public AdfPosition FailHitboxOffset { get; set; } = new(0d, 0d);

        public double FailHitboxRotation { get; set; } = 0d;

        public string Components { get; set; } = "";


    }
}