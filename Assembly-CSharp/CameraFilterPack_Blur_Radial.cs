using System;
using UnityEngine;

// Token: 0x02000150 RID: 336
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Radial")]
public class CameraFilterPack_Blur_Radial : MonoBehaviour
{
	// Token: 0x17000254 RID: 596
	// (get) Token: 0x06000C9D RID: 3229 RVA: 0x000728A5 File Offset: 0x00070AA5
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

	// Token: 0x06000C9E RID: 3230 RVA: 0x000728D9 File Offset: 0x00070AD9
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Radial");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C9F RID: 3231 RVA: 0x000728FC File Offset: 0x00070AFC
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
			this.material.SetFloat("_Value", this.Intensity);
			this.material.SetFloat("_Value2", this.MovX);
			this.material.SetFloat("_Value3", this.MovY);
			this.material.SetFloat("_Value4", this.blurWidth);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CA0 RID: 3232 RVA: 0x000729F4 File Offset: 0x00070BF4
	private void Update()
	{
	}

	// Token: 0x06000CA1 RID: 3233 RVA: 0x000729F6 File Offset: 0x00070BF6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010E3 RID: 4323
	public Shader SCShader;

	// Token: 0x040010E4 RID: 4324
	private float TimeX = 1f;

	// Token: 0x040010E5 RID: 4325
	private Material SCMaterial;

	// Token: 0x040010E6 RID: 4326
	[Range(-0.5f, 0.5f)]
	public float Intensity = 0.125f;

	// Token: 0x040010E7 RID: 4327
	[Range(-2f, 2f)]
	public float MovX = 0.5f;

	// Token: 0x040010E8 RID: 4328
	[Range(-2f, 2f)]
	public float MovY = 0.5f;

	// Token: 0x040010E9 RID: 4329
	[Range(0f, 10f)]
	private float blurWidth = 1f;
}
