using System;

// Token: 0x0200048D RID: 1165
[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
	// Token: 0x06001F0C RID: 7948 RVA: 0x001B6A0B File Offset: 0x001B4C0B
	public StringArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F0D RID: 7949 RVA: 0x001B6A14 File Offset: 0x001B4C14
	public StringArrayWrapper(string[] elements) : base(elements)
	{
	}
}
