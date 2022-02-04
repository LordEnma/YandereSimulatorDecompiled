using System;
using UnityEngine;

// Token: 0x02000233 RID: 563
public class CameraDistanceDisableScript : MonoBehaviour
{
	// Token: 0x06001214 RID: 4628 RVA: 0x0008A9B3 File Offset: 0x00088BB3
	private void Update()
	{
		if (Vector3.Distance(this.Yandere.position, this.RenderTarget.position) > 15f)
		{
			this.MyCamera.enabled = false;
			return;
		}
		this.MyCamera.enabled = true;
	}

	// Token: 0x040016BB RID: 5819
	public Transform RenderTarget;

	// Token: 0x040016BC RID: 5820
	public Transform Yandere;

	// Token: 0x040016BD RID: 5821
	public Camera MyCamera;
}
