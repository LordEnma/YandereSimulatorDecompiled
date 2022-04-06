using System;
using UnityEngine;

// Token: 0x02000147 RID: 327
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Bloom")]
public class CameraFilterPack_Blur_Bloom : MonoBehaviour
{
	// Token: 0x1700024B RID: 587
	// (get) Token: 0x06000C69 RID: 3177 RVA: 0x0007207B File Offset: 0x0007027B
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

	// Token: 0x06000C6A RID: 3178 RVA: 0x000720AF File Offset: 0x000702AF
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Bloom");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C6B RID: 3179 RVA: 0x000720D0 File Offset: 0x000702D0
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

	// Token: 0x06000C6C RID: 3180 RVA: 0x00072195 File Offset: 0x00070395
	private void Update()
	{
	}

	// Token: 0x06000C6D RID: 3181 RVA: 0x00072197 File Offset: 0x00070397
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010BF RID: 4287
	public Shader SCShader;

	// Token: 0x040010C0 RID: 4288
	private float TimeX = 1f;

	// Token: 0x040010C1 RID: 4289
	private Material SCMaterial;

	// Token: 0x040010C2 RID: 4290
	[Range(0f, 10f)]
	public float Amount = 4.5f;

	// Token: 0x040010C3 RID: 4291
	[Range(0f, 1f)]
	public float Glow = 0.5f;
}
