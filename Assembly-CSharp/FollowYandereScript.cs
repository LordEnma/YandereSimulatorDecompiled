using System;
using UnityEngine;

// Token: 0x020002CD RID: 717
public class FollowYandereScript : MonoBehaviour
{
	// Token: 0x0600149F RID: 5279 RVA: 0x000CA4FC File Offset: 0x000C86FC
	private void Update()
	{
		base.transform.position = new Vector3(this.Yandere.position.x, base.transform.position.y, this.Yandere.position.z);
	}

	// Token: 0x0400203D RID: 8253
	public Transform Yandere;
}
