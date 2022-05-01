using System;
using UnityEngine;

// Token: 0x020004FE RID: 1278
public class NormalBufferView : MonoBehaviour
{
	// Token: 0x06002137 RID: 8503 RVA: 0x001EC84A File Offset: 0x001EAA4A
	public void ApplyNormalView()
	{
		this.camera.SetReplacementShader(this.normalShader, "RenderType");
	}

	// Token: 0x06002138 RID: 8504 RVA: 0x001EC862 File Offset: 0x001EAA62
	public void DisableNormalView()
	{
		this.camera.ResetReplacementShader();
	}

	// Token: 0x0400497E RID: 18814
	[SerializeField]
	private Camera camera;

	// Token: 0x0400497F RID: 18815
	[SerializeField]
	private Shader normalShader;
}
