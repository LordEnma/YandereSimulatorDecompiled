using System;
using UnityEngine;

// Token: 0x020002AC RID: 684
[Serializable]
public abstract class Entity
{
	// Token: 0x06001438 RID: 5176 RVA: 0x000C4EC3 File Offset: 0x000C30C3
	public Entity(GenderType gender)
	{
		this.gender = gender;
		this.deathType = DeathType.None;
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x06001439 RID: 5177 RVA: 0x000C4ED9 File Offset: 0x000C30D9
	public GenderType Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x0600143A RID: 5178 RVA: 0x000C4EE1 File Offset: 0x000C30E1
	// (set) Token: 0x0600143B RID: 5179 RVA: 0x000C4EE9 File Offset: 0x000C30E9
	public DeathType DeathType
	{
		get
		{
			return this.deathType;
		}
		set
		{
			this.deathType = value;
		}
	}

	// Token: 0x17000365 RID: 869
	// (get) Token: 0x0600143C RID: 5180
	public abstract EntityType EntityType { get; }

	// Token: 0x04001EFA RID: 7930
	[SerializeField]
	private GenderType gender;

	// Token: 0x04001EFB RID: 7931
	[SerializeField]
	private DeathType deathType;
}
