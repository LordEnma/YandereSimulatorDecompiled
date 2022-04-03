using System;
using UnityEngine;

// Token: 0x02000233 RID: 563
public class CameraDistanceDisableScript : MonoBehaviour
{
	// Token: 0x06001217 RID: 4631 RVA: 0x0008B1C3 File Offset: 0x000893C3
	private void Update()
	{
		if (Vector3.Distance(this.Yandere.position, this.RenderTarget.position) > 15f)
		{
			this.MyCamera.enabled = false;
			return;
		}
		this.MyCamera.enabled = true;
	}

	// Token: 0x040016CE RID: 5838
	public Transform RenderTarget;

	// Token: 0x040016CF RID: 5839
	public Transform Yandere;

	// Token: 0x040016D0 RID: 5840
	public Camera MyCamera;
}
