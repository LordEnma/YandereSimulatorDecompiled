using System;

// Token: 0x020002B5 RID: 693
[Serializable]
public class ScheduleBlock
{
	// Token: 0x0600144F RID: 5199 RVA: 0x000C626F File Offset: 0x000C446F
	public ScheduleBlock(float time, string destination, string action)
	{
		this.time = time;
		this.destination = destination;
		this.action = action;
	}

	// Token: 0x04001F47 RID: 8007
	public float time;

	// Token: 0x04001F48 RID: 8008
	public string destination;

	// Token: 0x04001F49 RID: 8009
	public string action;
}
