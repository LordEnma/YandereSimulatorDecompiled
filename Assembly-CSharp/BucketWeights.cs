using System;
using UnityEngine;

// Token: 0x020000FE RID: 254
[Serializable]
public class BucketWeights : BucketContents
{
	// Token: 0x17000209 RID: 521
	// (get) Token: 0x06000A82 RID: 2690 RVA: 0x0005D6F7 File Offset: 0x0005B8F7
	// (set) Token: 0x06000A83 RID: 2691 RVA: 0x0005D6FF File Offset: 0x0005B8FF
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
	// (get) Token: 0x06000A84 RID: 2692 RVA: 0x0005D70F File Offset: 0x0005B90F
	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Weights;
		}
	}

	// Token: 0x1700020B RID: 523
	// (get) Token: 0x06000A85 RID: 2693 RVA: 0x0005D712 File Offset: 0x0005B912
	public override bool IsCleaningAgent
	{
		get
		{
			return false;
		}
	}

	// Token: 0x1700020C RID: 524
	// (get) Token: 0x06000A86 RID: 2694 RVA: 0x0005D715 File Offset: 0x0005B915
	public override bool IsFlammable
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06000A87 RID: 2695 RVA: 0x0005D718 File Offset: 0x0005B918
	public override bool CanBeLifted(int strength)
	{
		return strength > 0;
	}

	// Token: 0x04000C4E RID: 3150
	[SerializeField]
	private int count;
}
