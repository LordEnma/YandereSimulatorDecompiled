using System;

// Token: 0x0200048B RID: 1163
[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
	// Token: 0x06001EFD RID: 7933 RVA: 0x001B5765 File Offset: 0x001B3965
	public ScheduleBlockArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001EFE RID: 7934 RVA: 0x001B576E File Offset: 0x001B396E
	public ScheduleBlockArrayWrapper(ScheduleBlock[] elements) : base(elements)
	{
	}
}
