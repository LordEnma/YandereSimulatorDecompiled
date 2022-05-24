using System;

// Token: 0x0200049B RID: 1179
[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
	// Token: 0x06001F71 RID: 8049 RVA: 0x001C08AB File Offset: 0x001BEAAB
	public StringArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F72 RID: 8050 RVA: 0x001C08B4 File Offset: 0x001BEAB4
	public StringArrayWrapper(string[] elements) : base(elements)
	{
	}
}
