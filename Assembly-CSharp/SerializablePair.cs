using System;

// Token: 0x020004AF RID: 1199
public class SerializablePair<T, U>
{
	// Token: 0x06001F80 RID: 8064 RVA: 0x001BA714 File Offset: 0x001B8914
	public SerializablePair(T first, U second)
	{
		this.first = first;
		this.second = second;
	}

	// Token: 0x06001F81 RID: 8065 RVA: 0x001BA72C File Offset: 0x001B892C
	public SerializablePair() : this(default(T), default(U))
	{
	}

	// Token: 0x04004193 RID: 16787
	public T first;

	// Token: 0x04004194 RID: 16788
	public U second;
}
