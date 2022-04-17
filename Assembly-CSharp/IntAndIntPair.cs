using System;

// Token: 0x020004B7 RID: 1207
[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
	// Token: 0x06001FAF RID: 8111 RVA: 0x001BEAE1 File Offset: 0x001BCCE1
	public IntAndIntPair(int first, int second) : base(first, second)
	{
	}

	// Token: 0x06001FB0 RID: 8112 RVA: 0x001BEAEB File Offset: 0x001BCCEB
	public IntAndIntPair() : base(0, 0)
	{
	}
}
