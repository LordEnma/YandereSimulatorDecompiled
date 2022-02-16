using System;
using UnityEngine;

// Token: 0x020001BB RID: 443
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Mirror")]
public class CameraFilterPack_FX_Mirror : MonoBehaviour
{
	// Token: 0x170002BF RID: 703
	// (get) Token: 0x06000F22 RID: 3874 RVA: 0x0007CDC0 File Offset: 0x0007AFC0
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

	// Token: 0x06000F23 RID: 3875 RVA: 0x0007CDF4 File Offset: 0x0007AFF4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Mirror");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F24 RID: 3876 RVA: 0x0007CE18 File Offset: 0x0007B018
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
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F25 RID: 3877 RVA: 0x0007CEB5 File Offset: 0x0007B0B5
	private void Update()
	{
	}

	// Token: 0x06000F26 RID: 3878 RVA: 0x0007CEB7 File Offset: 0x0007B0B7
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400136A RID: 4970
	public Shader SCShader;

	// Token: 0x0400136B RID: 4971
	private float TimeX = 1f;

	// Token: 0x0400136C RID: 4972
	private Material SCMaterial;
}
