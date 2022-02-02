using System;

// Token: 0x020002B6 RID: 694
[Serializable]
public class ScheduleBlock
{
	// Token: 0x06001454 RID: 5204 RVA: 0x000C6769 File Offset: 0x000C4969
	public ScheduleBlock(float time, string destination, string action)
	{
		this.time = time;
		this.destination = destination;
		this.action = action;
	}

	// Token: 0x04001F4F RID: 8015
	public float time;

	// Token: 0x04001F50 RID: 8016
	public string destination;

	// Token: 0x04001F51 RID: 8017
	public string action;
}
