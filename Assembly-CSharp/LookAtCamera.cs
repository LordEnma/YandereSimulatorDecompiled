using System;
using UnityEngine;

// Token: 0x02000510 RID: 1296
public class LookAtCamera : MonoBehaviour
{
	// Token: 0x06002121 RID: 8481 RVA: 0x001E4C65 File Offset: 0x001E2E65
	private void Start()
	{
		if (this.cameraToLookAt == null)
		{
			this.cameraToLookAt = Camera.main;
		}
	}

	// Token: 0x06002122 RID: 8482 RVA: 0x001E4C80 File Offset: 0x001E2E80
	private void Update()
	{
		Vector3 b = new Vector3(0f, this.cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
		base.transform.LookAt(this.cameraToLookAt.transform.position - b);
	}

	// Token: 0x04004894 RID: 18580
	public Camera cameraToLookAt;
}
