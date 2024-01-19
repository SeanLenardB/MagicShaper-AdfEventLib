using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	public static class ExtensionSharedConstants
	{
		public const int TileWidth = 150;

		public const int CanvasWidth = 1778;
		public const int CanvasHeight = 1000;


		/*
		* Decoration Depth:
		* Back 100 ~ -100 Front
		*/

		public const string SingleDecorationManipulationTagPrefix = "quartrond_singleDecorationManipulation";
		public const int SingleDecorationManipulationDepth = -10;

		public const string TextRenderTagPrefix = "quartrond_textRender";
		public const int TextRenderDepth = -95;
		
		public const string LyricsTagPrefix = "quartrond_lyrics";
		public const int LyricsDepth = -96;

		public const string UpliftParticlesBackgroundTagPrefix = "quartrond_upliftParticlesBackground";
		public const string UpliftParticlesForegroundTagPrefix = "quartrond_upliftParticlesForeground";
		public const int UpliftParticlesBackgroundDepth = 80;
		public const int UpliftParticlesForegroundDepth = -80;

		public const string DecoBgImageTagPrefix = "quartrond_backgroundImage";
		public const int DecoBgImageDepth = 90;

		public const string ShapeFocusOnTileTagPrefix = "quartrond_shapeFocusOnTile";
		public const int ShapeFocusOnTileDepth = 10;
		public const string SneakImageVisionTagPrefix = "quartrond_sneakImageVision";
		public const int SneakImageVisionDepth = 11;

		public const string VisionLimitTagPrefix = "quartrond_visionLimit";
		public const int VisionLimitDepth = -90;
		
		public const string FloatingTrackBackgroundTagPrefix = "quartrond_floatingTrack";
		public const int FloatingTrackBackgroundDepth = 70;

		public const string FloatingPlanetBackgroundTagPrefix = "quartrond_floatingPlanet";
		public const int FloatingPlanetBackgroundDepth = 65;
	}
}
