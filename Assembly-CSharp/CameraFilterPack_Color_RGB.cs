using System;
using UnityEngine;

// Token: 0x02000163 RID: 355
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/RGB")]
public class CameraFilterPack_Color_RGB : MonoBehaviour
{
	// Token: 0x17000267 RID: 615
	// (get) Token: 0x06000D0E RID: 3342 RVA: 0x000745A4 File Offset: 0x000727A4
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

	// Token: 0x06000D0F RID: 3343 RVA: 0x000745D8 File Offset: 0x000727D8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_RGB");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D10 RID: 3344 RVA: 0x000745FC File Offset: 0x000727FC
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

	// Token: 0x06000D11 RID: 3345 RVA: 0x000746B2 File Offset: 0x000728B2
	private void Update()
	{
	}

	// Token: 0x06000D12 RID: 3346 RVA: 0x000746B4 File Offset: 0x000728B4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001157 RID: 4439
	public Shader SCShader;

	// Token: 0x04001158 RID: 4440
	private float TimeX = 1f;

	// Token: 0x04001159 RID: 4441
	private Material SCMaterial;

	// Token: 0x0400115A RID: 4442
	public Color ColorRGB = new Color(1f, 1f, 1f);
}
