using System;
using UnityEngine;

// Token: 0x020002B4 RID: 692
[Serializable]
public class Stance
{
	// Token: 0x06001458 RID: 5208 RVA: 0x000C6858 File Offset: 0x000C4A58
	public Stance(StanceType initialStance)
	{
		this.current = initialStance;
		this.previous = initialStance;
	}

	// Token: 0x17000368 RID: 872
	// (get) Token: 0x06001459 RID: 5209 RVA: 0x000C686E File Offset: 0x000C4A6E
	// (set) Token: 0x0600145A RID: 5210 RVA: 0x000C6876 File Offset: 0x000C4A76
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
	// (get) Token: 0x0600145B RID: 5211 RVA: 0x000C688B File Offset: 0x000C4A8B
	public StanceType Previous
	{
		get
		{
			return this.previous;
		}
	}

	// Token: 0x04001F52 RID: 8018
	[SerializeField]
	private StanceType current;

	// Token: 0x04001F53 RID: 8019
	[SerializeField]
	private StanceType previous;
}
