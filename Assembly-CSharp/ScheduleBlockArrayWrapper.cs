using System;

// Token: 0x02000494 RID: 1172
[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
	// Token: 0x06001F43 RID: 8003 RVA: 0x001BB95D File Offset: 0x001B9B5D
	public ScheduleBlockArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F44 RID: 8004 RVA: 0x001BB966 File Offset: 0x001B9B66
	public ScheduleBlockArrayWrapper(ScheduleBlock[] elements) : base(elements)
	{
	}
}
