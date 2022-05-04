using System;
using UnityEngine;

// Token: 0x020002B0 RID: 688
[Serializable]
public abstract class Entity
{
	// Token: 0x06001459 RID: 5209 RVA: 0x000C6F6F File Offset: 0x000C516F
	public Entity(GenderType gender)
	{
		this.gender = gender;
		this.deathType = DeathType.None;
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x0600145A RID: 5210 RVA: 0x000C6F85 File Offset: 0x000C5185
	public GenderType Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x0600145B RID: 5211 RVA: 0x000C6F8D File Offset: 0x000C518D
	// (set) Token: 0x0600145C RID: 5212 RVA: 0x000C6F95 File Offset: 0x000C5195
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
	// (get) Token: 0x0600145D RID: 5213
	public abstract EntityType EntityType { get; }

	// Token: 0x04001F45 RID: 8005
	[SerializeField]
	private GenderType gender;

	// Token: 0x04001F46 RID: 8006
	[SerializeField]
	private DeathType deathType;
}
