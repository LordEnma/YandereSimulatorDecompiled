using System;
using UnityEngine;

// Token: 0x020004FA RID: 1274
public class CameraDepthTextureMode : MonoBehaviour
{
	// Token: 0x0600211E RID: 8478 RVA: 0x001EA7DE File Offset: 0x001E89DE
	private void OnValidate()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x0600211F RID: 8479 RVA: 0x001EA7E6 File Offset: 0x001E89E6
	private void Awake()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x06002120 RID: 8480 RVA: 0x001EA7EE File Offset: 0x001E89EE
	private void SetCameraDepthTextureMode()
	{
		base.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
	}

	// Token: 0x0400494E RID: 18766
	[SerializeField]
	private DepthTextureMode depthTextureMode;
}
