using System;
using UnityEngine;

// Token: 0x020004EB RID: 1259
public class CameraDepthTextureMode : MonoBehaviour
{
	// Token: 0x060020C1 RID: 8385 RVA: 0x001E2682 File Offset: 0x001E0882
	private void OnValidate()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020C2 RID: 8386 RVA: 0x001E268A File Offset: 0x001E088A
	private void Awake()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020C3 RID: 8387 RVA: 0x001E2692 File Offset: 0x001E0892
	private void SetCameraDepthTextureMode()
	{
		base.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
	}

	// Token: 0x0400484C RID: 18508
	[SerializeField]
	private DepthTextureMode depthTextureMode;
}
