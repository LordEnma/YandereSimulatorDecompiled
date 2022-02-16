using System;
using UnityEngine;

// Token: 0x02000147 RID: 327
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Bloom")]
public class CameraFilterPack_Blur_Bloom : MonoBehaviour
{
	// Token: 0x1700024B RID: 587
	// (get) Token: 0x06000C67 RID: 3175 RVA: 0x000719A3 File Offset: 0x0006FBA3
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

	// Token: 0x06000C68 RID: 3176 RVA: 0x000719D7 File Offset: 0x0006FBD7
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Bloom");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C69 RID: 3177 RVA: 0x000719F8 File Offset: 0x0006FBF8
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
			this.material.SetFloat("_Amount", this.Amount);
			this.material.SetFloat("_Glow", this.Glow);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C6A RID: 3178 RVA: 0x00071ABD File Offset: 0x0006FCBD
	private void Update()
	{
	}

	// Token: 0x06000C6B RID: 3179 RVA: 0x00071ABF File Offset: 0x0006FCBF
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010AF RID: 4271
	public Shader SCShader;

	// Token: 0x040010B0 RID: 4272
	private float TimeX = 1f;

	// Token: 0x040010B1 RID: 4273
	private Material SCMaterial;

	// Token: 0x040010B2 RID: 4274
	[Range(0f, 10f)]
	public float Amount = 4.5f;

	// Token: 0x040010B3 RID: 4275
	[Range(0f, 1f)]
	public float Glow = 0.5f;
}
