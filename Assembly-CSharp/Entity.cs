using System;
using UnityEngine;

// Token: 0x020002AF RID: 687
[Serializable]
public abstract class Entity
{
	// Token: 0x0600144B RID: 5195 RVA: 0x000C6283 File Offset: 0x000C4483
	public Entity(GenderType gender)
	{
		this.gender = gender;
		this.deathType = DeathType.None;
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x0600144C RID: 5196 RVA: 0x000C6299 File Offset: 0x000C4499
	public GenderType Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x0600144D RID: 5197 RVA: 0x000C62A1 File Offset: 0x000C44A1
	// (set) Token: 0x0600144E RID: 5198 RVA: 0x000C62A9 File Offset: 0x000C44A9
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
	// (get) Token: 0x0600144F RID: 5199
	public abstract EntityType EntityType { get; }

	// Token: 0x04001F25 RID: 7973
	[SerializeField]
	private GenderType gender;

	// Token: 0x04001F26 RID: 7974
	[SerializeField]
	private DeathType deathType;
}
