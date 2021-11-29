using System;
using UnityEngine;

// Token: 0x020004E6 RID: 1254
[Serializable]
public struct HighlightTarget
{
	// Token: 0x040047FC RID: 18428
	public Color TargetColor;

	// Token: 0x040047FD RID: 18429
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	public Color ReplacementColor;

	// Token: 0x040047FE RID: 18430
	[Range(0f, 1f)]
	public float Threshold;

	// Token: 0x040047FF RID: 18431
	[Range(0f, 1f)]
	public float SmoothColorInterpolation;
}
