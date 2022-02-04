using System;
using UnityEngine;

// Token: 0x020002AD RID: 685
[Serializable]
public abstract class Entity
{
	// Token: 0x0600143D RID: 5181 RVA: 0x000C56CF File Offset: 0x000C38CF
	public Entity(GenderType gender)
	{
		this.gender = gender;
		this.deathType = DeathType.None;
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x0600143E RID: 5182 RVA: 0x000C56E5 File Offset: 0x000C38E5
	public GenderType Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x0600143F RID: 5183 RVA: 0x000C56ED File Offset: 0x000C38ED
	// (set) Token: 0x06001440 RID: 5184 RVA: 0x000C56F5 File Offset: 0x000C38F5
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
	// (get) Token: 0x06001441 RID: 5185
	public abstract EntityType EntityType { get; }

	// Token: 0x04001F06 RID: 7942
	[SerializeField]
	private GenderType gender;

	// Token: 0x04001F07 RID: 7943
	[SerializeField]
	private DeathType deathType;
}
