using System;
using UnityEngine;

// Token: 0x02000112 RID: 274
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Mirror")]
public class CameraFilterPack_3D_Mirror : MonoBehaviour
{
	// Token: 0x17000216 RID: 534
	// (get) Token: 0x06000AEC RID: 2796 RVA: 0x0006A060 File Offset: 0x00068260
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

	// Token: 0x06000AED RID: 2797 RVA: 0x0006A094 File Offset: 0x00068294
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/3D_Mirror");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000AEE RID: 2798 RVA: 0x0006A0B8 File Offset: 0x000682B8
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
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetFloat("Lightning", this.Lightning);
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

	// Token: 0x06000AEF RID: 2799 RVA: 0x0006A27B File Offset: 0x0006847B
	private void Update()
	{
	}

	// Token: 0x06000AF0 RID: 2800 RVA: 0x0006A27D File Offset: 0x0006847D
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000EB0 RID: 3760
	public Shader SCShader;

	// Token: 0x04000EB1 RID: 3761
	public bool _Visualize;

	// Token: 0x04000EB2 RID: 3762
	private float TimeX = 1f;

	// Token: 0x04000EB3 RID: 3763
	private Material SCMaterial;

	// Token: 0x04000EB4 RID: 3764
	[Range(0f, 100f)]
	public float _FixDistance = 1.5f;

	// Token: 0x04000EB5 RID: 3765
	[Range(-0.99f, 0.99f)]
	public float _Distance = 0.4f;

	// Token: 0x04000EB6 RID: 3766
	[Range(0f, 0.5f)]
	public float _Size = 0.5f;

	// Token: 0x04000EB7 RID: 3767
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000EB8 RID: 3768
	[Range(0f, 2f)]
	public float Lightning = 2f;

	// Token: 0x04000EB9 RID: 3769
	public bool AutoAnimatedNear;

	// Token: 0x04000EBA RID: 3770
	[Range(-5f, 5f)]
	public float AutoAnimatedNearSpeed = 0.5f;

	// Token: 0x04000EBB RID: 3771
	public static Color ChangeColorRGB;
}
