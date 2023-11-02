namespace MagicShaper.AdofaiCore.AdfClass
{
    public class AdfHitsound
    {
        public AdfHitsound(AdfHitsoundType hitsound, int hitsoundVolume)
        {
            HitsoundType = hitsound;
            HitsoundVolume = hitsoundVolume;
        }

        public AdfHitsoundType HitsoundType { get; set; }

        public int HitsoundVolume { get; set; }
    }


}