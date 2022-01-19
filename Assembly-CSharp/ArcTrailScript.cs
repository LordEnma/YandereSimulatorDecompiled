using System;
using UnityEngine;

// Token: 0x020000D2 RID: 210
public class ArcTrailScript : MonoBehaviour
{
	// Token: 0x060009D8 RID: 2520 RVA: 0x00052036 File Offset: 0x00050236
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			this.Trail.material.SetColor("_TintColor", ArcTrailScript.TRAIL_TINT_COLOR);
		}
	}

	// Token: 0x04000A5A RID: 2650
	private static readonly Color TRAIL_TINT_COLOR = new Color(1f, 0f, 0f, 1f);

	// Token: 0x04000A5B RID: 2651
	public TrailRenderer Trail;
}
