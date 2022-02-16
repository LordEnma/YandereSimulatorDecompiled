using System;
using UnityEngine;

// Token: 0x02000074 RID: 116
public class MinMaxRangeAttribute : PropertyAttribute
{
	// Token: 0x06000373 RID: 883 RVA: 0x000224F0 File Offset: 0x000206F0
	public MinMaxRangeAttribute(float minLimit, float maxLimit)
	{
		this.minLimit = minLimit;
		this.maxLimit = maxLimit;
	}

	// Token: 0x040004B5 RID: 1205
	public float minLimit;

	// Token: 0x040004B6 RID: 1206
	public float maxLimit;
}
