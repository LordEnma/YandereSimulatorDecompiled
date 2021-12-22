using System;

// Token: 0x0200048C RID: 1164
[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
	// Token: 0x06001F07 RID: 7943 RVA: 0x001B6521 File Offset: 0x001B4721
	public ScheduleBlockArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F08 RID: 7944 RVA: 0x001B652A File Offset: 0x001B472A
	public ScheduleBlockArrayWrapper(ScheduleBlock[] elements) : base(elements)
	{
	}
}
