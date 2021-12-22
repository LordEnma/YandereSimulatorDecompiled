using System;

// Token: 0x020002B5 RID: 693
[Serializable]
public class ScheduleBlock
{
	// Token: 0x0600144F RID: 5199 RVA: 0x000C6027 File Offset: 0x000C4227
	public ScheduleBlock(float time, string destination, string action)
	{
		this.time = time;
		this.destination = destination;
		this.action = action;
	}

	// Token: 0x04001F44 RID: 8004
	public float time;

	// Token: 0x04001F45 RID: 8005
	public string destination;

	// Token: 0x04001F46 RID: 8006
	public string action;
}
