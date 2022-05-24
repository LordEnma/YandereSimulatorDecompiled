using System;

// Token: 0x020004B8 RID: 1208
public class SerializablePair<T, U>
{
	// Token: 0x06001FC1 RID: 8129 RVA: 0x001C1570 File Offset: 0x001BF770
	public SerializablePair(T first, U second)
	{
		this.first = first;
		this.second = second;
	}

	// Token: 0x06001FC2 RID: 8130 RVA: 0x001C1588 File Offset: 0x001BF788
	public SerializablePair() : this(default(T), default(U))
	{
	}

	// Token: 0x04004272 RID: 17010
	public T first;

	// Token: 0x04004273 RID: 17011
	public U second;
}
