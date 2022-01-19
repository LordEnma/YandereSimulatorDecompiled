using System;

// Token: 0x0200048F RID: 1167
[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
	// Token: 0x06001F17 RID: 7959 RVA: 0x001B8049 File Offset: 0x001B6249
	public ScheduleBlockArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F18 RID: 7960 RVA: 0x001B8052 File Offset: 0x001B6252
	public ScheduleBlockArrayWrapper(ScheduleBlock[] elements) : base(elements)
	{
	}
}
