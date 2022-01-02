using System;
using UnityEngine;

// Token: 0x02000074 RID: 116
public class MinMaxRangeAttribute : PropertyAttribute
{
	// Token: 0x06000373 RID: 883 RVA: 0x000224F8 File Offset: 0x000206F8
	public MinMaxRangeAttribute(float minLimit, float maxLimit)
	{
		this.minLimit = minLimit;
		this.maxLimit = maxLimit;
	}

	// Token: 0x040004B3 RID: 1203
	public float minLimit;

	// Token: 0x040004B4 RID: 1204
	public float maxLimit;
}
