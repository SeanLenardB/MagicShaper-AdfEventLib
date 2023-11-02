using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
	internal class AdfEventPositionTrack : AdfEventBase
	{

		public override string EventType => "PositionTrack";

		public AdfPosition PositionOffset { get; set; } = new(0, 0);

		public AdfTileReference RelativeTo { get; set; } = new(0, AdfTileReferenceType.ThisTile);

		public double Rotation { get; set; } = 0d;

		public double Scale { get; set; } = 100d;

		public double Opacity { get; set; } = 100d;

		public bool JustThisTile { get; set; } = false;

		public bool EditorOnly { get; set; } = false;

	}
}
