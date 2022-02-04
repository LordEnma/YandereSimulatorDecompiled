using System;
using UnityEngine;

// Token: 0x020001FA RID: 506
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixelisation/OilPaint")]
public class CameraFilterPack_Pixelisation_OilPaint : MonoBehaviour
{
	// Token: 0x170002FE RID: 766
	// (get) Token: 0x060010BD RID: 4285 RVA: 0x00084CEF File Offset: 0x00082EEF
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

	// Token: 0x060010BE RID: 4286 RVA: 0x00084D23 File Offset: 0x00082F23
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Pixelisation_OilPaint");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010BF RID: 4287 RVA: 0x00084D44 File Offset: 0x00082F44
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			this.material.SetFloat("_Value", this.Value);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010C0 RID: 4288 RVA: 0x00084DFA File Offset: 0x00082FFA
	private void Update()
	{
	}

	// Token: 0x060010C1 RID: 4289 RVA: 0x00084DFC File Offset: 0x00082FFC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001549 RID: 5449
	public Shader SCShader;

	// Token: 0x0400154A RID: 5450
	private float TimeX = 1f;

	// Token: 0x0400154B RID: 5451
	private Material SCMaterial;

	// Token: 0x0400154C RID: 5452
	[Range(0f, 5f)]
	public float Value = 1f;
}
