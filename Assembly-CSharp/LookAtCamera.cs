using System;
using UnityEngine;

// Token: 0x02000516 RID: 1302
public class LookAtCamera : MonoBehaviour
{
	// Token: 0x06002152 RID: 8530 RVA: 0x001E9269 File Offset: 0x001E7469
	private void Start()
	{
		if (this.cameraToLookAt == null)
		{
			this.cameraToLookAt = Camera.main;
		}
	}

	// Token: 0x06002153 RID: 8531 RVA: 0x001E9284 File Offset: 0x001E7484
	private void Update()
	{
		Vector3 b = new Vector3(0f, this.cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
		base.transform.LookAt(this.cameraToLookAt.transform.position - b);
	}

	// Token: 0x04004914 RID: 18708
	public Camera cameraToLookAt;
}
