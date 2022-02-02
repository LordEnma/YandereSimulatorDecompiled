using System;
using UnityEngine;

// Token: 0x02000498 RID: 1176
[Serializable]
public class RangeInt
{
	// Token: 0x06001F45 RID: 8005 RVA: 0x001B8D44 File Offset: 0x001B6F44
	public RangeInt(int value, int min, int max)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}

	// Token: 0x06001F46 RID: 8006 RVA: 0x001B8D61 File Offset: 0x001B6F61
	public RangeInt(int min, int max) : this(min, min, max)
	{
	}

	// Token: 0x170004BD RID: 1213
	// (get) Token: 0x06001F47 RID: 8007 RVA: 0x001B8D6C File Offset: 0x001B6F6C
	// (set) Token: 0x06001F48 RID: 8008 RVA: 0x001B8D74 File Offset: 0x001B6F74
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
	// (get) Token: 0x06001F49 RID: 8009 RVA: 0x001B8D7D File Offset: 0x001B6F7D
	public int Min
	{
		get
		{
			return this.min;
		}
	}

	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x06001F4A RID: 8010 RVA: 0x001B8D85 File Offset: 0x001B6F85
	public int Max
	{
		get
		{
			return this.max;
		}
	}

	// Token: 0x170004C0 RID: 1216
	// (get) Token: 0x06001F4B RID: 8011 RVA: 0x001B8D8D File Offset: 0x001B6F8D
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
	// (get) Token: 0x06001F4C RID: 8012 RVA: 0x001B8DAC File Offset: 0x001B6FAC
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

	// Token: 0x04004167 RID: 16743
	[SerializeField]
	private int value;

	// Token: 0x04004168 RID: 16744
	[SerializeField]
	private int min;

	// Token: 0x04004169 RID: 16745
	[SerializeField]
	private int max;
}
