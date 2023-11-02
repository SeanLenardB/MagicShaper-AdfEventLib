using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicShaper.AdofaiCore.AdfClass;

namespace MagicShaper.AdofaiCore.AdfEvents
{
    internal partial class AdfEventRepeatEvents : AdfEventBase
	{

		public override string EventType => "RepeatEvents";

		public AdfRepeatEventType RepeatType { get; set; } = AdfRepeatEventType.Beat;

		public int Repetitions { get; set; } = 1;

		public int FloorCount { get; set; } = 1;

		public double Interval { get; set; } = 1d;

		public bool ExecuteOnCurrentFloor { get; set; } = false;

		public string Tag { get; set; } = "";
	}
}
