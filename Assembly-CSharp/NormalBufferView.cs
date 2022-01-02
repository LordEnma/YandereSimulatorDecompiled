using System;
using UnityEngine;

// Token: 0x020004EE RID: 1262
public class NormalBufferView : MonoBehaviour
{
	// Token: 0x060020CD RID: 8397 RVA: 0x001E2DF6 File Offset: 0x001E0FF6
	public void ApplyNormalView()
	{
		this.camera.SetReplacementShader(this.normalShader, "RenderType");
	}

	// Token: 0x060020CE RID: 8398 RVA: 0x001E2E0E File Offset: 0x001E100E
	public void DisableNormalView()
	{
		this.camera.ResetReplacementShader();
	}

	// Token: 0x0400485D RID: 18525
	[SerializeField]
	private Camera camera;

	// Token: 0x0400485E RID: 18526
	[SerializeField]
	private Shader normalShader;
}
