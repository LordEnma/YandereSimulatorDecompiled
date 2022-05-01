using System;

// Token: 0x020002B9 RID: 697
[Serializable]
public class ScheduleBlock
{
	// Token: 0x06001470 RID: 5232 RVA: 0x000C80F1 File Offset: 0x000C62F1
	public ScheduleBlock(float time, string destination, string action)
	{
		this.time = time;
		this.destination = destination;
		this.action = action;
	}

	// Token: 0x04001F8F RID: 8079
	public float time;

	// Token: 0x04001F90 RID: 8080
	public string destination;

	// Token: 0x04001F91 RID: 8081
	public string action;
}
