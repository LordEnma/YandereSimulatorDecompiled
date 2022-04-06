using System;
using UnityEngine;

// Token: 0x0200015C RID: 348
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/BrightContrastSaturation")]
public class CameraFilterPack_Color_BrightContrastSaturation : MonoBehaviour
{
	// Token: 0x17000260 RID: 608
	// (get) Token: 0x06000CE7 RID: 3303 RVA: 0x00074454 File Offset: 0x00072654
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

	// Token: 0x06000CE8 RID: 3304 RVA: 0x00074488 File Offset: 0x00072688
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_BrightContrastSaturation");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CE9 RID: 3305 RVA: 0x000744AC File Offset: 0x000726AC
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

	// Token: 0x06000CEA RID: 3306 RVA: 0x0007458E File Offset: 0x0007278E
	private void Update()
	{
	}

	// Token: 0x06000CEB RID: 3307 RVA: 0x00074590 File Offset: 0x00072790
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400114A RID: 4426
	public Shader SCShader;

	// Token: 0x0400114B RID: 4427
	private float TimeX = 1f;

	// Token: 0x0400114C RID: 4428
	private Material SCMaterial;

	// Token: 0x0400114D RID: 4429
	[Range(0f, 10f)]
	public float Brightness = 2f;

	// Token: 0x0400114E RID: 4430
	[Range(0f, 10f)]
	public float Saturation = 1.5f;

	// Token: 0x0400114F RID: 4431
	[Range(0f, 10f)]
	public float Contrast = 1.5f;
}
