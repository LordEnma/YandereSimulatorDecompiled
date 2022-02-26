using System;
using UnityEngine;

// Token: 0x02000422 RID: 1058
public class ShadowScript : MonoBehaviour
{
	// Token: 0x06001C8A RID: 7306 RVA: 0x0014E09C File Offset: 0x0014C29C
	private void Update()
	{
		Vector3 position = base.transform.position;
		Vector3 position2 = this.Foot.position;
		position.x = position2.x;
		position.z = position2.z;
		base.transform.position = position;
	}

	// Token: 0x040032BE RID: 12990
	public Transform Foot;
}
