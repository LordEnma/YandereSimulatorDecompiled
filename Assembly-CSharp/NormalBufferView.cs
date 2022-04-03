using System;
using UnityEngine;

// Token: 0x020004FC RID: 1276
public class NormalBufferView : MonoBehaviour
{
	// Token: 0x0600211F RID: 8479 RVA: 0x001EA432 File Offset: 0x001E8632
	public void ApplyNormalView()
	{
		this.camera.SetReplacementShader(this.normalShader, "RenderType");
	}

	// Token: 0x06002120 RID: 8480 RVA: 0x001EA44A File Offset: 0x001E864A
	public void DisableNormalView()
	{
		this.camera.ResetReplacementShader();
	}

	// Token: 0x04004952 RID: 18770
	[SerializeField]
	private Camera camera;

	// Token: 0x04004953 RID: 18771
	[SerializeField]
	private Shader normalShader;
}
