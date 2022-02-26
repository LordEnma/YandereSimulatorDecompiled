using System;
using UnityEngine;

// Token: 0x020004F0 RID: 1264
public class CameraDepthTextureMode : MonoBehaviour
{
	// Token: 0x060020EA RID: 8426 RVA: 0x001E6132 File Offset: 0x001E4332
	private void OnValidate()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020EB RID: 8427 RVA: 0x001E613A File Offset: 0x001E433A
	private void Awake()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020EC RID: 8428 RVA: 0x001E6142 File Offset: 0x001E4342
	private void SetCameraDepthTextureMode()
	{
		base.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
	}

	// Token: 0x0400489D RID: 18589
	[SerializeField]
	private DepthTextureMode depthTextureMode;
}
