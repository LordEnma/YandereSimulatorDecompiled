using System;
using UnityEngine;

// Token: 0x020001F7 RID: 503
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixelisation/Deep OilPaint HQ")]
public class CameraFilterPack_Pixelisation_DeepOilPaintHQ : MonoBehaviour
{
	// Token: 0x170002FC RID: 764
	// (get) Token: 0x060010AE RID: 4270 RVA: 0x000846D7 File Offset: 0x000828D7
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

	// Token: 0x060010AF RID: 4271 RVA: 0x0008470B File Offset: 0x0008290B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Deep_OilPaintHQ");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010B0 RID: 4272 RVA: 0x0008472C File Offset: 0x0008292C
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
			if (this.AutoAnimatedNear)
			{
				this._Distance += Time.deltaTime * this.AutoAnimatedNearSpeed;
				if (this._Distance > 1f)
				{
					this._Distance = -1f;
				}
				if (this._Distance < -1f)
				{
					this._Distance = 1f;
				}
				this.material.SetFloat("_Near", this._Distance);
			}
			else
			{
				this.material.SetFloat("_Near", this._Distance);
			}
			this.material.SetFloat("_Far", this._Size);
			this.material.SetFloat("_FixDistance", this._FixDistance);
			this.material.SetFloat("_LightIntensity", this.Intensity);
			this.material.SetFloat("_Visualize", (float)(this._Visualize ? 1 : 0));
			float farClipPlane = base.GetComponent<Camera>().farClipPlane;
			this.material.SetFloat("_FarCamera", 1000f / farClipPlane);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			base.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010B1 RID: 4273 RVA: 0x000848D9 File Offset: 0x00082AD9
	private void Update()
	{
	}

	// Token: 0x060010B2 RID: 4274 RVA: 0x000848DB File Offset: 0x00082ADB
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001532 RID: 5426
	public Shader SCShader;

	// Token: 0x04001533 RID: 5427
	private float TimeX = 1f;

	// Token: 0x04001534 RID: 5428
	public bool _Visualize;

	// Token: 0x04001535 RID: 5429
	private Material SCMaterial;

	// Token: 0x04001536 RID: 5430
	[Range(0f, 100f)]
	public float _FixDistance = 1.5f;

	// Token: 0x04001537 RID: 5431
	[Range(-0.99f, 0.99f)]
	public float _Distance = 0.4f;

	// Token: 0x04001538 RID: 5432
	[Range(0f, 0.5f)]
	public float _Size = 0.5f;

	// Token: 0x04001539 RID: 5433
	[Range(0f, 8f)]
	public float Intensity = 1f;

	// Token: 0x0400153A RID: 5434
	public bool AutoAnimatedNear;

	// Token: 0x0400153B RID: 5435
	[Range(-5f, 5f)]
	public float AutoAnimatedNearSpeed = 0.5f;

	// Token: 0x0400153C RID: 5436
	public static Color ChangeColorRGB;
}
