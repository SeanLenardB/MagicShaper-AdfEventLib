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
		AdfVfxProj_EscapingAFoulPresence.ProjMain();

		//AdfChart chart = AdfChart.ParseChart(File.ReadAllText(@"C:\Users\admin\Downloads\rayofhope\main new.adofai"));

		//foreach (var tile in chart.ChartTiles)
		//{
		//	List<IAdfEvent> toKeep = new();
		//	foreach (var e in tile.TileEvents)
		//	{
				
		//		if (e is AdfEventTwirl || e is AdfEventSetSpeed || e is AdfEventPositionTrack)
		//		{
		//			toKeep.Add(e);
		//		}
		//	}
		//	tile.TileEvents.Clear();
		//	foreach (var e in toKeep)
		//	{
		//		tile.TileEvents.Add(e);
		//	}
		//}


		//File.WriteAllText(@"C:\Users\admin\Downloads\rayofhope\main noneffect.adofai", chart.ChartJson.ToJsonString());




	}

	
}