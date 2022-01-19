using System;

// Token: 0x02000490 RID: 1168
[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
	// Token: 0x06001F19 RID: 7961 RVA: 0x001B805B File Offset: 0x001B625B
	public StringArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F1A RID: 7962 RVA: 0x001B8064 File Offset: 0x001B6264
	public StringArrayWrapper(string[] elements) : base(elements)
	{
	}
}
