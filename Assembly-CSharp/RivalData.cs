using System;
using UnityEngine;

// Token: 0x020002B3 RID: 691
[Serializable]
public class RivalData
{
	// Token: 0x0600145D RID: 5213 RVA: 0x000C6A7D File Offset: 0x000C4C7D
	public RivalData(int week)
	{
		this.week = week;
	}

	// Token: 0x17000367 RID: 871
	// (get) Token: 0x0600145E RID: 5214 RVA: 0x000C6A8C File Offset: 0x000C4C8C
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x04001F52 RID: 8018
	[SerializeField]
	private int week;
}
