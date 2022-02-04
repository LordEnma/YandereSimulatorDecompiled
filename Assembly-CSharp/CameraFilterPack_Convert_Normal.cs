using System;
using UnityEngine;

// Token: 0x02000172 RID: 370
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Convert/NormalMap")]
public class CameraFilterPack_Convert_Normal : MonoBehaviour
{
	// Token: 0x17000276 RID: 630
	// (get) Token: 0x06000D6A RID: 3434 RVA: 0x000760BC File Offset: 0x000742BC
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

	// Token: 0x06000D6B RID: 3435 RVA: 0x000760F0 File Offset: 0x000742F0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Convert_Normal");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D6C RID: 3436 RVA: 0x00076114 File Offset: 0x00074314
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

	// Token: 0x06000D6D RID: 3437 RVA: 0x00076170 File Offset: 0x00074370
	private void Update()
	{
	}

	// Token: 0x06000D6E RID: 3438 RVA: 0x00076172 File Offset: 0x00074372
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011B3 RID: 4531
	public Shader SCShader;

	// Token: 0x040011B4 RID: 4532
	[Range(0f, 0.5f)]
	public float _Heigh = 0.0125f;

	// Token: 0x040011B5 RID: 4533
	[Range(0f, 0.25f)]
	public float _Intervale = 0.0025f;

	// Token: 0x040011B6 RID: 4534
	private Material SCMaterial;
}
