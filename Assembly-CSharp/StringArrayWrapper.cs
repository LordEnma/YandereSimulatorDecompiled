using System;

// Token: 0x02000499 RID: 1177
[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
	// Token: 0x06001F57 RID: 8023 RVA: 0x001BD403 File Offset: 0x001BB603
	public StringArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F58 RID: 8024 RVA: 0x001BD40C File Offset: 0x001BB60C
	public StringArrayWrapper(string[] elements) : base(elements)
	{
	}
}
