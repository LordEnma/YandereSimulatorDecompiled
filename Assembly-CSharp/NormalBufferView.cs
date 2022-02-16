using System;
using UnityEngine;

// Token: 0x020004F2 RID: 1266
public class NormalBufferView : MonoBehaviour
{
	// Token: 0x060020EA RID: 8426 RVA: 0x001E56D6 File Offset: 0x001E38D6
	public void ApplyNormalView()
	{
		this.camera.SetReplacementShader(this.normalShader, "RenderType");
	}

	// Token: 0x060020EB RID: 8427 RVA: 0x001E56EE File Offset: 0x001E38EE
	public void DisableNormalView()
	{
		this.camera.ResetReplacementShader();
	}

	// Token: 0x04004895 RID: 18581
	[SerializeField]
	private Camera camera;

	// Token: 0x04004896 RID: 18582
	[SerializeField]
	private Shader normalShader;
}
