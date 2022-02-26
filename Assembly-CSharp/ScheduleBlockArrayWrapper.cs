using System;

// Token: 0x02000491 RID: 1169
[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
	// Token: 0x06001F2E RID: 7982 RVA: 0x001B9A3D File Offset: 0x001B7C3D
	public ScheduleBlockArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F2F RID: 7983 RVA: 0x001B9A46 File Offset: 0x001B7C46
	public ScheduleBlockArrayWrapper(ScheduleBlock[] elements) : base(elements)
	{
	}
}
