using System;

// Token: 0x0200049A RID: 1178
[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
	// Token: 0x06001F66 RID: 8038 RVA: 0x001BF19B File Offset: 0x001BD39B
	public StringArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F67 RID: 8039 RVA: 0x001BF1A4 File Offset: 0x001BD3A4
	public StringArrayWrapper(string[] elements) : base(elements)
	{
	}
}
