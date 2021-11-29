using System;
using UnityEngine;

// Token: 0x020001F3 RID: 499
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/ThermaVision")]
public class CameraFilterPack_Oculus_ThermaVision : MonoBehaviour
{
	// Token: 0x170002F8 RID: 760
	// (get) Token: 0x06001096 RID: 4246 RVA: 0x000840DD File Offset: 0x000822DD
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

	// Token: 0x06001097 RID: 4247 RVA: 0x00084111 File Offset: 0x00082311
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Oculus_ThermaVision");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001098 RID: 4248 RVA: 0x00084134 File Offset: 0x00082334
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

	// Token: 0x06001099 RID: 4249 RVA: 0x0008422C File Offset: 0x0008242C
	private void Update()
	{
	}

	// Token: 0x0600109A RID: 4250 RVA: 0x0008422E File Offset: 0x0008242E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001516 RID: 5398
	public Shader SCShader;

	// Token: 0x04001517 RID: 5399
	private float TimeX = 1f;

	// Token: 0x04001518 RID: 5400
	private Material SCMaterial;

	// Token: 0x04001519 RID: 5401
	[Range(0f, 1f)]
	public float Therma_Variation = 0.5f;

	// Token: 0x0400151A RID: 5402
	[Range(0f, 8f)]
	private float Contrast = 3f;

	// Token: 0x0400151B RID: 5403
	[Range(0f, 4f)]
	private float Burn;

	// Token: 0x0400151C RID: 5404
	[Range(0f, 16f)]
	private float SceneCut = 1f;
}
