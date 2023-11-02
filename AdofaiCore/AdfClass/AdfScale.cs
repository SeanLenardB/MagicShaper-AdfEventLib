﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfClass
{
	internal class AdfScale
	{
		public AdfScale(double x, double y)
		{
			X = x;
			Y = y;
		}
		
		public AdfScale(double s)
		{
			X = s;
			Y = s;
		}

		public double X { get; set; }
		public double Y { get; set; }

		public override string ToString()
		{
			return $"[{X}, {Y}]";
		}

		public class AdfScaleConverter : JsonConverter<AdfScale>
		{
			public override AdfScale? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			{
				reader.Read();
				double x = reader.GetDouble();
				reader.Read();
				double y = reader.GetDouble();
				reader.Read();
				return new(x, y);
			}

			public override void Write(Utf8JsonWriter writer, AdfScale value, JsonSerializerOptions options)
			{
				writer.WriteStartArray();
				writer.WriteNumberValue(value.X);
				writer.WriteNumberValue(value.Y);


				writer.WriteEndArray();
			}
		}
	}
}
