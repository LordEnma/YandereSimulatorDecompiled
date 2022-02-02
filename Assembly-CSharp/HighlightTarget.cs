using System;
using UnityEngine;

// Token: 0x020004EB RID: 1259
[Serializable]
public struct HighlightTarget
{
	// Token: 0x0400486A RID: 18538
	public Color TargetColor;

	// Token: 0x0400486B RID: 18539
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	public Color ReplacementColor;

	// Token: 0x0400486C RID: 18540
	[Range(0f, 1f)]
	public float Threshold;

	// Token: 0x0400486D RID: 18541
	[Range(0f, 1f)]
	public float SmoothColorInterpolation;
}
