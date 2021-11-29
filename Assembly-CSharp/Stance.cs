using System;
using UnityEngine;

// Token: 0x020002B0 RID: 688
[Serializable]
public class Stance
{
	// Token: 0x0600143B RID: 5179 RVA: 0x000C48A0 File Offset: 0x000C2AA0
	public Stance(StanceType initialStance)
	{
		this.current = initialStance;
		this.previous = initialStance;
	}

	// Token: 0x17000368 RID: 872
	// (get) Token: 0x0600143C RID: 5180 RVA: 0x000C48B6 File Offset: 0x000C2AB6
	// (set) Token: 0x0600143D RID: 5181 RVA: 0x000C48BE File Offset: 0x000C2ABE
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
	// (get) Token: 0x0600143E RID: 5182 RVA: 0x000C48D3 File Offset: 0x000C2AD3
	public StanceType Previous
	{
		get
		{
			return this.previous;
		}
	}

	// Token: 0x04001EF7 RID: 7927
	[SerializeField]
	private StanceType current;

	// Token: 0x04001EF8 RID: 7928
	[SerializeField]
	private StanceType previous;
}
