using System;
using UnityEngine;

// Token: 0x02000428 RID: 1064
public class ShadowScript : MonoBehaviour
{
	// Token: 0x06001CB5 RID: 7349 RVA: 0x00150EEC File Offset: 0x0014F0EC
	private void Update()
	{
		Vector3 position = base.transform.position;
		Vector3 position2 = this.Foot.position;
		position.x = position2.x;
		position.z = position2.z;
		base.transform.position = position;
	}

	// Token: 0x04003341 RID: 13121
	public Transform Foot;
}
