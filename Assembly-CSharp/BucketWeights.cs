using System;
using UnityEngine;

// Token: 0x020000FD RID: 253
[Serializable]
public class BucketWeights : BucketContents
{
	// Token: 0x17000209 RID: 521
	// (get) Token: 0x06000A7F RID: 2687 RVA: 0x0005CFB3 File Offset: 0x0005B1B3
	// (set) Token: 0x06000A80 RID: 2688 RVA: 0x0005CFBB File Offset: 0x0005B1BB
	public int Count
	{
		get
		{
			return this.count;
		}
		set
		{
			this.count = ((value < 0) ? 0 : value);
		}
	}

	// Token: 0x1700020A RID: 522
	// (get) Token: 0x06000A81 RID: 2689 RVA: 0x0005CFCB File Offset: 0x0005B1CB
	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Weights;
		}
	}

	// Token: 0x1700020B RID: 523
	// (get) Token: 0x06000A82 RID: 2690 RVA: 0x0005CFCE File Offset: 0x0005B1CE
	public override bool IsCleaningAgent
	{
		get
		{
			return false;
		}
	}

	// Token: 0x1700020C RID: 524
	// (get) Token: 0x06000A83 RID: 2691 RVA: 0x0005CFD1 File Offset: 0x0005B1D1
	public override bool IsFlammable
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06000A84 RID: 2692 RVA: 0x0005CFD4 File Offset: 0x0005B1D4
	public override bool CanBeLifted(int strength)
	{
		return strength > 0;
	}

	// Token: 0x04000C40 RID: 3136
	[SerializeField]
	private int count;
}
