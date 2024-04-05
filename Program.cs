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
		AdfChart chart = AdfChart.Parse(@"G:\Adofai levels\Breakcore Speedrun Any% in Tiger Shark\level-nerfed.adofai");
		chart.SetLineTrackStyle(169, 675, yScale: 50);
		chart.SetLineTrackStyle(779, 1277, yScale: 50);

		File.WriteAllText(@"G:\Adofai levels\Breakcore Speedrun Any% in Tiger Shark\level-nerfed-fun.adofai", chart.ChartJson.ToJsonString());
	}

	
}