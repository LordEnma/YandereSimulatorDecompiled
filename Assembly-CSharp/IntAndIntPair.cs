using System;

// Token: 0x020004B7 RID: 1207
[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
	// Token: 0x06001FA9 RID: 8105 RVA: 0x001BE105 File Offset: 0x001BC305
	public IntAndIntPair(int first, int second) : base(first, second)
	{
	}

	// Token: 0x06001FAA RID: 8106 RVA: 0x001BE10F File Offset: 0x001BC30F
	public IntAndIntPair() : base(0, 0)
	{
	}
}
