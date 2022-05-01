using System;
using UnityEngine;

// Token: 0x020004A2 RID: 1186
[Serializable]
public class RangeInt
{
	// Token: 0x06001F90 RID: 8080 RVA: 0x001BF95C File Offset: 0x001BDB5C
	public RangeInt(int value, int min, int max)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}

	// Token: 0x06001F91 RID: 8081 RVA: 0x001BF979 File Offset: 0x001BDB79
	public RangeInt(int min, int max) : this(min, min, max)
	{
	}

	// Token: 0x170004C1 RID: 1217
	// (get) Token: 0x06001F92 RID: 8082 RVA: 0x001BF984 File Offset: 0x001BDB84
	// (set) Token: 0x06001F93 RID: 8083 RVA: 0x001BF98C File Offset: 0x001BDB8C
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

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06001F94 RID: 8084 RVA: 0x001BF995 File Offset: 0x001BDB95
	public int Min
	{
		get
		{
			return this.min;
		}
	}

	// Token: 0x170004C3 RID: 1219
	// (get) Token: 0x06001F95 RID: 8085 RVA: 0x001BF99D File Offset: 0x001BDB9D
	public int Max
	{
		get
		{
			return this.max;
		}
	}

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x06001F96 RID: 8086 RVA: 0x001BF9A5 File Offset: 0x001BDBA5
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

	// Token: 0x170004C5 RID: 1221
	// (get) Token: 0x06001F97 RID: 8087 RVA: 0x001BF9C4 File Offset: 0x001BDBC4
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

	// Token: 0x04004241 RID: 16961
	[SerializeField]
	private int value;

	// Token: 0x04004242 RID: 16962
	[SerializeField]
	private int min;

	// Token: 0x04004243 RID: 16963
	[SerializeField]
	private int max;
}
