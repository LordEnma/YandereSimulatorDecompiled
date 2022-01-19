using System;
using UnityEngine;

// Token: 0x02000498 RID: 1176
[Serializable]
public class RangeInt
{
	// Token: 0x06001F43 RID: 8003 RVA: 0x001B881C File Offset: 0x001B6A1C
	public RangeInt(int value, int min, int max)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}

	// Token: 0x06001F44 RID: 8004 RVA: 0x001B8839 File Offset: 0x001B6A39
	public RangeInt(int min, int max) : this(min, min, max)
	{
	}

	// Token: 0x170004BD RID: 1213
	// (get) Token: 0x06001F45 RID: 8005 RVA: 0x001B8844 File Offset: 0x001B6A44
	// (set) Token: 0x06001F46 RID: 8006 RVA: 0x001B884C File Offset: 0x001B6A4C
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

	// Token: 0x170004BE RID: 1214
	// (get) Token: 0x06001F47 RID: 8007 RVA: 0x001B8855 File Offset: 0x001B6A55
	public int Min
	{
		get
		{
			return this.min;
		}
	}

	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x06001F48 RID: 8008 RVA: 0x001B885D File Offset: 0x001B6A5D
	public int Max
	{
		get
		{
			return this.max;
		}
	}

	// Token: 0x170004C0 RID: 1216
	// (get) Token: 0x06001F49 RID: 8009 RVA: 0x001B8865 File Offset: 0x001B6A65
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

	// Token: 0x170004C1 RID: 1217
	// (get) Token: 0x06001F4A RID: 8010 RVA: 0x001B8884 File Offset: 0x001B6A84
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

	// Token: 0x0400415F RID: 16735
	[SerializeField]
	private int value;

	// Token: 0x04004160 RID: 16736
	[SerializeField]
	private int min;

	// Token: 0x04004161 RID: 16737
	[SerializeField]
	private int max;
}
