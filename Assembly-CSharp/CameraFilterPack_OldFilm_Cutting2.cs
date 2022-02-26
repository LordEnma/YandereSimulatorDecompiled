using System;
using UnityEngine;

// Token: 0x020001F6 RID: 502
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Old Film/Cutting 2")]
public class CameraFilterPack_OldFilm_Cutting2 : MonoBehaviour
{
	// Token: 0x170002FA RID: 762
	// (get) Token: 0x060010A6 RID: 4262 RVA: 0x0008487B File Offset: 0x00082A7B
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

	// Token: 0x060010A7 RID: 4263 RVA: 0x000848AF File Offset: 0x00082AAF
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

	// Token: 0x060010A8 RID: 4264 RVA: 0x000848E8 File Offset: 0x00082AE8
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

	// Token: 0x060010A9 RID: 4265 RVA: 0x000849D5 File Offset: 0x00082BD5
	private void Update()
	{
	}

	// Token: 0x060010AA RID: 4266 RVA: 0x000849D7 File Offset: 0x00082BD7
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400152D RID: 5421
	public Shader SCShader;

	// Token: 0x0400152E RID: 5422
	private float TimeX = 1f;

	// Token: 0x0400152F RID: 5423
	[Range(0f, 10f)]
	public float Speed = 5f;

	// Token: 0x04001530 RID: 5424
	[Range(0f, 2f)]
	public float Luminosity = 1f;

	// Token: 0x04001531 RID: 5425
	[Range(0f, 1f)]
	public float Vignette = 1f;

	// Token: 0x04001532 RID: 5426
	[Range(0f, 1f)]
	public float Negative;

	// Token: 0x04001533 RID: 5427
	private Material SCMaterial;

	// Token: 0x04001534 RID: 5428
	private Texture2D Texture2;
}
