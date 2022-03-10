using System;
using UnityEngine;

// Token: 0x02000114 RID: 276
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Scan_Scene")]
public class CameraFilterPack_3D_Scan_Scene : MonoBehaviour
{
	// Token: 0x17000218 RID: 536
	// (get) Token: 0x06000AF6 RID: 2806 RVA: 0x0006A173 File Offset: 0x00068373
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

	// Token: 0x06000AF7 RID: 2807 RVA: 0x0006A1A7 File Offset: 0x000683A7
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/3D_Scan_Scene");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000AF8 RID: 2808 RVA: 0x0006A1C8 File Offset: 0x000683C8
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

	// Token: 0x06000AF9 RID: 2809 RVA: 0x0006A38B File Offset: 0x0006858B
	private void Update()
	{
	}

	// Token: 0x06000AFA RID: 2810 RVA: 0x0006A38D File Offset: 0x0006858D
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000EC3 RID: 3779
	public Shader SCShader;

	// Token: 0x04000EC4 RID: 3780
	public bool _Visualize;

	// Token: 0x04000EC5 RID: 3781
	private float TimeX = 1f;

	// Token: 0x04000EC6 RID: 3782
	private Material SCMaterial;

	// Token: 0x04000EC7 RID: 3783
	[Range(0f, 100f)]
	public float _FixDistance = 1f;

	// Token: 0x04000EC8 RID: 3784
	[Range(0f, 0.99f)]
	public float _Distance = 1f;

	// Token: 0x04000EC9 RID: 3785
	[Range(0f, 0.1f)]
	public float _Size = 0.01f;

	// Token: 0x04000ECA RID: 3786
	public bool AutoAnimatedNear;

	// Token: 0x04000ECB RID: 3787
	[Range(-5f, 5f)]
	public float AutoAnimatedNearSpeed = 1f;

	// Token: 0x04000ECC RID: 3788
	public Color ScanColor = new Color(2f, 0f, 0f, 1f);

	// Token: 0x04000ECD RID: 3789
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000ECE RID: 3790
	public static Color ChangeColorRGB;

	// Token: 0x04000ECF RID: 3791
	private Texture2D Texture2;
}
