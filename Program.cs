using MagicShaper;
using MagicShaper.AdfExtensions;
using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using MagicShaper.VfxProjects;
using System.Text.Json.Nodes;

internal class Program
{
	private static void Main(string[] args)
	{
		// AdfVfxProj_EscapingAFoulPresence.ProjMain();

		AdfChart chart = AdfChart.ParseChart(File.ReadAllText(@"G:\Adofai levels\decotest\level.adofai"));
		//actions



		File.WriteAllText(@"G:\Adofai levels\decotest\level output.adofai", chart.ChartJson.ToJsonString());



	}

	
}