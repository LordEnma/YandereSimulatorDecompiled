using System;
using UnityEngine;

// Token: 0x02000114 RID: 276
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Scan_Scene")]
public class CameraFilterPack_3D_Scan_Scene : MonoBehaviour
{
	// Token: 0x17000218 RID: 536
	// (get) Token: 0x06000AF8 RID: 2808 RVA: 0x0006A5EF File Offset: 0x000687EF
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

	// Token: 0x06000AF9 RID: 2809 RVA: 0x0006A623 File Offset: 0x00068823
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/3D_Scan_Scene");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000AFA RID: 2810 RVA: 0x0006A644 File Offset: 0x00068844
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
			this.material.SetFloat("_DepthLevel", this.Fade);
			if (this.AutoAnimatedNear)
			{
				this._Distance += Time.deltaTime * this.AutoAnimatedNearSpeed;
				if (this._Distance > 1f)
				{
					this._Distance = 0f;
				}
				if (this._Distance < 0f)
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
			this.material.SetColor("_ColorRGB", this.ScanColor);
			this.material.SetFloat("_FixDistance", this._FixDistance);
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

	// Token: 0x06000AFB RID: 2811 RVA: 0x0006A807 File Offset: 0x00068A07
	private void Update()
	{
	}

	// Token: 0x06000AFC RID: 2812 RVA: 0x0006A809 File Offset: 0x00068A09
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000ECA RID: 3786
	public Shader SCShader;

	// Token: 0x04000ECB RID: 3787
	public bool _Visualize;

	// Token: 0x04000ECC RID: 3788
	private float TimeX = 1f;

	// Token: 0x04000ECD RID: 3789
	private Material SCMaterial;

	// Token: 0x04000ECE RID: 3790
	[Range(0f, 100f)]
	public float _FixDistance = 1f;

	// Token: 0x04000ECF RID: 3791
	[Range(0f, 0.99f)]
	public float _Distance = 1f;

	// Token: 0x04000ED0 RID: 3792
	[Range(0f, 0.1f)]
	public float _Size = 0.01f;

	// Token: 0x04000ED1 RID: 3793
	public bool AutoAnimatedNear;

	// Token: 0x04000ED2 RID: 3794
	[Range(-5f, 5f)]
	public float AutoAnimatedNearSpeed = 1f;

	// Token: 0x04000ED3 RID: 3795
	public Color ScanColor = new Color(2f, 0f, 0f, 1f);

	// Token: 0x04000ED4 RID: 3796
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000ED5 RID: 3797
	public static Color ChangeColorRGB;

	// Token: 0x04000ED6 RID: 3798
	private Texture2D Texture2;
}
