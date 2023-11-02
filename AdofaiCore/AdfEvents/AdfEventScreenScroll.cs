using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
	internal class AdfEventScreenScroll : AdfEventBase, IAdfEventTaggable, IAdfEventAngleOffsetable
	{

		public double AngleOffset { get; set; } = 0d;

		public override string EventType => "ScreenScroll";

		public string EventTag { get; set; } = "";

		public AdfPosition Scroll { get; set; } = new(0, 0);

	}
}
