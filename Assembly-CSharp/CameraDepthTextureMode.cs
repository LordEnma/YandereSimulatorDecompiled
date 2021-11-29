using System;
using UnityEngine;

// Token: 0x020004E9 RID: 1257
public class CameraDepthTextureMode : MonoBehaviour
{
	// Token: 0x060020B0 RID: 8368 RVA: 0x001E0F4E File Offset: 0x001DF14E
	private void OnValidate()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020B1 RID: 8369 RVA: 0x001E0F56 File Offset: 0x001DF156
	private void Awake()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020B2 RID: 8370 RVA: 0x001E0F5E File Offset: 0x001DF15E
	private void SetCameraDepthTextureMode()
	{
		base.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
	}

	// Token: 0x0400480D RID: 18445
	[SerializeField]
	private DepthTextureMode depthTextureMode;
}
