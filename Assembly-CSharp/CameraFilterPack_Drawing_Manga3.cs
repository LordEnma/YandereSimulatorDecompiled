using System;
using UnityEngine;

// Token: 0x02000192 RID: 402
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga3")]
public class CameraFilterPack_Drawing_Manga3 : MonoBehaviour
{
	// Token: 0x17000296 RID: 662
	// (get) Token: 0x06000E2D RID: 3629 RVA: 0x000796A8 File Offset: 0x000778A8
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

	// Token: 0x06000E2E RID: 3630 RVA: 0x000796DC File Offset: 0x000778DC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga3");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E2F RID: 3631 RVA: 0x00079700 File Offset: 0x00077900
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

	// Token: 0x06000E30 RID: 3632 RVA: 0x00079786 File Offset: 0x00077986
	private void Update()
	{
	}

	// Token: 0x06000E31 RID: 3633 RVA: 0x00079788 File Offset: 0x00077988
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400127C RID: 4732
	public Shader SCShader;

	// Token: 0x0400127D RID: 4733
	private float TimeX = 1f;

	// Token: 0x0400127E RID: 4734
	private Material SCMaterial;

	// Token: 0x0400127F RID: 4735
	[Range(1f, 8f)]
	public float DotSize = 4.72f;
}
