using System;
using UnityEngine;

// Token: 0x0200018D RID: 397
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Halftone")]
public class CameraFilterPack_Drawing_Halftone : MonoBehaviour
{
	// Token: 0x17000291 RID: 657
	// (get) Token: 0x06000E0D RID: 3597 RVA: 0x00078999 File Offset: 0x00076B99
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

	// Token: 0x06000E0E RID: 3598 RVA: 0x000789CD File Offset: 0x00076BCD
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Halftone");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E0F RID: 3599 RVA: 0x000789F0 File Offset: 0x00076BF0
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

	// Token: 0x06000E10 RID: 3600 RVA: 0x00078A8C File Offset: 0x00076C8C
	private void Update()
	{
	}

	// Token: 0x06000E11 RID: 3601 RVA: 0x00078A8E File Offset: 0x00076C8E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001255 RID: 4693
	public Shader SCShader;

	// Token: 0x04001256 RID: 4694
	private float TimeX = 1f;

	// Token: 0x04001257 RID: 4695
	private Material SCMaterial;

	// Token: 0x04001258 RID: 4696
	[Range(0f, 1f)]
	public float Threshold = 0.6f;

	// Token: 0x04001259 RID: 4697
	[Range(1f, 16f)]
	public float DotSize = 4f;
}
