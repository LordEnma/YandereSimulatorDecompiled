using System;

// Token: 0x020002B7 RID: 695
[Serializable]
public class ScheduleBlock
{
	// Token: 0x06001459 RID: 5209 RVA: 0x000C69A1 File Offset: 0x000C4BA1
	public ScheduleBlock(float time, string destination, string action)
	{
		this.time = time;
		this.destination = destination;
		this.action = action;
	}

	// Token: 0x04001F57 RID: 8023
	public float time;

	// Token: 0x04001F58 RID: 8024
	public string destination;

	// Token: 0x04001F59 RID: 8025
	public string action;
}
