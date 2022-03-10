using System;
using UnityEngine;

// Token: 0x020002D0 RID: 720
public class FollowYandereScript : MonoBehaviour
{
	// Token: 0x060014B2 RID: 5298 RVA: 0x000CBBC4 File Offset: 0x000C9DC4
	private void Update()
	{
		base.transform.position = new Vector3(this.Yandere.position.x, base.transform.position.y, this.Yandere.position.z);
	}

	// Token: 0x0400206D RID: 8301
	public Transform Yandere;
}
