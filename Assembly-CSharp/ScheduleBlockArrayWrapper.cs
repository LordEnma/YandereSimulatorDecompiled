using System;

// Token: 0x0200048F RID: 1167
[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
	// Token: 0x06001F1B RID: 7963 RVA: 0x001B887D File Offset: 0x001B6A7D
	public ScheduleBlockArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F1C RID: 7964 RVA: 0x001B8886 File Offset: 0x001B6A86
	public ScheduleBlockArrayWrapper(ScheduleBlock[] elements) : base(elements)
	{
	}
}
