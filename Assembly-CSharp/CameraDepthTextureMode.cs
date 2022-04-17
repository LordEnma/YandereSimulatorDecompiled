using System;
using UnityEngine;

// Token: 0x020004FA RID: 1274
public class CameraDepthTextureMode : MonoBehaviour
{
	// Token: 0x06002125 RID: 8485 RVA: 0x001EB23A File Offset: 0x001E943A
	private void OnValidate()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x06002126 RID: 8486 RVA: 0x001EB242 File Offset: 0x001E9442
	private void Awake()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x06002127 RID: 8487 RVA: 0x001EB24A File Offset: 0x001E944A
	private void SetCameraDepthTextureMode()
	{
		base.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
	}

	// Token: 0x04004960 RID: 18784
	[SerializeField]
	private DepthTextureMode depthTextureMode;
}
