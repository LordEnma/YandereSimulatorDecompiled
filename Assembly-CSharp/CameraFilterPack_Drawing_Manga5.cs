using System;
using UnityEngine;

// Token: 0x02000194 RID: 404
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga5")]
public class CameraFilterPack_Drawing_Manga5 : MonoBehaviour
{
	// Token: 0x17000298 RID: 664
	// (get) Token: 0x06000E39 RID: 3641 RVA: 0x000798D8 File Offset: 0x00077AD8
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

	// Token: 0x06000E3A RID: 3642 RVA: 0x0007990C File Offset: 0x00077B0C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga5");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E3B RID: 3643 RVA: 0x00079930 File Offset: 0x00077B30
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

	// Token: 0x06000E3C RID: 3644 RVA: 0x000799B6 File Offset: 0x00077BB6
	private void Update()
	{
	}

	// Token: 0x06000E3D RID: 3645 RVA: 0x000799B8 File Offset: 0x00077BB8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001284 RID: 4740
	public Shader SCShader;

	// Token: 0x04001285 RID: 4741
	private float TimeX = 1f;

	// Token: 0x04001286 RID: 4742
	private Material SCMaterial;

	// Token: 0x04001287 RID: 4743
	[Range(1f, 8f)]
	public float DotSize = 4.72f;
}
