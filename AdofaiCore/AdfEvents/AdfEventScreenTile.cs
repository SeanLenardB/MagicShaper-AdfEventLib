using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
	internal class AdfEventScreenTile : AdfEventBase, IAdfEventAngleOffsetable, IAdfEventEaseable, IAdfEventTaggable
	{

		public string EventTag { get; set; } = "";

		public override string EventType => "ScreenTile";

		public double AngleOffset { get; set; } = 0d;

		public AdfEaseType Ease { get; set; } = AdfEaseType.Linear;

		public double Duration { get; set; } = 0d;

		public AdfPosition Tile { get; set; } = new(1, 1);

	}
}
