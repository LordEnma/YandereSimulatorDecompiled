using System;
using UnityEngine;

// Token: 0x020002AC RID: 684
[Serializable]
public abstract class Entity
{
	// Token: 0x06001438 RID: 5176 RVA: 0x000C510B File Offset: 0x000C330B
	public Entity(GenderType gender)
	{
		this.gender = gender;
		this.deathType = DeathType.None;
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x06001439 RID: 5177 RVA: 0x000C5121 File Offset: 0x000C3321
	public GenderType Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x0600143A RID: 5178 RVA: 0x000C5129 File Offset: 0x000C3329
	// (set) Token: 0x0600143B RID: 5179 RVA: 0x000C5131 File Offset: 0x000C3331
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

	// Token: 0x04001EFD RID: 7933
	[SerializeField]
	private GenderType gender;

	// Token: 0x04001EFE RID: 7934
	[SerializeField]
	private DeathType deathType;
}
