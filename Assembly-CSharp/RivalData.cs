using System;
using UnityEngine;

// Token: 0x020002B1 RID: 689
[Serializable]
public class RivalData
{
	// Token: 0x0600144A RID: 5194 RVA: 0x000C59A1 File Offset: 0x000C3BA1
	public RivalData(int week)
	{
		this.week = week;
	}

	// Token: 0x17000367 RID: 871
	// (get) Token: 0x0600144B RID: 5195 RVA: 0x000C59B0 File Offset: 0x000C3BB0
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x04001F25 RID: 7973
	[SerializeField]
	private int week;
}
