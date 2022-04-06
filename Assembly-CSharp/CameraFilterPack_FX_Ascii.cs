using System;
using UnityEngine;

// Token: 0x020001AA RID: 426
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Ascii")]
public class CameraFilterPack_FX_Ascii : MonoBehaviour
{
	// Token: 0x170002AE RID: 686
	// (get) Token: 0x06000EBE RID: 3774 RVA: 0x0007BB81 File Offset: 0x00079D81
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

	// Token: 0x06000EBF RID: 3775 RVA: 0x0007BBB5 File Offset: 0x00079DB5
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Ascii");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EC0 RID: 3776 RVA: 0x0007BBD8 File Offset: 0x00079DD8
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

	// Token: 0x06000EC1 RID: 3777 RVA: 0x0007BCA4 File Offset: 0x00079EA4
	private void Update()
	{
	}

	// Token: 0x06000EC2 RID: 3778 RVA: 0x0007BCA6 File Offset: 0x00079EA6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001318 RID: 4888
	public Shader SCShader;

	// Token: 0x04001319 RID: 4889
	[Range(0f, 2f)]
	public float Value = 1f;

	// Token: 0x0400131A RID: 4890
	[Range(0.01f, 1f)]
	public float Fade = 1f;

	// Token: 0x0400131B RID: 4891
	private float TimeX = 1f;

	// Token: 0x0400131C RID: 4892
	private Material SCMaterial;
}
