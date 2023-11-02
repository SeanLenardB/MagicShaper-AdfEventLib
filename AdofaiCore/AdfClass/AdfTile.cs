using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicShaper.AdofaiCore.AdfEvents;

namespace MagicShaper.AdofaiCore.AdfClass
{
    internal class AdfTile
    {
        public AdfTile(double targetAngle, AdfTile? prevTile, List<IAdfEvent> tileEvents)
        {
            TargetAngle = targetAngle;
            PrevTile = prevTile;
            TileEvents = tileEvents;
        }

        public double TargetAngle { get; set; }

        public AdfTile? PrevTile { get; set; }


        public bool IsFirstTile => PrevTile is null;

        public int TileIndex => IsFirstTile ? 0 : PrevTile!.TileIndex + 1;


        public List<IAdfEvent> TileEvents { get; set; }




    }
}
