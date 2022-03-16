using System;
using UnityEngine;

// Token: 0x0200051C RID: 1308
public class LookAtCamera : MonoBehaviour
{
	// Token: 0x06002179 RID: 8569 RVA: 0x001EC789 File Offset: 0x001EA989
	private void Start()
	{
		if (this.cameraToLookAt == null)
		{
			this.cameraToLookAt = Camera.main;
		}
	}

	// Token: 0x0600217A RID: 8570 RVA: 0x001EC7A4 File Offset: 0x001EA9A4
	private void Update()
	{
		Vector3 b = new Vector3(0f, this.cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
		base.transform.LookAt(this.cameraToLookAt.transform.position - b);
	}

	// Token: 0x040049A0 RID: 18848
	public Camera cameraToLookAt;
}
