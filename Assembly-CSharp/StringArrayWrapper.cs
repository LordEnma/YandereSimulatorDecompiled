using System;

// Token: 0x02000491 RID: 1169
[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
	// Token: 0x06001F27 RID: 7975 RVA: 0x001B8F03 File Offset: 0x001B7103
	public StringArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F28 RID: 7976 RVA: 0x001B8F0C File Offset: 0x001B710C
	public StringArrayWrapper(string[] elements) : base(elements)
	{
	}
}
