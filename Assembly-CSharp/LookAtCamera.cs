using System;
using UnityEngine;

// Token: 0x02000512 RID: 1298
public class LookAtCamera : MonoBehaviour
{
	// Token: 0x06002132 RID: 8498 RVA: 0x001E6399 File Offset: 0x001E4599
	private void Start()
	{
		if (this.cameraToLookAt == null)
		{
			this.cameraToLookAt = Camera.main;
		}
	}

	// Token: 0x06002133 RID: 8499 RVA: 0x001E63B4 File Offset: 0x001E45B4
	private void Update()
	{
		Vector3 b = new Vector3(0f, this.cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
		base.transform.LookAt(this.cameraToLookAt.transform.position - b);
	}

	// Token: 0x040048D3 RID: 18643
	public Camera cameraToLookAt;
}
