using System;

// Token: 0x020002B8 RID: 696
[Serializable]
public class ScheduleBlock
{
	// Token: 0x06001465 RID: 5221 RVA: 0x000C7841 File Offset: 0x000C5A41
	public ScheduleBlock(float time, string destination, string action)
	{
		this.time = time;
		this.destination = destination;
		this.action = action;
	}

	// Token: 0x04001F7F RID: 8063
	public float time;

	// Token: 0x04001F80 RID: 8064
	public string destination;

	// Token: 0x04001F81 RID: 8065
	public string action;
}
