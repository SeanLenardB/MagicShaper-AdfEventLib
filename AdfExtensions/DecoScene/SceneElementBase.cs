using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions.DecoScene
{
	internal abstract class SceneElementBase : ISceneElement
	{
		public int SceneId { get; set; } = -1;

		public string Guid { get; private set; } = ""; 

		public virtual void OnElementInitialize(AdfChart chart)
		{
			Random random = new();
			Guid = random.Next(0, 1000000).ToString().PadLeft(6, '0');
		}

		public virtual List<IAdfEvent> OnChartBegin()
		{
			return new();
		}

		public virtual List<IAdfEvent> OnChartEnd()
		{
			return new();
		}

		public virtual List<IAdfEvent> OnSceneBegin()
		{
			return new();
		}

		public virtual List<IAdfEvent> OnSceneEnd()
		{
			return new();
		}

		public virtual List<IAdfEvent> OnTile(int relativeTileIndex)
		{
			return new();
		}

		public string Tag(object? obj = null)
		{
			return $"quartrond_Scene{SceneId}_Element{Guid}{(obj is null ? "" : "_" + obj?.ToString())}";
		}
	}
}
