using System;

// Token: 0x020004AA RID: 1194
[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
	// Token: 0x06001F51 RID: 8017 RVA: 0x001B6479 File Offset: 0x001B4679
	public IntAndIntPair(int first, int second) : base(first, second)
	{
	}

	// Token: 0x06001F52 RID: 8018 RVA: 0x001B6483 File Offset: 0x001B4683
	public IntAndIntPair() : base(0, 0)
	{
	}
}
