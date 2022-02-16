using System;

// Token: 0x020004AE RID: 1198
public class SerializablePair<T, U>
{
	// Token: 0x06001F77 RID: 8055 RVA: 0x001B9BC8 File Offset: 0x001B7DC8
	public SerializablePair(T first, U second)
	{
		this.first = first;
		this.second = second;
	}

	// Token: 0x06001F78 RID: 8056 RVA: 0x001B9BE0 File Offset: 0x001B7DE0
	public SerializablePair() : this(default(T), default(U))
	{
	}

	// Token: 0x04004183 RID: 16771
	public T first;

	// Token: 0x04004184 RID: 16772
	public U second;
}
