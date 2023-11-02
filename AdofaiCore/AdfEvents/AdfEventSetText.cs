using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
	internal class AdfEventSetText : AdfEventBase, IAdfEventTaggable, IAdfEventAngleOffsetable
	{

		public string EventTag { get; set; } = "";

		public override string EventType => "SetText";

		public string Tag { get; set; } = "";

		public string DecText { get; set; } = "Text";

		public double AngleOffset { get; set; } = 0d;

		
	}
}
