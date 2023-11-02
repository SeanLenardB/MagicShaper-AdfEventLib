using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicShaper.AdofaiCore.AdfClass;

namespace MagicShaper.AdofaiCore.AdfEvents
{
    internal partial class AdfEventScalePlanets : AdfEventBase, IAdfEventAngleOffsetable, IAdfEventEaseable, IAdfEventTaggable
    {

        public string EventTag { get; set; } = "";

        public override string EventType => "ScalePlanets";


        public double AngleOffset { get; set; } = 0d;

        public AdfTargetPlanetType TargetPlanet { get; set; } = AdfTargetPlanetType.FirePlanet;

        public double Scale { get; set; } = 100d;
		
        public double Duration { get; set; } = 1d;

        public AdfEaseType Ease { get; set; } = AdfEaseType.Linear;

    }
}
