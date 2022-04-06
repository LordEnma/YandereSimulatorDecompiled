using System;

// Token: 0x020004B6 RID: 1206
public class SerializablePair<T, U>
{
	// Token: 0x06001FA7 RID: 8103 RVA: 0x001BE0C8 File Offset: 0x001BC2C8
	public SerializablePair(T first, U second)
	{
		this.first = first;
		this.second = second;
	}

	// Token: 0x06001FA8 RID: 8104 RVA: 0x001BE0E0 File Offset: 0x001BC2E0
	public SerializablePair() : this(default(T), default(U))
	{
	}

	// Token: 0x04004225 RID: 16933
	public T first;

	// Token: 0x04004226 RID: 16934
	public U second;
}
