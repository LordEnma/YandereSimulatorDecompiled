using System;
using UnityEngine;

// Token: 0x020002AF RID: 687
[Serializable]
public class RivalData
{
	// Token: 0x06001440 RID: 5184 RVA: 0x000C5259 File Offset: 0x000C3459
	public RivalData(int week)
	{
		this.week = week;
	}

	// Token: 0x17000367 RID: 871
	// (get) Token: 0x06001441 RID: 5185 RVA: 0x000C5268 File Offset: 0x000C3468
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x04001F15 RID: 7957
	[SerializeField]
	private int week;
}
