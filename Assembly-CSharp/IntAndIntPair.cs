using System;

// Token: 0x020004B8 RID: 1208
[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
	// Token: 0x06001FB8 RID: 8120 RVA: 0x001BFE9D File Offset: 0x001BE09D
	public IntAndIntPair(int first, int second) : base(first, second)
	{
	}

	// Token: 0x06001FB9 RID: 8121 RVA: 0x001BFEA7 File Offset: 0x001BE0A7
	public IntAndIntPair() : base(0, 0)
	{
	}
}
