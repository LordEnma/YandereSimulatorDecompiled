using System;

// Token: 0x0200048E RID: 1166
[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
	// Token: 0x06001F15 RID: 7957 RVA: 0x001B7379 File Offset: 0x001B5579
	public ScheduleBlockArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F16 RID: 7958 RVA: 0x001B7382 File Offset: 0x001B5582
	public ScheduleBlockArrayWrapper(ScheduleBlock[] elements) : base(elements)
	{
	}
}
