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
			var option = AdfChart.GetJsonOptions();
			option.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

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

			return jObject.ToJsonString().Insert(1, this is AdfEventAddDecoration ? "" : $"\"floor\": {tileIndex},");
		}
	}
}
