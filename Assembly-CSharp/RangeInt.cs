using System;
using UnityEngine;

// Token: 0x0200049A RID: 1178
[Serializable]
public class RangeInt
{
	// Token: 0x06001F5D RID: 8029 RVA: 0x001BA9B0 File Offset: 0x001B8BB0
	public RangeInt(int value, int min, int max)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}

	// Token: 0x06001F5E RID: 8030 RVA: 0x001BA9CD File Offset: 0x001B8BCD
	public RangeInt(int min, int max) : this(min, min, max)
	{
	}

	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x06001F5F RID: 8031 RVA: 0x001BA9D8 File Offset: 0x001B8BD8
	// (set) Token: 0x06001F60 RID: 8032 RVA: 0x001BA9E0 File Offset: 0x001B8BE0
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

	// Token: 0x170004C0 RID: 1216
	// (get) Token: 0x06001F61 RID: 8033 RVA: 0x001BA9E9 File Offset: 0x001B8BE9
	public int Min
	{
		get
		{
			return this.min;
		}
	}

	// Token: 0x170004C1 RID: 1217
	// (get) Token: 0x06001F62 RID: 8034 RVA: 0x001BA9F1 File Offset: 0x001B8BF1
	public int Max
	{
		get
		{
			return this.max;
		}
	}

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06001F63 RID: 8035 RVA: 0x001BA9F9 File Offset: 0x001B8BF9
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

	// Token: 0x170004C3 RID: 1219
	// (get) Token: 0x06001F64 RID: 8036 RVA: 0x001BAA18 File Offset: 0x001B8C18
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

	// Token: 0x040041A0 RID: 16800
	[SerializeField]
	private int value;

	// Token: 0x040041A1 RID: 16801
	[SerializeField]
	private int min;

	// Token: 0x040041A2 RID: 16802
	[SerializeField]
	private int max;
}
