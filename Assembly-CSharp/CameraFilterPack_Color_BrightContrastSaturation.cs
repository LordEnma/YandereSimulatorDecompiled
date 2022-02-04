using System;
using UnityEngine;

// Token: 0x0200015C RID: 348
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/BrightContrastSaturation")]
public class CameraFilterPack_Color_BrightContrastSaturation : MonoBehaviour
{
	// Token: 0x17000260 RID: 608
	// (get) Token: 0x06000CE4 RID: 3300 RVA: 0x00073C2C File Offset: 0x00071E2C
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

	// Token: 0x06000CE5 RID: 3301 RVA: 0x00073C60 File Offset: 0x00071E60
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_BrightContrastSaturation");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CE6 RID: 3302 RVA: 0x00073C84 File Offset: 0x00071E84
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

	// Token: 0x06000CE7 RID: 3303 RVA: 0x00073D66 File Offset: 0x00071F66
	private void Update()
	{
	}

	// Token: 0x06000CE8 RID: 3304 RVA: 0x00073D68 File Offset: 0x00071F68
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001137 RID: 4407
	public Shader SCShader;

	// Token: 0x04001138 RID: 4408
	private float TimeX = 1f;

	// Token: 0x04001139 RID: 4409
	private Material SCMaterial;

	// Token: 0x0400113A RID: 4410
	[Range(0f, 10f)]
	public float Brightness = 2f;

	// Token: 0x0400113B RID: 4411
	[Range(0f, 10f)]
	public float Saturation = 1.5f;

	// Token: 0x0400113C RID: 4412
	[Range(0f, 10f)]
	public float Contrast = 1.5f;
}
