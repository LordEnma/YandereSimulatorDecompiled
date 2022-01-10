using System;

// Token: 0x020002B6 RID: 694
[Serializable]
public class ScheduleBlock
{
	// Token: 0x06001453 RID: 5203 RVA: 0x000C6491 File Offset: 0x000C4691
	public ScheduleBlock(float time, string destination, string action)
	{
		this.time = time;
		this.destination = destination;
		this.action = action;
	}

	// Token: 0x04001F48 RID: 8008
	public float time;

	// Token: 0x04001F49 RID: 8009
	public string destination;

	// Token: 0x04001F4A RID: 8010
	public string action;
}
