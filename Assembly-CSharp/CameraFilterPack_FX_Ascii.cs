using System;
using UnityEngine;

// Token: 0x020001AA RID: 426
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Ascii")]
public class CameraFilterPack_FX_Ascii : MonoBehaviour
{
	// Token: 0x170002AE RID: 686
	// (get) Token: 0x06000EBC RID: 3772 RVA: 0x0007B4A9 File Offset: 0x000796A9
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

	// Token: 0x06000EBD RID: 3773 RVA: 0x0007B4DD File Offset: 0x000796DD
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Ascii");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EBE RID: 3774 RVA: 0x0007B500 File Offset: 0x00079700
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
			this.material.SetFloat("Value", this.Value);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EBF RID: 3775 RVA: 0x0007B5CC File Offset: 0x000797CC
	private void Update()
	{
	}

	// Token: 0x06000EC0 RID: 3776 RVA: 0x0007B5CE File Offset: 0x000797CE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001308 RID: 4872
	public Shader SCShader;

	// Token: 0x04001309 RID: 4873
	[Range(0f, 2f)]
	public float Value = 1f;

	// Token: 0x0400130A RID: 4874
	[Range(0.01f, 1f)]
	public float Fade = 1f;

	// Token: 0x0400130B RID: 4875
	private float TimeX = 1f;

	// Token: 0x0400130C RID: 4876
	private Material SCMaterial;
}
