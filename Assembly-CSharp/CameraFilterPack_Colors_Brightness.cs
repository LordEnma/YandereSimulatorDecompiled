using System;
using UnityEngine;

// Token: 0x0200016B RID: 363
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Brightness")]
public class CameraFilterPack_Colors_Brightness : MonoBehaviour
{
	// Token: 0x1700026F RID: 623
	// (get) Token: 0x06000D40 RID: 3392 RVA: 0x0007575C File Offset: 0x0007395C
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

	// Token: 0x06000D41 RID: 3393 RVA: 0x00075790 File Offset: 0x00073990
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_Brightness");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D42 RID: 3394 RVA: 0x000757B1 File Offset: 0x000739B1
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.material.SetFloat("_Val", this._Brightness);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D43 RID: 3395 RVA: 0x000757EC File Offset: 0x000739EC
	private void Update()
	{
	}

	// Token: 0x06000D44 RID: 3396 RVA: 0x000757EE File Offset: 0x000739EE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400118A RID: 4490
	public Shader SCShader;

	// Token: 0x0400118B RID: 4491
	[Range(0f, 2f)]
	public float _Brightness = 1.5f;

	// Token: 0x0400118C RID: 4492
	private Material SCMaterial;
}
