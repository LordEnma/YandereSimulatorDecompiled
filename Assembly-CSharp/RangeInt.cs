using System;
using UnityEngine;

// Token: 0x02000498 RID: 1176
[Serializable]
public class RangeInt
{
	// Token: 0x06001F47 RID: 8007 RVA: 0x001B9050 File Offset: 0x001B7250
	public RangeInt(int value, int min, int max)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}

	// Token: 0x06001F48 RID: 8008 RVA: 0x001B906D File Offset: 0x001B726D
	public RangeInt(int min, int max) : this(min, min, max)
	{
	}

	// Token: 0x170004BD RID: 1213
	// (get) Token: 0x06001F49 RID: 8009 RVA: 0x001B9078 File Offset: 0x001B7278
	// (set) Token: 0x06001F4A RID: 8010 RVA: 0x001B9080 File Offset: 0x001B7280
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
	// (get) Token: 0x06001F4B RID: 8011 RVA: 0x001B9089 File Offset: 0x001B7289
	public int Min
	{
		get
		{
			return this.min;
		}
	}

	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x06001F4C RID: 8012 RVA: 0x001B9091 File Offset: 0x001B7291
	public int Max
	{
		get
		{
			return this.max;
		}
	}

	// Token: 0x170004C0 RID: 1216
	// (get) Token: 0x06001F4D RID: 8013 RVA: 0x001B9099 File Offset: 0x001B7299
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
	// (get) Token: 0x06001F4E RID: 8014 RVA: 0x001B90B8 File Offset: 0x001B72B8
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

	// Token: 0x0400416D RID: 16749
	[SerializeField]
	private int value;

	// Token: 0x0400416E RID: 16750
	[SerializeField]
	private int min;

	// Token: 0x0400416F RID: 16751
	[SerializeField]
	private int max;
}
