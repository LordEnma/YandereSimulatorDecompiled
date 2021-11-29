using System;
using UnityEngine;

// Token: 0x020002AE RID: 686
[Serializable]
public class RivalData
{
	// Token: 0x06001439 RID: 5177 RVA: 0x000C4889 File Offset: 0x000C2A89
	public RivalData(int week)
	{
		this.week = week;
	}

	// Token: 0x17000367 RID: 871
	// (get) Token: 0x0600143A RID: 5178 RVA: 0x000C4898 File Offset: 0x000C2A98
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x04001EF2 RID: 7922
	[SerializeField]
	private int week;
}
