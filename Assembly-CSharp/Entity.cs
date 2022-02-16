using System;
using UnityEngine;

// Token: 0x020002AE RID: 686
[Serializable]
public abstract class Entity
{
	// Token: 0x06001442 RID: 5186 RVA: 0x000C5853 File Offset: 0x000C3A53
	public Entity(GenderType gender)
	{
		this.gender = gender;
		this.deathType = DeathType.None;
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x06001443 RID: 5187 RVA: 0x000C5869 File Offset: 0x000C3A69
	public GenderType Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x06001444 RID: 5188 RVA: 0x000C5871 File Offset: 0x000C3A71
	// (set) Token: 0x06001445 RID: 5189 RVA: 0x000C5879 File Offset: 0x000C3A79
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
	// (get) Token: 0x06001446 RID: 5190
	public abstract EntityType EntityType { get; }

	// Token: 0x04001F0D RID: 7949
	[SerializeField]
	private GenderType gender;

	// Token: 0x04001F0E RID: 7950
	[SerializeField]
	private DeathType deathType;
}
