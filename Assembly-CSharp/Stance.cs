using System;
using UnityEngine;

// Token: 0x020002B2 RID: 690
[Serializable]
public class Stance
{
	// Token: 0x06001446 RID: 5190 RVA: 0x000C557C File Offset: 0x000C377C
	public Stance(StanceType initialStance)
	{
		this.current = initialStance;
		this.previous = initialStance;
	}

	// Token: 0x17000368 RID: 872
	// (get) Token: 0x06001447 RID: 5191 RVA: 0x000C5592 File Offset: 0x000C3792
	// (set) Token: 0x06001448 RID: 5192 RVA: 0x000C559A File Offset: 0x000C379A
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
	// (get) Token: 0x06001449 RID: 5193 RVA: 0x000C55AF File Offset: 0x000C37AF
	public StanceType Previous
	{
		get
		{
			return this.previous;
		}
	}

	// Token: 0x04001F1E RID: 7966
	[SerializeField]
	private StanceType current;

	// Token: 0x04001F1F RID: 7967
	[SerializeField]
	private StanceType previous;
}
