using System;
using UnityEngine;

// Token: 0x02000188 RID: 392
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/CellShading2")]
public class CameraFilterPack_Drawing_CellShading2 : MonoBehaviour
{
	// Token: 0x1700028C RID: 652
	// (get) Token: 0x06000DEF RID: 3567 RVA: 0x0007836A File Offset: 0x0007656A
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

	// Token: 0x06000DF0 RID: 3568 RVA: 0x0007839E File Offset: 0x0007659E
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_CellShading2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DF1 RID: 3569 RVA: 0x000783C0 File Offset: 0x000765C0
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

	// Token: 0x06000DF2 RID: 3570 RVA: 0x0007849B File Offset: 0x0007669B
	private void Update()
	{
	}

	// Token: 0x06000DF3 RID: 3571 RVA: 0x0007849D File Offset: 0x0007669D
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001238 RID: 4664
	public Shader SCShader;

	// Token: 0x04001239 RID: 4665
	private float TimeX = 1f;

	// Token: 0x0400123A RID: 4666
	private Material SCMaterial;

	// Token: 0x0400123B RID: 4667
	[Range(0f, 1f)]
	public float EdgeSize = 0.1f;

	// Token: 0x0400123C RID: 4668
	[Range(0f, 10f)]
	public float ColorLevel = 4f;

	// Token: 0x0400123D RID: 4669
	[Range(0f, 1f)]
	public float Blur = 1f;
}
