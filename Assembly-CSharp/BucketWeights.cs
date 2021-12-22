using System;
using UnityEngine;

// Token: 0x020000FD RID: 253
[Serializable]
public class BucketWeights : BucketContents
{
	// Token: 0x17000209 RID: 521
	// (get) Token: 0x06000A7E RID: 2686 RVA: 0x0005CCEF File Offset: 0x0005AEEF
	// (set) Token: 0x06000A7F RID: 2687 RVA: 0x0005CCF7 File Offset: 0x0005AEF7
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
	// (get) Token: 0x06000A80 RID: 2688 RVA: 0x0005CD07 File Offset: 0x0005AF07
	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Weights;
		}
	}

	// Token: 0x1700020B RID: 523
	// (get) Token: 0x06000A81 RID: 2689 RVA: 0x0005CD0A File Offset: 0x0005AF0A
	public override bool IsCleaningAgent
	{
		get
		{
			return false;
		}
	}

	// Token: 0x1700020C RID: 524
	// (get) Token: 0x06000A82 RID: 2690 RVA: 0x0005CD0D File Offset: 0x0005AF0D
	public override bool IsFlammable
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06000A83 RID: 2691 RVA: 0x0005CD10 File Offset: 0x0005AF10
	public override bool CanBeLifted(int strength)
	{
		return strength > 0;
	}

	// Token: 0x04000C33 RID: 3123
	[SerializeField]
	private int count;
}
