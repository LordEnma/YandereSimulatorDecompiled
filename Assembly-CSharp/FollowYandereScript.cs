using System;
using UnityEngine;

// Token: 0x020002D2 RID: 722
public class FollowYandereScript : MonoBehaviour
{
	// Token: 0x060014C4 RID: 5316 RVA: 0x000CC9D4 File Offset: 0x000CABD4
	private void Update()
	{
		base.transform.position = new Vector3(this.Yandere.position.x, base.transform.position.y, this.Yandere.position.z);
	}

	// Token: 0x0400208F RID: 8335
	public Transform Yandere;
}
