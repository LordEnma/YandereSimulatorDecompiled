using System;
using UnityEngine;

// Token: 0x020001AA RID: 426
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/DarkMatter")]
public class CameraFilterPack_FX_DarkMatter : MonoBehaviour
{
	// Token: 0x170002AF RID: 687
	// (get) Token: 0x06000EBE RID: 3774 RVA: 0x0007B2C9 File Offset: 0x000794C9
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

	// Token: 0x06000EBF RID: 3775 RVA: 0x0007B2FD File Offset: 0x000794FD
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_DarkMatter");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EC0 RID: 3776 RVA: 0x0007B320 File Offset: 0x00079520
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
			this.material.SetFloat("_Value", this.Speed);
			this.material.SetFloat("_Value2", this.Intensity);
			this.material.SetFloat("_Value3", this.PosX);
			this.material.SetFloat("_Value4", this.PosY);
			this.material.SetFloat("_Value5", this.Zoom);
			this.material.SetFloat("_Value6", this.DarkIntensity);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EC1 RID: 3777 RVA: 0x0007B444 File Offset: 0x00079644
	private void Update()
	{
	}

	// Token: 0x06000EC2 RID: 3778 RVA: 0x0007B446 File Offset: 0x00079646
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001305 RID: 4869
	public Shader SCShader;

	// Token: 0x04001306 RID: 4870
	private float TimeX = 1f;

	// Token: 0x04001307 RID: 4871
	private Material SCMaterial;

	// Token: 0x04001308 RID: 4872
	[Range(-10f, 10f)]
	public float Speed = 0.8f;

	// Token: 0x04001309 RID: 4873
	[Range(0f, 1f)]
	public float Intensity = 1f;

	// Token: 0x0400130A RID: 4874
	[Range(-1f, 2f)]
	public float PosX = 0.5f;

	// Token: 0x0400130B RID: 4875
	[Range(-1f, 2f)]
	public float PosY = 0.5f;

	// Token: 0x0400130C RID: 4876
	[Range(-2f, 2f)]
	public float Zoom = 0.33f;

	// Token: 0x0400130D RID: 4877
	[Range(0f, 5f)]
	public float DarkIntensity = 2f;
}
