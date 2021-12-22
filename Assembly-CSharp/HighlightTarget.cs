using System;
using UnityEngine;

// Token: 0x020004E8 RID: 1256
[Serializable]
public struct HighlightTarget
{
	// Token: 0x0400483B RID: 18491
	public Color TargetColor;

	// Token: 0x0400483C RID: 18492
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	public Color ReplacementColor;

	// Token: 0x0400483D RID: 18493
	[Range(0f, 1f)]
	public float Threshold;

	// Token: 0x0400483E RID: 18494
	[Range(0f, 1f)]
	public float SmoothColorInterpolation;
}
