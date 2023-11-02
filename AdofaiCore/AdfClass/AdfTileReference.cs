using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfClass
{
	internal class AdfTileReference
	{
		public AdfTileReference(int positionOffset, AdfTileReferenceType tileReferenceType)
		{
			PositionOffset = positionOffset;
			TileReferenceType = tileReferenceType;
		}

		public int PositionOffset { get; set; }

		public AdfTileReferenceType TileReferenceType { get; set; }

		public override string ToString()
		{
			return $"[{PositionOffset}, \"{TileReferenceType}\"]";
		}

		public class AdfTileReferenceConverter : JsonConverter<AdfTileReference>
		{
			public override AdfTileReference? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			{
				reader.Read();
				int x = reader.GetInt32();
				reader.Read();
				string y = reader.GetString()!;
				reader.Read();
				return new(x, Enum.Parse<AdfTileReferenceType>(y));
			}

			public override void Write(Utf8JsonWriter writer, AdfTileReference value, JsonSerializerOptions options)
			{
				writer.WriteStartArray();
				writer.WriteNumberValue(value.PositionOffset);
				writer.WriteStringValue(value.TileReferenceType.ToString());

				writer.WriteEndArray();
			}
		}
	}
}
