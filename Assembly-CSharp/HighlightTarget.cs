using System;
using UnityEngine;

// Token: 0x020004EC RID: 1260
[Serializable]
public struct HighlightTarget
{
	// Token: 0x0400487C RID: 18556
	public Color TargetColor;

	// Token: 0x0400487D RID: 18557
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	public Color ReplacementColor;

	// Token: 0x0400487E RID: 18558
	[Range(0f, 1f)]
	public float Threshold;

	// Token: 0x0400487F RID: 18559
	[Range(0f, 1f)]
	public float SmoothColorInterpolation;
}
