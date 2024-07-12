using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents.Dlc
{
	internal class AdfEventHold : AdfEventBase
	{
		public override string EventType => "Hold";

		public int Duration { get; set; } = 0;

		public int DistanceMultiplier { get; set; } = 100;

		public bool LandingAnimation { get; set; } = false;
    }
}
