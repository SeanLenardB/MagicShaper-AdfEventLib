using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
	internal class AdfEventShakeScreen : AdfEventBase, IAdfEventEaseable, IAdfEventAngleOffsetable, IAdfEventTaggable
	{

		public string EventTag { get; set; } = "";

		public override string EventType => "ShakeScreen";

		public AdfEaseType Ease { get; set; } = AdfEaseType.Linear;

		public double Duration { get; set; } = 1d;

		public double AngleOffset { get; set; } = 0d;

		public double Strength { get; set; } = 0d;

		public double Intensity { get; set; } = 0d;

		public bool FadeOut { get; set; } = true;


	}
}
