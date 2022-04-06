using System;
using UnityEngine;

// Token: 0x020001F4 RID: 500
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/ThermaVision")]
public class CameraFilterPack_Oculus_ThermaVision : MonoBehaviour
{
	// Token: 0x170002F8 RID: 760
	// (get) Token: 0x0600109C RID: 4252 RVA: 0x00084AFD File Offset: 0x00082CFD
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

	// Token: 0x0600109D RID: 4253 RVA: 0x00084B31 File Offset: 0x00082D31
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Oculus_ThermaVision");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600109E RID: 4254 RVA: 0x00084B54 File Offset: 0x00082D54
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

	// Token: 0x0600109F RID: 4255 RVA: 0x00084C4C File Offset: 0x00082E4C
	private void Update()
	{
	}

	// Token: 0x060010A0 RID: 4256 RVA: 0x00084C4E File Offset: 0x00082E4E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400152E RID: 5422
	public Shader SCShader;

	// Token: 0x0400152F RID: 5423
	private float TimeX = 1f;

	// Token: 0x04001530 RID: 5424
	private Material SCMaterial;

	// Token: 0x04001531 RID: 5425
	[Range(0f, 1f)]
	public float Therma_Variation = 0.5f;

	// Token: 0x04001532 RID: 5426
	[Range(0f, 8f)]
	private float Contrast = 3f;

	// Token: 0x04001533 RID: 5427
	[Range(0f, 4f)]
	private float Burn;

	// Token: 0x04001534 RID: 5428
	[Range(0f, 16f)]
	private float SceneCut = 1f;
}
