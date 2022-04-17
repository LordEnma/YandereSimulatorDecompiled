using System;
using UnityEngine;

// Token: 0x02000522 RID: 1314
public class LookAtCamera : MonoBehaviour
{
	// Token: 0x06002198 RID: 8600 RVA: 0x001EEF85 File Offset: 0x001ED185
	private void Start()
	{
		if (this.cameraToLookAt == null)
		{
			this.cameraToLookAt = Camera.main;
		}
	}

	// Token: 0x06002199 RID: 8601 RVA: 0x001EEFA0 File Offset: 0x001ED1A0
	private void Update()
	{
		Vector3 b = new Vector3(0f, this.cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
		base.transform.LookAt(this.cameraToLookAt.transform.position - b);
	}

	// Token: 0x040049E8 RID: 18920
	public Camera cameraToLookAt;
}
