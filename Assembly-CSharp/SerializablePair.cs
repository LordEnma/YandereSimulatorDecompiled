using System;

// Token: 0x020004AD RID: 1197
public class SerializablePair<T, U>
{
	// Token: 0x06001F69 RID: 8041 RVA: 0x001B8D20 File Offset: 0x001B6F20
	public SerializablePair(T first, U second)
	{
		this.first = first;
		this.second = second;
	}

	// Token: 0x06001F6A RID: 8042 RVA: 0x001B8D38 File Offset: 0x001B6F38
	public SerializablePair() : this(default(T), default(U))
	{
	}

	// Token: 0x04004169 RID: 16745
	public T first;

	// Token: 0x0400416A RID: 16746
	public U second;
}
