using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions.DecoScene
{
	internal class DecoScene
	{
		public List<ISceneElement> Elements { get; set; } = new();

		public int TileBegin { get; set; } = 0;

		public int TileEnd { get; set; } = 0;

		public int Id { get; } = -1;

		public void ApplyTo(AdfChart chart)
		{
			int guid = 0;
			foreach (var element in Elements)
			{
				element.SceneId = Id;
				element.Guid = guid++.ToString();

				chart.ChartTiles[0].TileEvents.AddRange(element.OnChartBegin());
				chart.ChartTiles[^1].TileEvents.AddRange(element.OnChartEnd());

				chart.ChartTiles[TileBegin].TileEvents.AddRange(element.OnSceneBegin());
				chart.ChartTiles[TileEnd].TileEvents.AddRange(element.OnSceneEnd());

				for (int i = TileBegin; i < TileEnd; i++)
				{
					chart.ChartTiles[i].TileEvents.AddRange(element.OnTile(i - TileBegin));
				}
			}
		}










		private DecoScene(int id)
		{
			Id = id;	
		}

		internal class DecoSceneFactory
		{
			private int _sceneIndex = 0;

			public DecoScene CreateScene()
			{
				return new(_sceneIndex++);
			}

		}


	}

}
