using System;

// Token: 0x020004A9 RID: 1193
public class SerializablePair<T, U>
{
	// Token: 0x06001F4F RID: 8015 RVA: 0x001B643C File Offset: 0x001B463C
	public SerializablePair(T first, U second)
	{
		this.first = first;
		this.second = second;
	}

	// Token: 0x06001F50 RID: 8016 RVA: 0x001B6454 File Offset: 0x001B4654
	public SerializablePair() : this(default(T), default(U))
	{
	}

	// Token: 0x04004117 RID: 16663
	public T first;

	// Token: 0x04004118 RID: 16664
	public U second;
}
