using System;
using UnityEngine;

// Token: 0x020004FD RID: 1277
public class NormalBufferView : MonoBehaviour
{
	// Token: 0x06002127 RID: 8487 RVA: 0x001EA962 File Offset: 0x001E8B62
	public void ApplyNormalView()
	{
		this.camera.SetReplacementShader(this.normalShader, "RenderType");
	}

	// Token: 0x06002128 RID: 8488 RVA: 0x001EA97A File Offset: 0x001E8B7A
	public void DisableNormalView()
	{
		this.camera.ResetReplacementShader();
	}

	// Token: 0x04004956 RID: 18774
	[SerializeField]
	private Camera camera;

	// Token: 0x04004957 RID: 18775
	[SerializeField]
	private Shader normalShader;
}
