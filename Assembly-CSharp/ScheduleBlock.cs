using System;

// Token: 0x020002B8 RID: 696
[Serializable]
public class ScheduleBlock
{
	// Token: 0x06001462 RID: 5218 RVA: 0x000C7285 File Offset: 0x000C5485
	public ScheduleBlock(float time, string destination, string action)
	{
		this.time = time;
		this.destination = destination;
		this.action = action;
	}

	// Token: 0x04001F66 RID: 8038
	public float time;

	// Token: 0x04001F67 RID: 8039
	public string destination;

	// Token: 0x04001F68 RID: 8040
	public string action;
}
