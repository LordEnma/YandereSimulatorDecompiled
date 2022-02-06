using System;
using UnityEngine;

// Token: 0x020002B0 RID: 688
[Serializable]
public class RivalData
{
	// Token: 0x06001445 RID: 5189 RVA: 0x000C58AD File Offset: 0x000C3AAD
	public RivalData(int week)
	{
		this.week = week;
	}

	// Token: 0x17000367 RID: 871
	// (get) Token: 0x06001446 RID: 5190 RVA: 0x000C58BC File Offset: 0x000C3ABC
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x04001F20 RID: 7968
	[SerializeField]
	private int week;
}
