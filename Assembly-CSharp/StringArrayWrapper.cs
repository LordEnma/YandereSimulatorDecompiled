using System;

// Token: 0x02000492 RID: 1170
[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
	// Token: 0x06001F33 RID: 7987 RVA: 0x001BA1EF File Offset: 0x001B83EF
	public StringArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F34 RID: 7988 RVA: 0x001BA1F8 File Offset: 0x001B83F8
	public StringArrayWrapper(string[] elements) : base(elements)
	{
	}
}
