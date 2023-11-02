using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
    internal class AdfEventAutoPlayTiles : AdfEventBase
    {

		public override string EventType => "AutoPlayTiles";

        public bool Enabled { get; set; } = true;

        public bool ShowStatusText { get; set; } = true;

    }
}
