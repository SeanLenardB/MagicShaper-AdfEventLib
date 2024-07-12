using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents.Dlc
{
	internal class AdfEventScaleRadius : AdfEventBase
	{
		public override string EventType => "ScaleRadius";

		public double Scale { get; set; } = 100;
    }
}
