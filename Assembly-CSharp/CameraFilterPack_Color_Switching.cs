using System;
using UnityEngine;

// Token: 0x02000165 RID: 357
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Switching")]
public class CameraFilterPack_Color_Switching : MonoBehaviour
{
	// Token: 0x17000269 RID: 617
	// (get) Token: 0x06000D1B RID: 3355 RVA: 0x00074BEC File Offset: 0x00072DEC
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

	// Token: 0x06000D1C RID: 3356 RVA: 0x00074C20 File Offset: 0x00072E20
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Switching");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D1D RID: 3357 RVA: 0x00074C44 File Offset: 0x00072E44
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
			this.material.SetFloat("_Distortion", (float)this.Color);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D1E RID: 3358 RVA: 0x00074CFB File Offset: 0x00072EFB
	private void Update()
	{
	}

	// Token: 0x06000D1F RID: 3359 RVA: 0x00074CFD File Offset: 0x00072EFD
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400116B RID: 4459
	public Shader SCShader;

	// Token: 0x0400116C RID: 4460
	private float TimeX = 1f;

	// Token: 0x0400116D RID: 4461
	private Material SCMaterial;

	// Token: 0x0400116E RID: 4462
	[Range(0f, 5f)]
	public int Color = 1;
}
