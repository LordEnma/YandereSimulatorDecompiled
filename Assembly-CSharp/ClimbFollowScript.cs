using System;
using UnityEngine;

// Token: 0x0200001F RID: 31
public class ClimbFollowScript : MonoBehaviour
{
	// Token: 0x0600007F RID: 127 RVA: 0x0001106C File Offset: 0x0000F26C
	private void Update()
	{
		base.transform.position = new Vector3(base.transform.position.x, this.Yandere.position.y, base.transform.position.z);
	}

	// Token: 0x0400025E RID: 606
	public Transform Yandere;
}
