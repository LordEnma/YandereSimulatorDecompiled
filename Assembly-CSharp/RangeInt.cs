using System;
using UnityEngine;

// Token: 0x02000498 RID: 1176
[Serializable]
public class RangeInt
{
	// Token: 0x06001F4A RID: 8010 RVA: 0x001B9270 File Offset: 0x001B7470
	public RangeInt(int value, int min, int max)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}

	// Token: 0x06001F4B RID: 8011 RVA: 0x001B928D File Offset: 0x001B748D
	public RangeInt(int min, int max) : this(min, min, max)
	{
	}

	// Token: 0x170004BE RID: 1214
	// (get) Token: 0x06001F4C RID: 8012 RVA: 0x001B9298 File Offset: 0x001B7498
	// (set) Token: 0x06001F4D RID: 8013 RVA: 0x001B92A0 File Offset: 0x001B74A0
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

	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x06001F4E RID: 8014 RVA: 0x001B92A9 File Offset: 0x001B74A9
	public int Min
	{
		get
		{
			return this.min;
		}
	}

	// Token: 0x170004C0 RID: 1216
	// (get) Token: 0x06001F4F RID: 8015 RVA: 0x001B92B1 File Offset: 0x001B74B1
	public int Max
	{
		get
		{
			return this.max;
		}
	}

	// Token: 0x170004C1 RID: 1217
	// (get) Token: 0x06001F50 RID: 8016 RVA: 0x001B92B9 File Offset: 0x001B74B9
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

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06001F51 RID: 8017 RVA: 0x001B92D8 File Offset: 0x001B74D8
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

	// Token: 0x04004170 RID: 16752
	[SerializeField]
	private int value;

	// Token: 0x04004171 RID: 16753
	[SerializeField]
	private int min;

	// Token: 0x04004172 RID: 16754
	[SerializeField]
	private int max;
}
