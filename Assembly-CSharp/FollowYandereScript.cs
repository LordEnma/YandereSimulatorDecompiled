using System;
using UnityEngine;

// Token: 0x020002D0 RID: 720
public class FollowYandereScript : MonoBehaviour
{
	// Token: 0x060014B5 RID: 5301 RVA: 0x000CC034 File Offset: 0x000CA234
	private void Update()
	{
		base.transform.position = new Vector3(this.Yandere.position.x, base.transform.position.y, this.Yandere.position.z);
	}

	// Token: 0x0400207D RID: 8317
	public Transform Yandere;
}
