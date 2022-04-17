using System;

// Token: 0x020004B6 RID: 1206
public class SerializablePair<T, U>
{
	// Token: 0x06001FAD RID: 8109 RVA: 0x001BEAA4 File Offset: 0x001BCCA4
	public SerializablePair(T first, U second)
	{
		this.first = first;
		this.second = second;
	}

	// Token: 0x06001FAE RID: 8110 RVA: 0x001BEABC File Offset: 0x001BCCBC
	public SerializablePair() : this(default(T), default(U))
	{
	}

	// Token: 0x04004235 RID: 16949
	public T first;

	// Token: 0x04004236 RID: 16950
	public U second;
}
