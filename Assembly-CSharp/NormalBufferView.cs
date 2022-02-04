using System;
using UnityEngine;

// Token: 0x020004F1 RID: 1265
public class NormalBufferView : MonoBehaviour
{
	// Token: 0x060020E0 RID: 8416 RVA: 0x001E501E File Offset: 0x001E321E
	public void ApplyNormalView()
	{
		this.camera.SetReplacementShader(this.normalShader, "RenderType");
	}

	// Token: 0x060020E1 RID: 8417 RVA: 0x001E5036 File Offset: 0x001E3236
	public void DisableNormalView()
	{
		this.camera.ResetReplacementShader();
	}

	// Token: 0x04004889 RID: 18569
	[SerializeField]
	private Camera camera;

	// Token: 0x0400488A RID: 18570
	[SerializeField]
	private Shader normalShader;
}
