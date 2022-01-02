using System;
using UnityEngine;

// Token: 0x020000FB RID: 251
[Serializable]
public class BucketWater : BucketContents
{
	// Token: 0x17000201 RID: 513
	// (get) Token: 0x06000A70 RID: 2672 RVA: 0x0005CCB3 File Offset: 0x0005AEB3
	// (set) Token: 0x06000A71 RID: 2673 RVA: 0x0005CCBB File Offset: 0x0005AEBB
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
	// (get) Token: 0x06000A72 RID: 2674 RVA: 0x0005CCC9 File Offset: 0x0005AEC9
	// (set) Token: 0x06000A73 RID: 2675 RVA: 0x0005CCD1 File Offset: 0x0005AED1
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
	// (get) Token: 0x06000A74 RID: 2676 RVA: 0x0005CCDA File Offset: 0x0005AEDA
	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Water;
		}
	}

	// Token: 0x17000204 RID: 516
	// (get) Token: 0x06000A75 RID: 2677 RVA: 0x0005CCDD File Offset: 0x0005AEDD
	public override bool IsCleaningAgent
	{
		get
		{
			return this.hasBleach;
		}
	}

	// Token: 0x17000205 RID: 517
	// (get) Token: 0x06000A76 RID: 2678 RVA: 0x0005CCE5 File Offset: 0x0005AEE5
	public override bool IsFlammable
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06000A77 RID: 2679 RVA: 0x0005CCE8 File Offset: 0x0005AEE8
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
