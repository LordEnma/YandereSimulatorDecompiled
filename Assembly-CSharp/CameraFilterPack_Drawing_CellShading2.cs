using System;
using UnityEngine;

// Token: 0x02000188 RID: 392
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/CellShading2")]
public class CameraFilterPack_Drawing_CellShading2 : MonoBehaviour
{
	// Token: 0x1700028C RID: 652
	// (get) Token: 0x06000DEE RID: 3566 RVA: 0x00078106 File Offset: 0x00076306
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

	// Token: 0x06000DEF RID: 3567 RVA: 0x0007813A File Offset: 0x0007633A
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_CellShading2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DF0 RID: 3568 RVA: 0x0007815C File Offset: 0x0007635C
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

	// Token: 0x06000DF1 RID: 3569 RVA: 0x00078237 File Offset: 0x00076437
	private void Update()
	{
	}

	// Token: 0x06000DF2 RID: 3570 RVA: 0x00078239 File Offset: 0x00076439
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001235 RID: 4661
	public Shader SCShader;

	// Token: 0x04001236 RID: 4662
	private float TimeX = 1f;

	// Token: 0x04001237 RID: 4663
	private Material SCMaterial;

	// Token: 0x04001238 RID: 4664
	[Range(0f, 1f)]
	public float EdgeSize = 0.1f;

	// Token: 0x04001239 RID: 4665
	[Range(0f, 10f)]
	public float ColorLevel = 4f;

	// Token: 0x0400123A RID: 4666
	[Range(0f, 1f)]
	public float Blur = 1f;
}
