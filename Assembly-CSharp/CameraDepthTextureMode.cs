using System;
using UnityEngine;

// Token: 0x020004F1 RID: 1265
public class CameraDepthTextureMode : MonoBehaviour
{
	// Token: 0x060020F0 RID: 8432 RVA: 0x001E6B0A File Offset: 0x001E4D0A
	private void OnValidate()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020F1 RID: 8433 RVA: 0x001E6B12 File Offset: 0x001E4D12
	private void Awake()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020F2 RID: 8434 RVA: 0x001E6B1A File Offset: 0x001E4D1A
	private void SetCameraDepthTextureMode()
	{
		base.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
	}

	// Token: 0x040048BA RID: 18618
	[SerializeField]
	private DepthTextureMode depthTextureMode;
}
