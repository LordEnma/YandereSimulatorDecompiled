using System;
using UnityEngine;

// Token: 0x02000216 RID: 534
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/RGB Display")]
public class CameraFilterPack_TV_Rgb : MonoBehaviour
{
	// Token: 0x1700031B RID: 795
	// (get) Token: 0x06001169 RID: 4457 RVA: 0x000879F1 File Offset: 0x00085BF1
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

	// Token: 0x0600116A RID: 4458 RVA: 0x00087A25 File Offset: 0x00085C25
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Rgb");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600116B RID: 4459 RVA: 0x00087A48 File Offset: 0x00085C48
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
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600116C RID: 4460 RVA: 0x00087AFE File Offset: 0x00085CFE
	private void Update()
	{
	}

	// Token: 0x0600116D RID: 4461 RVA: 0x00087B00 File Offset: 0x00085D00
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015F6 RID: 5622
	public Shader SCShader;

	// Token: 0x040015F7 RID: 5623
	private float TimeX = 1f;

	// Token: 0x040015F8 RID: 5624
	[Range(0.01f, 4f)]
	public float Distortion = 1f;

	// Token: 0x040015F9 RID: 5625
	private Material SCMaterial;
}
