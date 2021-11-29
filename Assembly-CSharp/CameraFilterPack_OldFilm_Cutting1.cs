using System;
using UnityEngine;

// Token: 0x020001F4 RID: 500
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Old Film/Cutting 1")]
public class CameraFilterPack_OldFilm_Cutting1 : MonoBehaviour
{
	// Token: 0x170002F9 RID: 761
	// (get) Token: 0x0600109C RID: 4252 RVA: 0x0008427C File Offset: 0x0008247C
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

	// Token: 0x0600109D RID: 4253 RVA: 0x000842B0 File Offset: 0x000824B0
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

	// Token: 0x0600109E RID: 4254 RVA: 0x000842E8 File Offset: 0x000824E8
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

	// Token: 0x0600109F RID: 4255 RVA: 0x000843CF File Offset: 0x000825CF
	private void Update()
	{
	}

	// Token: 0x060010A0 RID: 4256 RVA: 0x000843D1 File Offset: 0x000825D1
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400151D RID: 5405
	public Shader SCShader;

	// Token: 0x0400151E RID: 5406
	private float TimeX = 1f;

	// Token: 0x0400151F RID: 5407
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x04001520 RID: 5408
	[Range(0f, 2f)]
	public float Luminosity = 1.5f;

	// Token: 0x04001521 RID: 5409
	[Range(0f, 1f)]
	public float Vignette = 1f;

	// Token: 0x04001522 RID: 5410
	[Range(0f, 2f)]
	public float Negative;

	// Token: 0x04001523 RID: 5411
	private Material SCMaterial;

	// Token: 0x04001524 RID: 5412
	private Texture2D Texture2;
}
