using System;
using UnityEngine;

// Token: 0x020004EE RID: 1262
public class CameraDepthTextureMode : MonoBehaviour
{
	// Token: 0x060020D1 RID: 8401 RVA: 0x001E42E2 File Offset: 0x001E24E2
	private void OnValidate()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020D2 RID: 8402 RVA: 0x001E42EA File Offset: 0x001E24EA
	private void Awake()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020D3 RID: 8403 RVA: 0x001E42F2 File Offset: 0x001E24F2
	private void SetCameraDepthTextureMode()
	{
		base.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
	}

	// Token: 0x04004870 RID: 18544
	[SerializeField]
	private DepthTextureMode depthTextureMode;
}
