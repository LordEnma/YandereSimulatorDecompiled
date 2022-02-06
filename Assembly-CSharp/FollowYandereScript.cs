using System;
using UnityEngine;

// Token: 0x020002CE RID: 718
public class FollowYandereScript : MonoBehaviour
{
	// Token: 0x060014A4 RID: 5284 RVA: 0x000CB070 File Offset: 0x000C9270
	private void Update()
	{
		base.transform.position = new Vector3(this.Yandere.position.x, base.transform.position.y, this.Yandere.position.z);
	}

	// Token: 0x0400204F RID: 8271
	public Transform Yandere;
}
