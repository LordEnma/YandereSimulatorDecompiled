using System;
using UnityEngine;

// Token: 0x020002AD RID: 685
[Serializable]
public abstract class Entity
{
	// Token: 0x0600143C RID: 5180 RVA: 0x000C5417 File Offset: 0x000C3617
	public Entity(GenderType gender)
	{
		this.gender = gender;
		this.deathType = DeathType.None;
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x0600143D RID: 5181 RVA: 0x000C542D File Offset: 0x000C362D
	public GenderType Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x0600143E RID: 5182 RVA: 0x000C5435 File Offset: 0x000C3635
	// (set) Token: 0x0600143F RID: 5183 RVA: 0x000C543D File Offset: 0x000C363D
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
	// (get) Token: 0x06001440 RID: 5184
	public abstract EntityType EntityType { get; }

	// Token: 0x04001F01 RID: 7937
	[SerializeField]
	private GenderType gender;

	// Token: 0x04001F02 RID: 7938
	[SerializeField]
	private DeathType deathType;
}
