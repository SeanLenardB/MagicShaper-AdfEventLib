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

		public string Guid { get; set; } = "";

		public List<string> Images { get; set; } = new();

		public List<IAdfEvent> OnChartBegin { get; set; } = new();
		public List<IAdfEvent> OnChartEnd { get; set; } = new();
		public List<IAdfEvent> OnSceneBegin { get; set; } = new();
		public List<IAdfEvent> OnSceneEnd { get; set; } = new();
		public List<Func<int, IAdfEvent?>> OnTile { get; set; } = new();

		protected virtual void EnsureImages(string image)
		{
			if (string.IsNullOrEmpty(image) && (Images.Count == 0 || string.IsNullOrEmpty(Images[0])))
			{
				throw new Exception("Use .Use() to set the image OR pass the image in the optional parameters. Both are empty now.");
			}

			if (!string.IsNullOrEmpty(image))
			{
				this.Images = new() { image };
			}
		}

		protected virtual void EnsureImages(List<string> images)
		{
			if (images.Count == 0 && (Images.Count == 0 || string.IsNullOrEmpty(Images[0])))
			{
				throw new Exception("Use .Use() to set the image OR pass the image in the optional parameters. Both are empty now.");
			}

			if (images.Count > 0)
			{
				this.Images = images;
			}
		}

		protected virtual void EnsureImages()
		{
			if (Images.Count == 0 || string.IsNullOrEmpty(Images[0]))
			{
				throw new Exception("Use .Use() to set the image OR pass the image in the optional parameters. Both are empty now.");
			}
		}

		public string Tag()
		{
			return $"quartrond_Apply-{{replaceme}}_Scene-{SceneId}_Element-{Guid} ";
		}

		public string Tag(int i)
		{
			return $"quartrond_Apply-{{replaceme}}_Scene-{SceneId}_Element-{Guid}_Item-{i}";
		}
	}
}
