using System;
using UnityEngine;

// Token: 0x020004EB RID: 1259
[Serializable]
public struct HighlightTarget
{
	// Token: 0x04004873 RID: 18547
	public Color TargetColor;

	// Token: 0x04004874 RID: 18548
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	public Color ReplacementColor;

	// Token: 0x04004875 RID: 18549
	[Range(0f, 1f)]
	public float Threshold;

	// Token: 0x04004876 RID: 18550
	[Range(0f, 1f)]
	public float SmoothColorInterpolation;
}
