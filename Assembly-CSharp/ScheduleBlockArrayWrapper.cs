using System;

// Token: 0x0200048F RID: 1167
[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
	// Token: 0x06001F1E RID: 7966 RVA: 0x001B8A9D File Offset: 0x001B6C9D
	public ScheduleBlockArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F1F RID: 7967 RVA: 0x001B8AA6 File Offset: 0x001B6CA6
	public ScheduleBlockArrayWrapper(ScheduleBlock[] elements) : base(elements)
	{
	}
}
