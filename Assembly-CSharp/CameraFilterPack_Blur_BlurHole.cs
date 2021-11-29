using System;
using UnityEngine;

// Token: 0x02000147 RID: 327
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Blur Hole")]
public class CameraFilterPack_Blur_BlurHole : MonoBehaviour
{
	// Token: 0x1700024C RID: 588
	// (get) Token: 0x06000C69 RID: 3177 RVA: 0x000717BA File Offset: 0x0006F9BA
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

	// Token: 0x06000C6A RID: 3178 RVA: 0x000717EE File Offset: 0x0006F9EE
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/BlurHole");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C6B RID: 3179 RVA: 0x00071810 File Offset: 0x0006FA10
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
			this.material.SetFloat("_Distortion", this.Size);
			this.material.SetFloat("_Radius", this._Radius);
			this.material.SetFloat("_SpotSize", this._SpotSize);
			this.material.SetFloat("_CenterX", this._CenterX);
			this.material.SetFloat("_CenterY", this._CenterY);
			this.material.SetFloat("_Alpha", this._AlphaBlur);
			this.material.SetFloat("_Alpha2", this._AlphaBlurInside);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C6C RID: 3180 RVA: 0x00071943 File Offset: 0x0006FB43
	private void Update()
	{
	}

	// Token: 0x06000C6D RID: 3181 RVA: 0x00071945 File Offset: 0x0006FB45
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010AC RID: 4268
	public Shader SCShader;

	// Token: 0x040010AD RID: 4269
	private float TimeX = 1f;

	// Token: 0x040010AE RID: 4270
	[Range(1f, 16f)]
	public float Size = 10f;

	// Token: 0x040010AF RID: 4271
	[Range(-1f, 1f)]
	public float _Radius = 0.25f;

	// Token: 0x040010B0 RID: 4272
	[Range(-4f, 4f)]
	public float _SpotSize = 1f;

	// Token: 0x040010B1 RID: 4273
	[Range(0f, 1f)]
	public float _CenterX = 0.5f;

	// Token: 0x040010B2 RID: 4274
	[Range(0f, 1f)]
	public float _CenterY = 0.5f;

	// Token: 0x040010B3 RID: 4275
	[Range(0f, 1f)]
	public float _AlphaBlur = 1f;

	// Token: 0x040010B4 RID: 4276
	[Range(0f, 1f)]
	public float _AlphaBlurInside;

	// Token: 0x040010B5 RID: 4277
	private Material SCMaterial;
}
