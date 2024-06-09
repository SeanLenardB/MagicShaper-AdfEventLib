using MagicShaper;
using MagicShaper.AdfExtensions;
using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using MagicShaper.VfxProjects;
using MagicShaper.VfxProjects.CDF2024;
using System.Runtime.Versioning;
using System.Text.Json.Nodes;

[SupportedOSPlatform("windows")]
internal class Program
{
	private static void Main(string[] args)
	{
		// AdfVfxProj_EverlastingStars.ProjMain();

		AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\Chrono - Copy - Copy\level.adofai");
		chart.SetupVisionLimit();
		chart.SetVisionLimitAutofit("ob1.png", 0);
		//File.WriteAllText(@"H:\Coding\CSharp\AdofaiGuessr\RenderChartImage\bin\Debug\net7.0\Chronoexplorers1.adofai", chart.ChartJson.ToJsonString());
		// chart.SetLineTrackStyle(169, 675, yScale: 50);
		//chart.SetLineTrackStyle(779, 1277, yScale: 50);

		for (int i = 1; i < chart.ChartTiles.Count; i++)
		{
            if (chart.GetInnerAngleAtTile(i) == 30d)
			{
				chart.ChartTiles[i].TileEvents.Add(new AdfEventRecolorTrack()
				{
					AngleOffset = -114514,
					Duration = 0d,
					TrackColor = new("000000a0"),
					SecondaryTrackColor = new("000000ff"),
					TrackColorType = AdfTrackColorType.Glow,
					TrackColorAnimDuration = 0.4d,
					TrackPulseLength = 25,
					TrackStyle = AdfTrackStyle.NeonLight,
					TrackGlowIntensity = 0
				});
                i++;
            }
			

        }

		File.WriteAllText(@"G:\Adofai levels\Chrono - Copy - Copy\level-vfx.adofai", chart.ChartJson.ToJsonString());
	}

	
}