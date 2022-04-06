using System;
using UnityEngine;

// Token: 0x020001F5 RID: 501
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Old Film/Cutting 1")]
public class CameraFilterPack_OldFilm_Cutting1 : MonoBehaviour
{
	// Token: 0x170002F9 RID: 761
	// (get) Token: 0x060010A2 RID: 4258 RVA: 0x00084C9C File Offset: 0x00082E9C
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

	// Token: 0x060010A3 RID: 4259 RVA: 0x00084CD0 File Offset: 0x00082ED0
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_OldFilm1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/OldFilm_Cutting1");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010A4 RID: 4260 RVA: 0x00084D08 File Offset: 0x00082F08
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
			this.material.SetFloat("_Value", this.Luminosity);
			this.material.SetFloat("_Value2", 1f - this.Vignette);
			this.material.SetFloat("_Value3", this.Negative);
			this.material.SetFloat("_Speed", this.Speed);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010A5 RID: 4261 RVA: 0x00084DEF File Offset: 0x00082FEF
	private void Update()
	{
	}

	// Token: 0x060010A6 RID: 4262 RVA: 0x00084DF1 File Offset: 0x00082FF1
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001535 RID: 5429
	public Shader SCShader;

	// Token: 0x04001536 RID: 5430
	private float TimeX = 1f;

	// Token: 0x04001537 RID: 5431
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x04001538 RID: 5432
	[Range(0f, 2f)]
	public float Luminosity = 1.5f;

	// Token: 0x04001539 RID: 5433
	[Range(0f, 1f)]
	public float Vignette = 1f;

	// Token: 0x0400153A RID: 5434
	[Range(0f, 2f)]
	public float Negative;

	// Token: 0x0400153B RID: 5435
	private Material SCMaterial;

	// Token: 0x0400153C RID: 5436
	private Texture2D Texture2;
}
