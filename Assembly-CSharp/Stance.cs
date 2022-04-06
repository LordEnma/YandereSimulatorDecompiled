using System;
using UnityEngine;

// Token: 0x020002B5 RID: 693
[Serializable]
public class Stance
{
	// Token: 0x0600145F RID: 5215 RVA: 0x000C6A94 File Offset: 0x000C4C94
	public Stance(StanceType initialStance)
	{
		this.current = initialStance;
		this.previous = initialStance;
	}

	// Token: 0x17000368 RID: 872
	// (get) Token: 0x06001460 RID: 5216 RVA: 0x000C6AAA File Offset: 0x000C4CAA
	// (set) Token: 0x06001461 RID: 5217 RVA: 0x000C6AB2 File Offset: 0x000C4CB2
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
	// (get) Token: 0x06001462 RID: 5218 RVA: 0x000C6AC7 File Offset: 0x000C4CC7
	public StanceType Previous
	{
		get
		{
			return this.previous;
		}
	}

	// Token: 0x04001F57 RID: 8023
	[SerializeField]
	private StanceType current;

	// Token: 0x04001F58 RID: 8024
	[SerializeField]
	private StanceType previous;
}
