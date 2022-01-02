using System;

// Token: 0x020004AB RID: 1195
[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
	// Token: 0x06001F5E RID: 8030 RVA: 0x001B770D File Offset: 0x001B590D
	public IntAndIntPair(int first, int second) : base(first, second)
	{
	}

	// Token: 0x06001F5F RID: 8031 RVA: 0x001B7717 File Offset: 0x001B5917
	public IntAndIntPair() : base(0, 0)
	{
	}
}
