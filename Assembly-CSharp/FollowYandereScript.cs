using System;
using UnityEngine;

// Token: 0x020002D3 RID: 723
public class FollowYandereScript : MonoBehaviour
{
	// Token: 0x060014C6 RID: 5318 RVA: 0x000CCD68 File Offset: 0x000CAF68
	private void Update()
	{
		base.transform.position = new Vector3(this.Yandere.position.x, base.transform.position.y, this.Yandere.position.z);
	}

	// Token: 0x04002096 RID: 8342
	public Transform Yandere;
}
