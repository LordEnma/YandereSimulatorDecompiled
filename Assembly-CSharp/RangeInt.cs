using System;
using UnityEngine;

// Token: 0x02000495 RID: 1173
[Serializable]
public class RangeInt
{
	// Token: 0x06001F36 RID: 7990 RVA: 0x001B71CC File Offset: 0x001B53CC
	public RangeInt(int value, int min, int max)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}

	// Token: 0x06001F37 RID: 7991 RVA: 0x001B71E9 File Offset: 0x001B53E9
	public RangeInt(int min, int max) : this(min, min, max)
	{
	}

	// Token: 0x170004BD RID: 1213
	// (get) Token: 0x06001F38 RID: 7992 RVA: 0x001B71F4 File Offset: 0x001B53F4
	// (set) Token: 0x06001F39 RID: 7993 RVA: 0x001B71FC File Offset: 0x001B53FC
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
	// (get) Token: 0x06001F3A RID: 7994 RVA: 0x001B7205 File Offset: 0x001B5405
	public int Min
	{
		get
		{
			return this.min;
		}
	}

	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x06001F3B RID: 7995 RVA: 0x001B720D File Offset: 0x001B540D
	public int Max
	{
		get
		{
			return this.max;
		}
	}

	// Token: 0x170004C0 RID: 1216
	// (get) Token: 0x06001F3C RID: 7996 RVA: 0x001B7215 File Offset: 0x001B5415
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
	// (get) Token: 0x06001F3D RID: 7997 RVA: 0x001B7234 File Offset: 0x001B5434
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

	// Token: 0x04004144 RID: 16708
	[SerializeField]
	private int value;

	// Token: 0x04004145 RID: 16709
	[SerializeField]
	private int min;

	// Token: 0x04004146 RID: 16710
	[SerializeField]
	private int max;
}
