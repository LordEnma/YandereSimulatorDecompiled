using System;
using UnityEngine;

// Token: 0x020004EA RID: 1258
[Serializable]
public struct HighlightTarget
{
	// Token: 0x04004858 RID: 18520
	public Color TargetColor;

	// Token: 0x04004859 RID: 18521
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	public Color ReplacementColor;

	// Token: 0x0400485A RID: 18522
	[Range(0f, 1f)]
	public float Threshold;

	// Token: 0x0400485B RID: 18523
	[Range(0f, 1f)]
	public float SmoothColorInterpolation;
}
