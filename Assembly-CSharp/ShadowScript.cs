using System;
using UnityEngine;

// Token: 0x02000420 RID: 1056
public class ShadowScript : MonoBehaviour
{
	// Token: 0x06001C7A RID: 7290 RVA: 0x0014D32C File Offset: 0x0014B52C
	private void Update()
	{
		Vector3 position = base.transform.position;
		Vector3 position2 = this.Foot.position;
		position.x = position2.x;
		position.z = position2.z;
		base.transform.position = position;
	}

	// Token: 0x040032A8 RID: 12968
	public Transform Foot;
}
