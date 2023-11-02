﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfClass
{
	internal class AdfNullableConverter<TEnum> : JsonConverter<TEnum?> where TEnum : struct
	{
		public override TEnum? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetString() is null ? null : Enum.Parse<TEnum>(reader.GetString()!);
		}

		public override void Write(Utf8JsonWriter writer, TEnum? value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToString());
		}



	}
}
