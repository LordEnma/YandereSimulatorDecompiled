using System;
using UnityEngine;

// Token: 0x020004F2 RID: 1266
[Serializable]
public struct HighlightTarget
{
	// Token: 0x04004908 RID: 18696
	public Color TargetColor;

	// Token: 0x04004909 RID: 18697
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	public Color ReplacementColor;

	// Token: 0x0400490A RID: 18698
	[Range(0f, 1f)]
	public float Threshold;

	// Token: 0x0400490B RID: 18699
	[Range(0f, 1f)]
	public float SmoothColorInterpolation;
}
