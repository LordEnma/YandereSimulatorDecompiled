using System;
using UnityEngine;

// Token: 0x02000524 RID: 1316
public class LookAtCamera : MonoBehaviour
{
	// Token: 0x060021AC RID: 8620 RVA: 0x001F1B5D File Offset: 0x001EFD5D
	private void Start()
	{
		if (this.cameraToLookAt == null)
		{
			this.cameraToLookAt = Camera.main;
		}
	}

	// Token: 0x060021AD RID: 8621 RVA: 0x001F1B78 File Offset: 0x001EFD78
	private void Update()
	{
		Vector3 b = new Vector3(0f, this.cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
		base.transform.LookAt(this.cameraToLookAt.transform.position - b);
	}

	// Token: 0x04004A25 RID: 18981
	public Camera cameraToLookAt;
}
