using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicShaper.AdofaiCore.AdfClass;

namespace MagicShaper.AdofaiCore.AdfEvents
{
    internal partial class AdfEventSetSpeed : AdfEventBase, IAdfEventAngleOffsetable
    {


        public double AngleOffset { get; set; } = 0d;

        public override string EventType => "SetSpeed";

        public AdfEventSpeedType SpeedType { get; set; } = AdfEventSpeedType.Bpm;

        public double BeatsPerMinute { get; set; } = 100d;

        public double BpmMultiplier { get; set; } = 1d;
    }


}
