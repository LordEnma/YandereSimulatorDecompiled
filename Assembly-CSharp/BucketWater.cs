using System;
using UnityEngine;

// Token: 0x020000FB RID: 251
[Serializable]
public class BucketWater : BucketContents
{
	// Token: 0x17000201 RID: 513
	// (get) Token: 0x06000A72 RID: 2674 RVA: 0x0005D367 File Offset: 0x0005B567
	// (set) Token: 0x06000A73 RID: 2675 RVA: 0x0005D36F File Offset: 0x0005B56F
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
	// (get) Token: 0x06000A74 RID: 2676 RVA: 0x0005D37D File Offset: 0x0005B57D
	// (set) Token: 0x06000A75 RID: 2677 RVA: 0x0005D385 File Offset: 0x0005B585
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
	// (get) Token: 0x06000A76 RID: 2678 RVA: 0x0005D38E File Offset: 0x0005B58E
	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Water;
		}
	}

	// Token: 0x17000204 RID: 516
	// (get) Token: 0x06000A77 RID: 2679 RVA: 0x0005D391 File Offset: 0x0005B591
	public override bool IsCleaningAgent
	{
		get
		{
			return this.hasBleach;
		}
	}

	// Token: 0x17000205 RID: 517
	// (get) Token: 0x06000A78 RID: 2680 RVA: 0x0005D399 File Offset: 0x0005B599
	public override bool IsFlammable
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06000A79 RID: 2681 RVA: 0x0005D39C File Offset: 0x0005B59C
	public override bool CanBeLifted(int strength)
	{
		return true;
	}

	// Token: 0x04000C47 RID: 3143
	[SerializeField]
	private float bloodiness;

	// Token: 0x04000C48 RID: 3144
	[SerializeField]
	private bool hasBleach;
}
