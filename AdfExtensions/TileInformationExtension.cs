using MagicShaper.AdofaiCore.AdfClass;
using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdfExtensions
{
	internal static class TileInformationExtension
	{
		/// <summary>
		/// use this only when you have modified any <see cref="AdfEventSetSpeed"></see>
		/// and want all tile bpm refreshed
		/// </summary>
		/// <param name="chart"></param>
		/// <param name="tileIndex"></param>
		/// <returns></returns>
		public static void RecalcTileBpm(this AdfChart chart)
		{
			Console.WriteLine("[TileInformationExtension] Recalculating Tile Bpm");
			BpmLookupTable = new();
			double firstBpm = chart.ChartJson["settings"]!["bpm"]!.GetValue<double>();
			for (int tileIndex = 0; tileIndex < chart.ChartTiles.Count; tileIndex++)
			{
				AdfTile tile = chart.ChartTiles[tileIndex];
				
				if (tile.IsFirstTile) 
				{
					BpmLookupTable.Add(tileIndex, firstBpm);
					continue;
				}

				foreach (var e in tile.TileEvents)
				{
					if (e is AdfEventSetSpeed es)
					{
						if (es.SpeedType == AdfEventSpeedType.Bpm)
						{
							BpmLookupTable.Add(tileIndex, es.BeatsPerMinute);
						}
						else
						{
							BpmLookupTable.Add(tileIndex, es.BpmMultiplier * chart.GetTileBpmAt(tileIndex - 1));
						}
					}
				}
				if (BpmLookupTable.ContainsKey(tileIndex)) { continue; }

				BpmLookupTable.Add(tileIndex, chart.GetTileBpmAt(tileIndex - 1));
            }
			Console.WriteLine("[TileInformationExtension] Recalculated Tile Bpm");

		}

		private static Dictionary<int, double> BpmLookupTable = new();

		public static double GetTileBpmAt(this AdfChart chart, int tileIndex) 
		{ 
			try
			{
				return BpmLookupTable[tileIndex];
			}
			catch
			{
                BpmLookupTable = new();
				chart.RecalcTileBpm();
				return BpmLookupTable[tileIndex];
			}
		}


		private static Dictionary<int, bool> IsLHSTable = new();

		public static bool GetIsLHSAt(this AdfChart chart, int tileIndex)
		{
			try
			{
				return IsLHSTable[tileIndex];
			}
			catch
			{
				IsLHSTable = new();
				chart.RecalcLHS();
				return IsLHSTable[tileIndex];
			}
		}

		/// <summary>
		/// use this only when you have modified any <see cref="AdfEventTwirl"></see>
		/// and want all lhs/rhs refreshed
		/// </summary>
		/// <param name="chart"></param>
		/// <param name="tileIndex"></param>
		/// <returns></returns>
		public static void RecalcLHS(this AdfChart chart)
		{
			IsLHSTable = new();

			for (int tileIndex = 0; tileIndex < chart.ChartTiles.Count; tileIndex++)
			{
				AdfTile tile = chart.ChartTiles[tileIndex];

				if (tile.IsFirstTile)
				{
					IsLHSTable.Add(tileIndex, true);
					continue;
				}

				IsLHSTable.Add(tileIndex, IsLHSTable[tileIndex - 1]);
				foreach (var e in tile.TileEvents)
				{
					if (e is AdfEventTwirl)
					{
						IsLHSTable[tileIndex] = !IsLHSTable[tileIndex - 1];
						break;
					}
				}
			}

		}
	}
}
