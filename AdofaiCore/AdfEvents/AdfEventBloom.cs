using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
	internal class AdfEventBloom : AdfEventBase, IAdfEventAngleOffsetable, IAdfEventEaseable, IAdfEventTaggable
	{

		public string EventTag { get; set; } = "";

		public override string EventType => "Bloom";

		public double AngleOffset { get; set; } = 0d;

		public AdfEaseType Ease { get; set; } = AdfEaseType.Linear;

		public double Duration { get; set; } = 0d;

		public bool Enabled { get; set; } = true;

		public double Threshold { get; set; } = 50d;

		public double Intensity { get; set; } = 100d;

		public AdfColor Color { get; set; } = new("ffffff");

	}
}
