using System;
using UnityEngine;

// Token: 0x020004A3 RID: 1187
[Serializable]
public class RangeInt
{
	// Token: 0x06001F9A RID: 8090 RVA: 0x001C0BF0 File Offset: 0x001BEDF0
	public RangeInt(int value, int min, int max)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}

	// Token: 0x06001F9B RID: 8091 RVA: 0x001C0C0D File Offset: 0x001BEE0D
	public RangeInt(int min, int max) : this(min, min, max)
	{
	}

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06001F9C RID: 8092 RVA: 0x001C0C18 File Offset: 0x001BEE18
	// (set) Token: 0x06001F9D RID: 8093 RVA: 0x001C0C20 File Offset: 0x001BEE20
	public int Value
	{
		get
		{
			return this.value;
		}
		set
		{
			this.value = value;
		}
	}

	// Token: 0x170004C3 RID: 1219
	// (get) Token: 0x06001F9E RID: 8094 RVA: 0x001C0C29 File Offset: 0x001BEE29
	public int Min
	{
		get
		{
			return this.min;
		}
	}

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x06001F9F RID: 8095 RVA: 0x001C0C31 File Offset: 0x001BEE31
	public int Max
	{
		get
		{
			return this.max;
		}
	}

	// Token: 0x170004C5 RID: 1221
	// (get) Token: 0x06001FA0 RID: 8096 RVA: 0x001C0C39 File Offset: 0x001BEE39
	public int Next
	{
		get
		{
			if (this.value != this.max)
			{
				return this.value + 1;
			}
			return this.min;
		}
	}

	// Token: 0x170004C6 RID: 1222
	// (get) Token: 0x06001FA1 RID: 8097 RVA: 0x001C0C58 File Offset: 0x001BEE58
	public int Previous
	{
		get
		{
			if (this.value != this.min)
			{
				return this.value - 1;
			}
			return this.max;
		}
	}

	// Token: 0x0400425F RID: 16991
	[SerializeField]
	private int value;

	// Token: 0x04004260 RID: 16992
	[SerializeField]
	private int min;

	// Token: 0x04004261 RID: 16993
	[SerializeField]
	private int max;
}
