using System;

// Token: 0x02000495 RID: 1173
[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
	// Token: 0x06001F45 RID: 8005 RVA: 0x001BB96F File Offset: 0x001B9B6F
	public StringArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F46 RID: 8006 RVA: 0x001BB978 File Offset: 0x001B9B78
	public StringArrayWrapper(string[] elements) : base(elements)
	{
	}
}
