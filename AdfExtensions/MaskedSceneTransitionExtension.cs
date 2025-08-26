using MagicShaper.AdfExtensions.DecoScene;
using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	internal static class MaskedSceneTransitionExtension
	{
		internal static ISceneElement FromWithMask(this ISceneElement sceneElement,
			string mask = "mask.png", int depthMin = 50, int depthMax = 60, double duration = 4d, double previewBeats = 2d,
			double scale = 1000, double rotation = 0, double x = 0, double y = 0,
			double dscale = 0, double drotation = 0, double dx = -10, double dy = 0)
		{
			for (int i = 0; i < sceneElement.OnSceneBegin.Count; i++)
			{
				if (sceneElement.OnSceneBegin[i] is AdfEventAddDecoration ad)
				{
					ad.MaskingType = AdfMaskingType.VisibleOutsideMask;
					continue;
				}
				if (sceneElement.OnSceneBegin[i] is AdfEventMoveDecorations am)
				{
					am.AngleOffset -= previewBeats * 180;
				}
			}


			sceneElement.OnSceneBegin.Add(new AdfEventAddDecoration()
			{
				Tag = sceneElement.Tag(-1),
				DecorationImage = mask,
				MaskingType = AdfMaskingType.Mask,

				UseMaskingDepth = true,
				MaskingFrontDepth = depthMin,
				MaskingBackDepth = depthMax,

				Scale = new(scale),
				Rotation = rotation,
				Position = new(x, y),
			});

			sceneElement.OnSceneBegin.Add(new AdfEventMoveDecorations()
			{
				Tag = sceneElement.Tag(-1),
				Duration = duration,
				AngleOffset = - 180 * previewBeats,
				Ease = AdfEaseType.OutCubic,

				PositionOffset = new(dx, dy),
				Scale = new(scale + dscale),
				RotationOffset = drotation
			});

			return sceneElement;

		}
	}
}
