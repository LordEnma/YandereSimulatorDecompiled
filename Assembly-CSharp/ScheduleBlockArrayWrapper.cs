using System;

// Token: 0x02000490 RID: 1168
[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
	// Token: 0x06001F25 RID: 7973 RVA: 0x001B8EF1 File Offset: 0x001B70F1
	public ScheduleBlockArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F26 RID: 7974 RVA: 0x001B8EFA File Offset: 0x001B70FA
	public ScheduleBlockArrayWrapper(ScheduleBlock[] elements) : base(elements)
	{
	}
}
