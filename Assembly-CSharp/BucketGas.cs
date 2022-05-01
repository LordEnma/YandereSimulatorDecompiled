using System;

// Token: 0x020000FC RID: 252
[Serializable]
public class BucketGas : BucketContents
{
	// Token: 0x17000206 RID: 518
	// (get) Token: 0x06000A7B RID: 2683 RVA: 0x0005D3A7 File Offset: 0x0005B5A7
	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Gas;
		}
	}

	// Token: 0x17000207 RID: 519
	// (get) Token: 0x06000A7C RID: 2684 RVA: 0x0005D3AA File Offset: 0x0005B5AA
	public override bool IsCleaningAgent
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000208 RID: 520
	// (get) Token: 0x06000A7D RID: 2685 RVA: 0x0005D3AD File Offset: 0x0005B5AD
	public override bool IsFlammable
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06000A7E RID: 2686 RVA: 0x0005D3B0 File Offset: 0x0005B5B0
	public override bool CanBeLifted(int strength)
	{
		return true;
	}
}
