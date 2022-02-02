using System;
using UnityEngine;

// Token: 0x020004EE RID: 1262
public class CameraDepthTextureMode : MonoBehaviour
{
	// Token: 0x060020D5 RID: 8405 RVA: 0x001E4B82 File Offset: 0x001E2D82
	private void OnValidate()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020D6 RID: 8406 RVA: 0x001E4B8A File Offset: 0x001E2D8A
	private void Awake()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020D7 RID: 8407 RVA: 0x001E4B92 File Offset: 0x001E2D92
	private void SetCameraDepthTextureMode()
	{
		base.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
	}

	// Token: 0x0400487B RID: 18555
	[SerializeField]
	private DepthTextureMode depthTextureMode;
}
