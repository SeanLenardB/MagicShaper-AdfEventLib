using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents.Dlc
{
	internal class AdfEventHide : AdfEventBase
	{
		public override string EventType => "Hide";

		public double AngleOffset { get; set; } = 0d;

		public bool HideJudgment { get; set; } = false;

		public bool HideTileIcon { get; set; } = false;

	}
}
