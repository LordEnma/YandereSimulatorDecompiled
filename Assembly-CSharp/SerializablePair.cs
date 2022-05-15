using System;

// Token: 0x020004B8 RID: 1208
public class SerializablePair<T, U>
{
	// Token: 0x06001FC0 RID: 8128 RVA: 0x001C10F4 File Offset: 0x001BF2F4
	public SerializablePair(T first, U second)
	{
		this.first = first;
		this.second = second;
	}

	// Token: 0x06001FC1 RID: 8129 RVA: 0x001C110C File Offset: 0x001BF30C
	public SerializablePair() : this(default(T), default(U))
	{
	}

	// Token: 0x04004269 RID: 17001
	public T first;

	// Token: 0x0400426A RID: 17002
	public U second;
}
