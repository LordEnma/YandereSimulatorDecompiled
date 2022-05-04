using System;

// Token: 0x0200049A RID: 1178
[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
	// Token: 0x06001F67 RID: 8039 RVA: 0x001BF297 File Offset: 0x001BD497
	public StringArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F68 RID: 8040 RVA: 0x001BF2A0 File Offset: 0x001BD4A0
	public StringArrayWrapper(string[] elements) : base(elements)
	{
	}
}
