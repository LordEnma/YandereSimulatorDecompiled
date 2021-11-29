using System;
using UnityEngine;

// Token: 0x020002AB RID: 683
[Serializable]
public abstract class Entity
{
	// Token: 0x06001431 RID: 5169 RVA: 0x000C473B File Offset: 0x000C293B
	public Entity(GenderType gender)
	{
		this.gender = gender;
		this.deathType = DeathType.None;
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x06001432 RID: 5170 RVA: 0x000C4751 File Offset: 0x000C2951
	public GenderType Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x06001433 RID: 5171 RVA: 0x000C4759 File Offset: 0x000C2959
	// (set) Token: 0x06001434 RID: 5172 RVA: 0x000C4761 File Offset: 0x000C2961
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
	// (get) Token: 0x06001435 RID: 5173
	public abstract EntityType EntityType { get; }

	// Token: 0x04001EDA RID: 7898
	[SerializeField]
	private GenderType gender;

	// Token: 0x04001EDB RID: 7899
	[SerializeField]
	private DeathType deathType;
}
