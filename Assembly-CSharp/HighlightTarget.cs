using System;
using UnityEngine;

// Token: 0x020004F9 RID: 1273
[Serializable]
public struct HighlightTarget
{
	// Token: 0x0400498C RID: 18828
	public Color TargetColor;

	// Token: 0x0400498D RID: 18829
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	public Color ReplacementColor;

	// Token: 0x0400498E RID: 18830
	[Range(0f, 1f)]
	public float Threshold;

	// Token: 0x0400498F RID: 18831
	[Range(0f, 1f)]
	public float SmoothColorInterpolation;
}
