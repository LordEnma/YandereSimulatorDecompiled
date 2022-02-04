using System;
using UnityEngine;

// Token: 0x020001F6 RID: 502
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Old Film/Cutting 2")]
public class CameraFilterPack_OldFilm_Cutting2 : MonoBehaviour
{
	// Token: 0x170002FA RID: 762
	// (get) Token: 0x060010A5 RID: 4261 RVA: 0x00084617 File Offset: 0x00082817
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

	// Token: 0x060010A6 RID: 4262 RVA: 0x0008464B File Offset: 0x0008284B
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_OldFilm2") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/OldFilm_Cutting2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010A7 RID: 4263 RVA: 0x00084684 File Offset: 0x00082884
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
			this.material.SetFloat("_Value", 2f - this.Luminosity);
			this.material.SetFloat("_Value2", 1f - this.Vignette);
			this.material.SetFloat("_Value3", this.Negative);
			this.material.SetFloat("_Speed", this.Speed);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010A8 RID: 4264 RVA: 0x00084771 File Offset: 0x00082971
	private void Update()
	{
	}

	// Token: 0x060010A9 RID: 4265 RVA: 0x00084773 File Offset: 0x00082973
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400152A RID: 5418
	public Shader SCShader;

	// Token: 0x0400152B RID: 5419
	private float TimeX = 1f;

	// Token: 0x0400152C RID: 5420
	[Range(0f, 10f)]
	public float Speed = 5f;

	// Token: 0x0400152D RID: 5421
	[Range(0f, 2f)]
	public float Luminosity = 1f;

	// Token: 0x0400152E RID: 5422
	[Range(0f, 1f)]
	public float Vignette = 1f;

	// Token: 0x0400152F RID: 5423
	[Range(0f, 1f)]
	public float Negative;

	// Token: 0x04001530 RID: 5424
	private Material SCMaterial;

	// Token: 0x04001531 RID: 5425
	private Texture2D Texture2;
}
