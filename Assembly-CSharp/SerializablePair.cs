using System;

// Token: 0x020004B5 RID: 1205
public class SerializablePair<T, U>
{
	// Token: 0x06001F9F RID: 8095 RVA: 0x001BDBC0 File Offset: 0x001BBDC0
	public SerializablePair(T first, U second)
	{
		this.first = first;
		this.second = second;
	}

	// Token: 0x06001FA0 RID: 8096 RVA: 0x001BDBD8 File Offset: 0x001BBDD8
	public SerializablePair() : this(default(T), default(U))
	{
	}

	// Token: 0x04004222 RID: 16930
	public T first;

	// Token: 0x04004223 RID: 16931
	public U second;
}
