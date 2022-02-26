using System;
using UnityEngine;

// Token: 0x020004ED RID: 1261
[Serializable]
public struct HighlightTarget
{
	// Token: 0x0400488C RID: 18572
	public Color TargetColor;

	// Token: 0x0400488D RID: 18573
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	public Color ReplacementColor;

	// Token: 0x0400488E RID: 18574
	[Range(0f, 1f)]
	public float Threshold;

	// Token: 0x0400488F RID: 18575
	[Range(0f, 1f)]
	public float SmoothColorInterpolation;
}
