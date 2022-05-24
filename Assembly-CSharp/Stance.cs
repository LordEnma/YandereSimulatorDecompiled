using System;
using UnityEngine;

// Token: 0x020002B6 RID: 694
[Serializable]
public class Stance
{
	// Token: 0x06001465 RID: 5221 RVA: 0x000C745C File Offset: 0x000C565C
	public Stance(StanceType initialStance)
	{
		this.current = initialStance;
		this.previous = initialStance;
	}

	// Token: 0x17000368 RID: 872
	// (get) Token: 0x06001466 RID: 5222 RVA: 0x000C7472 File Offset: 0x000C5672
	// (set) Token: 0x06001467 RID: 5223 RVA: 0x000C747A File Offset: 0x000C567A
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
	// (get) Token: 0x06001468 RID: 5224 RVA: 0x000C748F File Offset: 0x000C568F
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
