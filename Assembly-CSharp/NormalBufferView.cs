using System;
using UnityEngine;

// Token: 0x020004EC RID: 1260
public class NormalBufferView : MonoBehaviour
{
	// Token: 0x060020B9 RID: 8377 RVA: 0x001E10D2 File Offset: 0x001DF2D2
	public void ApplyNormalView()
	{
		this.camera.SetReplacementShader(this.normalShader, "RenderType");
	}

	// Token: 0x060020BA RID: 8378 RVA: 0x001E10EA File Offset: 0x001DF2EA
	public void DisableNormalView()
	{
		this.camera.ResetReplacementShader();
	}

	// Token: 0x04004815 RID: 18453
	[SerializeField]
	private Camera camera;

	// Token: 0x04004816 RID: 18454
	[SerializeField]
	private Shader normalShader;
}
