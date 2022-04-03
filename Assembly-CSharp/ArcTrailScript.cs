using System;
using UnityEngine;

// Token: 0x020000D2 RID: 210
public class ArcTrailScript : MonoBehaviour
{
	// Token: 0x060009D8 RID: 2520 RVA: 0x0005212E File Offset: 0x0005032E
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			this.Trail.material.SetColor("_TintColor", ArcTrailScript.TRAIL_TINT_COLOR);
		}
	}

	// Token: 0x04000A65 RID: 2661
	private static readonly Color TRAIL_TINT_COLOR = new Color(1f, 0f, 0f, 1f);

	// Token: 0x04000A66 RID: 2662
	public TrailRenderer Trail;
}
