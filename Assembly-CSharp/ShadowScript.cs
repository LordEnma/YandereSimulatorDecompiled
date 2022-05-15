using System;
using UnityEngine;

// Token: 0x02000429 RID: 1065
public class ShadowScript : MonoBehaviour
{
	// Token: 0x06001CBB RID: 7355 RVA: 0x00151B6C File Offset: 0x0014FD6C
	private void Update()
	{
		Vector3 position = base.transform.position;
		Vector3 position2 = this.Foot.position;
		position.x = position2.x;
		position.z = position2.z;
		base.transform.position = position;
	}

	// Token: 0x04003356 RID: 13142
	public Transform Foot;
}
