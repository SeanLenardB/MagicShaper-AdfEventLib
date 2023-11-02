using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
    internal partial class AdfEventMoveCamera : AdfEventBase, IAdfEventAngleOffsetable, IAdfEventEaseable, IAdfEventTaggable
	{

		public string EventTag { get; set; } = "";

		public override string EventType => "MoveCamera";

		public double AngleOffset { get; set; } = 0d;

		public AdfEaseType Ease { get; set; } = AdfEaseType.Linear;

		public double Duration { get; set; } = 1d;

		public AdfPosition? Position { get; set; } = new(null, null);

		public AdfCameraRelativeToType? RelativeTo { get; set; } = null;

		public double? Rotation { get; set; } = null;

		public double? Zoom { get; set; } = null;
	}
}
