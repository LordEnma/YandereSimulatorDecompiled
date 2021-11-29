using System;
using UnityEngine;

// Token: 0x0200019C RID: 412
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Toon")]
public class CameraFilterPack_Drawing_Toon : MonoBehaviour
{
	// Token: 0x170002A1 RID: 673
	// (get) Token: 0x06000E69 RID: 3689 RVA: 0x00079F3A File Offset: 0x0007813A
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

	// Token: 0x06000E6A RID: 3690 RVA: 0x00079F6E File Offset: 0x0007816E
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Toon");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E6B RID: 3691 RVA: 0x00079F90 File Offset: 0x00078190
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
			this.material.SetFloat("_Distortion", this.Threshold);
			this.material.SetFloat("_DotSize", this.DotSize);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E6C RID: 3692 RVA: 0x0007A02C File Offset: 0x0007822C
	private void Update()
	{
	}

	// Token: 0x06000E6D RID: 3693 RVA: 0x0007A02E File Offset: 0x0007822E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012B9 RID: 4793
	public Shader SCShader;

	// Token: 0x040012BA RID: 4794
	private Material SCMaterial;

	// Token: 0x040012BB RID: 4795
	private float TimeX = 1f;

	// Token: 0x040012BC RID: 4796
	[Range(0f, 2f)]
	public float Threshold = 1f;

	// Token: 0x040012BD RID: 4797
	[Range(0f, 8f)]
	public float DotSize = 1f;
}
