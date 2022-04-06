using System;
using UnityEngine;

// Token: 0x0200015F RID: 351
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Contrast")]
public class CameraFilterPack_Color_Contrast : MonoBehaviour
{
	// Token: 0x17000263 RID: 611
	// (get) Token: 0x06000CF9 RID: 3321 RVA: 0x000748AE File Offset: 0x00072AAE
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

	// Token: 0x06000CFA RID: 3322 RVA: 0x000748E2 File Offset: 0x00072AE2
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Contrast");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CFB RID: 3323 RVA: 0x00074904 File Offset: 0x00072B04
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_Contrast", this.Contrast);
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CFC RID: 3324 RVA: 0x000749BA File Offset: 0x00072BBA
	private void Update()
	{
	}

	// Token: 0x06000CFD RID: 3325 RVA: 0x000749BC File Offset: 0x00072BBC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400115A RID: 4442
	public Shader SCShader;

	// Token: 0x0400115B RID: 4443
	private float TimeX = 1f;

	// Token: 0x0400115C RID: 4444
	private Material SCMaterial;

	// Token: 0x0400115D RID: 4445
	[Range(0f, 10f)]
	public float Contrast = 4.5f;
}
