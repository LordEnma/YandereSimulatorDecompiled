using System;
using UnityEngine;

// Token: 0x0200014F RID: 335
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Radial")]
public class CameraFilterPack_Blur_Radial : MonoBehaviour
{
	// Token: 0x17000254 RID: 596
	// (get) Token: 0x06000C99 RID: 3225 RVA: 0x00072449 File Offset: 0x00070649
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

	// Token: 0x06000C9A RID: 3226 RVA: 0x0007247D File Offset: 0x0007067D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Radial");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C9B RID: 3227 RVA: 0x000724A0 File Offset: 0x000706A0
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

	// Token: 0x06000C9C RID: 3228 RVA: 0x00072598 File Offset: 0x00070798
	private void Update()
	{
	}

	// Token: 0x06000C9D RID: 3229 RVA: 0x0007259A File Offset: 0x0007079A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010DB RID: 4315
	public Shader SCShader;

	// Token: 0x040010DC RID: 4316
	private float TimeX = 1f;

	// Token: 0x040010DD RID: 4317
	private Material SCMaterial;

	// Token: 0x040010DE RID: 4318
	[Range(-0.5f, 0.5f)]
	public float Intensity = 0.125f;

	// Token: 0x040010DF RID: 4319
	[Range(-2f, 2f)]
	public float MovX = 0.5f;

	// Token: 0x040010E0 RID: 4320
	[Range(-2f, 2f)]
	public float MovY = 0.5f;

	// Token: 0x040010E1 RID: 4321
	[Range(0f, 10f)]
	private float blurWidth = 1f;
}
