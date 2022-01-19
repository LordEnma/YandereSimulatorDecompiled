using System;
using UnityEngine;

// Token: 0x020002CE RID: 718
public class FollowYandereScript : MonoBehaviour
{
	// Token: 0x060014A3 RID: 5283 RVA: 0x000CAB10 File Offset: 0x000C8D10
	private void Update()
	{
		base.transform.position = new Vector3(this.Yandere.position.x, base.transform.position.y, this.Yandere.position.z);
	}

	// Token: 0x04002047 RID: 8263
	public Transform Yandere;
}
