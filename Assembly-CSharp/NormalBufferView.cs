using System;
using UnityEngine;

// Token: 0x020004F8 RID: 1272
public class NormalBufferView : MonoBehaviour
{
	// Token: 0x06002111 RID: 8465 RVA: 0x001E8BF6 File Offset: 0x001E6DF6
	public void ApplyNormalView()
	{
		this.camera.SetReplacementShader(this.normalShader, "RenderType");
	}

	// Token: 0x06002112 RID: 8466 RVA: 0x001E8C0E File Offset: 0x001E6E0E
	public void DisableNormalView()
	{
		this.camera.ResetReplacementShader();
	}

	// Token: 0x04004921 RID: 18721
	[SerializeField]
	private Camera camera;

	// Token: 0x04004922 RID: 18722
	[SerializeField]
	private Shader normalShader;
}
