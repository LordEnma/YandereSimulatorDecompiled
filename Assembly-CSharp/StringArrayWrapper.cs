using System;

// Token: 0x0200048C RID: 1164
[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
	// Token: 0x06001EFF RID: 7935 RVA: 0x001B5777 File Offset: 0x001B3977
	public StringArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F00 RID: 7936 RVA: 0x001B5780 File Offset: 0x001B3980
	public StringArrayWrapper(string[] elements) : base(elements)
	{
	}
}
