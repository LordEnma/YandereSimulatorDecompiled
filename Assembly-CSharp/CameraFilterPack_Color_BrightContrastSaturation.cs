using System;
using UnityEngine;

// Token: 0x0200015B RID: 347
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/BrightContrastSaturation")]
public class CameraFilterPack_Color_BrightContrastSaturation : MonoBehaviour
{
	// Token: 0x17000260 RID: 608
	// (get) Token: 0x06000CE1 RID: 3297 RVA: 0x00073A34 File Offset: 0x00071C34
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

	// Token: 0x06000CE2 RID: 3298 RVA: 0x00073A68 File Offset: 0x00071C68
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_BrightContrastSaturation");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CE3 RID: 3299 RVA: 0x00073A8C File Offset: 0x00071C8C
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

	// Token: 0x06000CE4 RID: 3300 RVA: 0x00073B6E File Offset: 0x00071D6E
	private void Update()
	{
	}

	// Token: 0x06000CE5 RID: 3301 RVA: 0x00073B70 File Offset: 0x00071D70
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001132 RID: 4402
	public Shader SCShader;

	// Token: 0x04001133 RID: 4403
	private float TimeX = 1f;

	// Token: 0x04001134 RID: 4404
	private Material SCMaterial;

	// Token: 0x04001135 RID: 4405
	[Range(0f, 10f)]
	public float Brightness = 2f;

	// Token: 0x04001136 RID: 4406
	[Range(0f, 10f)]
	public float Saturation = 1.5f;

	// Token: 0x04001137 RID: 4407
	[Range(0f, 10f)]
	public float Contrast = 1.5f;
}
