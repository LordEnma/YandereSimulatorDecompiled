using System;

// Token: 0x02000499 RID: 1177
[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
	// Token: 0x06001F5D RID: 8029 RVA: 0x001BDDDF File Offset: 0x001BBFDF
	public StringArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F5E RID: 8030 RVA: 0x001BDDE8 File Offset: 0x001BBFE8
	public StringArrayWrapper(string[] elements) : base(elements)
	{
	}
}
