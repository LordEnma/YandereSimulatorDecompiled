using System;

// Token: 0x02000490 RID: 1168
[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
	// Token: 0x06001F1B RID: 7963 RVA: 0x001B8583 File Offset: 0x001B6783
	public StringArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F1C RID: 7964 RVA: 0x001B858C File Offset: 0x001B678C
	public StringArrayWrapper(string[] elements) : base(elements)
	{
	}
}
