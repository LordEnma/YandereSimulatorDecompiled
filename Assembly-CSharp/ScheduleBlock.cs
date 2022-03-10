using System;

// Token: 0x020002B8 RID: 696
[Serializable]
public class ScheduleBlock
{
	// Token: 0x06001462 RID: 5218 RVA: 0x000C73D1 File Offset: 0x000C55D1
	public ScheduleBlock(float time, string destination, string action)
	{
		this.time = time;
		this.destination = destination;
		this.action = action;
	}

	// Token: 0x04001F6F RID: 8047
	public float time;

	// Token: 0x04001F70 RID: 8048
	public string destination;

	// Token: 0x04001F71 RID: 8049
	public string action;
}
