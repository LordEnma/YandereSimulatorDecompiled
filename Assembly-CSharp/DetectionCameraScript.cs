using System;
using UnityEngine;

// Token: 0x02000280 RID: 640
public class DetectionCameraScript : MonoBehaviour
{
	// Token: 0x06001382 RID: 4994 RVA: 0x000B37B8 File Offset: 0x000B19B8
	private void Update()
	{
		base.transform.position = this.YandereChan.transform.position + Vector3.up * 100f;
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}

	// Token: 0x04001CC8 RID: 7368
	public Transform YandereChan;
}
