using System;
using UnityEngine;

// Token: 0x020004F9 RID: 1273
public class CameraDepthTextureMode : MonoBehaviour
{
	// Token: 0x06002116 RID: 8470 RVA: 0x001EA2AE File Offset: 0x001E84AE
	private void OnValidate()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x06002117 RID: 8471 RVA: 0x001EA2B6 File Offset: 0x001E84B6
	private void Awake()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x06002118 RID: 8472 RVA: 0x001EA2BE File Offset: 0x001E84BE
	private void SetCameraDepthTextureMode()
	{
		base.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
	}

	// Token: 0x0400494A RID: 18762
	[SerializeField]
	private DepthTextureMode depthTextureMode;
}
