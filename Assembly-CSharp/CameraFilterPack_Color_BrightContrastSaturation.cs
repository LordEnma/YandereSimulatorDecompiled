using System;
using UnityEngine;

// Token: 0x0200015C RID: 348
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/BrightContrastSaturation")]
public class CameraFilterPack_Color_BrightContrastSaturation : MonoBehaviour
{
	// Token: 0x17000260 RID: 608
	// (get) Token: 0x06000CE5 RID: 3301 RVA: 0x00073D7C File Offset: 0x00071F7C
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

	// Token: 0x06000CE6 RID: 3302 RVA: 0x00073DB0 File Offset: 0x00071FB0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_BrightContrastSaturation");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CE7 RID: 3303 RVA: 0x00073DD4 File Offset: 0x00071FD4
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_Brightness", this.Brightness);
			this.material.SetFloat("_Saturation", this.Saturation);
			this.material.SetFloat("_Contrast", this.Contrast);
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CE8 RID: 3304 RVA: 0x00073EB6 File Offset: 0x000720B6
	private void Update()
	{
	}

	// Token: 0x06000CE9 RID: 3305 RVA: 0x00073EB8 File Offset: 0x000720B8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400113A RID: 4410
	public Shader SCShader;

	// Token: 0x0400113B RID: 4411
	private float TimeX = 1f;

	// Token: 0x0400113C RID: 4412
	private Material SCMaterial;

	// Token: 0x0400113D RID: 4413
	[Range(0f, 10f)]
	public float Brightness = 2f;

	// Token: 0x0400113E RID: 4414
	[Range(0f, 10f)]
	public float Saturation = 1.5f;

	// Token: 0x0400113F RID: 4415
	[Range(0f, 10f)]
	public float Contrast = 1.5f;
}
