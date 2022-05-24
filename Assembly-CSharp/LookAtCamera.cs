using System;
using UnityEngine;

// Token: 0x02000524 RID: 1316
public class LookAtCamera : MonoBehaviour
{
	// Token: 0x060021AD RID: 8621 RVA: 0x001F20C5 File Offset: 0x001F02C5
	private void Start()
	{
		if (this.cameraToLookAt == null)
		{
			this.cameraToLookAt = Camera.main;
		}
	}

	// Token: 0x060021AE RID: 8622 RVA: 0x001F20E0 File Offset: 0x001F02E0
	private void Update()
	{
		Vector3 b = new Vector3(0f, this.cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
		base.transform.LookAt(this.cameraToLookAt.transform.position - b);
	}

	// Token: 0x04004A2E RID: 18990
	public Camera cameraToLookAt;
}
