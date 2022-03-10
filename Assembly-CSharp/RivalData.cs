using System;
using UnityEngine;

// Token: 0x020002B2 RID: 690
[Serializable]
public class RivalData
{
	// Token: 0x06001453 RID: 5203 RVA: 0x000C63D1 File Offset: 0x000C45D1
	public RivalData(int week)
	{
		this.week = week;
	}

	// Token: 0x17000367 RID: 871
	// (get) Token: 0x06001454 RID: 5204 RVA: 0x000C63E0 File Offset: 0x000C45E0
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x04001F3D RID: 7997
	[SerializeField]
	private int week;
}
