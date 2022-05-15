using System;

// Token: 0x0200049A RID: 1178
[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
	// Token: 0x06001F6E RID: 8046 RVA: 0x001C041D File Offset: 0x001BE61D
	public ScheduleBlockArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F6F RID: 8047 RVA: 0x001C0426 File Offset: 0x001BE626
	public ScheduleBlockArrayWrapper(ScheduleBlock[] elements) : base(elements)
	{
	}
}
