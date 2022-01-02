using System;
using UnityEngine;

// Token: 0x02000233 RID: 563
public class CameraDistanceDisableScript : MonoBehaviour
{
	// Token: 0x06001214 RID: 4628 RVA: 0x0008A94F File Offset: 0x00088B4F
	private void Update()
	{
		if (Vector3.Distance(this.Yandere.position, this.RenderTarget.position) > 15f)
		{
			this.MyCamera.enabled = false;
			return;
		}
		this.MyCamera.enabled = true;
	}

	// Token: 0x040016B8 RID: 5816
	public Transform RenderTarget;

	// Token: 0x040016B9 RID: 5817
	public Transform Yandere;

	// Token: 0x040016BA RID: 5818
	public Camera MyCamera;
}
