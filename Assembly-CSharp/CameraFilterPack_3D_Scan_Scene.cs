using System;
using UnityEngine;

// Token: 0x02000113 RID: 275
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Scan_Scene")]
public class CameraFilterPack_3D_Scan_Scene : MonoBehaviour
{
	// Token: 0x17000218 RID: 536
	// (get) Token: 0x06000AF2 RID: 2802 RVA: 0x00069BCF File Offset: 0x00067DCF
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

	// Token: 0x06000AF3 RID: 2803 RVA: 0x00069C03 File Offset: 0x00067E03
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/3D_Scan_Scene");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000AF4 RID: 2804 RVA: 0x00069C24 File Offset: 0x00067E24
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

	// Token: 0x06000AF5 RID: 2805 RVA: 0x00069DE7 File Offset: 0x00067FE7
	private void Update()
	{
	}

	// Token: 0x06000AF6 RID: 2806 RVA: 0x00069DE9 File Offset: 0x00067FE9
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000EB2 RID: 3762
	public Shader SCShader;

	// Token: 0x04000EB3 RID: 3763
	public bool _Visualize;

	// Token: 0x04000EB4 RID: 3764
	private float TimeX = 1f;

	// Token: 0x04000EB5 RID: 3765
	private Material SCMaterial;

	// Token: 0x04000EB6 RID: 3766
	[Range(0f, 100f)]
	public float _FixDistance = 1f;

	// Token: 0x04000EB7 RID: 3767
	[Range(0f, 0.99f)]
	public float _Distance = 1f;

	// Token: 0x04000EB8 RID: 3768
	[Range(0f, 0.1f)]
	public float _Size = 0.01f;

	// Token: 0x04000EB9 RID: 3769
	public bool AutoAnimatedNear;

	// Token: 0x04000EBA RID: 3770
	[Range(-5f, 5f)]
	public float AutoAnimatedNearSpeed = 1f;

	// Token: 0x04000EBB RID: 3771
	public Color ScanColor = new Color(2f, 0f, 0f, 1f);

	// Token: 0x04000EBC RID: 3772
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000EBD RID: 3773
	public static Color ChangeColorRGB;

	// Token: 0x04000EBE RID: 3774
	private Texture2D Texture2;
}
