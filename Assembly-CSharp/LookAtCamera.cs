using System;
using UnityEngine;

// Token: 0x02000523 RID: 1315
public class LookAtCamera : MonoBehaviour
{
	// Token: 0x060021A2 RID: 8610 RVA: 0x001F050D File Offset: 0x001EE70D
	private void Start()
	{
		if (this.cameraToLookAt == null)
		{
			this.cameraToLookAt = Camera.main;
		}
	}

	// Token: 0x060021A3 RID: 8611 RVA: 0x001F0528 File Offset: 0x001EE728
	private void Update()
	{
		Vector3 b = new Vector3(0f, this.cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
		base.transform.LookAt(this.cameraToLookAt.transform.position - b);
	}

	// Token: 0x040049FE RID: 18942
	public Camera cameraToLookAt;
}
