using System;
using UnityEngine;

// Token: 0x020000FE RID: 254
[Serializable]
public class BucketWeights : BucketContents
{
	// Token: 0x17000209 RID: 521
	// (get) Token: 0x06000A82 RID: 2690 RVA: 0x0005D71F File Offset: 0x0005B91F
	// (set) Token: 0x06000A83 RID: 2691 RVA: 0x0005D727 File Offset: 0x0005B927
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
	// (get) Token: 0x06000A84 RID: 2692 RVA: 0x0005D737 File Offset: 0x0005B937
	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Weights;
		}
	}

	// Token: 0x1700020B RID: 523
	// (get) Token: 0x06000A85 RID: 2693 RVA: 0x0005D73A File Offset: 0x0005B93A
	public override bool IsCleaningAgent
	{
		get
		{
			return false;
		}
	}

	// Token: 0x1700020C RID: 524
	// (get) Token: 0x06000A86 RID: 2694 RVA: 0x0005D73D File Offset: 0x0005B93D
	public override bool IsFlammable
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06000A87 RID: 2695 RVA: 0x0005D740 File Offset: 0x0005B940
	public override bool CanBeLifted(int strength)
	{
		return strength > 0;
	}

	// Token: 0x04000C4E RID: 3150
	[SerializeField]
	private int count;
}
