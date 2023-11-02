using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
	internal class AdfEventSetConditionalEvents : AdfEventBase
	{

		public override string EventType => "SetConditionalEvents";

		public string PerfectTag { get; set; } = "NONE";
		public string EarlyPerfectTag { get; set; } = "NONE";
		public string LatePerfectTag { get; set; } = "NONE";
		public string VeryEarlyTag { get; set; } = "NONE";
		public string VeryLateTag { get; set; } = "NONE";
		public string TooEarlyTag { get; set; } = "NONE";
		public string TooLateTag { get; set; } = "NONE";
		public string LossTag { get; set; } = "NONE";

	}
}
