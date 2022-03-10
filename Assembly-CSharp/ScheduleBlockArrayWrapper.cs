using System;

// Token: 0x02000491 RID: 1169
[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
	// Token: 0x06001F31 RID: 7985 RVA: 0x001BA1DD File Offset: 0x001B83DD
	public ScheduleBlockArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F32 RID: 7986 RVA: 0x001BA1E6 File Offset: 0x001B83E6
	public ScheduleBlockArrayWrapper(ScheduleBlock[] elements) : base(elements)
	{
	}
}
