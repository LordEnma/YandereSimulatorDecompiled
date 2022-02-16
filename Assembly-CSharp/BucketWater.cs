using System;
using UnityEngine;

// Token: 0x020000FB RID: 251
[Serializable]
public class BucketWater : BucketContents
{
	// Token: 0x17000201 RID: 513
	// (get) Token: 0x06000A71 RID: 2673 RVA: 0x0005CD27 File Offset: 0x0005AF27
	// (set) Token: 0x06000A72 RID: 2674 RVA: 0x0005CD2F File Offset: 0x0005AF2F
	public float Bloodiness
	{
		get
		{
			return this.bloodiness;
		}
		set
		{
			this.bloodiness = Mathf.Clamp01(value);
		}
	}

	// Token: 0x17000202 RID: 514
	// (get) Token: 0x06000A73 RID: 2675 RVA: 0x0005CD3D File Offset: 0x0005AF3D
	// (set) Token: 0x06000A74 RID: 2676 RVA: 0x0005CD45 File Offset: 0x0005AF45
	public bool HasBleach
	{
		get
		{
			return this.hasBleach;
		}
		set
		{
			this.hasBleach = value;
		}
	}

	// Token: 0x17000203 RID: 515
	// (get) Token: 0x06000A75 RID: 2677 RVA: 0x0005CD4E File Offset: 0x0005AF4E
	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Water;
		}
	}

	// Token: 0x17000204 RID: 516
	// (get) Token: 0x06000A76 RID: 2678 RVA: 0x0005CD51 File Offset: 0x0005AF51
	public override bool IsCleaningAgent
	{
		get
		{
			return this.hasBleach;
		}
	}

	// Token: 0x17000205 RID: 517
	// (get) Token: 0x06000A77 RID: 2679 RVA: 0x0005CD59 File Offset: 0x0005AF59
	public override bool IsFlammable
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06000A78 RID: 2680 RVA: 0x0005CD5C File Offset: 0x0005AF5C
	public override bool CanBeLifted(int strength)
	{
		return true;
	}

	// Token: 0x04000C35 RID: 3125
	[SerializeField]
	private float bloodiness;

	// Token: 0x04000C36 RID: 3126
	[SerializeField]
	private bool hasBleach;
}
