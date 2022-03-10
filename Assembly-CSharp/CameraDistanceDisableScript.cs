using System;
using UnityEngine;

// Token: 0x02000233 RID: 563
public class CameraDistanceDisableScript : MonoBehaviour
{
	// Token: 0x06001215 RID: 4629 RVA: 0x0008AD5F File Offset: 0x00088F5F
	private void Update()
	{
		if (Vector3.Distance(this.Yandere.position, this.RenderTarget.position) > 15f)
		{
			this.MyCamera.enabled = false;
			return;
		}
		this.MyCamera.enabled = true;
	}

	// Token: 0x040016C7 RID: 5831
	public Transform RenderTarget;

	// Token: 0x040016C8 RID: 5832
	public Transform Yandere;

	// Token: 0x040016C9 RID: 5833
	public Camera MyCamera;
}
