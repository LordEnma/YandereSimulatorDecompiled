using System;
using UnityEngine;

// Token: 0x02000163 RID: 355
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/RGB")]
public class CameraFilterPack_Color_RGB : MonoBehaviour
{
	// Token: 0x17000267 RID: 615
	// (get) Token: 0x06000D11 RID: 3345 RVA: 0x00074DCC File Offset: 0x00072FCC
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

	// Token: 0x06000D12 RID: 3346 RVA: 0x00074E00 File Offset: 0x00073000
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_RGB");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D13 RID: 3347 RVA: 0x00074E24 File Offset: 0x00073024
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
			this.material.SetColor("_ColorRGB", this.ColorRGB);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D14 RID: 3348 RVA: 0x00074EDA File Offset: 0x000730DA
	private void Update()
	{
	}

	// Token: 0x06000D15 RID: 3349 RVA: 0x00074EDC File Offset: 0x000730DC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400116A RID: 4458
	public Shader SCShader;

	// Token: 0x0400116B RID: 4459
	private float TimeX = 1f;

	// Token: 0x0400116C RID: 4460
	private Material SCMaterial;

	// Token: 0x0400116D RID: 4461
	public Color ColorRGB = new Color(1f, 1f, 1f);
}
