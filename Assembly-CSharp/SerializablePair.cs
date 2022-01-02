using System;

// Token: 0x020004AA RID: 1194
public class SerializablePair<T, U>
{
	// Token: 0x06001F5C RID: 8028 RVA: 0x001B76D0 File Offset: 0x001B58D0
	public SerializablePair(T first, U second)
	{
		this.first = first;
		this.second = second;
	}

	// Token: 0x06001F5D RID: 8029 RVA: 0x001B76E8 File Offset: 0x001B58E8
	public SerializablePair() : this(default(T), default(U))
	{
	}

	// Token: 0x0400414E RID: 16718
	public T first;

	// Token: 0x0400414F RID: 16719
	public U second;
}
