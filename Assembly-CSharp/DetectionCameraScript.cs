using System;
using UnityEngine;

// Token: 0x02000280 RID: 640
public class DetectionCameraScript : MonoBehaviour
{
	// Token: 0x06001381 RID: 4993 RVA: 0x000B35A0 File Offset: 0x000B17A0
	private void Update()
	{
		base.transform.position = this.YandereChan.transform.position + Vector3.up * 100f;
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}

	// Token: 0x04001CC2 RID: 7362
	public Transform YandereChan;
}
