using System;
using UnityEngine;

// Token: 0x020002AF RID: 687
[Serializable]
public abstract class Entity
{
	// Token: 0x0600144E RID: 5198 RVA: 0x000C66F3 File Offset: 0x000C48F3
	public Entity(GenderType gender)
	{
		this.gender = gender;
		this.deathType = DeathType.None;
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x0600144F RID: 5199 RVA: 0x000C6709 File Offset: 0x000C4909
	public GenderType Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x06001450 RID: 5200 RVA: 0x000C6711 File Offset: 0x000C4911
	// (set) Token: 0x06001451 RID: 5201 RVA: 0x000C6719 File Offset: 0x000C4919
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
	// (get) Token: 0x06001452 RID: 5202
	public abstract EntityType EntityType { get; }

	// Token: 0x04001F35 RID: 7989
	[SerializeField]
	private GenderType gender;

	// Token: 0x04001F36 RID: 7990
	[SerializeField]
	private DeathType deathType;
}
