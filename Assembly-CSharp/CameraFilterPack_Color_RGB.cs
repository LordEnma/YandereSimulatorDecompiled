using System;
using UnityEngine;

// Token: 0x02000163 RID: 355
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/RGB")]
public class CameraFilterPack_Color_RGB : MonoBehaviour
{
	// Token: 0x17000267 RID: 615
	// (get) Token: 0x06000D0F RID: 3343 RVA: 0x000746F4 File Offset: 0x000728F4
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

	// Token: 0x06000D10 RID: 3344 RVA: 0x00074728 File Offset: 0x00072928
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_RGB");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D11 RID: 3345 RVA: 0x0007474C File Offset: 0x0007294C
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

	// Token: 0x06000D12 RID: 3346 RVA: 0x00074802 File Offset: 0x00072A02
	private void Update()
	{
	}

	// Token: 0x06000D13 RID: 3347 RVA: 0x00074804 File Offset: 0x00072A04
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400115A RID: 4442
	public Shader SCShader;

	// Token: 0x0400115B RID: 4443
	private float TimeX = 1f;

	// Token: 0x0400115C RID: 4444
	private Material SCMaterial;

	// Token: 0x0400115D RID: 4445
	public Color ColorRGB = new Color(1f, 1f, 1f);
}
