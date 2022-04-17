using System;
using UnityEngine;

// Token: 0x020004F7 RID: 1271
[Serializable]
public struct HighlightTarget
{
	// Token: 0x0400494F RID: 18767
	public Color TargetColor;

	// Token: 0x04004950 RID: 18768
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	public Color ReplacementColor;

	// Token: 0x04004951 RID: 18769
	[Range(0f, 1f)]
	public float Threshold;

	// Token: 0x04004952 RID: 18770
	[Range(0f, 1f)]
	public float SmoothColorInterpolation;
}
