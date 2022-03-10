using System;

// Token: 0x020004B0 RID: 1200
[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
	// Token: 0x06001F85 RID: 8069 RVA: 0x001BAEF1 File Offset: 0x001B90F1
	public IntAndIntPair(int first, int second) : base(first, second)
	{
	}

	// Token: 0x06001F86 RID: 8070 RVA: 0x001BAEFB File Offset: 0x001B90FB
	public IntAndIntPair() : base(0, 0)
	{
	}
}
