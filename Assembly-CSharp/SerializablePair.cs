using System;

// Token: 0x020004B2 RID: 1202
public class SerializablePair<T, U>
{
	// Token: 0x06001F95 RID: 8085 RVA: 0x001BC634 File Offset: 0x001BA834
	public SerializablePair(T first, U second)
	{
		this.first = first;
		this.second = second;
	}

	// Token: 0x06001F96 RID: 8086 RVA: 0x001BC64C File Offset: 0x001BA84C
	public SerializablePair() : this(default(T), default(U))
	{
	}

	// Token: 0x040041F5 RID: 16885
	public T first;

	// Token: 0x040041F6 RID: 16886
	public U second;
}
