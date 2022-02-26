using System;
using UnityEngine;

// Token: 0x0200049A RID: 1178
[Serializable]
public class RangeInt
{
	// Token: 0x06001F5A RID: 8026 RVA: 0x001BA210 File Offset: 0x001B8410
	public RangeInt(int value, int min, int max)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}

	// Token: 0x06001F5B RID: 8027 RVA: 0x001BA22D File Offset: 0x001B842D
	public RangeInt(int min, int max) : this(min, min, max)
	{
	}

	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x06001F5C RID: 8028 RVA: 0x001BA238 File Offset: 0x001B8438
	// (set) Token: 0x06001F5D RID: 8029 RVA: 0x001BA240 File Offset: 0x001B8440
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
	// (get) Token: 0x06001F5E RID: 8030 RVA: 0x001BA249 File Offset: 0x001B8449
	public int Min
	{
		get
		{
			return this.min;
		}
	}

	// Token: 0x170004C1 RID: 1217
	// (get) Token: 0x06001F5F RID: 8031 RVA: 0x001BA251 File Offset: 0x001B8451
	public int Max
	{
		get
		{
			return this.max;
		}
	}

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06001F60 RID: 8032 RVA: 0x001BA259 File Offset: 0x001B8459
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
	// (get) Token: 0x06001F61 RID: 8033 RVA: 0x001BA278 File Offset: 0x001B8478
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

	// Token: 0x04004189 RID: 16777
	[SerializeField]
	private int value;

	// Token: 0x0400418A RID: 16778
	[SerializeField]
	private int min;

	// Token: 0x0400418B RID: 16779
	[SerializeField]
	private int max;
}
