using System;
using UnityEngine;

// Token: 0x020004F3 RID: 1267
public class NormalBufferView : MonoBehaviour
{
	// Token: 0x060020F3 RID: 8435 RVA: 0x001E62B6 File Offset: 0x001E44B6
	public void ApplyNormalView()
	{
		this.camera.SetReplacementShader(this.normalShader, "RenderType");
	}

	// Token: 0x060020F4 RID: 8436 RVA: 0x001E62CE File Offset: 0x001E44CE
	public void DisableNormalView()
	{
		this.camera.ResetReplacementShader();
	}

	// Token: 0x040048A5 RID: 18597
	[SerializeField]
	private Camera camera;

	// Token: 0x040048A6 RID: 18598
	[SerializeField]
	private Shader normalShader;
}
