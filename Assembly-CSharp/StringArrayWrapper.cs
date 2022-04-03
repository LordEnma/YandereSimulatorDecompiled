using System;

// Token: 0x02000498 RID: 1176
[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
	// Token: 0x06001F4F RID: 8015 RVA: 0x001BCEFB File Offset: 0x001BB0FB
	public StringArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F50 RID: 8016 RVA: 0x001BCF04 File Offset: 0x001BB104
	public StringArrayWrapper(string[] elements) : base(elements)
	{
	}
}
