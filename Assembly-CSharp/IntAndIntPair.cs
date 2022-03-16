using System;

// Token: 0x020004B3 RID: 1203
[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
	// Token: 0x06001F97 RID: 8087 RVA: 0x001BC671 File Offset: 0x001BA871
	public IntAndIntPair(int first, int second) : base(first, second)
	{
	}

	// Token: 0x06001F98 RID: 8088 RVA: 0x001BC67B File Offset: 0x001BA87B
	public IntAndIntPair() : base(0, 0)
	{
	}
}
