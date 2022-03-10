using System;
using UnityEngine;

// Token: 0x02000281 RID: 641
public class DetectionCameraScript : MonoBehaviour
{
	// Token: 0x06001386 RID: 4998 RVA: 0x000B3A5C File Offset: 0x000B1C5C
	private void Update()
	{
		base.transform.position = this.YandereChan.transform.position + Vector3.up * 100f;
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}

	// Token: 0x04001CD5 RID: 7381
	public Transform YandereChan;
}
