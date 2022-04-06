using System;
using UnityEngine;

// Token: 0x02000427 RID: 1063
public class ShadowScript : MonoBehaviour
{
	// Token: 0x06001CAA RID: 7338 RVA: 0x001502A0 File Offset: 0x0014E4A0
	private void Update()
	{
		Vector3 position = base.transform.position;
		Vector3 position2 = this.Foot.position;
		position.x = position2.x;
		position.z = position2.z;
		base.transform.position = position;
	}

	// Token: 0x04003327 RID: 13095
	public Transform Foot;
}
