using System;
using UnityEngine;

// Token: 0x020002B4 RID: 692
[Serializable]
public class Stance
{
	// Token: 0x06001455 RID: 5205 RVA: 0x000C63E8 File Offset: 0x000C45E8
	public Stance(StanceType initialStance)
	{
		this.current = initialStance;
		this.previous = initialStance;
	}

	// Token: 0x17000368 RID: 872
	// (get) Token: 0x06001456 RID: 5206 RVA: 0x000C63FE File Offset: 0x000C45FE
	// (set) Token: 0x06001457 RID: 5207 RVA: 0x000C6406 File Offset: 0x000C4606
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
	// (get) Token: 0x06001458 RID: 5208 RVA: 0x000C641B File Offset: 0x000C461B
	public StanceType Previous
	{
		get
		{
			return this.previous;
		}
	}

	// Token: 0x04001F42 RID: 8002
	[SerializeField]
	private StanceType current;

	// Token: 0x04001F43 RID: 8003
	[SerializeField]
	private StanceType previous;
}
