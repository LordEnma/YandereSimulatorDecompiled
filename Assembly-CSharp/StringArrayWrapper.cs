using System;

// Token: 0x0200048F RID: 1167
[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
	// Token: 0x06001F17 RID: 7959 RVA: 0x001B738B File Offset: 0x001B558B
	public StringArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F18 RID: 7960 RVA: 0x001B7394 File Offset: 0x001B5594
	public StringArrayWrapper(string[] elements) : base(elements)
	{
	}
}
