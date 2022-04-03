using System;
using UnityEngine;

// Token: 0x020002AF RID: 687
[Serializable]
public abstract class Entity
{
	// Token: 0x0600144F RID: 5199 RVA: 0x000C6827 File Offset: 0x000C4A27
	public Entity(GenderType gender)
	{
		this.gender = gender;
		this.deathType = DeathType.None;
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x06001450 RID: 5200 RVA: 0x000C683D File Offset: 0x000C4A3D
	public GenderType Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x06001451 RID: 5201 RVA: 0x000C6845 File Offset: 0x000C4A45
	// (set) Token: 0x06001452 RID: 5202 RVA: 0x000C684D File Offset: 0x000C4A4D
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
	// (get) Token: 0x06001453 RID: 5203
	public abstract EntityType EntityType { get; }

	// Token: 0x04001F38 RID: 7992
	[SerializeField]
	private GenderType gender;

	// Token: 0x04001F39 RID: 7993
	[SerializeField]
	private DeathType deathType;
}
