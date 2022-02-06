using System;
using UnityEngine;

// Token: 0x02000515 RID: 1301
public class LookAtCamera : MonoBehaviour
{
	// Token: 0x0600214B RID: 8523 RVA: 0x001E8DB5 File Offset: 0x001E6FB5
	private void Start()
	{
		if (this.cameraToLookAt == null)
		{
			this.cameraToLookAt = Camera.main;
		}
	}

	// Token: 0x0600214C RID: 8524 RVA: 0x001E8DD0 File Offset: 0x001E6FD0
	private void Update()
	{
		Vector3 b = new Vector3(0f, this.cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
		base.transform.LookAt(this.cameraToLookAt.transform.position - b);
	}

	// Token: 0x0400490B RID: 18699
	public Camera cameraToLookAt;
}
