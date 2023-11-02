using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
	internal class AdfEventRecolorTrack : AdfEventBase, IAdfEventAngleOffsetable, IAdfEventTaggable, IAdfEventEaseable
    {


        public string EventTag { get; set; } = "";

        public override string EventType => "RecolorTrack";

        public double AngleOffset { get; set; } = 0d;

        public AdfTileReference StartTile { get; set; } = new(0, AdfTileReferenceType.ThisTile);

        public AdfTileReference EndTile { get; set; } = new(0, AdfTileReferenceType.ThisTile);

        public int GapLength { get; set; } = 0;



		public AdfTrackColorType TrackColorType { get; set; } = AdfTrackColorType.Single;


		public AdfColor TrackColor { get; set; } = new("debb7b");

		public AdfColor SecondaryTrackColor { get; set; } = new("ffffff");


		public double TrackColorAnimDuration { get; set; } = 2d;

		public AdfTrackColorPulseType TrackColorPulse { get; set; } = AdfTrackColorPulseType.None;

		public int TrackPulseLength { get; set; } = 10;

		public AdfTrackStyle TrackStyle { get; set; } = AdfTrackStyle.Standard;

		public double TrackGlowIntensity { get; set; } = 100d;



		public AdfEaseType Ease { get; set; } = AdfEaseType.Linear;

		public double Duration { get; set; } = 0d;

    }
}
