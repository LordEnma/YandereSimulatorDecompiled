using System;

// Token: 0x020004B6 RID: 1206
[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
	// Token: 0x06001FA1 RID: 8097 RVA: 0x001BDBFD File Offset: 0x001BBDFD
	public IntAndIntPair(int first, int second) : base(first, second)
	{
	}

	// Token: 0x06001FA2 RID: 8098 RVA: 0x001BDC07 File Offset: 0x001BBE07
	public IntAndIntPair() : base(0, 0)
	{
	}
}
