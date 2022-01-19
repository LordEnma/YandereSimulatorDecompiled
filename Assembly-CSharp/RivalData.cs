using System;
using UnityEngine;

// Token: 0x020002B0 RID: 688
[Serializable]
public class RivalData
{
	// Token: 0x06001444 RID: 5188 RVA: 0x000C5565 File Offset: 0x000C3765
	public RivalData(int week)
	{
		this.week = week;
	}

	// Token: 0x17000367 RID: 871
	// (get) Token: 0x06001445 RID: 5189 RVA: 0x000C5574 File Offset: 0x000C3774
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x04001F19 RID: 7961
	[SerializeField]
	private int week;
}
