using System;
using UnityEngine;

// Token: 0x020002D2 RID: 722
public class FollowYandereScript : MonoBehaviour
{
	// Token: 0x060014BE RID: 5310 RVA: 0x000CC378 File Offset: 0x000CA578
	private void Update()
	{
		base.transform.position = new Vector3(this.Yandere.position.x, base.transform.position.y, this.Yandere.position.z);
	}

	// Token: 0x04002084 RID: 8324
	public Transform Yandere;
}
