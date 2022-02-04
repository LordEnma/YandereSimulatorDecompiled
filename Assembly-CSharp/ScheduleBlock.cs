using System;

// Token: 0x020002B6 RID: 694
[Serializable]
public class ScheduleBlock
{
	// Token: 0x06001454 RID: 5204 RVA: 0x000C681D File Offset: 0x000C4A1D
	public ScheduleBlock(float time, string destination, string action)
	{
		this.time = time;
		this.destination = destination;
		this.action = action;
	}

	// Token: 0x04001F50 RID: 8016
	public float time;

	// Token: 0x04001F51 RID: 8017
	public string destination;

	// Token: 0x04001F52 RID: 8018
	public string action;
}
