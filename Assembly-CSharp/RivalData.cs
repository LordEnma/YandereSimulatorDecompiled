using System;
using UnityEngine;

// Token: 0x020002B3 RID: 691
[Serializable]
public class RivalData
{
	// Token: 0x06001461 RID: 5217 RVA: 0x000C70BD File Offset: 0x000C52BD
	public RivalData(int week)
	{
		this.week = week;
	}

	// Token: 0x17000367 RID: 871
	// (get) Token: 0x06001462 RID: 5218 RVA: 0x000C70CC File Offset: 0x000C52CC
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x04001F5D RID: 8029
	[SerializeField]
	private int week;
}
