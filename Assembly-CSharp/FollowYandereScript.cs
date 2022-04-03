using System;
using UnityEngine;

// Token: 0x020002D1 RID: 721
public class FollowYandereScript : MonoBehaviour
{
	// Token: 0x060014B8 RID: 5304 RVA: 0x000CC270 File Offset: 0x000CA470
	private void Update()
	{
		base.transform.position = new Vector3(this.Yandere.position.x, base.transform.position.y, this.Yandere.position.z);
	}

	// Token: 0x04002082 RID: 8322
	public Transform Yandere;
}
