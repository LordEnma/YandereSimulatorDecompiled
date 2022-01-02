using System;
using UnityEngine;

// Token: 0x020004E8 RID: 1256
[Serializable]
public struct HighlightTarget
{
	// Token: 0x04004844 RID: 18500
	public Color TargetColor;

	// Token: 0x04004845 RID: 18501
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	public Color ReplacementColor;

	// Token: 0x04004846 RID: 18502
	[Range(0f, 1f)]
	public float Threshold;

	// Token: 0x04004847 RID: 18503
	[Range(0f, 1f)]
	public float SmoothColorInterpolation;
}
