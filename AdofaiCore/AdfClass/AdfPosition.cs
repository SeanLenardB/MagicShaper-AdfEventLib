using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfClass
{
	internal class AdfPosition
	{
		public AdfPosition(double? x, double? y)
		{
			X = x;
			Y = y;
		}

		public double? X { get; set; }
		public double? Y { get; set; }

		public override string ToString()
		{
			return $"[{(X is null ? "null" : X)}, {(Y is null ? "null" : Y)}]";
		}

		public class AdfPositionConverter : JsonConverter<AdfPosition>
		{
			public override AdfPosition? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			{
                reader.Read();
				double? x = reader.TokenType == JsonTokenType.Null ? null : reader.GetDouble();
				reader.Read();
				double? y = reader.TokenType == JsonTokenType.Null ? null : reader.GetDouble();
				reader.Read();
				return new(x, y);
			}

			public override void Write(Utf8JsonWriter writer, AdfPosition value, JsonSerializerOptions options)
			{
				writer.WriteStartArray();
				if (value.X is not null)
				{
					writer.WriteNumberValue((double)value.X);
				}
				else
				{
					writer.WriteNullValue();
				}

				if (value.Y is not null)
				{
					writer.WriteNumberValue((double)value.Y);
				}
				else
				{
					writer.WriteNullValue();
				}
				writer.WriteEndArray();
			}
		}

	}
}
