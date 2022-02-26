using System;

// Token: 0x02000492 RID: 1170
[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
	// Token: 0x06001F30 RID: 7984 RVA: 0x001B9A4F File Offset: 0x001B7C4F
	public StringArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F31 RID: 7985 RVA: 0x001B9A58 File Offset: 0x001B7C58
	public StringArrayWrapper(string[] elements) : base(elements)
	{
	}
}
