using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
    internal partial class AdfEventFlash : AdfEventBase, IAdfEventTaggable, IAdfEventEaseable, IAdfEventAngleOffsetable
	{

		public double AngleOffset { get; set; } = 0d;

		public override string EventType => "Flash";

		public string EventTag { get; set; } = "";

		public AdfEaseType Ease { get; set; } = AdfEaseType.Linear;

		public double Duration { get; set; } = 1d;

		public AdfFlashPlaneType Plane { get; set; } = AdfFlashPlaneType.Background;

		public AdfColor StartColor { get; set; } = new("ffffff");

		public AdfColor EndColor { get; set; } = new("ffffff");

		public double StartOpacity { get; set; } = 100d;

		public double EndOpacity { get; set; } = 0d;

	}
}
