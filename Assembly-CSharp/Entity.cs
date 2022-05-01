using System;
using UnityEngine;

// Token: 0x020002B0 RID: 688
[Serializable]
public abstract class Entity
{
	// Token: 0x06001459 RID: 5209 RVA: 0x000C6FA3 File Offset: 0x000C51A3
	public Entity(GenderType gender)
	{
		this.gender = gender;
		this.deathType = DeathType.None;
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x0600145A RID: 5210 RVA: 0x000C6FB9 File Offset: 0x000C51B9
	public GenderType Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x0600145B RID: 5211 RVA: 0x000C6FC1 File Offset: 0x000C51C1
	// (set) Token: 0x0600145C RID: 5212 RVA: 0x000C6FC9 File Offset: 0x000C51C9
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
