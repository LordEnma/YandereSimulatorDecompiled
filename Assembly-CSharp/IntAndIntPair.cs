using System;

// Token: 0x020004B9 RID: 1209
[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
	// Token: 0x06001FC3 RID: 8131 RVA: 0x001C15AD File Offset: 0x001BF7AD
	public IntAndIntPair(int first, int second) : base(first, second)
	{
	}

	// Token: 0x06001FC4 RID: 8132 RVA: 0x001C15B7 File Offset: 0x001BF7B7
	public IntAndIntPair() : base(0, 0)
	{
	}
}
