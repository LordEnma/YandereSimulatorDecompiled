using System;
using UnityEngine;

// Token: 0x02000281 RID: 641
public class DetectionCameraScript : MonoBehaviour
{
	// Token: 0x0600138A RID: 5002 RVA: 0x000B3EE8 File Offset: 0x000B20E8
	private void Update()
	{
		base.transform.position = this.YandereChan.transform.position + Vector3.up * 100f;
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}

	// Token: 0x04001CE6 RID: 7398
	public Transform YandereChan;
}
