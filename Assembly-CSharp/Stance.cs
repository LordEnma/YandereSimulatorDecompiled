using System;
using UnityEngine;

// Token: 0x020002B4 RID: 692
[Serializable]
public class Stance
{
	// Token: 0x06001459 RID: 5209 RVA: 0x000C698C File Offset: 0x000C4B8C
	public Stance(StanceType initialStance)
	{
		this.current = initialStance;
		this.previous = initialStance;
	}

	// Token: 0x17000368 RID: 872
	// (get) Token: 0x0600145A RID: 5210 RVA: 0x000C69A2 File Offset: 0x000C4BA2
	// (set) Token: 0x0600145B RID: 5211 RVA: 0x000C69AA File Offset: 0x000C4BAA
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
	// (get) Token: 0x0600145C RID: 5212 RVA: 0x000C69BF File Offset: 0x000C4BBF
	public StanceType Previous
	{
		get
		{
			return this.previous;
		}
	}

	// Token: 0x04001F55 RID: 8021
	[SerializeField]
	private StanceType current;

	// Token: 0x04001F56 RID: 8022
	[SerializeField]
	private StanceType previous;
}
