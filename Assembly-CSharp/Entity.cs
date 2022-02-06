using System;
using UnityEngine;

// Token: 0x020002AD RID: 685
[Serializable]
public abstract class Entity
{
	// Token: 0x0600143D RID: 5181 RVA: 0x000C575F File Offset: 0x000C395F
	public Entity(GenderType gender)
	{
		this.gender = gender;
		this.deathType = DeathType.None;
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x0600143E RID: 5182 RVA: 0x000C5775 File Offset: 0x000C3975
	public GenderType Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x0600143F RID: 5183 RVA: 0x000C577D File Offset: 0x000C397D
	// (set) Token: 0x06001440 RID: 5184 RVA: 0x000C5785 File Offset: 0x000C3985
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

	// Token: 0x04001F08 RID: 7944
	[SerializeField]
	private GenderType gender;

	// Token: 0x04001F09 RID: 7945
	[SerializeField]
	private DeathType deathType;
}
