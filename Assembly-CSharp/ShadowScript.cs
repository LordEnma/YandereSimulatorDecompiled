using System;
using UnityEngine;

// Token: 0x0200041C RID: 1052
public class ShadowScript : MonoBehaviour
{
	// Token: 0x06001C64 RID: 7268 RVA: 0x0014A4C8 File Offset: 0x001486C8
	private void Update()
	{
		Vector3 position = base.transform.position;
		Vector3 position2 = this.Foot.position;
		position.x = position2.x;
		position.z = position2.z;
		base.transform.position = position;
	}

	// Token: 0x04003261 RID: 12897
	public Transform Foot;
}
