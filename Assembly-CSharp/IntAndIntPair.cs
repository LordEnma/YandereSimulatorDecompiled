using System;

// Token: 0x020004AE RID: 1198
[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
	// Token: 0x06001F6B RID: 8043 RVA: 0x001B8D5D File Offset: 0x001B6F5D
	public IntAndIntPair(int first, int second) : base(first, second)
	{
	}

	// Token: 0x06001F6C RID: 8044 RVA: 0x001B8D67 File Offset: 0x001B6F67
	public IntAndIntPair() : base(0, 0)
	{
	}
}
