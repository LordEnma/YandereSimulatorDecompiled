using System;

// Token: 0x0200049B RID: 1179
[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
	// Token: 0x06001F70 RID: 8048 RVA: 0x001C042F File Offset: 0x001BE62F
	public StringArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F71 RID: 8049 RVA: 0x001C0438 File Offset: 0x001BE638
	public StringArrayWrapper(string[] elements) : base(elements)
	{
	}
}
