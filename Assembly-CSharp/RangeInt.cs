using System;
using UnityEngine;

// Token: 0x02000494 RID: 1172
[Serializable]
public class RangeInt
{
	// Token: 0x06001F29 RID: 7977 RVA: 0x001B5F38 File Offset: 0x001B4138
	public RangeInt(int value, int min, int max)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}

	// Token: 0x06001F2A RID: 7978 RVA: 0x001B5F55 File Offset: 0x001B4155
	public RangeInt(int min, int max) : this(min, min, max)
	{
	}

	// Token: 0x170004BC RID: 1212
	// (get) Token: 0x06001F2B RID: 7979 RVA: 0x001B5F60 File Offset: 0x001B4160
	// (set) Token: 0x06001F2C RID: 7980 RVA: 0x001B5F68 File Offset: 0x001B4168
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

	// Token: 0x170004BD RID: 1213
	// (get) Token: 0x06001F2D RID: 7981 RVA: 0x001B5F71 File Offset: 0x001B4171
	public int Min
	{
		get
		{
			return this.min;
		}
	}

	// Token: 0x170004BE RID: 1214
	// (get) Token: 0x06001F2E RID: 7982 RVA: 0x001B5F79 File Offset: 0x001B4179
	public int Max
	{
		get
		{
			return this.max;
		}
	}

	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x06001F2F RID: 7983 RVA: 0x001B5F81 File Offset: 0x001B4181
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

	// Token: 0x170004C0 RID: 1216
	// (get) Token: 0x06001F30 RID: 7984 RVA: 0x001B5FA0 File Offset: 0x001B41A0
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

	// Token: 0x0400410D RID: 16653
	[SerializeField]
	private int value;

	// Token: 0x0400410E RID: 16654
	[SerializeField]
	private int min;

	// Token: 0x0400410F RID: 16655
	[SerializeField]
	private int max;
}
