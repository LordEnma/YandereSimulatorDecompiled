using System;

// Token: 0x02000499 RID: 1177
[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
	// Token: 0x06001F64 RID: 8036 RVA: 0x001BF189 File Offset: 0x001BD389
	public ScheduleBlockArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F65 RID: 8037 RVA: 0x001BF192 File Offset: 0x001BD392
	public ScheduleBlockArrayWrapper(ScheduleBlock[] elements) : base(elements)
	{
	}
}
