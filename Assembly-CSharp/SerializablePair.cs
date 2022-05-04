using System;

// Token: 0x020004B7 RID: 1207
public class SerializablePair<T, U>
{
	// Token: 0x06001FB7 RID: 8119 RVA: 0x001BFF5C File Offset: 0x001BE15C
	public SerializablePair(T first, U second)
	{
		this.first = first;
		this.second = second;
	}

	// Token: 0x06001FB8 RID: 8120 RVA: 0x001BFF74 File Offset: 0x001BE174
	public SerializablePair() : this(default(T), default(U))
	{
	}

	// Token: 0x0400424B RID: 16971
	public T first;

	// Token: 0x0400424C RID: 16972
	public U second;
}
