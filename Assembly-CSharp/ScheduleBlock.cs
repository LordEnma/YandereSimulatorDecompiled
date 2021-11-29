using System;

// Token: 0x020002B4 RID: 692
[Serializable]
public class ScheduleBlock
{
	// Token: 0x06001448 RID: 5192 RVA: 0x000C588B File Offset: 0x000C3A8B
	public ScheduleBlock(float time, string destination, string action)
	{
		this.time = time;
		this.destination = destination;
		this.action = action;
	}

	// Token: 0x04001F24 RID: 7972
	public float time;

	// Token: 0x04001F25 RID: 7973
	public string destination;

	// Token: 0x04001F26 RID: 7974
	public string action;
}
