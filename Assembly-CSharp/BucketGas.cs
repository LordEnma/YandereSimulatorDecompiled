using System;

// Token: 0x020000FD RID: 253
[Serializable]
public class BucketGas : BucketContents
{
	// Token: 0x17000206 RID: 518
	// (get) Token: 0x06000A7D RID: 2685 RVA: 0x0005D70B File Offset: 0x0005B90B
	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Gas;
		}
	}

	// Token: 0x17000207 RID: 519
	// (get) Token: 0x06000A7E RID: 2686 RVA: 0x0005D70E File Offset: 0x0005B90E
	public override bool IsCleaningAgent
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000208 RID: 520
	// (get) Token: 0x06000A7F RID: 2687 RVA: 0x0005D711 File Offset: 0x0005B911
	public override bool IsFlammable
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06000A80 RID: 2688 RVA: 0x0005D714 File Offset: 0x0005B914
	public override bool CanBeLifted(int strength)
	{
		return true;
	}
}
