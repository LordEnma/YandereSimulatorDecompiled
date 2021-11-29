using System;
using UnityEngine;

// Token: 0x0200018F RID: 399
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga")]
public class CameraFilterPack_Drawing_Manga : MonoBehaviour
{
	// Token: 0x17000294 RID: 660
	// (get) Token: 0x06000E1B RID: 3611 RVA: 0x00078A5B File Offset: 0x00076C5B
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

	// Token: 0x06000E1C RID: 3612 RVA: 0x00078A8F File Offset: 0x00076C8F
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E1D RID: 3613 RVA: 0x00078AB0 File Offset: 0x00076CB0
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
			this.material.SetFloat("_DotSize", this.DotSize);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E1E RID: 3614 RVA: 0x00078B36 File Offset: 0x00076D36
	private void Update()
	{
	}

	// Token: 0x06000E1F RID: 3615 RVA: 0x00078B38 File Offset: 0x00076D38
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400125C RID: 4700
	public Shader SCShader;

	// Token: 0x0400125D RID: 4701
	private float TimeX = 1f;

	// Token: 0x0400125E RID: 4702
	private Material SCMaterial;

	// Token: 0x0400125F RID: 4703
	[Range(1f, 8f)]
	public float DotSize = 4.72f;
}
