using System;

// Token: 0x020000FB RID: 251
public abstract class BucketContents
{
	// Token: 0x170001FE RID: 510
	// (get) Token: 0x06000A6F RID: 2671
	public abstract BucketContentsType Type { get; }

	// Token: 0x170001FF RID: 511
	// (get) Token: 0x06000A70 RID: 2672
	public abstract bool IsCleaningAgent { get; }

	// Token: 0x17000200 RID: 512
	// (get) Token: 0x06000A71 RID: 2673
	public abstract bool IsFlammable { get; }

	// Token: 0x06000A72 RID: 2674
	public abstract bool CanBeLifted(int strength);
}
