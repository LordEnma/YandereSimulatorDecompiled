using System;
using UnityEngine;

// Token: 0x02000153 RID: 339
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Steam")]
public class CameraFilterPack_Blur_Steam : MonoBehaviour
{
	// Token: 0x17000257 RID: 599
	// (get) Token: 0x06000CAF RID: 3247 RVA: 0x00072EB1 File Offset: 0x000710B1
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

	// Token: 0x06000CB0 RID: 3248 RVA: 0x00072EE5 File Offset: 0x000710E5
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Steam");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CB1 RID: 3249 RVA: 0x00072F08 File Offset: 0x00071108
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
			this.material.SetFloat("_Radius", this.Radius);
			this.material.SetFloat("_Quality", this.Quality);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CB2 RID: 3250 RVA: 0x00072FCD File Offset: 0x000711CD
	private void Update()
	{
	}

	// Token: 0x06000CB3 RID: 3251 RVA: 0x00072FCF File Offset: 0x000711CF
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010FF RID: 4351
	public Shader SCShader;

	// Token: 0x04001100 RID: 4352
	private float TimeX = 1f;

	// Token: 0x04001101 RID: 4353
	private Material SCMaterial;

	// Token: 0x04001102 RID: 4354
	[Range(0f, 1f)]
	public float Radius = 0.1f;

	// Token: 0x04001103 RID: 4355
	[Range(0f, 1f)]
	public float Quality = 0.75f;
}
