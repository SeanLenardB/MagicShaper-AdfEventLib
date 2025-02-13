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

		public double? Rotation { get; set; } = null;

		public double? Scale { get; set; } = null;

		public double? Opacity { get; set; } = null;

		public bool JustThisTile { get; set; } = false;

		public bool EditorOnly { get; set; } = false;

		public bool? StickToFloors { get; set; } = null;

	}
}
