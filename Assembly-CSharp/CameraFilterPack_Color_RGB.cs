using System;
using UnityEngine;

// Token: 0x02000162 RID: 354
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/RGB")]
public class CameraFilterPack_Color_RGB : MonoBehaviour
{
	// Token: 0x17000267 RID: 615
	// (get) Token: 0x06000D0B RID: 3339 RVA: 0x000743AC File Offset: 0x000725AC
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

	// Token: 0x06000D0C RID: 3340 RVA: 0x000743E0 File Offset: 0x000725E0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_RGB");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D0D RID: 3341 RVA: 0x00074404 File Offset: 0x00072604
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

	// Token: 0x06000D0E RID: 3342 RVA: 0x000744BA File Offset: 0x000726BA
	private void Update()
	{
	}

	// Token: 0x06000D0F RID: 3343 RVA: 0x000744BC File Offset: 0x000726BC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001152 RID: 4434
	public Shader SCShader;

	// Token: 0x04001153 RID: 4435
	private float TimeX = 1f;

	// Token: 0x04001154 RID: 4436
	private Material SCMaterial;

	// Token: 0x04001155 RID: 4437
	public Color ColorRGB = new Color(1f, 1f, 1f);
}
