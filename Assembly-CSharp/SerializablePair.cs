using System;

// Token: 0x020004AD RID: 1197
public class SerializablePair<T, U>
{
	// Token: 0x06001F6B RID: 8043 RVA: 0x001B9248 File Offset: 0x001B7448
	public SerializablePair(T first, U second)
	{
		this.first = first;
		this.second = second;
	}

	// Token: 0x06001F6C RID: 8044 RVA: 0x001B9260 File Offset: 0x001B7460
	public SerializablePair() : this(default(T), default(U))
	{
	}

	// Token: 0x04004171 RID: 16753
	public T first;

	// Token: 0x04004172 RID: 16754
	public U second;
}
