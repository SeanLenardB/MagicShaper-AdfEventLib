using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents.Dlc
{
	internal class AdfEventScaleMargin : AdfEventBase
	{
		public override string EventType => "ScaleMargin";

		public double Scale { get; set; } = 100d;
	}
}
