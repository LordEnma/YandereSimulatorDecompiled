using System;
using UnityEngine;

// Token: 0x02000512 RID: 1298
public class LookAtCamera : MonoBehaviour
{
	// Token: 0x06002135 RID: 8501 RVA: 0x001E6989 File Offset: 0x001E4B89
	private void Start()
	{
		if (this.cameraToLookAt == null)
		{
			this.cameraToLookAt = Camera.main;
		}
	}

	// Token: 0x06002136 RID: 8502 RVA: 0x001E69A4 File Offset: 0x001E4BA4
	private void Update()
	{
		Vector3 b = new Vector3(0f, this.cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
		base.transform.LookAt(this.cameraToLookAt.transform.position - b);
	}

	// Token: 0x040048DC RID: 18652
	public Camera cameraToLookAt;
}
