using System;
using UnityEngine;

// Token: 0x020002CC RID: 716
public class FollowYandereScript : MonoBehaviour
{
	// Token: 0x06001498 RID: 5272 RVA: 0x000C9D58 File Offset: 0x000C7F58
	private void Update()
	{
		base.transform.position = new Vector3(this.Yandere.position.x, base.transform.position.y, this.Yandere.position.z);
	}

	// Token: 0x0400201D RID: 8221
	public Transform Yandere;
}
