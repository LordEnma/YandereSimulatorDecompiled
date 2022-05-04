using System;

// Token: 0x02000499 RID: 1177
[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
	// Token: 0x06001F65 RID: 8037 RVA: 0x001BF285 File Offset: 0x001BD485
	public ScheduleBlockArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F66 RID: 8038 RVA: 0x001BF28E File Offset: 0x001BD48E
	public ScheduleBlockArrayWrapper(ScheduleBlock[] elements) : base(elements)
	{
	}
}
