using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
	internal class AdfEventHallOfMirrors : AdfEventBase, IAdfEventAngleOffsetable, IAdfEventTaggable
	{

		public double AngleOffset { get; set; } = 0d;

		public override string EventType => "HallOfMirrors";

		public string EventTag { get; set; } = "";

		public bool Enabled { get; set; } = true;

	}
}
