using System;
using UnityEngine;

// Token: 0x02000172 RID: 370
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Convert/NormalMap")]
public class CameraFilterPack_Convert_Normal : MonoBehaviour
{
	// Token: 0x17000276 RID: 630
	// (get) Token: 0x06000D6B RID: 3435 RVA: 0x0007620C File Offset: 0x0007440C
	private Material material
	{
		get
		{
			if (this.SCMaterial == null)
			{
				this.SCMaterial = new Material(this.SCShader);
				this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.SCMaterial;
		}
	}

	// Token: 0x06000D6C RID: 3436 RVA: 0x00076240 File Offset: 0x00074440
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Convert_Normal");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D6D RID: 3437 RVA: 0x00076264 File Offset: 0x00074464
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.material.SetFloat("_Heigh", this._Heigh);
			this.material.SetFloat("_Intervale", this._Intervale);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D6E RID: 3438 RVA: 0x000762C0 File Offset: 0x000744C0
	private void Update()
	{
	}

	// Token: 0x06000D6F RID: 3439 RVA: 0x000762C2 File Offset: 0x000744C2
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011B6 RID: 4534
	public Shader SCShader;

	// Token: 0x040011B7 RID: 4535
	[Range(0f, 0.5f)]
	public float _Heigh = 0.0125f;

	// Token: 0x040011B8 RID: 4536
	[Range(0f, 0.25f)]
	public float _Intervale = 0.0025f;

	// Token: 0x040011B9 RID: 4537
	private Material SCMaterial;
}
