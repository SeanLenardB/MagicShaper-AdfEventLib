using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
	internal class AdfEventSetFrameRate : AdfEventBase, IAdfEventAngleOffsetable
	{
        public override string EventType => "SetFrameRate";

        public double AngleOffset { get; set; } = 0d;

		public bool Enabled { get; set; } = true;

		public double FrameRate { get; set; } = 5d;
	}
}
