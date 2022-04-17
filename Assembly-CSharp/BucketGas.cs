using System;

// Token: 0x020000FC RID: 252
[Serializable]
public class BucketGas : BucketContents
{
	// Token: 0x17000206 RID: 518
	// (get) Token: 0x06000A7B RID: 2683 RVA: 0x0005D253 File Offset: 0x0005B453
	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Gas;
		}
	}

	// Token: 0x17000207 RID: 519
	// (get) Token: 0x06000A7C RID: 2684 RVA: 0x0005D256 File Offset: 0x0005B456
	public override bool IsCleaningAgent
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000208 RID: 520
	// (get) Token: 0x06000A7D RID: 2685 RVA: 0x0005D259 File Offset: 0x0005B459
	public override bool IsFlammable
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06000A7E RID: 2686 RVA: 0x0005D25C File Offset: 0x0005B45C
	public override bool CanBeLifted(int strength)
	{
		return true;
	}
}
