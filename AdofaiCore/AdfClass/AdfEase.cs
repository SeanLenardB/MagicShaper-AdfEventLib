namespace MagicShaper.AdofaiCore.AdfClass
{
    public class AdfEase
    {
        public AdfEase(AdfEaseType easeType, double easeDuration)
        {
            EaseType = easeType;
            EaseDuration = easeDuration;
        }

        public AdfEaseType EaseType { get; set; }

        public double EaseDuration { get; set; }
    }


}