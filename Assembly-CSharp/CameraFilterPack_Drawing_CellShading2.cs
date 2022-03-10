using System;
using UnityEngine;

// Token: 0x02000188 RID: 392
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/CellShading2")]
public class CameraFilterPack_Drawing_CellShading2 : MonoBehaviour
{
	// Token: 0x1700028C RID: 652
	// (get) Token: 0x06000DEF RID: 3567 RVA: 0x000784B2 File Offset: 0x000766B2
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

	// Token: 0x06000DF0 RID: 3568 RVA: 0x000784E6 File Offset: 0x000766E6
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_CellShading2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DF1 RID: 3569 RVA: 0x00078508 File Offset: 0x00076708
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
			this.material.SetFloat("_EdgeSize", this.EdgeSize);
			this.material.SetFloat("_ColorLevel", this.ColorLevel);
			this.material.SetFloat("_Distortion", this.Blur);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DF2 RID: 3570 RVA: 0x000785E3 File Offset: 0x000767E3
	private void Update()
	{
	}

	// Token: 0x06000DF3 RID: 3571 RVA: 0x000785E5 File Offset: 0x000767E5
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001241 RID: 4673
	public Shader SCShader;

	// Token: 0x04001242 RID: 4674
	private float TimeX = 1f;

	// Token: 0x04001243 RID: 4675
	private Material SCMaterial;

	// Token: 0x04001244 RID: 4676
	[Range(0f, 1f)]
	public float EdgeSize = 0.1f;

	// Token: 0x04001245 RID: 4677
	[Range(0f, 10f)]
	public float ColorLevel = 4f;

	// Token: 0x04001246 RID: 4678
	[Range(0f, 1f)]
	public float Blur = 1f;
}
