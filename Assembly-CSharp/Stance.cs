using System;
using UnityEngine;

// Token: 0x020002B6 RID: 694
[Serializable]
public class Stance
{
	// Token: 0x06001465 RID: 5221 RVA: 0x000C73C4 File Offset: 0x000C55C4
	public Stance(StanceType initialStance)
	{
		this.current = initialStance;
		this.previous = initialStance;
	}

	// Token: 0x17000368 RID: 872
	// (get) Token: 0x06001466 RID: 5222 RVA: 0x000C73DA File Offset: 0x000C55DA
	// (set) Token: 0x06001467 RID: 5223 RVA: 0x000C73E2 File Offset: 0x000C55E2
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
	// (get) Token: 0x06001468 RID: 5224 RVA: 0x000C73F7 File Offset: 0x000C55F7
	public StanceType Previous
	{
		get
		{
			return this.previous;
		}
	}

	// Token: 0x04001F69 RID: 8041
	[SerializeField]
	private StanceType current;

	// Token: 0x04001F6A RID: 8042
	[SerializeField]
	private StanceType previous;
}
