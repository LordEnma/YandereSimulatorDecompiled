using System;

// Token: 0x020004AF RID: 1199
[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
	// Token: 0x06001F79 RID: 8057 RVA: 0x001B9C05 File Offset: 0x001B7E05
	public IntAndIntPair(int first, int second) : base(first, second)
	{
	}

	// Token: 0x06001F7A RID: 8058 RVA: 0x001B9C0F File Offset: 0x001B7E0F
	public IntAndIntPair() : base(0, 0)
	{
	}
}
