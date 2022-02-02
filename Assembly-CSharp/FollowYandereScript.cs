using System;
using UnityEngine;

// Token: 0x020002CE RID: 718
public class FollowYandereScript : MonoBehaviour
{
	// Token: 0x060014A4 RID: 5284 RVA: 0x000CAF2C File Offset: 0x000C912C
	private void Update()
	{
		base.transform.position = new Vector3(this.Yandere.position.x, base.transform.position.y, this.Yandere.position.z);
	}

	// Token: 0x0400204C RID: 8268
	public Transform Yandere;
}
