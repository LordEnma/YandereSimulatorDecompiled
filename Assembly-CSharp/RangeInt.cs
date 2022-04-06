using System;
using UnityEngine;

// Token: 0x020004A1 RID: 1185
[Serializable]
public class RangeInt
{
	// Token: 0x06001F81 RID: 8065 RVA: 0x001BDBC4 File Offset: 0x001BBDC4
	public RangeInt(int value, int min, int max)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}

	// Token: 0x06001F82 RID: 8066 RVA: 0x001BDBE1 File Offset: 0x001BBDE1
	public RangeInt(int min, int max) : this(min, min, max)
	{
	}

	// Token: 0x170004C0 RID: 1216
	// (get) Token: 0x06001F83 RID: 8067 RVA: 0x001BDBEC File Offset: 0x001BBDEC
	// (set) Token: 0x06001F84 RID: 8068 RVA: 0x001BDBF4 File Offset: 0x001BBDF4
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

	// Token: 0x170004C1 RID: 1217
	// (get) Token: 0x06001F85 RID: 8069 RVA: 0x001BDBFD File Offset: 0x001BBDFD
	public int Min
	{
		get
		{
			return this.min;
		}
	}

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06001F86 RID: 8070 RVA: 0x001BDC05 File Offset: 0x001BBE05
	public int Max
	{
		get
		{
			return this.max;
		}
	}

	// Token: 0x170004C3 RID: 1219
	// (get) Token: 0x06001F87 RID: 8071 RVA: 0x001BDC0D File Offset: 0x001BBE0D
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

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x06001F88 RID: 8072 RVA: 0x001BDC2C File Offset: 0x001BBE2C
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

	// Token: 0x0400421B RID: 16923
	[SerializeField]
	private int value;

	// Token: 0x0400421C RID: 16924
	[SerializeField]
	private int min;

	// Token: 0x0400421D RID: 16925
	[SerializeField]
	private int max;
}
