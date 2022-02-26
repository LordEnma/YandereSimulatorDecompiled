using System;
using UnityEngine;

// Token: 0x02000233 RID: 563
public class CameraDistanceDisableScript : MonoBehaviour
{
	// Token: 0x06001215 RID: 4629 RVA: 0x0008AC17 File Offset: 0x00088E17
	private void Update()
	{
		if (Vector3.Distance(this.Yandere.position, this.RenderTarget.position) > 15f)
		{
			this.MyCamera.enabled = false;
			return;
		}
		this.MyCamera.enabled = true;
	}

	// Token: 0x040016BE RID: 5822
	public Transform RenderTarget;

	// Token: 0x040016BF RID: 5823
	public Transform Yandere;

	// Token: 0x040016C0 RID: 5824
	public Camera MyCamera;
}
