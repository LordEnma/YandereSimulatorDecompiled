using System;

// Token: 0x020000F9 RID: 249
public abstract class BucketContents
{
	// Token: 0x170001FE RID: 510
	// (get) Token: 0x06000A68 RID: 2664
	public abstract BucketContentsType Type { get; }

	// Token: 0x170001FF RID: 511
	// (get) Token: 0x06000A69 RID: 2665
	public abstract bool IsCleaningAgent { get; }

	// Token: 0x17000200 RID: 512
	// (get) Token: 0x06000A6A RID: 2666
	public abstract bool IsFlammable { get; }

	// Token: 0x06000A6B RID: 2667
	public abstract bool CanBeLifted(int strength);
}
