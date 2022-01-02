using System;
using UnityEngine;

// Token: 0x020002CD RID: 717
public class FollowYandereScript : MonoBehaviour
{
	// Token: 0x0600149F RID: 5279 RVA: 0x000CA744 File Offset: 0x000C8944
	private void Update()
	{
		base.transform.position = new Vector3(this.Yandere.position.x, base.transform.position.y, this.Yandere.position.z);
	}

	// Token: 0x04002040 RID: 8256
	public Transform Yandere;
}
