using System;
using UnityEngine;

// Token: 0x02000074 RID: 116
public class MinMaxRangeAttribute : PropertyAttribute
{
	// Token: 0x06000373 RID: 883 RVA: 0x000227E0 File Offset: 0x000209E0
	public MinMaxRangeAttribute(float minLimit, float maxLimit)
	{
		this.minLimit = minLimit;
		this.maxLimit = maxLimit;
	}

	// Token: 0x040004C0 RID: 1216
	public float minLimit;

	// Token: 0x040004C1 RID: 1217
	public float maxLimit;
}
