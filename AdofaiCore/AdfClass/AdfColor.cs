using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfClass
{
	internal class AdfColor
	{
		public AdfColor(string colorStr)
		{
			A = 0xff;
			if (colorStr.Length == 8)
			{
				A = (byte)(HexCharToNumber(colorStr[6]) * 0x10 + HexCharToNumber(colorStr[7]) * 0x01);
			}
			R = (byte)(HexCharToNumber(colorStr[0]) * 0x10 + HexCharToNumber(colorStr[1]) * 0x01);
			G = (byte)(HexCharToNumber(colorStr[2]) * 0x10 + HexCharToNumber(colorStr[3]) * 0x01);
			B = (byte)(HexCharToNumber(colorStr[4]) * 0x10 + HexCharToNumber(colorStr[5]) * 0x01);
		}

		public byte R { get; set; }
		public byte G { get; set; }
		public byte B { get; set; }
		public byte A { get; set; }

		public override string ToString() 
		{
			return $"{HexToChar(R/16)}{HexToChar(R%16)}{HexToChar(G/16)}{HexToChar(G%16)}{HexToChar(B/16)}{HexToChar(B%16)}{HexToChar(A/16)}{HexToChar(A%16)}";
		}

		private static byte HexCharToNumber(char hex)
		{
			switch (hex)
			{
				case 'a': return 10;
				case 'b': return 11;
				case 'c': return 12;
				case 'd': return 13;
				case 'e': return 14;
				case 'f': return 15;
				default:
					return byte.Parse(hex.ToString());
			}
		}

		private static char HexToChar(int hex)
		{
			return hex switch
			{
				0 => '0',
				1 => '1',
				2 => '2',
				3 => '3',
				4 => '4',
				5 => '5',
				6 => '6',
				7 => '7',
				8 => '8',
				9 => '9',
				10 => 'a',
				11 => 'b',
				12 => 'c',
				13 => 'd',
				14 => 'e',
				15 => 'f',
				_ => throw new ArgumentOutOfRangeException(),
			};
		}



		public class AdfColorConverter : JsonConverter<AdfColor>
		{
			public override AdfColor? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			{
				return new(reader.GetString()!);
			}

			public override void Write(Utf8JsonWriter writer, AdfColor value, JsonSerializerOptions options)
			{
				writer.WriteStringValue(value.ToString());
			}
		}
	}
}
