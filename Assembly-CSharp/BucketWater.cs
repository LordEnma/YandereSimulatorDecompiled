using System;
using UnityEngine;

// Token: 0x020000FB RID: 251
[Serializable]
public class BucketWater : BucketContents
{
	// Token: 0x17000201 RID: 513
	// (get) Token: 0x06000A72 RID: 2674 RVA: 0x0005D213 File Offset: 0x0005B413
	// (set) Token: 0x06000A73 RID: 2675 RVA: 0x0005D21B File Offset: 0x0005B41B
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
	// (get) Token: 0x06000A74 RID: 2676 RVA: 0x0005D229 File Offset: 0x0005B429
	// (set) Token: 0x06000A75 RID: 2677 RVA: 0x0005D231 File Offset: 0x0005B431
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
	// (get) Token: 0x06000A76 RID: 2678 RVA: 0x0005D23A File Offset: 0x0005B43A
	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Water;
		}
	}

	// Token: 0x17000204 RID: 516
	// (get) Token: 0x06000A77 RID: 2679 RVA: 0x0005D23D File Offset: 0x0005B43D
	public override bool IsCleaningAgent
	{
		get
		{
			return this.hasBleach;
		}
	}

	// Token: 0x17000205 RID: 517
	// (get) Token: 0x06000A78 RID: 2680 RVA: 0x0005D245 File Offset: 0x0005B445
	public override bool IsFlammable
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06000A79 RID: 2681 RVA: 0x0005D248 File Offset: 0x0005B448
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
