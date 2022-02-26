using System;

// Token: 0x020004B0 RID: 1200
[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
	// Token: 0x06001F82 RID: 8066 RVA: 0x001BA751 File Offset: 0x001B8951
	public IntAndIntPair(int first, int second) : base(first, second)
	{
	}

	// Token: 0x06001F83 RID: 8067 RVA: 0x001BA75B File Offset: 0x001B895B
	public IntAndIntPair() : base(0, 0)
	{
	}
}
