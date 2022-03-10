using System;
using UnityEngine;

// Token: 0x020004EE RID: 1262
[Serializable]
public struct HighlightTarget
{
	// Token: 0x040048A9 RID: 18601
	public Color TargetColor;

	// Token: 0x040048AA RID: 18602
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	public Color ReplacementColor;

	// Token: 0x040048AB RID: 18603
	[Range(0f, 1f)]
	public float Threshold;

	// Token: 0x040048AC RID: 18604
	[Range(0f, 1f)]
	public float SmoothColorInterpolation;
}
