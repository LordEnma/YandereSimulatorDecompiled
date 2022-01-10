using System;
using UnityEngine;

// Token: 0x020002AD RID: 685
[Serializable]
public abstract class Entity
{
	// Token: 0x0600143C RID: 5180 RVA: 0x000C5343 File Offset: 0x000C3543
	public Entity(GenderType gender)
	{
		this.gender = gender;
		this.deathType = DeathType.None;
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x0600143D RID: 5181 RVA: 0x000C5359 File Offset: 0x000C3559
	public GenderType Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x0600143E RID: 5182 RVA: 0x000C5361 File Offset: 0x000C3561
	// (set) Token: 0x0600143F RID: 5183 RVA: 0x000C5369 File Offset: 0x000C3569
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

	// Token: 0x04001EFE RID: 7934
	[SerializeField]
	private GenderType gender;

	// Token: 0x04001EFF RID: 7935
	[SerializeField]
	private DeathType deathType;
}
