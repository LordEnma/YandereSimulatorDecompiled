using System;

// Token: 0x020004AC RID: 1196
public class SerializablePair<T, U>
{
	// Token: 0x06001F67 RID: 8039 RVA: 0x001B8050 File Offset: 0x001B6250
	public SerializablePair(T first, U second)
	{
		this.first = first;
		this.second = second;
	}

	// Token: 0x06001F68 RID: 8040 RVA: 0x001B8068 File Offset: 0x001B6268
	public SerializablePair() : this(default(T), default(U))
	{
	}

	// Token: 0x04004162 RID: 16738
	public T first;

	// Token: 0x04004163 RID: 16739
	public U second;
}
