using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
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

		public int Id { get; } = -1;

		public void ApplyTo(AdfChart chart, int tileBegin, int tileEnd)
		{
			foreach (var element in Elements)
			{
				chart.ChartTiles[0].TileEvents.AddRange(element.OnChartBegin);
				chart.ChartTiles[^1].TileEvents.AddRange(element.OnChartEnd);

				foreach (var e in element.OnSceneBegin)
				{
					FixEventFloor(e, tileBegin, tileEnd);
					chart.ChartTiles[tileBegin].TileEvents.Add(e);
				}
				foreach (var e in element.OnSceneEnd)
				{
					FixEventFloor(e, tileBegin, tileEnd);
					chart.ChartTiles[tileEnd].TileEvents.Add(e);
				}

				for (int i = tileBegin; i < tileEnd; i++)
				{
					foreach (var del in element.OnTile)
					{
						IAdfEvent? item = del(i - tileBegin);
						if (item is null)
						{
							continue;
						}

						chart.ChartTiles[i].TileEvents.Add(item);
					}
				}
			}
		}

		private IAdfEvent FixEventFloor(IAdfEvent e, int tileBegin, int tileEnd)
		{
			if (e is AdfEventAddDecoration ea1)
			{
				ea1.Floor += tileBegin;
				return ea1;
			}
			if (e is AdfEventAddObject ea2)
			{
				ea2.Floor += tileBegin;
				return ea2;
			}

			return e;
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

			public DecoScene CreateScene()
			{
				return new(_sceneIndex++);
			}

		}


	}

}
