using System;
using UnityEngine;

// Token: 0x020002B2 RID: 690
[Serializable]
public class RivalData
{
	// Token: 0x06001457 RID: 5207 RVA: 0x000C6975 File Offset: 0x000C4B75
	public RivalData(int week)
	{
		this.week = week;
	}

	// Token: 0x17000367 RID: 871
	// (get) Token: 0x06001458 RID: 5208 RVA: 0x000C6984 File Offset: 0x000C4B84
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x04001F50 RID: 8016
	[SerializeField]
	private int week;
}
