using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
    internal partial class AdfEventMoveDecorations : AdfEventBase, IAdfEventAngleOffsetable, IAdfEventEaseable, IAdfEventTaggable
	{

		public string EventTag { get; set; } = "";

		public string Tag { get; set; } = "sampleTag";

		public override string EventType => "MoveDecorations";

		public double AngleOffset { get; set; } = 0d;

		public AdfEaseType Ease { get; set; } = AdfEaseType.Linear;

		public double Duration { get; set; } = 1d;

		public AdfPosition? PositionOffset { get; set; } = new(null, null);
		public AdfPosition? ParallaxOffset { get; set; } = null;
		public AdfPosition? Parallax { get; set; } = null;
		public AdfPosition? PivotOffset { get; set; } = null;
		public AdfScale? Scale { get; set; } = null;


		public double? RotationOffset { get; set; } = null;

		public double? Opacity { get; set; } = null;

		public bool? Visible { get; set; } = null;

		public AdfMoveDecorationRelativeToType? RelativeTo { get; set; } = null;

		public string? DecorationImage { get; set; } = null;

		public int? Depth { get; set; } = null;

		public AdfColor? Color { get; set; } = null;
	}
}
