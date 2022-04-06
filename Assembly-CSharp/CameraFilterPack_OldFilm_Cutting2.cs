using System;
using UnityEngine;

// Token: 0x020001F6 RID: 502
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Old Film/Cutting 2")]
public class CameraFilterPack_OldFilm_Cutting2 : MonoBehaviour
{
	// Token: 0x170002FA RID: 762
	// (get) Token: 0x060010A8 RID: 4264 RVA: 0x00084E3F File Offset: 0x0008303F
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

	// Token: 0x060010A9 RID: 4265 RVA: 0x00084E73 File Offset: 0x00083073
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

	// Token: 0x060010AA RID: 4266 RVA: 0x00084EAC File Offset: 0x000830AC
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

	// Token: 0x060010AB RID: 4267 RVA: 0x00084F99 File Offset: 0x00083199
	private void Update()
	{
	}

	// Token: 0x060010AC RID: 4268 RVA: 0x00084F9B File Offset: 0x0008319B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400153D RID: 5437
	public Shader SCShader;

	// Token: 0x0400153E RID: 5438
	private float TimeX = 1f;

	// Token: 0x0400153F RID: 5439
	[Range(0f, 10f)]
	public float Speed = 5f;

	// Token: 0x04001540 RID: 5440
	[Range(0f, 2f)]
	public float Luminosity = 1f;

	// Token: 0x04001541 RID: 5441
	[Range(0f, 1f)]
	public float Vignette = 1f;

	// Token: 0x04001542 RID: 5442
	[Range(0f, 1f)]
	public float Negative;

	// Token: 0x04001543 RID: 5443
	private Material SCMaterial;

	// Token: 0x04001544 RID: 5444
	private Texture2D Texture2;
}
