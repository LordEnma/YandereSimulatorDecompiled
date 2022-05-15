using System;
using UnityEngine;

// Token: 0x020000D2 RID: 210
public class ArcTrailScript : MonoBehaviour
{
	// Token: 0x060009D8 RID: 2520 RVA: 0x000523F6 File Offset: 0x000505F6
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			this.Trail.material.SetColor("_TintColor", ArcTrailScript.TRAIL_TINT_COLOR);
		}
	}

	// Token: 0x04000A67 RID: 2663
	private static readonly Color TRAIL_TINT_COLOR = new Color(1f, 0f, 0f, 1f);

	// Token: 0x04000A68 RID: 2664
	public TrailRenderer Trail;
}
