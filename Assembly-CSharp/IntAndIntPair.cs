using System;

// Token: 0x020004AB RID: 1195
[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
	// Token: 0x06001F5B RID: 8027 RVA: 0x001B7235 File Offset: 0x001B5435
	public IntAndIntPair(int first, int second) : base(first, second)
	{
	}

	// Token: 0x06001F5C RID: 8028 RVA: 0x001B723F File Offset: 0x001B543F
	public IntAndIntPair() : base(0, 0)
	{
	}
}
