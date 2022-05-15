using System;
using UnityEngine;

// Token: 0x02000234 RID: 564
public class CameraDistanceDisableScript : MonoBehaviour
{
	// Token: 0x06001219 RID: 4633 RVA: 0x0008B75F File Offset: 0x0008995F
	private void Update()
	{
		if (Vector3.Distance(this.Yandere.position, this.RenderTarget.position) > 15f)
		{
			this.MyCamera.enabled = false;
			return;
		}
		this.MyCamera.enabled = true;
	}

	// Token: 0x040016D7 RID: 5847
	public Transform RenderTarget;

	// Token: 0x040016D8 RID: 5848
	public Transform Yandere;

	// Token: 0x040016D9 RID: 5849
	public Camera MyCamera;
}
