using System;
using UnityEngine;

// Token: 0x02000517 RID: 1303
public class LookAtCamera : MonoBehaviour
{
	// Token: 0x0600215B RID: 8539 RVA: 0x001E9E49 File Offset: 0x001E8049
	private void Start()
	{
		if (this.cameraToLookAt == null)
		{
			this.cameraToLookAt = Camera.main;
		}
	}

	// Token: 0x0600215C RID: 8540 RVA: 0x001E9E64 File Offset: 0x001E8064
	private void Update()
	{
		Vector3 b = new Vector3(0f, this.cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
		base.transform.LookAt(this.cameraToLookAt.transform.position - b);
	}

	// Token: 0x04004924 RID: 18724
	public Camera cameraToLookAt;
}
