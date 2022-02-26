using System;
using UnityEngine;

// Token: 0x020002B4 RID: 692
[Serializable]
public class Stance
{
	// Token: 0x06001455 RID: 5205 RVA: 0x000C629C File Offset: 0x000C449C
	public Stance(StanceType initialStance)
	{
		this.current = initialStance;
		this.previous = initialStance;
	}

	// Token: 0x17000368 RID: 872
	// (get) Token: 0x06001456 RID: 5206 RVA: 0x000C62B2 File Offset: 0x000C44B2
	// (set) Token: 0x06001457 RID: 5207 RVA: 0x000C62BA File Offset: 0x000C44BA
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
	// (get) Token: 0x06001458 RID: 5208 RVA: 0x000C62CF File Offset: 0x000C44CF
	public StanceType Previous
	{
		get
		{
			return this.previous;
		}
	}

	// Token: 0x04001F39 RID: 7993
	[SerializeField]
	private StanceType current;

	// Token: 0x04001F3A RID: 7994
	[SerializeField]
	private StanceType previous;
}
