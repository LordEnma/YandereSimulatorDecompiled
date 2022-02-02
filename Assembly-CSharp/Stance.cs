using System;
using UnityEngine;

// Token: 0x020002B2 RID: 690
[Serializable]
public class Stance
{
	// Token: 0x06001447 RID: 5191 RVA: 0x000C5780 File Offset: 0x000C3980
	public Stance(StanceType initialStance)
	{
		this.current = initialStance;
		this.previous = initialStance;
	}

	// Token: 0x17000368 RID: 872
	// (get) Token: 0x06001448 RID: 5192 RVA: 0x000C5796 File Offset: 0x000C3996
	// (set) Token: 0x06001449 RID: 5193 RVA: 0x000C579E File Offset: 0x000C399E
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
	// (get) Token: 0x0600144A RID: 5194 RVA: 0x000C57B3 File Offset: 0x000C39B3
	public StanceType Previous
	{
		get
		{
			return this.previous;
		}
	}

	// Token: 0x04001F22 RID: 7970
	[SerializeField]
	private StanceType current;

	// Token: 0x04001F23 RID: 7971
	[SerializeField]
	private StanceType previous;
}
