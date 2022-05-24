using System;

// Token: 0x020002BA RID: 698
[Serializable]
public class ScheduleBlock
{
	// Token: 0x06001472 RID: 5234 RVA: 0x000C8445 File Offset: 0x000C6645
	public ScheduleBlock(float time, string destination, string action)
	{
		this.time = time;
		this.destination = destination;
		this.action = action;
	}

	// Token: 0x04001F96 RID: 8086
	public float time;

	// Token: 0x04001F97 RID: 8087
	public string destination;

	// Token: 0x04001F98 RID: 8088
	public string action;
}
