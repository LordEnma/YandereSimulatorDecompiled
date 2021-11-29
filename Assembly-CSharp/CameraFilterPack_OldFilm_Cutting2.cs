using System;
using UnityEngine;

// Token: 0x020001F5 RID: 501
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Old Film/Cutting 2")]
public class CameraFilterPack_OldFilm_Cutting2 : MonoBehaviour
{
	// Token: 0x170002FA RID: 762
	// (get) Token: 0x060010A2 RID: 4258 RVA: 0x0008441F File Offset: 0x0008261F
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

	// Token: 0x060010A3 RID: 4259 RVA: 0x00084453 File Offset: 0x00082653
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

	// Token: 0x060010A4 RID: 4260 RVA: 0x0008448C File Offset: 0x0008268C
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

	// Token: 0x060010A5 RID: 4261 RVA: 0x00084579 File Offset: 0x00082779
	private void Update()
	{
	}

	// Token: 0x060010A6 RID: 4262 RVA: 0x0008457B File Offset: 0x0008277B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001525 RID: 5413
	public Shader SCShader;

	// Token: 0x04001526 RID: 5414
	private float TimeX = 1f;

	// Token: 0x04001527 RID: 5415
	[Range(0f, 10f)]
	public float Speed = 5f;

	// Token: 0x04001528 RID: 5416
	[Range(0f, 2f)]
	public float Luminosity = 1f;

	// Token: 0x04001529 RID: 5417
	[Range(0f, 1f)]
	public float Vignette = 1f;

	// Token: 0x0400152A RID: 5418
	[Range(0f, 1f)]
	public float Negative;

	// Token: 0x0400152B RID: 5419
	private Material SCMaterial;

	// Token: 0x0400152C RID: 5420
	private Texture2D Texture2;
}
