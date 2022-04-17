using System;
using UnityEngine;

// Token: 0x020004FD RID: 1277
public class NormalBufferView : MonoBehaviour
{
	// Token: 0x0600212E RID: 8494 RVA: 0x001EB3BE File Offset: 0x001E95BE
	public void ApplyNormalView()
	{
		this.camera.SetReplacementShader(this.normalShader, "RenderType");
	}

	// Token: 0x0600212F RID: 8495 RVA: 0x001EB3D6 File Offset: 0x001E95D6
	public void DisableNormalView()
	{
		this.camera.ResetReplacementShader();
	}

	// Token: 0x04004968 RID: 18792
	[SerializeField]
	private Camera camera;

	// Token: 0x04004969 RID: 18793
	[SerializeField]
	private Shader normalShader;
}
