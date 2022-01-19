using System;
using UnityEngine;

// Token: 0x02000420 RID: 1056
public class ShadowScript : MonoBehaviour
{
	// Token: 0x06001C77 RID: 7287 RVA: 0x0014CC5C File Offset: 0x0014AE5C
	private void Update()
	{
		Vector3 position = base.transform.position;
		Vector3 position2 = this.Foot.position;
		position.x = position2.x;
		position.z = position2.z;
		base.transform.position = position;
	}

	// Token: 0x0400329E RID: 12958
	public Transform Foot;
}
