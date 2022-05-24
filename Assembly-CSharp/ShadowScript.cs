using System;
using UnityEngine;

// Token: 0x02000429 RID: 1065
public class ShadowScript : MonoBehaviour
{
	// Token: 0x06001CBC RID: 7356 RVA: 0x00151E28 File Offset: 0x00150028
	private void Update()
	{
		Vector3 position = base.transform.position;
		Vector3 position2 = this.Foot.position;
		position.x = position2.x;
		position.z = position2.z;
		base.transform.position = position;
	}

	// Token: 0x0400335E RID: 13150
	public Transform Foot;
}
