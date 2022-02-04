using System;

// Token: 0x020004AE RID: 1198
[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
	// Token: 0x06001F6F RID: 8047 RVA: 0x001B9591 File Offset: 0x001B7791
	public IntAndIntPair(int first, int second) : base(first, second)
	{
	}

	// Token: 0x06001F70 RID: 8048 RVA: 0x001B959B File Offset: 0x001B779B
	public IntAndIntPair() : base(0, 0)
	{
	}
}
