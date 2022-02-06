using System;

// Token: 0x020004AD RID: 1197
public class SerializablePair<T, U>
{
	// Token: 0x06001F70 RID: 8048 RVA: 0x001B9774 File Offset: 0x001B7974
	public SerializablePair(T first, U second)
	{
		this.first = first;
		this.second = second;
	}

	// Token: 0x06001F71 RID: 8049 RVA: 0x001B978C File Offset: 0x001B798C
	public SerializablePair() : this(default(T), default(U))
	{
	}

	// Token: 0x0400417A RID: 16762
	public T first;

	// Token: 0x0400417B RID: 16763
	public U second;
}
