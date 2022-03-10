using System;
using UnityEngine;

// Token: 0x020001F4 RID: 500
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/ThermaVision")]
public class CameraFilterPack_Oculus_ThermaVision : MonoBehaviour
{
	// Token: 0x170002F8 RID: 760
	// (get) Token: 0x0600109A RID: 4250 RVA: 0x00084681 File Offset: 0x00082881
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

	// Token: 0x0600109B RID: 4251 RVA: 0x000846B5 File Offset: 0x000828B5
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Oculus_ThermaVision");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600109C RID: 4252 RVA: 0x000846D8 File Offset: 0x000828D8
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
			this.material.SetFloat("_Value", this.Therma_Variation);
			this.material.SetFloat("_Value2", this.Contrast);
			this.material.SetFloat("_Value3", this.Burn);
			this.material.SetFloat("_Value4", this.SceneCut);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600109D RID: 4253 RVA: 0x000847D0 File Offset: 0x000829D0
	private void Update()
	{
	}

	// Token: 0x0600109E RID: 4254 RVA: 0x000847D2 File Offset: 0x000829D2
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001527 RID: 5415
	public Shader SCShader;

	// Token: 0x04001528 RID: 5416
	private float TimeX = 1f;

	// Token: 0x04001529 RID: 5417
	private Material SCMaterial;

	// Token: 0x0400152A RID: 5418
	[Range(0f, 1f)]
	public float Therma_Variation = 0.5f;

	// Token: 0x0400152B RID: 5419
	[Range(0f, 8f)]
	private float Contrast = 3f;

	// Token: 0x0400152C RID: 5420
	[Range(0f, 4f)]
	private float Burn;

	// Token: 0x0400152D RID: 5421
	[Range(0f, 16f)]
	private float SceneCut = 1f;
}
