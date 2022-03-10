using System;
using UnityEngine;

// Token: 0x0200018C RID: 396
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/EnhancedComics")]
public class CameraFilterPack_Drawing_EnhancedComics : MonoBehaviour
{
	// Token: 0x17000290 RID: 656
	// (get) Token: 0x06000E07 RID: 3591 RVA: 0x000789D8 File Offset: 0x00076BD8
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

	// Token: 0x06000E08 RID: 3592 RVA: 0x00078A0C File Offset: 0x00076C0C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_EnhancedComics");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E09 RID: 3593 RVA: 0x00078A30 File Offset: 0x00076C30
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
			this.material.SetFloat("_ColorR", this._ColorR);
			this.material.SetFloat("_ColorG", this._ColorG);
			this.material.SetFloat("_ColorB", this._ColorB);
			this.material.SetFloat("_Blood", this._Blood);
			this.material.SetColor("_ColorRGB", this.ColorRGB);
			this.material.SetFloat("_SmoothStart", this._SmoothStart);
			this.material.SetFloat("_SmoothEnd", this._SmoothEnd);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E0A RID: 3594 RVA: 0x00078B53 File Offset: 0x00076D53
	private void Update()
	{
	}

	// Token: 0x06000E0B RID: 3595 RVA: 0x00078B55 File Offset: 0x00076D55
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001253 RID: 4691
	public Shader SCShader;

	// Token: 0x04001254 RID: 4692
	private float TimeX = 1f;

	// Token: 0x04001255 RID: 4693
	private Material SCMaterial;

	// Token: 0x04001256 RID: 4694
	[Range(0f, 1f)]
	public float DotSize = 0.15f;

	// Token: 0x04001257 RID: 4695
	[Range(0f, 1f)]
	public float _ColorR = 0.9f;

	// Token: 0x04001258 RID: 4696
	[Range(0f, 1f)]
	public float _ColorG = 0.4f;

	// Token: 0x04001259 RID: 4697
	[Range(0f, 1f)]
	public float _ColorB = 0.4f;

	// Token: 0x0400125A RID: 4698
	[Range(0f, 1f)]
	public float _Blood = 0.5f;

	// Token: 0x0400125B RID: 4699
	[Range(0f, 1f)]
	public float _SmoothStart = 0.02f;

	// Token: 0x0400125C RID: 4700
	[Range(0f, 1f)]
	public float _SmoothEnd = 0.1f;

	// Token: 0x0400125D RID: 4701
	public Color ColorRGB = new Color(1f, 0f, 0f);
}
