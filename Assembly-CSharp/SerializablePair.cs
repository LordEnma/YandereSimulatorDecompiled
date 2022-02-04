using System;

// Token: 0x020004AD RID: 1197
public class SerializablePair<T, U>
{
	// Token: 0x06001F6D RID: 8045 RVA: 0x001B9554 File Offset: 0x001B7754
	public SerializablePair(T first, U second)
	{
		this.first = first;
		this.second = second;
	}

	// Token: 0x06001F6E RID: 8046 RVA: 0x001B956C File Offset: 0x001B776C
	public SerializablePair() : this(default(T), default(U))
	{
	}

	// Token: 0x04004177 RID: 16759
	public T first;

	// Token: 0x04004178 RID: 16760
	public U second;
}
