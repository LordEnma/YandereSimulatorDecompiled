using System;
using UnityEngine;

// Token: 0x020004FF RID: 1279
public class NormalBufferView : MonoBehaviour
{
	// Token: 0x06002142 RID: 8514 RVA: 0x001EDF96 File Offset: 0x001EC196
	public void ApplyNormalView()
	{
		this.camera.SetReplacementShader(this.normalShader, "RenderType");
	}

	// Token: 0x06002143 RID: 8515 RVA: 0x001EDFAE File Offset: 0x001EC1AE
	public void DisableNormalView()
	{
		this.camera.ResetReplacementShader();
	}

	// Token: 0x040049A5 RID: 18853
	[SerializeField]
	private Camera camera;

	// Token: 0x040049A6 RID: 18854
	[SerializeField]
	private Shader normalShader;
}
