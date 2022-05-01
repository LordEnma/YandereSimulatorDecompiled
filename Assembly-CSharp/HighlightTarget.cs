using System;
using UnityEngine;

// Token: 0x020004F8 RID: 1272
[Serializable]
public struct HighlightTarget
{
	// Token: 0x04004965 RID: 18789
	public Color TargetColor;

	// Token: 0x04004966 RID: 18790
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	public Color ReplacementColor;

	// Token: 0x04004967 RID: 18791
	[Range(0f, 1f)]
	public float Threshold;

	// Token: 0x04004968 RID: 18792
	[Range(0f, 1f)]
	public float SmoothColorInterpolation;
}
