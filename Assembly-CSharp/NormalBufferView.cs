using System;
using UnityEngine;

// Token: 0x020004F0 RID: 1264
public class NormalBufferView : MonoBehaviour
{
	// Token: 0x060020D8 RID: 8408 RVA: 0x001E3796 File Offset: 0x001E1996
	public void ApplyNormalView()
	{
		this.camera.SetReplacementShader(this.normalShader, "RenderType");
	}

	// Token: 0x060020D9 RID: 8409 RVA: 0x001E37AE File Offset: 0x001E19AE
	public void DisableNormalView()
	{
		this.camera.ResetReplacementShader();
	}

	// Token: 0x04004871 RID: 18545
	[SerializeField]
	private Camera camera;

	// Token: 0x04004872 RID: 18546
	[SerializeField]
	private Shader normalShader;
}
