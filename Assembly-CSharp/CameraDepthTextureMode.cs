using System;
using UnityEngine;

// Token: 0x020004EE RID: 1262
public class CameraDepthTextureMode : MonoBehaviour
{
	// Token: 0x060020D7 RID: 8407 RVA: 0x001E4E9A File Offset: 0x001E309A
	private void OnValidate()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020D8 RID: 8408 RVA: 0x001E4EA2 File Offset: 0x001E30A2
	private void Awake()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020D9 RID: 8409 RVA: 0x001E4EAA File Offset: 0x001E30AA
	private void SetCameraDepthTextureMode()
	{
		base.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
	}

	// Token: 0x04004881 RID: 18561
	[SerializeField]
	private DepthTextureMode depthTextureMode;
}
