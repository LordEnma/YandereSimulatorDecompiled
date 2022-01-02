using System;
using UnityEngine;

// Token: 0x02000280 RID: 640
public class DetectionCameraScript : MonoBehaviour
{
	// Token: 0x06001381 RID: 4993 RVA: 0x000B3520 File Offset: 0x000B1720
	private void Update()
	{
		base.transform.position = this.YandereChan.transform.position + Vector3.up * 100f;
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}

	// Token: 0x04001CC0 RID: 7360
	public Transform YandereChan;
}
