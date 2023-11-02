using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using MagicShaper.AdofaiCore.AdfClass;

namespace MagicShaper.AdofaiCore.AdfEvents
{
    internal class AdfEventAnimateTrack : AdfEventBase
    {

        public override string EventType => "AnimateTrack";

        public AdfTrackAnimationType? TrackAnimation { get; set; }

        public AdfTrackDisappearAnimationType? TrackDisappearAnimation { get; set; }

        public double BeatsAhead { get; set; } = 3d;

        public double BeatsBehind { get; set; } = 4d;


            //EventJson(new()
            //{
            //    { "trackAnimation", TrackAnimation },
            //    { "trackDisappearAnimation", TrackDisappearAnimation },
            //    { "beatsAhead", BeatsAhead },
            //    { "beatsBehind", BeatsBehind }
            //}, tileIndex, EventName);

        
    }
}
