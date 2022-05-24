using System;
using UnityEngine;

// Token: 0x020004A3 RID: 1187
[Serializable]
public class RangeInt
{
	// Token: 0x06001F9B RID: 8091 RVA: 0x001C106C File Offset: 0x001BF26C
	public RangeInt(int value, int min, int max)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}

	// Token: 0x06001F9C RID: 8092 RVA: 0x001C1089 File Offset: 0x001BF289
	public RangeInt(int min, int max) : this(min, min, max)
	{
	}

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06001F9D RID: 8093 RVA: 0x001C1094 File Offset: 0x001BF294
	// (set) Token: 0x06001F9E RID: 8094 RVA: 0x001C109C File Offset: 0x001BF29C
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
	// (get) Token: 0x06001F9F RID: 8095 RVA: 0x001C10A5 File Offset: 0x001BF2A5
	public int Min
	{
		get
		{
			return this.min;
		}
	}

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x06001FA0 RID: 8096 RVA: 0x001C10AD File Offset: 0x001BF2AD
	public int Max
	{
		get
		{
			return this.max;
		}
	}

	// Token: 0x170004C5 RID: 1221
	// (get) Token: 0x06001FA1 RID: 8097 RVA: 0x001C10B5 File Offset: 0x001BF2B5
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
	// (get) Token: 0x06001FA2 RID: 8098 RVA: 0x001C10D4 File Offset: 0x001BF2D4
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

	// Token: 0x04004268 RID: 17000
	[SerializeField]
	private int value;

	// Token: 0x04004269 RID: 17001
	[SerializeField]
	private int min;

	// Token: 0x0400426A RID: 17002
	[SerializeField]
	private int max;
}
