using System;

// Token: 0x020004B9 RID: 1209
[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
	// Token: 0x06001FC2 RID: 8130 RVA: 0x001C1131 File Offset: 0x001BF331
	public IntAndIntPair(int first, int second) : base(first, second)
	{
	}

	// Token: 0x06001FC3 RID: 8131 RVA: 0x001C113B File Offset: 0x001BF33B
	public IntAndIntPair() : base(0, 0)
	{
	}
}
