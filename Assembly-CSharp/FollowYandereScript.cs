using System;
using UnityEngine;

// Token: 0x020002D2 RID: 722
public class FollowYandereScript : MonoBehaviour
{
	// Token: 0x060014C0 RID: 5312 RVA: 0x000CC540 File Offset: 0x000CA740
	private void Update()
	{
		base.transform.position = new Vector3(this.Yandere.position.x, base.transform.position.y, this.Yandere.position.z);
	}

	// Token: 0x04002086 RID: 8326
	public Transform Yandere;
}
