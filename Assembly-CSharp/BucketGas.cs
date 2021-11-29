using System;

// Token: 0x020000FB RID: 251
[Serializable]
public class BucketGas : BucketContents
{
	// Token: 0x17000206 RID: 518
	// (get) Token: 0x06000A76 RID: 2678 RVA: 0x0005CB67 File Offset: 0x0005AD67
	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Gas;
		}
	}

	// Token: 0x17000207 RID: 519
	// (get) Token: 0x06000A77 RID: 2679 RVA: 0x0005CB6A File Offset: 0x0005AD6A
	public override bool IsCleaningAgent
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000208 RID: 520
	// (get) Token: 0x06000A78 RID: 2680 RVA: 0x0005CB6D File Offset: 0x0005AD6D
	public override bool IsFlammable
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06000A79 RID: 2681 RVA: 0x0005CB70 File Offset: 0x0005AD70
	public override bool CanBeLifted(int strength)
	{
		return true;
	}
}
