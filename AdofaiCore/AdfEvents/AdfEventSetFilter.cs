using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
	internal class AdfEventSetFilter : AdfEventBase, IAdfEventAngleOffsetable, IAdfEventEaseable, IAdfEventTaggable
	{

		public override string EventType => "SetFilter";

		public string EventTag { get; set; } = "";

		public double AngleOffset { get; set; } = 0d;

		public AdfEaseType Ease { get; set; } = AdfEaseType.Linear;

		public double Duration { get; set; } = 0d;

		public bool Enabled { get; set; } = true;

		public double Intensity { get; set; } = 100d;

		public bool DisableOthers { get; set; } = false;

		public AdfFilter Filter { get; set; } = AdfFilter.Grayscale;

		
	}
}
