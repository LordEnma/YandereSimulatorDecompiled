using System;
using UnityEngine;

// Token: 0x020002B5 RID: 693
[Serializable]
public class Stance
{
	// Token: 0x06001463 RID: 5219 RVA: 0x000C7108 File Offset: 0x000C5308
	public Stance(StanceType initialStance)
	{
		this.current = initialStance;
		this.previous = initialStance;
	}

	// Token: 0x17000368 RID: 872
	// (get) Token: 0x06001464 RID: 5220 RVA: 0x000C711E File Offset: 0x000C531E
	// (set) Token: 0x06001465 RID: 5221 RVA: 0x000C7126 File Offset: 0x000C5326
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
	// (get) Token: 0x06001466 RID: 5222 RVA: 0x000C713B File Offset: 0x000C533B
	public StanceType Previous
	{
		get
		{
			return this.previous;
		}
	}

	// Token: 0x04001F62 RID: 8034
	[SerializeField]
	private StanceType current;

	// Token: 0x04001F63 RID: 8035
	[SerializeField]
	private StanceType previous;
}
