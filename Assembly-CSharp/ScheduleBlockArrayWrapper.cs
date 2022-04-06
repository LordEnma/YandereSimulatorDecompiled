using System;

// Token: 0x02000498 RID: 1176
[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
	// Token: 0x06001F55 RID: 8021 RVA: 0x001BD3F1 File Offset: 0x001BB5F1
	public ScheduleBlockArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F56 RID: 8022 RVA: 0x001BD3FA File Offset: 0x001BB5FA
	public ScheduleBlockArrayWrapper(ScheduleBlock[] elements) : base(elements)
	{
	}
}
