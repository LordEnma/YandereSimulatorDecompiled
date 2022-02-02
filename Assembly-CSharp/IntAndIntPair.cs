using System;

// Token: 0x020004AE RID: 1198
[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
	// Token: 0x06001F6D RID: 8045 RVA: 0x001B9285 File Offset: 0x001B7485
	public IntAndIntPair(int first, int second) : base(first, second)
	{
	}

	// Token: 0x06001F6E RID: 8046 RVA: 0x001B928F File Offset: 0x001B748F
	public IntAndIntPair() : base(0, 0)
	{
	}
}
