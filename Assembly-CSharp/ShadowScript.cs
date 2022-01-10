using System;
using UnityEngine;

// Token: 0x0200041F RID: 1055
public class ShadowScript : MonoBehaviour
{
	// Token: 0x06001C75 RID: 7285 RVA: 0x0014B548 File Offset: 0x00149748
	private void Update()
	{
		Vector3 position = base.transform.position;
		Vector3 position2 = this.Foot.position;
		position.x = position2.x;
		position.z = position2.z;
		base.transform.position = position;
	}

	// Token: 0x04003299 RID: 12953
	public Transform Foot;
}
