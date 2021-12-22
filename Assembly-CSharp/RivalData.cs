using System;
using UnityEngine;

// Token: 0x020002AF RID: 687
[Serializable]
public class RivalData
{
	// Token: 0x06001440 RID: 5184 RVA: 0x000C5011 File Offset: 0x000C3211
	public RivalData(int week)
	{
		this.week = week;
	}

	// Token: 0x17000367 RID: 871
	// (get) Token: 0x06001441 RID: 5185 RVA: 0x000C5020 File Offset: 0x000C3220
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x04001F12 RID: 7954
	[SerializeField]
	private int week;
}
