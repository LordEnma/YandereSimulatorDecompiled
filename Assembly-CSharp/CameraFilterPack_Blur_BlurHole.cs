using System;
using UnityEngine;

// Token: 0x02000148 RID: 328
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Blur Hole")]
public class CameraFilterPack_Blur_BlurHole : MonoBehaviour
{
	// Token: 0x1700024C RID: 588
	// (get) Token: 0x06000C6F RID: 3183 RVA: 0x000721DA File Offset: 0x000703DA
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

	// Token: 0x06000C70 RID: 3184 RVA: 0x0007220E File Offset: 0x0007040E
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/BlurHole");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C71 RID: 3185 RVA: 0x00072230 File Offset: 0x00070430
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

	// Token: 0x06000C72 RID: 3186 RVA: 0x00072363 File Offset: 0x00070563
	private void Update()
	{
	}

	// Token: 0x06000C73 RID: 3187 RVA: 0x00072365 File Offset: 0x00070565
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010C4 RID: 4292
	public Shader SCShader;

	// Token: 0x040010C5 RID: 4293
	private float TimeX = 1f;

	// Token: 0x040010C6 RID: 4294
	[Range(1f, 16f)]
	public float Size = 10f;

	// Token: 0x040010C7 RID: 4295
	[Range(-1f, 1f)]
	public float _Radius = 0.25f;

	// Token: 0x040010C8 RID: 4296
	[Range(-4f, 4f)]
	public float _SpotSize = 1f;

	// Token: 0x040010C9 RID: 4297
	[Range(0f, 1f)]
	public float _CenterX = 0.5f;

	// Token: 0x040010CA RID: 4298
	[Range(0f, 1f)]
	public float _CenterY = 0.5f;

	// Token: 0x040010CB RID: 4299
	[Range(0f, 1f)]
	public float _AlphaBlur = 1f;

	// Token: 0x040010CC RID: 4300
	[Range(0f, 1f)]
	public float _AlphaBlurInside;

	// Token: 0x040010CD RID: 4301
	private Material SCMaterial;
}
