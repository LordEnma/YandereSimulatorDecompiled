using System;
using UnityEngine;

// Token: 0x020004F6 RID: 1270
[Serializable]
public struct HighlightTarget
{
	// Token: 0x04004939 RID: 18745
	public Color TargetColor;

	// Token: 0x0400493A RID: 18746
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	public Color ReplacementColor;

	// Token: 0x0400493B RID: 18747
	[Range(0f, 1f)]
	public float Threshold;

	// Token: 0x0400493C RID: 18748
	[Range(0f, 1f)]
	public float SmoothColorInterpolation;
}
