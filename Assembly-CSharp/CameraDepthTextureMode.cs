using System;
using UnityEngine;

// Token: 0x020004FB RID: 1275
public class CameraDepthTextureMode : MonoBehaviour
{
	// Token: 0x0600212F RID: 8495 RVA: 0x001EC7C2 File Offset: 0x001EA9C2
	private void OnValidate()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x06002130 RID: 8496 RVA: 0x001EC7CA File Offset: 0x001EA9CA
	private void Awake()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x06002131 RID: 8497 RVA: 0x001EC7D2 File Offset: 0x001EA9D2
	private void SetCameraDepthTextureMode()
	{
		base.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
	}

	// Token: 0x04004976 RID: 18806
	[SerializeField]
	private DepthTextureMode depthTextureMode;
}
