using System;

// Token: 0x020002B8 RID: 696
[Serializable]
public class ScheduleBlock
{
	// Token: 0x06001466 RID: 5222 RVA: 0x000C7975 File Offset: 0x000C5B75
	public ScheduleBlock(float time, string destination, string action)
	{
		this.time = time;
		this.destination = destination;
		this.action = action;
	}

	// Token: 0x04001F82 RID: 8066
	public float time;

	// Token: 0x04001F83 RID: 8067
	public string destination;

	// Token: 0x04001F84 RID: 8068
	public string action;
}
