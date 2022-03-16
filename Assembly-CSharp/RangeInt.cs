using System;
using UnityEngine;

// Token: 0x0200049D RID: 1181
[Serializable]
public class RangeInt
{
	// Token: 0x06001F6F RID: 8047 RVA: 0x001BC130 File Offset: 0x001BA330
	public RangeInt(int value, int min, int max)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}

	// Token: 0x06001F70 RID: 8048 RVA: 0x001BC14D File Offset: 0x001BA34D
	public RangeInt(int min, int max) : this(min, min, max)
	{
	}

	// Token: 0x170004C0 RID: 1216
	// (get) Token: 0x06001F71 RID: 8049 RVA: 0x001BC158 File Offset: 0x001BA358
	// (set) Token: 0x06001F72 RID: 8050 RVA: 0x001BC160 File Offset: 0x001BA360
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

	// Token: 0x170004C1 RID: 1217
	// (get) Token: 0x06001F73 RID: 8051 RVA: 0x001BC169 File Offset: 0x001BA369
	public int Min
	{
		get
		{
			return this.min;
		}
	}

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06001F74 RID: 8052 RVA: 0x001BC171 File Offset: 0x001BA371
	public int Max
	{
		get
		{
			return this.max;
		}
	}

	// Token: 0x170004C3 RID: 1219
	// (get) Token: 0x06001F75 RID: 8053 RVA: 0x001BC179 File Offset: 0x001BA379
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

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x06001F76 RID: 8054 RVA: 0x001BC198 File Offset: 0x001BA398
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

	// Token: 0x040041EB RID: 16875
	[SerializeField]
	private int value;

	// Token: 0x040041EC RID: 16876
	[SerializeField]
	private int min;

	// Token: 0x040041ED RID: 16877
	[SerializeField]
	private int max;
}
