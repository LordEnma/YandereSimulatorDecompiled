using System;
using UnityEngine;

// Token: 0x02000151 RID: 337
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Radial_Fast")]
public class CameraFilterPack_Blur_Radial_Fast : MonoBehaviour
{
	// Token: 0x17000255 RID: 597
	// (get) Token: 0x06000CA2 RID: 3234 RVA: 0x000727EB File Offset: 0x000709EB
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

	// Token: 0x06000CA3 RID: 3235 RVA: 0x0007281F File Offset: 0x00070A1F
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Radial_Fast");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CA4 RID: 3236 RVA: 0x00072840 File Offset: 0x00070A40
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

	// Token: 0x06000CA5 RID: 3237 RVA: 0x00072938 File Offset: 0x00070B38
	private void Update()
	{
	}

	// Token: 0x06000CA6 RID: 3238 RVA: 0x0007293A File Offset: 0x00070B3A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010E7 RID: 4327
	public Shader SCShader;

	// Token: 0x040010E8 RID: 4328
	private float TimeX = 1f;

	// Token: 0x040010E9 RID: 4329
	private Material SCMaterial;

	// Token: 0x040010EA RID: 4330
	[Range(-0.5f, 0.5f)]
	public float Intensity = 0.125f;

	// Token: 0x040010EB RID: 4331
	[Range(-2f, 2f)]
	public float MovX = 0.5f;

	// Token: 0x040010EC RID: 4332
	[Range(-2f, 2f)]
	public float MovY = 0.5f;

	// Token: 0x040010ED RID: 4333
	[Range(0f, 10f)]
	private float blurWidth = 1f;
}
