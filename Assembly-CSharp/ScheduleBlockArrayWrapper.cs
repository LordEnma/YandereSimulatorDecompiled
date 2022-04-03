using System;

// Token: 0x02000497 RID: 1175
[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
	// Token: 0x06001F4D RID: 8013 RVA: 0x001BCEE9 File Offset: 0x001BB0E9
	public ScheduleBlockArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F4E RID: 8014 RVA: 0x001BCEF2 File Offset: 0x001BB0F2
	public ScheduleBlockArrayWrapper(ScheduleBlock[] elements) : base(elements)
	{
	}
}
