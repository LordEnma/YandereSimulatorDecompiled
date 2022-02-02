using System;
using UnityEngine;

// Token: 0x02000420 RID: 1056
public class ShadowScript : MonoBehaviour
{
	// Token: 0x06001C78 RID: 7288 RVA: 0x0014D090 File Offset: 0x0014B290
	private void Update()
	{
		Vector3 position = base.transform.position;
		Vector3 position2 = this.Foot.position;
		position.x = position2.x;
		position.z = position2.z;
		base.transform.position = position;
	}

	// Token: 0x040032A4 RID: 12964
	public Transform Foot;
}
