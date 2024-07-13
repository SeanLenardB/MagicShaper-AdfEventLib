using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions.DecoScene
{
	internal interface ISceneElement
	{
		int SceneId { get; set; }

		string Guid { get; set; }

		internal List<IAdfEvent> OnChartBegin { get; set; }

		internal List<IAdfEvent> OnChartEnd { get; set; }

		internal List<IAdfEvent> OnSceneBegin { get; set; }

		internal List<IAdfEvent> OnSceneEnd { get; set; }

		internal List<Func<int, IAdfEvent?>> OnTile { get; set; }
	}
}
