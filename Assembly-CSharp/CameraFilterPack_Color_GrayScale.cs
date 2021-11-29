using System;
using UnityEngine;

// Token: 0x0200015F RID: 351
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/GrayScale")]
public class CameraFilterPack_Color_GrayScale : MonoBehaviour
{
	// Token: 0x17000264 RID: 612
	// (get) Token: 0x06000CF9 RID: 3321 RVA: 0x00073FD4 File Offset: 0x000721D4
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

	// Token: 0x06000CFA RID: 3322 RVA: 0x00074008 File Offset: 0x00072208
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_GrayScale");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CFB RID: 3323 RVA: 0x0007402C File Offset: 0x0007222C
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Fade", this._Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CFC RID: 3324 RVA: 0x000740E2 File Offset: 0x000722E2
	private void Update()
	{
	}

	// Token: 0x06000CFD RID: 3325 RVA: 0x000740E4 File Offset: 0x000722E4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001146 RID: 4422
	public Shader SCShader;

	// Token: 0x04001147 RID: 4423
	private float TimeX = 1f;

	// Token: 0x04001148 RID: 4424
	[Range(0f, 1f)]
	public float _Fade = 1f;

	// Token: 0x04001149 RID: 4425
	private Material SCMaterial;
}
