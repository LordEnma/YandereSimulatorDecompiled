using System;

// Token: 0x020004AE RID: 1198
[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
	// Token: 0x06001F72 RID: 8050 RVA: 0x001B97B1 File Offset: 0x001B79B1
	public IntAndIntPair(int first, int second) : base(first, second)
	{
	}

	// Token: 0x06001F73 RID: 8051 RVA: 0x001B97BB File Offset: 0x001B79BB
	public IntAndIntPair() : base(0, 0)
	{
	}
}
