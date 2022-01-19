using System;
using UnityEngine;

// Token: 0x020004F1 RID: 1265
public class NormalBufferView : MonoBehaviour
{
	// Token: 0x060020DA RID: 8410 RVA: 0x001E4466 File Offset: 0x001E2666
	public void ApplyNormalView()
	{
		this.camera.SetReplacementShader(this.normalShader, "RenderType");
	}

	// Token: 0x060020DB RID: 8411 RVA: 0x001E447E File Offset: 0x001E267E
	public void DisableNormalView()
	{
		this.camera.ResetReplacementShader();
	}

	// Token: 0x04004878 RID: 18552
	[SerializeField]
	private Camera camera;

	// Token: 0x04004879 RID: 18553
	[SerializeField]
	private Shader normalShader;
}
