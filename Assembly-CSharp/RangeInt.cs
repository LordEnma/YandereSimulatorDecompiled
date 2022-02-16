using System;
using UnityEngine;

// Token: 0x02000499 RID: 1177
[Serializable]
public class RangeInt
{
	// Token: 0x06001F51 RID: 8017 RVA: 0x001B96C4 File Offset: 0x001B78C4
	public RangeInt(int value, int min, int max)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}

	// Token: 0x06001F52 RID: 8018 RVA: 0x001B96E1 File Offset: 0x001B78E1
	public RangeInt(int min, int max) : this(min, min, max)
	{
	}

	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x06001F53 RID: 8019 RVA: 0x001B96EC File Offset: 0x001B78EC
	// (set) Token: 0x06001F54 RID: 8020 RVA: 0x001B96F4 File Offset: 0x001B78F4
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
	// (get) Token: 0x06001F55 RID: 8021 RVA: 0x001B96FD File Offset: 0x001B78FD
	public int Min
	{
		get
		{
			return this.min;
		}
	}

	// Token: 0x170004C1 RID: 1217
	// (get) Token: 0x06001F56 RID: 8022 RVA: 0x001B9705 File Offset: 0x001B7905
	public int Max
	{
		get
		{
			return this.max;
		}
	}

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06001F57 RID: 8023 RVA: 0x001B970D File Offset: 0x001B790D
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
	// (get) Token: 0x06001F58 RID: 8024 RVA: 0x001B972C File Offset: 0x001B792C
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

	// Token: 0x04004179 RID: 16761
	[SerializeField]
	private int value;

	// Token: 0x0400417A RID: 16762
	[SerializeField]
	private int min;

	// Token: 0x0400417B RID: 16763
	[SerializeField]
	private int max;
}
