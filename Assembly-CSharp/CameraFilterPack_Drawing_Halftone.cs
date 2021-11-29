using System;
using UnityEngine;

// Token: 0x0200018C RID: 396
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Halftone")]
public class CameraFilterPack_Drawing_Halftone : MonoBehaviour
{
	// Token: 0x17000291 RID: 657
	// (get) Token: 0x06000E09 RID: 3593 RVA: 0x00078651 File Offset: 0x00076851
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

	// Token: 0x06000E0A RID: 3594 RVA: 0x00078685 File Offset: 0x00076885
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Halftone");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E0B RID: 3595 RVA: 0x000786A8 File Offset: 0x000768A8
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

	// Token: 0x06000E0C RID: 3596 RVA: 0x00078744 File Offset: 0x00076944
	private void Update()
	{
	}

	// Token: 0x06000E0D RID: 3597 RVA: 0x00078746 File Offset: 0x00076946
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400124D RID: 4685
	public Shader SCShader;

	// Token: 0x0400124E RID: 4686
	private float TimeX = 1f;

	// Token: 0x0400124F RID: 4687
	private Material SCMaterial;

	// Token: 0x04001250 RID: 4688
	[Range(0f, 1f)]
	public float Threshold = 0.6f;

	// Token: 0x04001251 RID: 4689
	[Range(1f, 16f)]
	public float DotSize = 4f;
}
