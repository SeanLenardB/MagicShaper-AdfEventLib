using MagicShaper.AdofaiCore.AdfClass;

namespace MagicShaper.AdofaiCore.AdfEvents
{
	public interface IAdfEvent
	{
		string EventType { get; }

		string JsonString(int tileIndex);

	}
	public interface IAdfEventAngleOffsetable : IAdfEvent
	{
		double AngleOffset { get; set; }
	}

	public interface IAdfEventEaseable : IAdfEvent
	{
		AdfEaseType Ease { get; set; }

		double Duration { get; set; }
	}

	public interface IAdfEventTaggable : IAdfEvent
	{
		string EventTag { get; set; }
	}

}