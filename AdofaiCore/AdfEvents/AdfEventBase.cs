using MagicShaper.AdofaiCore.AdfClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
	internal abstract class AdfEventBase : IAdfEvent
	{
		public virtual string EventType => throw new NotImplementedException();

		public static string EventJson(Dictionary<string, object?> values, int tileIndex, string eventName)
		{
			JsonObject jObject = new();
			foreach (var item in values)
			{
				if (item.Value is not null)
				{
					jObject.Add(item.Key, item.Value.ToString());
				}
			}
			jObject.Add("floor", tileIndex);
			jObject.Add("eventType", eventName);
			return jObject.ToString();
		}

		public string JsonString(int tileIndex)
		{
			JsonSerializerOptions option = new()
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase

			};
			option.Converters.Add(new AdfNullableConverter<AdfTrackAnimationType>());
			option.Converters.Add(new AdfNullableConverter<AdfTrackDisappearAnimationType>());
			option.Converters.Add(new AdfConverter<AdfGameSoundType>());
			option.Converters.Add(new AdfConverter<AdfHitsoundType>());
			option.Converters.Add(new AdfConverter<AdfFilter>());
			option.Converters.Add(new AdfConverter<AdfEaseType>());
			option.Converters.Add(new AdfConverter<AdfEasePartBehaviorType>());
			option.Converters.Add(new AdfConverter<AdfRepeatEventType>());
			option.Converters.Add(new AdfConverter<AdfTrackColorType>());
			option.Converters.Add(new AdfConverter<AdfTrackColorPulseType>());
			option.Converters.Add(new AdfConverter<AdfTrackStyle>());
			option.Converters.Add(new AdfConverter<AdfTargetPlanetType>());

			option.Converters.Add(new AdfPosition.AdfPositionConverter());
			option.Converters.Add(new AdfTileReference.AdfTileReferenceConverter());
			option.Converters.Add(new AdfColor.AdfColorConverter());
			option.Converters.Add(new AdfScale.AdfScaleConverter());

			JsonObject jObject = JsonSerializer.SerializeToNode(this,
				this.GetType(), option)!.AsObject();
			List<string> keys = new();
			foreach (var item in jObject)
			{
				if (item.Value is null)
				{
					keys.Add(item.Key);
				}
			}
			foreach (var key in keys)
			{
				jObject.Remove(key);
			}

			return jObject.ToJsonString().Insert(1, $"\"floor\": {tileIndex}, \"eventType\": \"{EventType}\",");
		}
	}
}
