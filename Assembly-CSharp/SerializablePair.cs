using System;

// Token: 0x020004AF RID: 1199
public class SerializablePair<T, U>
{
	// Token: 0x06001F83 RID: 8067 RVA: 0x001BAEB4 File Offset: 0x001B90B4
	public SerializablePair(T first, U second)
	{
		this.first = first;
		this.second = second;
	}

	// Token: 0x06001F84 RID: 8068 RVA: 0x001BAECC File Offset: 0x001B90CC
	public SerializablePair() : this(default(T), default(U))
	{
	}

	// Token: 0x040041AA RID: 16810
	public T first;

	// Token: 0x040041AB RID: 16811
	public U second;
}
