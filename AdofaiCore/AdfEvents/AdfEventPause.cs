using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
    internal class AdfEventPause : AdfEventBase
    {

        public override string EventType => "Pause";

        public double Duration { get; set; } = 1d;

        public int CountdownTicks { get; set; } = 0;

        public AdfAngleCorrectionDirection AngleCorrectionDir { get; set; } = AdfAngleCorrectionDirection.Backward;

    }
}
