using System;
using UnityEngine;

// Token: 0x02000232 RID: 562
public class CameraDistanceDisableScript : MonoBehaviour
{
	// Token: 0x06001211 RID: 4625 RVA: 0x0008A7BB File Offset: 0x000889BB
	private void Update()
	{
		if (Vector3.Distance(this.Yandere.position, this.RenderTarget.position) > 15f)
		{
			this.MyCamera.enabled = false;
			return;
		}
		this.MyCamera.enabled = true;
	}

	// Token: 0x040016B6 RID: 5814
	public Transform RenderTarget;

	// Token: 0x040016B7 RID: 5815
	public Transform Yandere;

	// Token: 0x040016B8 RID: 5816
	public Camera MyCamera;
}
