using System;

// Token: 0x020000FD RID: 253
[Serializable]
public class BucketGas : BucketContents
{
	// Token: 0x17000206 RID: 518
	// (get) Token: 0x06000A7D RID: 2685 RVA: 0x0005D6E3 File Offset: 0x0005B8E3
	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Gas;
		}
	}

	// Token: 0x17000207 RID: 519
	// (get) Token: 0x06000A7E RID: 2686 RVA: 0x0005D6E6 File Offset: 0x0005B8E6
	public override bool IsCleaningAgent
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000208 RID: 520
	// (get) Token: 0x06000A7F RID: 2687 RVA: 0x0005D6E9 File Offset: 0x0005B8E9
	public override bool IsFlammable
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06000A80 RID: 2688 RVA: 0x0005D6EC File Offset: 0x0005B8EC
	public override bool CanBeLifted(int strength)
	{
		return true;
	}
}
