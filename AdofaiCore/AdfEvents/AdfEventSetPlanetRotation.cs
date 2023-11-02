using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicShaper.AdofaiCore.AdfClass;

namespace MagicShaper.AdofaiCore.AdfEvents
{
    internal partial class AdfEventSetPlanetRotation : AdfEventBase
    {

        public AdfEaseType Ease { get; set; } = AdfEaseType.Linear;

        public int EaseParts { get; set; } = 1;

        public override string EventType => "SetPlanetRotation";

        public AdfEasePartBehaviorType EasePartBehavior { get; set; } = AdfEasePartBehaviorType.Mirror;
    }
}
