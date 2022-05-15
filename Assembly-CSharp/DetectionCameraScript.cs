using System;
using UnityEngine;

// Token: 0x02000283 RID: 643
public class DetectionCameraScript : MonoBehaviour
{
	// Token: 0x06001396 RID: 5014 RVA: 0x000B4838 File Offset: 0x000B2A38
	private void Update()
	{
		base.transform.position = this.YandereChan.transform.position + Vector3.up * 100f;
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}

	// Token: 0x04001CF8 RID: 7416
	public Transform YandereChan;
}
