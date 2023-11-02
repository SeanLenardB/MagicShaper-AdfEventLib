using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
	internal class AdfEventMoveTrack : AdfEventBase, IAdfEventAngleOffsetable, IAdfEventEaseable, IAdfEventTaggable
	{

		public string EventTag { get; set; } = "";

		public override string EventType => "MoveTrack";

		public AdfEaseType Ease { get; set; } = AdfEaseType.Linear;

		public double Duration { get; set; } = 1d;

		public double AngleOffset { get; set; } = 0d;

		public AdfTileReference StartTile { get; set; } = new(0, AdfTileReferenceType.ThisTile);

		public AdfTileReference EndTile { get; set; } = new(0, AdfTileReferenceType.ThisTile);

		public int GapLength { get; set; } = 0;

		public AdfPosition PositionOffset { get; set; } = new(null, null);

		public double? RotationOffset { get; set; } = null;

		public AdfScale? Scale { get; set; } = null;

		public double? Opacity { get; set; } = null;


	}
}
