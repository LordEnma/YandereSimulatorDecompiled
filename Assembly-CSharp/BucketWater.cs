using System;
using UnityEngine;

// Token: 0x020000FB RID: 251
[Serializable]
public class BucketWater : BucketContents
{
	// Token: 0x17000201 RID: 513
	// (get) Token: 0x06000A72 RID: 2674 RVA: 0x0005D10F File Offset: 0x0005B30F
	// (set) Token: 0x06000A73 RID: 2675 RVA: 0x0005D117 File Offset: 0x0005B317
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
	// (get) Token: 0x06000A74 RID: 2676 RVA: 0x0005D125 File Offset: 0x0005B325
	// (set) Token: 0x06000A75 RID: 2677 RVA: 0x0005D12D File Offset: 0x0005B32D
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
	// (get) Token: 0x06000A76 RID: 2678 RVA: 0x0005D136 File Offset: 0x0005B336
	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Water;
		}
	}

	// Token: 0x17000204 RID: 516
	// (get) Token: 0x06000A77 RID: 2679 RVA: 0x0005D139 File Offset: 0x0005B339
	public override bool IsCleaningAgent
	{
		get
		{
			return this.hasBleach;
		}
	}

	// Token: 0x17000205 RID: 517
	// (get) Token: 0x06000A78 RID: 2680 RVA: 0x0005D141 File Offset: 0x0005B341
	public override bool IsFlammable
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06000A79 RID: 2681 RVA: 0x0005D144 File Offset: 0x0005B344
	public override bool CanBeLifted(int strength)
	{
		return true;
	}

	// Token: 0x04000C45 RID: 3141
	[SerializeField]
	private float bloodiness;

	// Token: 0x04000C46 RID: 3142
	[SerializeField]
	private bool hasBleach;
}
