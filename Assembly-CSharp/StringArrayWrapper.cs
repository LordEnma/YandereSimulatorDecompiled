using System;

// Token: 0x0200048D RID: 1165
[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
	// Token: 0x06001F09 RID: 7945 RVA: 0x001B6533 File Offset: 0x001B4733
	public StringArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F0A RID: 7946 RVA: 0x001B653C File Offset: 0x001B473C
	public StringArrayWrapper(string[] elements) : base(elements)
	{
	}
}
