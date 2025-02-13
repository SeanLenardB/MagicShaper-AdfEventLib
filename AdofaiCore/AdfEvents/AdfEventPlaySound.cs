using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
	internal class AdfEventPlaySound : AdfEventBase, IAdfEventAngleOffsetable, IAdfEventTaggable
	{
		public string EventTag { get; set; } = "";

		public override string EventType => "PlaySound";

		public double AngleOffset { get; set; } = 0d;

		public AdfHitsoundType Hitsound { get; set; } = AdfHitsoundType.Kick;

		public double HitsoundVolume { get; set; } = 100d;

	}
}
