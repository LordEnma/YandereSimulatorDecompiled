using System;
using UnityEngine;

// Token: 0x02000282 RID: 642
public class DetectionCameraScript : MonoBehaviour
{
	// Token: 0x06001394 RID: 5012 RVA: 0x000B45F0 File Offset: 0x000B27F0
	private void Update()
	{
		base.transform.position = this.YandereChan.transform.position + Vector3.up * 100f;
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}

	// Token: 0x04001CF1 RID: 7409
	public Transform YandereChan;
}
