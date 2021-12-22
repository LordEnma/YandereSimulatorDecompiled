using System;

// Token: 0x020004AA RID: 1194
public class SerializablePair<T, U>
{
	// Token: 0x06001F59 RID: 8025 RVA: 0x001B71F8 File Offset: 0x001B53F8
	public SerializablePair(T first, U second)
	{
		this.first = first;
		this.second = second;
	}

	// Token: 0x06001F5A RID: 8026 RVA: 0x001B7210 File Offset: 0x001B5410
	public SerializablePair() : this(default(T), default(U))
	{
	}

	// Token: 0x04004147 RID: 16711
	public T first;

	// Token: 0x04004148 RID: 16712
	public U second;
}
