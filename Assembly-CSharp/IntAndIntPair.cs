using System;

// Token: 0x020004AD RID: 1197
[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
	// Token: 0x06001F69 RID: 8041 RVA: 0x001B808D File Offset: 0x001B628D
	public IntAndIntPair(int first, int second) : base(first, second)
	{
	}

	// Token: 0x06001F6A RID: 8042 RVA: 0x001B8097 File Offset: 0x001B6297
	public IntAndIntPair() : base(0, 0)
	{
	}
}
