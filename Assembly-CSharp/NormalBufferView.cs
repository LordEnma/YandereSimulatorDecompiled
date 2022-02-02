using System;
using UnityEngine;

// Token: 0x020004F1 RID: 1265
public class NormalBufferView : MonoBehaviour
{
	// Token: 0x060020DE RID: 8414 RVA: 0x001E4D06 File Offset: 0x001E2F06
	public void ApplyNormalView()
	{
		this.camera.SetReplacementShader(this.normalShader, "RenderType");
	}

	// Token: 0x060020DF RID: 8415 RVA: 0x001E4D1E File Offset: 0x001E2F1E
	public void DisableNormalView()
	{
		this.camera.ResetReplacementShader();
	}

	// Token: 0x04004883 RID: 18563
	[SerializeField]
	private Camera camera;

	// Token: 0x04004884 RID: 18564
	[SerializeField]
	private Shader normalShader;
}
