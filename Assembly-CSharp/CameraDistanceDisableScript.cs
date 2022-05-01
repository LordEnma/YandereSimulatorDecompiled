using System;
using UnityEngine;

// Token: 0x02000233 RID: 563
public class CameraDistanceDisableScript : MonoBehaviour
{
	// Token: 0x06001217 RID: 4631 RVA: 0x0008B433 File Offset: 0x00089633
	private void Update()
	{
		if (Vector3.Distance(this.Yandere.position, this.RenderTarget.position) > 15f)
		{
			this.MyCamera.enabled = false;
			return;
		}
		this.MyCamera.enabled = true;
	}

	// Token: 0x040016D1 RID: 5841
	public Transform RenderTarget;

	// Token: 0x040016D2 RID: 5842
	public Transform Yandere;

	// Token: 0x040016D3 RID: 5843
	public Camera MyCamera;
}
