using System;
using UnityEngine;

// Token: 0x020004A1 RID: 1185
[Serializable]
public class RangeInt
{
	// Token: 0x06001F87 RID: 8071 RVA: 0x001BE5A0 File Offset: 0x001BC7A0
	public RangeInt(int value, int min, int max)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}

	// Token: 0x06001F88 RID: 8072 RVA: 0x001BE5BD File Offset: 0x001BC7BD
	public RangeInt(int min, int max) : this(min, min, max)
	{
	}

	// Token: 0x170004C1 RID: 1217
	// (get) Token: 0x06001F89 RID: 8073 RVA: 0x001BE5C8 File Offset: 0x001BC7C8
	// (set) Token: 0x06001F8A RID: 8074 RVA: 0x001BE5D0 File Offset: 0x001BC7D0
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

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06001F8B RID: 8075 RVA: 0x001BE5D9 File Offset: 0x001BC7D9
	public int Min
	{
		get
		{
			return this.min;
		}
	}

	// Token: 0x170004C3 RID: 1219
	// (get) Token: 0x06001F8C RID: 8076 RVA: 0x001BE5E1 File Offset: 0x001BC7E1
	public int Max
	{
		get
		{
			return this.max;
		}
	}

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x06001F8D RID: 8077 RVA: 0x001BE5E9 File Offset: 0x001BC7E9
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

	// Token: 0x170004C5 RID: 1221
	// (get) Token: 0x06001F8E RID: 8078 RVA: 0x001BE608 File Offset: 0x001BC808
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

	// Token: 0x0400422B RID: 16939
	[SerializeField]
	private int value;

	// Token: 0x0400422C RID: 16940
	[SerializeField]
	private int min;

	// Token: 0x0400422D RID: 16941
	[SerializeField]
	private int max;
}
