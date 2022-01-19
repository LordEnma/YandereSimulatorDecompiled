using System;
using UnityEngine;

// Token: 0x020004EB RID: 1259
[Serializable]
public struct HighlightTarget
{
	// Token: 0x0400485F RID: 18527
	public Color TargetColor;

	// Token: 0x04004860 RID: 18528
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	public Color ReplacementColor;

	// Token: 0x04004861 RID: 18529
	[Range(0f, 1f)]
	public float Threshold;

	// Token: 0x04004862 RID: 18530
	[Range(0f, 1f)]
	public float SmoothColorInterpolation;
}
