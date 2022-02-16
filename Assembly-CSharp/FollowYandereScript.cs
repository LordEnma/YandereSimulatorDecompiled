using System;
using UnityEngine;

// Token: 0x020002CF RID: 719
public class FollowYandereScript : MonoBehaviour
{
	// Token: 0x060014A9 RID: 5289 RVA: 0x000CB164 File Offset: 0x000C9364
	private void Update()
	{
		base.transform.position = new Vector3(this.Yandere.position.x, base.transform.position.y, this.Yandere.position.z);
	}

	// Token: 0x04002054 RID: 8276
	public Transform Yandere;
}
