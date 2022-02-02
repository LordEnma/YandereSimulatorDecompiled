using System;

// Token: 0x0200048F RID: 1167
[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
	// Token: 0x06001F19 RID: 7961 RVA: 0x001B8571 File Offset: 0x001B6771
	public ScheduleBlockArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F1A RID: 7962 RVA: 0x001B857A File Offset: 0x001B677A
	public ScheduleBlockArrayWrapper(ScheduleBlock[] elements) : base(elements)
	{
	}
}
