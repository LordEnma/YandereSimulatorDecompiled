using System;
using UnityEngine;

// Token: 0x02000193 RID: 403
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga4")]
public class CameraFilterPack_Drawing_Manga4 : MonoBehaviour
{
	// Token: 0x17000297 RID: 663
	// (get) Token: 0x06000E31 RID: 3633 RVA: 0x00079344 File Offset: 0x00077544
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

	// Token: 0x06000E32 RID: 3634 RVA: 0x00079378 File Offset: 0x00077578
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga4");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E33 RID: 3635 RVA: 0x0007939C File Offset: 0x0007759C
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

	// Token: 0x06000E34 RID: 3636 RVA: 0x00079422 File Offset: 0x00077622
	private void Update()
	{
	}

	// Token: 0x06000E35 RID: 3637 RVA: 0x00079424 File Offset: 0x00077624
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001279 RID: 4729
	public Shader SCShader;

	// Token: 0x0400127A RID: 4730
	private float TimeX = 1f;

	// Token: 0x0400127B RID: 4731
	private Material SCMaterial;

	// Token: 0x0400127C RID: 4732
	[Range(1f, 8f)]
	public float DotSize = 4.72f;
}
