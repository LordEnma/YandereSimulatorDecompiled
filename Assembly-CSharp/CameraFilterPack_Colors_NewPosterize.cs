using System;
using UnityEngine;

// Token: 0x0200016F RID: 367
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/NewPosterize")]
public class CameraFilterPack_Colors_NewPosterize : MonoBehaviour
{
	// Token: 0x17000273 RID: 627
	// (get) Token: 0x06000D5B RID: 3419 RVA: 0x00076425 File Offset: 0x00074625
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

	// Token: 0x06000D5C RID: 3420 RVA: 0x00076459 File Offset: 0x00074659
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_NewPosterize");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D5D RID: 3421 RVA: 0x0007647C File Offset: 0x0007467C
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
			this.material.SetFloat("_Value", this.Gamma);
			this.material.SetFloat("_Value2", this.Colors);
			this.material.SetFloat("_Value3", this.Green_Mod);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D5E RID: 3422 RVA: 0x00076574 File Offset: 0x00074774
	private void Update()
	{
	}

	// Token: 0x06000D5F RID: 3423 RVA: 0x00076576 File Offset: 0x00074776
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011B0 RID: 4528
	public Shader SCShader;

	// Token: 0x040011B1 RID: 4529
	private float TimeX = 1f;

	// Token: 0x040011B2 RID: 4530
	private Material SCMaterial;

	// Token: 0x040011B3 RID: 4531
	[Range(0f, 2f)]
	public float Gamma = 1f;

	// Token: 0x040011B4 RID: 4532
	[Range(0f, 16f)]
	public float Colors = 11f;

	// Token: 0x040011B5 RID: 4533
	[Range(-1f, 1f)]
	public float Green_Mod = 1f;

	// Token: 0x040011B6 RID: 4534
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
