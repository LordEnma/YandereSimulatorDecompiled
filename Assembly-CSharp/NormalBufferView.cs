using System;
using UnityEngine;

// Token: 0x020004EE RID: 1262
public class NormalBufferView : MonoBehaviour
{
	// Token: 0x060020CA RID: 8394 RVA: 0x001E2806 File Offset: 0x001E0A06
	public void ApplyNormalView()
	{
		this.camera.SetReplacementShader(this.normalShader, "RenderType");
	}

	// Token: 0x060020CB RID: 8395 RVA: 0x001E281E File Offset: 0x001E0A1E
	public void DisableNormalView()
	{
		this.camera.ResetReplacementShader();
	}

	// Token: 0x04004854 RID: 18516
	[SerializeField]
	private Camera camera;

	// Token: 0x04004855 RID: 18517
	[SerializeField]
	private Shader normalShader;
}
