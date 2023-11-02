using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
    internal partial class AdfEventCustomBackground : AdfEventBase, IAdfEventAngleOffsetable, IAdfEventTaggable
	{

		public string EventTag { get; set; } = "";

		public override string EventType => "CustomBackground";

		public double AngleOffset { get; set; } = 0d;

		public AdfColor Color { get; set; } = new("000000");

		public string Image { get; set; } = "";

		public AdfColor ImageColor { get; set; } = new("ffffff");

		public AdfPosition Parallax { get; set; } = new(100, 100);

		public AdfBackgroundDisplayMode BackgroundDisplayMode { get; set; } = AdfBackgroundDisplayMode.FitToScreen;

		public bool ImageSmoothing { get; set; } = true;

		public bool LockRotation { get; set; } = false;

		public bool LoopBackground { get; set; } = false;

		public int ScalingRatio { get; set; } = 100;
	}
}
