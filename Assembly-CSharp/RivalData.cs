using System;
using UnityEngine;

// Token: 0x020002B2 RID: 690
[Serializable]
public class RivalData
{
	// Token: 0x06001456 RID: 5206 RVA: 0x000C6841 File Offset: 0x000C4A41
	public RivalData(int week)
	{
		this.week = week;
	}

	// Token: 0x17000367 RID: 871
	// (get) Token: 0x06001457 RID: 5207 RVA: 0x000C6850 File Offset: 0x000C4A50
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x04001F4D RID: 8013
	[SerializeField]
	private int week;
}
