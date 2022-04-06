using System;
using UnityEngine;

// Token: 0x0200018D RID: 397
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Halftone")]
public class CameraFilterPack_Drawing_Halftone : MonoBehaviour
{
	// Token: 0x17000291 RID: 657
	// (get) Token: 0x06000E0F RID: 3599 RVA: 0x00079071 File Offset: 0x00077271
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

	// Token: 0x06000E10 RID: 3600 RVA: 0x000790A5 File Offset: 0x000772A5
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Halftone");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E11 RID: 3601 RVA: 0x000790C8 File Offset: 0x000772C8
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

	// Token: 0x06000E12 RID: 3602 RVA: 0x00079164 File Offset: 0x00077364
	private void Update()
	{
	}

	// Token: 0x06000E13 RID: 3603 RVA: 0x00079166 File Offset: 0x00077366
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001265 RID: 4709
	public Shader SCShader;

	// Token: 0x04001266 RID: 4710
	private float TimeX = 1f;

	// Token: 0x04001267 RID: 4711
	private Material SCMaterial;

	// Token: 0x04001268 RID: 4712
	[Range(0f, 1f)]
	public float Threshold = 0.6f;

	// Token: 0x04001269 RID: 4713
	[Range(1f, 16f)]
	public float DotSize = 4f;
}
