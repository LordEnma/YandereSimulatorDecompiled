using System;
using UnityEngine;

// Token: 0x02000151 RID: 337
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Radial_Fast")]
public class CameraFilterPack_Blur_Radial_Fast : MonoBehaviour
{
	// Token: 0x17000255 RID: 597
	// (get) Token: 0x06000CA5 RID: 3237 RVA: 0x00073013 File Offset: 0x00071213
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

	// Token: 0x06000CA6 RID: 3238 RVA: 0x00073047 File Offset: 0x00071247
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Radial_Fast");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CA7 RID: 3239 RVA: 0x00073068 File Offset: 0x00071268
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

	// Token: 0x06000CA8 RID: 3240 RVA: 0x00073160 File Offset: 0x00071360
	private void Update()
	{
	}

	// Token: 0x06000CA9 RID: 3241 RVA: 0x00073162 File Offset: 0x00071362
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010FA RID: 4346
	public Shader SCShader;

	// Token: 0x040010FB RID: 4347
	private float TimeX = 1f;

	// Token: 0x040010FC RID: 4348
	private Material SCMaterial;

	// Token: 0x040010FD RID: 4349
	[Range(-0.5f, 0.5f)]
	public float Intensity = 0.125f;

	// Token: 0x040010FE RID: 4350
	[Range(-2f, 2f)]
	public float MovX = 0.5f;

	// Token: 0x040010FF RID: 4351
	[Range(-2f, 2f)]
	public float MovY = 0.5f;

	// Token: 0x04001100 RID: 4352
	[Range(0f, 10f)]
	private float blurWidth = 1f;
}
