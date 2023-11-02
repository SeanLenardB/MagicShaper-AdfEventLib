using MagicShaper.AdofaiCore.AdfEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfClass
{
    internal class AdfChart
    {
        public AdfChart(List<AdfTile> chartTiles, JsonObject chartJson)
        {
            ChartTiles = chartTiles;
			_chartJson = chartJson;
        }

        public List<AdfTile> ChartTiles { get; set; }

        private JsonObject _chartJson;

        public JsonObject ChartJson
		{
			get
			{
				_chartJson["actions"]!.AsArray().Clear();
                _chartJson["actions"] = JsonNode.Parse('[' + GetEvents() + ']',
										  null,
										  new System.Text.Json.JsonDocumentOptions() { AllowTrailingCommas = true })!.AsArray();
				return _chartJson;
			}
            init 
            {
                _chartJson = value;
			}
		}

		internal static AdfChart ParseJsonToChart(JsonDocument chartJson)
        {
            List<AdfTile> tiles = new();
            foreach (var o in chartJson.RootElement.GetProperty("angleData").EnumerateArray())
            {
                double angle = o.GetDouble();

                if (tiles.Count == 0)
                {
                    tiles.Add(new(angle, null, new()));
                }
                else
                {
                    tiles.Add(new(angle, tiles[^1], new()));
                }
            }


            foreach (var action in chartJson.RootElement.GetProperty("actions").EnumerateArray())
            {

                var tileAction = ParseAction(action);
                if (tileAction is not null)
                {
                    tiles[action.GetProperty("floor").GetInt32()].TileEvents.Add(tileAction);
                }
            }

            return new AdfChart(tiles, JsonNode.Parse(chartJson.RootElement.ToString(), null, new() { AllowTrailingCommas = true })!.AsObject());

        }

        internal static AdfChart ParseChart(string chartText) => ParseJsonToChart(JsonDocument.Parse(chartText, new() { AllowTrailingCommas = true }));

        
        
        
        internal string GetEvents()
        {
            StringBuilder sb = new();

            foreach (var tile in ChartTiles)
            {
                foreach (var action in tile.TileEvents)
                {
                    sb.AppendLine(action.JsonString(tile.TileIndex) + ',');

                }
            }
            return sb.ToString().Replace("True", "true").Replace("False", "false");
        }


        public static IAdfEvent? ParseAction(JsonElement action)
        {
			JsonSerializerOptions option = new()
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,

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
			option.Converters.Add(new AdfConverter<AdfEventSpeedType>());

			option.Converters.Add(new AdfPosition.AdfPositionConverter());
			option.Converters.Add(new AdfTileReference.AdfTileReferenceConverter());
			option.Converters.Add(new AdfColor.AdfColorConverter());

            List<IAdfEvent> events = new()
            {
                new AdfEventAnimateTrack(),
                new AdfEventAutoPlayTiles(),
                new AdfEventBloom(),
                new AdfEventCheckpoint(),
                new AdfEventColorTrack(),
                new AdfEventCustomBackground(),
                new AdfEventFlash(),
                new AdfEventHallOfMirrors(),
                new AdfEventMoveCamera(),
                new AdfEventMoveDecorations(),
                new AdfEventMoveTrack(),
                new AdfEventPause(),
                new AdfEventPositionTrack(),
                new AdfEventRecolorTrack(),
                new AdfEventRepeatEvents(),
                new AdfEventScalePlanets(),
                new AdfEventScreenScroll(),
                new AdfEventScreenTile(),
                new AdfEventSetConditionalEvents(),
                new AdfEventSetFilter(),
                new AdfEventSetHitsound(),
                new AdfEventSetPlanetRotation(),
                new AdfEventSetSpeed(),
                new AdfEventSetText(),
                new AdfEventShakeScreen(),
                new AdfEventTwirl(),

            };

			foreach (var e in events)
            {
                if (action.GetProperty("eventType").GetString() == e.EventType)
                {
                    return (IAdfEvent?)action.Deserialize(e.GetType(), option);
				}
            }

            return null;


			/* "SetSpeed" => new AdfEventSetSpeed(
				action["angleOffset"]!.GetValue<double>(),
				Enum.Parse<AdfEventSpeedType>(action["speedType"]!.GetValue<string>()),
				action["beatsPerMinute"]!.GetValue<double>(),
				action["bpmMultiplier"]!.GetValue<double>()),
			"Twirl" => new AdfEventTwirl(),
			"SetHitsound" => new AdfEventSetHitsound(
                Enum.Parse<AdfGameSoundType>(action["gameSound"]!.GetValue<string>()),
                new(
					Enum.Parse<AdfHitsoundType>(action["hitsound"]!.GetValue<string>()),
					action["hitsoundVolume"]!.GetValue<int>())),
            "AutoPlayTiles" => new AdfEventAutoPlayTiles(
				action["enabled"]!.GetValue<bool>(),
				action["showStatusText"]!.GetValue<bool>()),
			"ColorTrack" => new AdfEventColorTrack(
                new(
					Enum.Parse<AdfTrackColorType>(action["trackColorType"]!.GetValue<string>()),
					new(action["trackColor"]!.GetValue<string>()),
					new(action["secondaryTrackColor"]!.GetValue<string>()),
					action["trackColorAnimDuration"]!.GetValue<double>(),
					Enum.Parse<AdfTrackColorPulseType>(action["trackColorPulse"]!.GetValue<string>()),
					action["trackPulseLength"]!.GetValue<int>(),
					Enum.Parse<AdfTrackStyle>(action["trackStyle"]!.GetValue<string>()),
					action["trackTexture"]!.GetValue<string>(),
					action["trackTextureScale"]!.GetValue<double>(),
					action["trackGlowIntensity"]!.GetValue<double>())),
			"RecolorTrack" => new AdfEventRecolorTrack(
                action["eventTag"]!.GetValue<string>(), 
                action["angleOffset"]!.GetValue<double>(),
				new(Enum.Parse<AdfEaseType>(action["ease"]!.GetValue<string>()), action["duration"]!.GetValue<double>()),
				new(action["startTile"]!.AsArray()[0]!.GetValue<int>(), Enum.Parse<AdfTileReferenceType>(action["startTile"]!.AsArray()[1]!.GetValue<string>())), 
                new(action["endTile"]!.AsArray()[0]!.GetValue<int>(), Enum.Parse<AdfTileReferenceType>(action["endTile"]!.AsArray()[1]!.GetValue<string>())), 
                action["gapLength"]!.GetValue<int>(), 
                new(
				    Enum.Parse<AdfTrackColorType>(action["trackColorType"]!.GetValue<string>()),
				    new(action["trackColor"]!.GetValue<string>()),
				    new(action["secondaryTrackColor"]!.GetValue<string>()),
				    action["trackColorAnimDuration"]!.GetValue<double>(),
				    Enum.Parse<AdfTrackColorPulseType>(action["trackColorPulse"]!.GetValue<string>()),
				    action["trackPulseLength"]!.GetValue<int>(),
				    Enum.Parse<AdfTrackStyle>(action["trackStyle"]!.GetValue<string>()),
                    "",
                    1d,
				    action["trackGlowIntensity"]!.GetValue<double>())),
            "PositionTrack" => new AdfEventPositionTrack(
                new(action["positionOffset"]!.AsArray()[0]!.GetValue<double>(), action["positionOffset"]!.AsArray()[1]!.GetValue<double>()),
				new(action["relativeTo"]!.AsArray()[0]!.GetValue<int>(), Enum.Parse<AdfTileReferenceType>(action["relativeTo"]!.AsArray()[1]!.GetValue<string>())),
                action["rotation"]!.GetValue<double>(),
                action["scale"]!.GetValue<double>(),
                action["opacity"]!.GetValue<double>(),
                action["justThisTile"]!.GetValue<bool>(),
                action["editorOnly"]!.GetValue<bool>()),
            "Flash" => new AdfEventFlash(
				action["angleOffset"]!.GetValue<double>(),
				action["eventTag"]!.GetValue<string>(),
                new(Enum.Parse<AdfEaseType>(action["ease"]!.GetValue<string>()), action["duration"]!.GetValue<double>()),
                Enum.Parse<AdfFlashPlaneType>(action["plane"]!.GetValue<string>()),
                new(action["startColor"]!.GetValue<string>()),
                new(action["endColor"]!.GetValue<string>()),
                action["startOpacity"]!.GetValue<double>(),
                action["endOpacity"]!.GetValue<double>()),
            "SetFilter" => new AdfEventSetFilter(
				action["eventTag"]!.GetValue<string>(),
				action["angleOffset"]!.GetValue<double>(),
				new(Enum.Parse<AdfEaseType>(action["ease"]!.GetValue<string>()), action["duration"]!.GetValue<double>()),
				action["enabled"]!.GetValue<bool>(),
				action["intensity"]!.GetValue<double>(),
				action["disableOthers"]!.GetValue<bool>(),
                Enum.Parse<AdfFilter>(action["filter"]!.GetValue<string>())),
            "Bloom" => new AdfEventBloom(
                action["eventTag"]!.GetValue<string>(),
				action["angleOffset"]!.GetValue<double>(),
				new(Enum.Parse<AdfEaseType>(action["ease"]!.GetValue<string>()), action["duration"]!.GetValue<double>()),
				action["enabled"]!.GetValue<bool>(),
				action["threshold"]!.GetValue<double>(),
				action["intensity"]!.GetValue<double>(),
                new(action["color"]!.GetValue<string>())), */
        }
    }
}
