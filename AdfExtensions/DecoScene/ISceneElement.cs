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

		internal List<IAdfEvent> OnChartBegin();

		internal List<IAdfEvent> OnChartEnd();

		internal List<IAdfEvent> OnSceneBegin();

		internal List<IAdfEvent> OnSceneEnd();

		internal List<IAdfEvent> OnTile(int relativeTileIndex);
	}
}
