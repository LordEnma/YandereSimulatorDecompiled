using System;
using UnityEngine;

// Token: 0x020002B1 RID: 689
[Serializable]
public class Stance
{
	// Token: 0x06001442 RID: 5186 RVA: 0x000C5028 File Offset: 0x000C3228
	public Stance(StanceType initialStance)
	{
		this.current = initialStance;
		this.previous = initialStance;
	}

	// Token: 0x17000368 RID: 872
	// (get) Token: 0x06001443 RID: 5187 RVA: 0x000C503E File Offset: 0x000C323E
	// (set) Token: 0x06001444 RID: 5188 RVA: 0x000C5046 File Offset: 0x000C3246
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
	// (get) Token: 0x06001445 RID: 5189 RVA: 0x000C505B File Offset: 0x000C325B
	public StanceType Previous
	{
		get
		{
			return this.previous;
		}
	}

	// Token: 0x04001F17 RID: 7959
	[SerializeField]
	private StanceType current;

	// Token: 0x04001F18 RID: 7960
	[SerializeField]
	private StanceType previous;
}
