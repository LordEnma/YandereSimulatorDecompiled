using System;
using UnityEngine;

// Token: 0x020004F9 RID: 1273
[Serializable]
public struct HighlightTarget
{
	// Token: 0x04004995 RID: 18837
	public Color TargetColor;

	// Token: 0x04004996 RID: 18838
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	public Color ReplacementColor;

	// Token: 0x04004997 RID: 18839
	[Range(0f, 1f)]
	public float Threshold;

	// Token: 0x04004998 RID: 18840
	[Range(0f, 1f)]
	public float SmoothColorInterpolation;
}
