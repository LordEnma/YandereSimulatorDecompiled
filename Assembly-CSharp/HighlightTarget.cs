using System;
using UnityEngine;

// Token: 0x020004EB RID: 1259
[Serializable]
public struct HighlightTarget
{
	// Token: 0x04004870 RID: 18544
	public Color TargetColor;

	// Token: 0x04004871 RID: 18545
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	public Color ReplacementColor;

	// Token: 0x04004872 RID: 18546
	[Range(0f, 1f)]
	public float Threshold;

	// Token: 0x04004873 RID: 18547
	[Range(0f, 1f)]
	public float SmoothColorInterpolation;
}
