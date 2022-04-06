using System;
using UnityEngine;

// Token: 0x020004F7 RID: 1271
[Serializable]
public struct HighlightTarget
{
	// Token: 0x0400493D RID: 18749
	public Color TargetColor;

	// Token: 0x0400493E RID: 18750
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	public Color ReplacementColor;

	// Token: 0x0400493F RID: 18751
	[Range(0f, 1f)]
	public float Threshold;

	// Token: 0x04004940 RID: 18752
	[Range(0f, 1f)]
	public float SmoothColorInterpolation;
}
