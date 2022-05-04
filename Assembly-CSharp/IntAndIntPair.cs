using System;

// Token: 0x020004B8 RID: 1208
[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
	// Token: 0x06001FB9 RID: 8121 RVA: 0x001BFF99 File Offset: 0x001BE199
	public IntAndIntPair(int first, int second) : base(first, second)
	{
	}

	// Token: 0x06001FBA RID: 8122 RVA: 0x001BFFA3 File Offset: 0x001BE1A3
	public IntAndIntPair() : base(0, 0)
	{
	}
}
