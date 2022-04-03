using System;
using UnityEngine;

// Token: 0x020004A0 RID: 1184
[Serializable]
public class RangeInt
{
	// Token: 0x06001F79 RID: 8057 RVA: 0x001BD6BC File Offset: 0x001BB8BC
	public RangeInt(int value, int min, int max)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}

	// Token: 0x06001F7A RID: 8058 RVA: 0x001BD6D9 File Offset: 0x001BB8D9
	public RangeInt(int min, int max) : this(min, min, max)
	{
	}

	// Token: 0x170004C0 RID: 1216
	// (get) Token: 0x06001F7B RID: 8059 RVA: 0x001BD6E4 File Offset: 0x001BB8E4
	// (set) Token: 0x06001F7C RID: 8060 RVA: 0x001BD6EC File Offset: 0x001BB8EC
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
	// (get) Token: 0x06001F7D RID: 8061 RVA: 0x001BD6F5 File Offset: 0x001BB8F5
	public int Min
	{
		get
		{
			return this.min;
		}
	}

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06001F7E RID: 8062 RVA: 0x001BD6FD File Offset: 0x001BB8FD
	public int Max
	{
		get
		{
			return this.max;
		}
	}

	// Token: 0x170004C3 RID: 1219
	// (get) Token: 0x06001F7F RID: 8063 RVA: 0x001BD705 File Offset: 0x001BB905
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
	// (get) Token: 0x06001F80 RID: 8064 RVA: 0x001BD724 File Offset: 0x001BB924
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

	// Token: 0x04004218 RID: 16920
	[SerializeField]
	private int value;

	// Token: 0x04004219 RID: 16921
	[SerializeField]
	private int min;

	// Token: 0x0400421A RID: 16922
	[SerializeField]
	private int max;
}
