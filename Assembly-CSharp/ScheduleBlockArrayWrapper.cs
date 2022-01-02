using System;

// Token: 0x0200048C RID: 1164
[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
	// Token: 0x06001F0A RID: 7946 RVA: 0x001B69F9 File Offset: 0x001B4BF9
	public ScheduleBlockArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F0B RID: 7947 RVA: 0x001B6A02 File Offset: 0x001B4C02
	public ScheduleBlockArrayWrapper(ScheduleBlock[] elements) : base(elements)
	{
	}
}
