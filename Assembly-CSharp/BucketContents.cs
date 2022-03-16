using System;

// Token: 0x020000FA RID: 250
public abstract class BucketContents
{
	// Token: 0x170001FE RID: 510
	// (get) Token: 0x06000A6D RID: 2669
	public abstract BucketContentsType Type { get; }

	// Token: 0x170001FF RID: 511
	// (get) Token: 0x06000A6E RID: 2670
	public abstract bool IsCleaningAgent { get; }

	// Token: 0x17000200 RID: 512
	// (get) Token: 0x06000A6F RID: 2671
	public abstract bool IsFlammable { get; }

	// Token: 0x06000A70 RID: 2672
	public abstract bool CanBeLifted(int strength);
}
