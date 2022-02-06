using System;

// Token: 0x02000490 RID: 1168
[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
	// Token: 0x06001F20 RID: 7968 RVA: 0x001B8AAF File Offset: 0x001B6CAF
	public StringArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F21 RID: 7969 RVA: 0x001B8AB8 File Offset: 0x001B6CB8
	public StringArrayWrapper(string[] elements) : base(elements)
	{
	}
}
