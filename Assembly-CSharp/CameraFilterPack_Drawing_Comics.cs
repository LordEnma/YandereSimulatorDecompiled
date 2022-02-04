using System;
using UnityEngine;

// Token: 0x02000189 RID: 393
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Comics")]
public class CameraFilterPack_Drawing_Comics : MonoBehaviour
{
	// Token: 0x1700028D RID: 653
	// (get) Token: 0x06000DF4 RID: 3572 RVA: 0x00078287 File Offset: 0x00076487
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

	// Token: 0x06000DF5 RID: 3573 RVA: 0x000782BB File Offset: 0x000764BB
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Comics");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DF6 RID: 3574 RVA: 0x000782DC File Offset: 0x000764DC
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

	// Token: 0x06000DF7 RID: 3575 RVA: 0x00078362 File Offset: 0x00076562
	private void Update()
	{
	}

	// Token: 0x06000DF8 RID: 3576 RVA: 0x00078364 File Offset: 0x00076564
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400123B RID: 4667
	public Shader SCShader;

	// Token: 0x0400123C RID: 4668
	private float TimeX = 1f;

	// Token: 0x0400123D RID: 4669
	private Material SCMaterial;

	// Token: 0x0400123E RID: 4670
	[Range(0f, 1f)]
	public float DotSize = 0.5f;
}
