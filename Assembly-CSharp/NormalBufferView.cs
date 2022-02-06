using System;
using UnityEngine;

// Token: 0x020004F1 RID: 1265
public class NormalBufferView : MonoBehaviour
{
	// Token: 0x060020E3 RID: 8419 RVA: 0x001E5222 File Offset: 0x001E3422
	public void ApplyNormalView()
	{
		this.camera.SetReplacementShader(this.normalShader, "RenderType");
	}

	// Token: 0x060020E4 RID: 8420 RVA: 0x001E523A File Offset: 0x001E343A
	public void DisableNormalView()
	{
		this.camera.ResetReplacementShader();
	}

	// Token: 0x0400488C RID: 18572
	[SerializeField]
	private Camera camera;

	// Token: 0x0400488D RID: 18573
	[SerializeField]
	private Shader normalShader;
}
