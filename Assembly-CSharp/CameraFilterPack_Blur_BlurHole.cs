using System;
using UnityEngine;

// Token: 0x02000148 RID: 328
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Blur Hole")]
public class CameraFilterPack_Blur_BlurHole : MonoBehaviour
{
	// Token: 0x1700024C RID: 588
	// (get) Token: 0x06000C6D RID: 3181 RVA: 0x00071C16 File Offset: 0x0006FE16
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

	// Token: 0x06000C6E RID: 3182 RVA: 0x00071C4A File Offset: 0x0006FE4A
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/BlurHole");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C6F RID: 3183 RVA: 0x00071C6C File Offset: 0x0006FE6C
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

	// Token: 0x06000C70 RID: 3184 RVA: 0x00071D9F File Offset: 0x0006FF9F
	private void Update()
	{
	}

	// Token: 0x06000C71 RID: 3185 RVA: 0x00071DA1 File Offset: 0x0006FFA1
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010B4 RID: 4276
	public Shader SCShader;

	// Token: 0x040010B5 RID: 4277
	private float TimeX = 1f;

	// Token: 0x040010B6 RID: 4278
	[Range(1f, 16f)]
	public float Size = 10f;

	// Token: 0x040010B7 RID: 4279
	[Range(-1f, 1f)]
	public float _Radius = 0.25f;

	// Token: 0x040010B8 RID: 4280
	[Range(-4f, 4f)]
	public float _SpotSize = 1f;

	// Token: 0x040010B9 RID: 4281
	[Range(0f, 1f)]
	public float _CenterX = 0.5f;

	// Token: 0x040010BA RID: 4282
	[Range(0f, 1f)]
	public float _CenterY = 0.5f;

	// Token: 0x040010BB RID: 4283
	[Range(0f, 1f)]
	public float _AlphaBlur = 1f;

	// Token: 0x040010BC RID: 4284
	[Range(0f, 1f)]
	public float _AlphaBlurInside;

	// Token: 0x040010BD RID: 4285
	private Material SCMaterial;
}
