using System;

// Token: 0x020002B6 RID: 694
[Serializable]
public class ScheduleBlock
{
	// Token: 0x06001453 RID: 5203 RVA: 0x000C6565 File Offset: 0x000C4765
	public ScheduleBlock(float time, string destination, string action)
	{
		this.time = time;
		this.destination = destination;
		this.action = action;
	}

	// Token: 0x04001F4B RID: 8011
	public float time;

	// Token: 0x04001F4C RID: 8012
	public string destination;

	// Token: 0x04001F4D RID: 8013
	public string action;
}
