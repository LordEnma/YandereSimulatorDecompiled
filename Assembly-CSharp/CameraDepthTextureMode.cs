using System;
using UnityEngine;

// Token: 0x020004FC RID: 1276
public class CameraDepthTextureMode : MonoBehaviour
{
	// Token: 0x0600213A RID: 8506 RVA: 0x001EE37A File Offset: 0x001EC57A
	private void OnValidate()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x0600213B RID: 8507 RVA: 0x001EE382 File Offset: 0x001EC582
	private void Awake()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x0600213C RID: 8508 RVA: 0x001EE38A File Offset: 0x001EC58A
	private void SetCameraDepthTextureMode()
	{
		base.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
	}

	// Token: 0x040049A6 RID: 18854
	[SerializeField]
	private DepthTextureMode depthTextureMode;
}
