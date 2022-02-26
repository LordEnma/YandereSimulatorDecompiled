using System;
using UnityEngine;

// Token: 0x020002B2 RID: 690
[Serializable]
public class RivalData
{
	// Token: 0x06001453 RID: 5203 RVA: 0x000C6285 File Offset: 0x000C4485
	public RivalData(int week)
	{
		this.week = week;
	}

	// Token: 0x17000367 RID: 871
	// (get) Token: 0x06001454 RID: 5204 RVA: 0x000C6294 File Offset: 0x000C4494
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x04001F34 RID: 7988
	[SerializeField]
	private int week;
}
