using System;
using UnityEngine;

// Token: 0x0200041D RID: 1053
public class ShadowScript : MonoBehaviour
{
	// Token: 0x06001C6C RID: 7276 RVA: 0x0014ADCC File Offset: 0x00148FCC
	private void Update()
	{
		Vector3 position = base.transform.position;
		Vector3 position2 = this.Foot.position;
		position.x = position2.x;
		position.z = position2.z;
		base.transform.position = position;
	}

	// Token: 0x0400328C RID: 12940
	public Transform Foot;
}
