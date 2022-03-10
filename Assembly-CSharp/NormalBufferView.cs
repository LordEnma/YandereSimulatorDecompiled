using System;
using UnityEngine;

// Token: 0x020004F4 RID: 1268
public class NormalBufferView : MonoBehaviour
{
	// Token: 0x060020F9 RID: 8441 RVA: 0x001E6C8E File Offset: 0x001E4E8E
	public void ApplyNormalView()
	{
		this.camera.SetReplacementShader(this.normalShader, "RenderType");
	}

	// Token: 0x060020FA RID: 8442 RVA: 0x001E6CA6 File Offset: 0x001E4EA6
	public void DisableNormalView()
	{
		this.camera.ResetReplacementShader();
	}

	// Token: 0x040048C2 RID: 18626
	[SerializeField]
	private Camera camera;

	// Token: 0x040048C3 RID: 18627
	[SerializeField]
	private Shader normalShader;
}
