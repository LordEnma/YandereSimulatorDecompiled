using System;
using UnityEngine;

// Token: 0x020000FB RID: 251
[Serializable]
public class BucketWater : BucketContents
{
	// Token: 0x17000201 RID: 513
	// (get) Token: 0x06000A70 RID: 2672 RVA: 0x0005CC9B File Offset: 0x0005AE9B
	// (set) Token: 0x06000A71 RID: 2673 RVA: 0x0005CCA3 File Offset: 0x0005AEA3
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
	// (get) Token: 0x06000A72 RID: 2674 RVA: 0x0005CCB1 File Offset: 0x0005AEB1
	// (set) Token: 0x06000A73 RID: 2675 RVA: 0x0005CCB9 File Offset: 0x0005AEB9
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
	// (get) Token: 0x06000A74 RID: 2676 RVA: 0x0005CCC2 File Offset: 0x0005AEC2
	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Water;
		}
	}

	// Token: 0x17000204 RID: 516
	// (get) Token: 0x06000A75 RID: 2677 RVA: 0x0005CCC5 File Offset: 0x0005AEC5
	public override bool IsCleaningAgent
	{
		get
		{
			return this.hasBleach;
		}
	}

	// Token: 0x17000205 RID: 517
	// (get) Token: 0x06000A76 RID: 2678 RVA: 0x0005CCCD File Offset: 0x0005AECD
	public override bool IsFlammable
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06000A77 RID: 2679 RVA: 0x0005CCD0 File Offset: 0x0005AED0
	public override bool CanBeLifted(int strength)
	{
		return true;
	}

	// Token: 0x04000C31 RID: 3121
	[SerializeField]
	private float bloodiness;

	// Token: 0x04000C32 RID: 3122
	[SerializeField]
	private bool hasBleach;
}
