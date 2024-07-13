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
			foreach (var element in Elements)
			{
				chart.ChartTiles[0].TileEvents.AddRange(element.OnChartBegin);
				chart.ChartTiles[^1].TileEvents.AddRange(element.OnChartEnd);

				chart.ChartTiles[TileBegin].TileEvents.AddRange(element.OnSceneBegin);
				chart.ChartTiles[TileEnd].TileEvents.AddRange(element.OnSceneEnd);

				for (int i = TileBegin; i < TileEnd; i++)
				{
					chart.ChartTiles[i].TileEvents.AddRange(element.OnTile.Select(x => x(i - TileBegin)));
				}
			}
		}

		private int _guid = 0;

		public T CreateElement<T>() where T : ISceneElement, new()
		{
			var element = new T
			{
				SceneId = Id,
				Guid = _guid++.ToString()
			};

			return element;
		}









		private DecoScene(int id)
		{
			Id = id;	
		}

		internal class DecoSceneFactory
		{
			private int _sceneIndex = 0;

			public DecoScene CreateScene(int tileBegin, int tileEnd)
			{
				return new(_sceneIndex++) { TileBegin = tileBegin, TileEnd = tileEnd };
			}

		}


	}

}
