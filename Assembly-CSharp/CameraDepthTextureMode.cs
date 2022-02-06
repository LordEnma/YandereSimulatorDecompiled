using System;
using UnityEngine;

// Token: 0x020004EE RID: 1262
public class CameraDepthTextureMode : MonoBehaviour
{
	// Token: 0x060020DA RID: 8410 RVA: 0x001E509E File Offset: 0x001E329E
	private void OnValidate()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020DB RID: 8411 RVA: 0x001E50A6 File Offset: 0x001E32A6
	private void Awake()
	{
		this.SetCameraDepthTextureMode();
	}

	// Token: 0x060020DC RID: 8412 RVA: 0x001E50AE File Offset: 0x001E32AE
	private void SetCameraDepthTextureMode()
	{
		base.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
	}

	// Token: 0x04004884 RID: 18564
	[SerializeField]
	private DepthTextureMode depthTextureMode;
}
