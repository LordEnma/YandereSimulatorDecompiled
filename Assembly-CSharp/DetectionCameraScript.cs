using System;
using UnityEngine;

// Token: 0x02000281 RID: 641
public class DetectionCameraScript : MonoBehaviour
{
	// Token: 0x06001386 RID: 4998 RVA: 0x000B36E8 File Offset: 0x000B18E8
	private void Update()
	{
		base.transform.position = this.YandereChan.transform.position + Vector3.up * 100f;
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}

	// Token: 0x04001CCB RID: 7371
	public Transform YandereChan;
}
