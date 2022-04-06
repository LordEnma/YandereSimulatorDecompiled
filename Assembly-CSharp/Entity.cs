using System;
using UnityEngine;

// Token: 0x020002B0 RID: 688
[Serializable]
public abstract class Entity
{
	// Token: 0x06001455 RID: 5205 RVA: 0x000C692F File Offset: 0x000C4B2F
	public Entity(GenderType gender)
	{
		this.gender = gender;
		this.deathType = DeathType.None;
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x06001456 RID: 5206 RVA: 0x000C6945 File Offset: 0x000C4B45
	public GenderType Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x06001457 RID: 5207 RVA: 0x000C694D File Offset: 0x000C4B4D
	// (set) Token: 0x06001458 RID: 5208 RVA: 0x000C6955 File Offset: 0x000C4B55
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
	// (get) Token: 0x06001459 RID: 5209
	public abstract EntityType EntityType { get; }

	// Token: 0x04001F3A RID: 7994
	[SerializeField]
	private GenderType gender;

	// Token: 0x04001F3B RID: 7995
	[SerializeField]
	private DeathType deathType;
}
