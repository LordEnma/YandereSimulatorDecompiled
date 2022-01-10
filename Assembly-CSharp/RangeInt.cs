using System;
using UnityEngine;

// Token: 0x02000497 RID: 1175
[Serializable]
public class RangeInt
{
	// Token: 0x06001F41 RID: 8001 RVA: 0x001B7B4C File Offset: 0x001B5D4C
	public RangeInt(int value, int min, int max)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}

	// Token: 0x06001F42 RID: 8002 RVA: 0x001B7B69 File Offset: 0x001B5D69
	public RangeInt(int min, int max) : this(min, min, max)
	{
	}

	// Token: 0x170004BD RID: 1213
	// (get) Token: 0x06001F43 RID: 8003 RVA: 0x001B7B74 File Offset: 0x001B5D74
	// (set) Token: 0x06001F44 RID: 8004 RVA: 0x001B7B7C File Offset: 0x001B5D7C
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
	// (get) Token: 0x06001F45 RID: 8005 RVA: 0x001B7B85 File Offset: 0x001B5D85
	public int Min
	{
		get
		{
			return this.min;
		}
	}

	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x06001F46 RID: 8006 RVA: 0x001B7B8D File Offset: 0x001B5D8D
	public int Max
	{
		get
		{
			return this.max;
		}
	}

	// Token: 0x170004C0 RID: 1216
	// (get) Token: 0x06001F47 RID: 8007 RVA: 0x001B7B95 File Offset: 0x001B5D95
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
	// (get) Token: 0x06001F48 RID: 8008 RVA: 0x001B7BB4 File Offset: 0x001B5DB4
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

	// Token: 0x04004158 RID: 16728
	[SerializeField]
	private int value;

	// Token: 0x04004159 RID: 16729
	[SerializeField]
	private int min;

	// Token: 0x0400415A RID: 16730
	[SerializeField]
	private int max;
}
