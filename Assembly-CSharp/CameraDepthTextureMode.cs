using System;
using UnityEngine;

// Token: 0x020004F5 RID: 1269
public class CameraDepthTextureMode : MonoBehaviour
{
	// Token: 0x06002108 RID: 8456 RVA: 0x001E8A72 File Offset: 0x001E6C72
	private void OnValidate()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x06002109 RID: 8457 RVA: 0x001E8A7A File Offset: 0x001E6C7A
	private void Awake()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x0600210A RID: 8458 RVA: 0x001E8A82 File Offset: 0x001E6C82
	private void SetCameraDepthTextureMode()
	{
		base.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
	}

	// Token: 0x04004919 RID: 18713
	[SerializeField]
	private DepthTextureMode depthTextureMode;
}
