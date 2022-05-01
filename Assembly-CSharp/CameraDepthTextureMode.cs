using System;
using UnityEngine;

// Token: 0x020004FB RID: 1275
public class CameraDepthTextureMode : MonoBehaviour
{
	// Token: 0x0600212E RID: 8494 RVA: 0x001EC6C6 File Offset: 0x001EA8C6
	private void OnValidate()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x0600212F RID: 8495 RVA: 0x001EC6CE File Offset: 0x001EA8CE
	private void Awake()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x06002130 RID: 8496 RVA: 0x001EC6D6 File Offset: 0x001EA8D6
	private void SetCameraDepthTextureMode()
	{
		base.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
	}

	// Token: 0x04004976 RID: 18806
	[SerializeField]
	private DepthTextureMode depthTextureMode;
}
