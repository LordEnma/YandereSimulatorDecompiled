using System;
using UnityEngine;

// Token: 0x02000152 RID: 338
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Steam")]
public class CameraFilterPack_Blur_Steam : MonoBehaviour
{
	// Token: 0x17000257 RID: 599
	// (get) Token: 0x06000CAB RID: 3243 RVA: 0x0007290D File Offset: 0x00070B0D
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

	// Token: 0x06000CAC RID: 3244 RVA: 0x00072941 File Offset: 0x00070B41
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Steam");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CAD RID: 3245 RVA: 0x00072964 File Offset: 0x00070B64
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

	// Token: 0x06000CAE RID: 3246 RVA: 0x00072A29 File Offset: 0x00070C29
	private void Update()
	{
	}

	// Token: 0x06000CAF RID: 3247 RVA: 0x00072A2B File Offset: 0x00070C2B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010EE RID: 4334
	public Shader SCShader;

	// Token: 0x040010EF RID: 4335
	private float TimeX = 1f;

	// Token: 0x040010F0 RID: 4336
	private Material SCMaterial;

	// Token: 0x040010F1 RID: 4337
	[Range(0f, 1f)]
	public float Radius = 0.1f;

	// Token: 0x040010F2 RID: 4338
	[Range(0f, 1f)]
	public float Quality = 0.75f;
}
