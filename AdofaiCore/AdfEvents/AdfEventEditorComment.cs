using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShaper.AdofaiCore.AdfEvents
{
	internal class AdfEventEditorComment : AdfEventBase
	{
		public override string EventType => "EditorComment";

		public string Comment { get; set; } = "Write your own comment here!\\n\\nMulti-lines and <color=#00FF00>colored</color> texts are also supported.";
	}
}
