using System;

// Token: 0x020002B9 RID: 697
[Serializable]
public class ScheduleBlock
{
	// Token: 0x0600146C RID: 5228 RVA: 0x000C7C29 File Offset: 0x000C5E29
	public ScheduleBlock(float time, string destination, string action)
	{
		this.time = time;
		this.destination = destination;
		this.action = action;
	}

	// Token: 0x04001F86 RID: 8070
	public float time;

	// Token: 0x04001F87 RID: 8071
	public string destination;

	// Token: 0x04001F88 RID: 8072
	public string action;
}
