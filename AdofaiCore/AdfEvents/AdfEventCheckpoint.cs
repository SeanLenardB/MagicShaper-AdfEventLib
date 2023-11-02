using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
    internal class AdfEventCheckpoint : AdfEventBase
    {


        public override string EventType => "Checkpoint";

        public int TileOffset { get; set; } = 0;
        
    }
}
