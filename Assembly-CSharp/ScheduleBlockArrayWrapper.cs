using System;

// Token: 0x02000498 RID: 1176
[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
	// Token: 0x06001F5B RID: 8027 RVA: 0x001BDDCD File Offset: 0x001BBFCD
	public ScheduleBlockArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F5C RID: 8028 RVA: 0x001BDDD6 File Offset: 0x001BBFD6
	public ScheduleBlockArrayWrapper(ScheduleBlock[] elements) : base(elements)
	{
	}
}
