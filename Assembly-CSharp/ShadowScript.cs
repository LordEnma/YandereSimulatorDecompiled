using System;
using UnityEngine;

// Token: 0x02000422 RID: 1058
public class ShadowScript : MonoBehaviour
{
	// Token: 0x06001C8C RID: 7308 RVA: 0x0014E5D8 File Offset: 0x0014C7D8
	private void Update()
	{
		Vector3 position = base.transform.position;
		Vector3 position2 = this.Foot.position;
		position.x = position2.x;
		position.z = position2.z;
		base.transform.position = position;
	}

	// Token: 0x040032D4 RID: 13012
	public Transform Foot;
}
