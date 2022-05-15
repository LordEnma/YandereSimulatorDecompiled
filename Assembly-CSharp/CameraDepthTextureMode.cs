using System;
using UnityEngine;

// Token: 0x020004FC RID: 1276
public class CameraDepthTextureMode : MonoBehaviour
{
	// Token: 0x06002139 RID: 8505 RVA: 0x001EDE12 File Offset: 0x001EC012
	private void OnValidate()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x0600213A RID: 8506 RVA: 0x001EDE1A File Offset: 0x001EC01A
	private void Awake()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x0600213B RID: 8507 RVA: 0x001EDE22 File Offset: 0x001EC022
	private void SetCameraDepthTextureMode()
	{
		base.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
	}

	// Token: 0x0400499D RID: 18845
	[SerializeField]
	private DepthTextureMode depthTextureMode;
}
