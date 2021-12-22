using System;
using UnityEngine;

// Token: 0x02000495 RID: 1173
[Serializable]
public class RangeInt
{
	// Token: 0x06001F33 RID: 7987 RVA: 0x001B6CF4 File Offset: 0x001B4EF4
	public RangeInt(int value, int min, int max)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}

	// Token: 0x06001F34 RID: 7988 RVA: 0x001B6D11 File Offset: 0x001B4F11
	public RangeInt(int min, int max) : this(min, min, max)
	{
	}

	// Token: 0x170004BC RID: 1212
	// (get) Token: 0x06001F35 RID: 7989 RVA: 0x001B6D1C File Offset: 0x001B4F1C
	// (set) Token: 0x06001F36 RID: 7990 RVA: 0x001B6D24 File Offset: 0x001B4F24
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
	// (get) Token: 0x06001F37 RID: 7991 RVA: 0x001B6D2D File Offset: 0x001B4F2D
	public int Min
	{
		get
		{
			return this.min;
		}
	}

	// Token: 0x170004BE RID: 1214
	// (get) Token: 0x06001F38 RID: 7992 RVA: 0x001B6D35 File Offset: 0x001B4F35
	public int Max
	{
		get
		{
			return this.max;
		}
	}

	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x06001F39 RID: 7993 RVA: 0x001B6D3D File Offset: 0x001B4F3D
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
	// (get) Token: 0x06001F3A RID: 7994 RVA: 0x001B6D5C File Offset: 0x001B4F5C
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

	// Token: 0x0400413D RID: 16701
	[SerializeField]
	private int value;

	// Token: 0x0400413E RID: 16702
	[SerializeField]
	private int min;

	// Token: 0x0400413F RID: 16703
	[SerializeField]
	private int max;
}
