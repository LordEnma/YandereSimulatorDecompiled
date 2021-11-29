using System;
using UnityEngine;

// Token: 0x020000FC RID: 252
[Serializable]
public class BucketWeights : BucketContents
{
	// Token: 0x17000209 RID: 521
	// (get) Token: 0x06000A7B RID: 2683 RVA: 0x0005CB7B File Offset: 0x0005AD7B
	// (set) Token: 0x06000A7C RID: 2684 RVA: 0x0005CB83 File Offset: 0x0005AD83
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
	// (get) Token: 0x06000A7D RID: 2685 RVA: 0x0005CB93 File Offset: 0x0005AD93
	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Weights;
		}
	}

	// Token: 0x1700020B RID: 523
	// (get) Token: 0x06000A7E RID: 2686 RVA: 0x0005CB96 File Offset: 0x0005AD96
	public override bool IsCleaningAgent
	{
		get
		{
			return false;
		}
	}

	// Token: 0x1700020C RID: 524
	// (get) Token: 0x06000A7F RID: 2687 RVA: 0x0005CB99 File Offset: 0x0005AD99
	public override bool IsFlammable
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06000A80 RID: 2688 RVA: 0x0005CB9C File Offset: 0x0005AD9C
	public override bool CanBeLifted(int strength)
	{
		return strength > 0;
	}

	// Token: 0x04000C31 RID: 3121
	[SerializeField]
	private int count;
}
