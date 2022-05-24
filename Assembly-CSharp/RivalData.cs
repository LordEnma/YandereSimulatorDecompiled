using System;
using UnityEngine;

// Token: 0x020002B4 RID: 692
[Serializable]
public class RivalData
{
	// Token: 0x06001463 RID: 5219 RVA: 0x000C7445 File Offset: 0x000C5645
	public RivalData(int week)
	{
		this.week = week;
	}

	// Token: 0x17000367 RID: 871
	// (get) Token: 0x06001464 RID: 5220 RVA: 0x000C7454 File Offset: 0x000C5654
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x04001F64 RID: 8036
	[SerializeField]
	private int week;
}
