using System;
using UnityEngine;

// Token: 0x020004ED RID: 1261
public class CameraDepthTextureMode : MonoBehaviour
{
	// Token: 0x060020CF RID: 8399 RVA: 0x001E3612 File Offset: 0x001E1812
	private void OnValidate()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020D0 RID: 8400 RVA: 0x001E361A File Offset: 0x001E181A
	private void Awake()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020D1 RID: 8401 RVA: 0x001E3622 File Offset: 0x001E1822
	private void SetCameraDepthTextureMode()
	{
		base.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
	}

	// Token: 0x04004869 RID: 18537
	[SerializeField]
	private DepthTextureMode depthTextureMode;
}
