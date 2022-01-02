using System;
using UnityEngine;

// Token: 0x020004EB RID: 1259
public class CameraDepthTextureMode : MonoBehaviour
{
	// Token: 0x060020C4 RID: 8388 RVA: 0x001E2C72 File Offset: 0x001E0E72
	private void OnValidate()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020C5 RID: 8389 RVA: 0x001E2C7A File Offset: 0x001E0E7A
	private void Awake()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020C6 RID: 8390 RVA: 0x001E2C82 File Offset: 0x001E0E82
	private void SetCameraDepthTextureMode()
	{
		base.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
	}

	// Token: 0x04004855 RID: 18517
	[SerializeField]
	private DepthTextureMode depthTextureMode;
}
