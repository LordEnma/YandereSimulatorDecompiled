using System;

[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
	public ScheduleBlockArrayWrapper(int size)
		: base(size)
	{
	}

	public ScheduleBlockArrayWrapper(ScheduleBlock[] elements)
		: base(elements)
	{
	}
}
