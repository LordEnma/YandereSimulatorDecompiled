using System;
using UnityEngine;

// Token: 0x02000281 RID: 641
public class DetectionCameraScript : MonoBehaviour
{
	// Token: 0x06001389 RID: 5001 RVA: 0x000B3E38 File Offset: 0x000B2038
	private void Update()
	{
		base.transform.position = this.YandereChan.transform.position + Vector3.up * 100f;
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}

	// Token: 0x04001CE3 RID: 7395
	public Transform YandereChan;
}
