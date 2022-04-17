using System;
using UnityEngine;

// Token: 0x02000427 RID: 1063
public class ShadowScript : MonoBehaviour
{
	// Token: 0x06001CAE RID: 7342 RVA: 0x001506B0 File Offset: 0x0014E8B0
	private void Update()
	{
		Vector3 position = base.transform.position;
		Vector3 position2 = this.Foot.position;
		position.x = position2.x;
		position.z = position2.z;
		base.transform.position = position;
	}

	// Token: 0x04003332 RID: 13106
	public Transform Foot;
}
