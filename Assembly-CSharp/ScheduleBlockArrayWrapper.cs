using System;

// Token: 0x0200049A RID: 1178
[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
	// Token: 0x06001F6F RID: 8047 RVA: 0x001C0899 File Offset: 0x001BEA99
	public ScheduleBlockArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F70 RID: 8048 RVA: 0x001C08A2 File Offset: 0x001BEAA2
	public ScheduleBlockArrayWrapper(ScheduleBlock[] elements) : base(elements)
	{
	}
}
