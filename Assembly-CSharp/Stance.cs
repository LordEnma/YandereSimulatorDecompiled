using System;
using UnityEngine;

// Token: 0x020002B3 RID: 691
[Serializable]
public class Stance
{
	// Token: 0x0600144C RID: 5196 RVA: 0x000C59B8 File Offset: 0x000C3BB8
	public Stance(StanceType initialStance)
	{
		this.current = initialStance;
		this.previous = initialStance;
	}

	// Token: 0x17000368 RID: 872
	// (get) Token: 0x0600144D RID: 5197 RVA: 0x000C59CE File Offset: 0x000C3BCE
	// (set) Token: 0x0600144E RID: 5198 RVA: 0x000C59D6 File Offset: 0x000C3BD6
	public StanceType Current
	{
		get
		{
			return this.current;
		}
		set
		{
			this.previous = this.current;
			this.current = value;
		}
	}

	// Token: 0x17000369 RID: 873
	// (get) Token: 0x0600144F RID: 5199 RVA: 0x000C59EB File Offset: 0x000C3BEB
	public StanceType Previous
	{
		get
		{
			return this.previous;
		}
	}

	// Token: 0x04001F2A RID: 7978
	[SerializeField]
	private StanceType current;

	// Token: 0x04001F2B RID: 7979
	[SerializeField]
	private StanceType previous;
}
