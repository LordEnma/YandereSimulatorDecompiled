using System;
using UnityEngine;

// Token: 0x02000074 RID: 116
public class MinMaxRangeAttribute : PropertyAttribute
{
	// Token: 0x06000373 RID: 883 RVA: 0x000226A0 File Offset: 0x000208A0
	public MinMaxRangeAttribute(float minLimit, float maxLimit)
	{
		this.minLimit = minLimit;
		this.maxLimit = maxLimit;
	}

	// Token: 0x040004BE RID: 1214
	public float minLimit;

	// Token: 0x040004BF RID: 1215
	public float maxLimit;
}
