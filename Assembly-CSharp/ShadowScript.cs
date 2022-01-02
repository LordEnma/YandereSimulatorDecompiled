using System;
using UnityEngine;

// Token: 0x0200041D RID: 1053
public class ShadowScript : MonoBehaviour
{
	// Token: 0x06001C6E RID: 7278 RVA: 0x0014B1D4 File Offset: 0x001493D4
	private void Update()
	{
		Vector3 position = base.transform.position;
		Vector3 position2 = this.Foot.position;
		position.x = position2.x;
		position.z = position2.z;
		base.transform.position = position;
	}

	// Token: 0x04003293 RID: 12947
	public Transform Foot;
}
