using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicShaper.AdofaiCore.AdfClass;

namespace MagicShaper.AdofaiCore.AdfEvents
{
	internal partial class AdfEventSetHitsound : AdfEventBase
    {
        public override string EventType => "SetHitsound";

        public AdfGameSoundType GameSound { get; set; } = AdfGameSoundType.Hitsound;

        public AdfHitsoundType Hitsound { get; set; } = AdfHitsoundType.Kick;

        public int HitsoundVolume { get; set; } = 100;

    }


}
