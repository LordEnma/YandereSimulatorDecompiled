using System;

// Token: 0x02000490 RID: 1168
[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
	// Token: 0x06001F1D RID: 7965 RVA: 0x001B888F File Offset: 0x001B6A8F
	public StringArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F1E RID: 7966 RVA: 0x001B8898 File Offset: 0x001B6A98
	public StringArrayWrapper(string[] elements) : base(elements)
	{
	}
}
