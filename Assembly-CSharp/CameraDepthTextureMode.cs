using System;
using UnityEngine;

// Token: 0x020004EF RID: 1263
public class CameraDepthTextureMode : MonoBehaviour
{
	// Token: 0x060020E1 RID: 8417 RVA: 0x001E5552 File Offset: 0x001E3752
	private void OnValidate()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020E2 RID: 8418 RVA: 0x001E555A File Offset: 0x001E375A
	private void Awake()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020E3 RID: 8419 RVA: 0x001E5562 File Offset: 0x001E3762
	private void SetCameraDepthTextureMode()
	{
		base.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
	}

	// Token: 0x0400488D RID: 18573
	[SerializeField]
	private DepthTextureMode depthTextureMode;
}
