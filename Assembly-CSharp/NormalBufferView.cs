using System;
using UnityEngine;

// Token: 0x020004FF RID: 1279
public class NormalBufferView : MonoBehaviour
{
	// Token: 0x06002143 RID: 8515 RVA: 0x001EE4FE File Offset: 0x001EC6FE
	public void ApplyNormalView()
	{
		this.camera.SetReplacementShader(this.normalShader, "RenderType");
	}

	// Token: 0x06002144 RID: 8516 RVA: 0x001EE516 File Offset: 0x001EC716
	public void DisableNormalView()
	{
		this.camera.ResetReplacementShader();
	}

	// Token: 0x040049AE RID: 18862
	[SerializeField]
	private Camera camera;

	// Token: 0x040049AF RID: 18863
	[SerializeField]
	private Shader normalShader;
}
