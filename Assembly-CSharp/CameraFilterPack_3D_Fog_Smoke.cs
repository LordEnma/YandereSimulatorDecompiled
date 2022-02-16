using System;
using UnityEngine;

// Token: 0x0200010E RID: 270
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Fog_Smoke")]
public class CameraFilterPack_3D_Fog_Smoke : MonoBehaviour
{
	// Token: 0x17000212 RID: 530
	// (get) Token: 0x06000AD2 RID: 2770 RVA: 0x00068F0F File Offset: 0x0006710F
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

	// Token: 0x06000AD3 RID: 2771 RVA: 0x00068F43 File Offset: 0x00067143
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_3D_Myst1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/3D_Myst");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000AD4 RID: 2772 RVA: 0x00068F7C File Offset: 0x0006717C
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
			this.material.SetFloat("_Visualize", (float)(this._Visualize ? 1 : 0));
			this.material.SetFloat("_FixDistance", this._FixDistance);
			this.material.SetFloat("_DistortionLevel", this.DistortionLevel * 28f);
			this.material.SetFloat("_DistortionSize", this.DistortionSize * 16f);
			this.material.SetFloat("_LightIntensity", this.LightIntensity * 64f);
			this.material.SetTexture("_MainTex2", this.Texture2);
			float farClipPlane = base.GetComponent<Camera>().farClipPlane;
			this.material.SetFloat("_FarCamera", 1000f / farClipPlane);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			base.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000AD5 RID: 2773 RVA: 0x0006917D File Offset: 0x0006737D
	private void Update()
	{
	}

	// Token: 0x06000AD6 RID: 2774 RVA: 0x0006917F File Offset: 0x0006737F
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000E6D RID: 3693
	public Shader SCShader;

	// Token: 0x04000E6E RID: 3694
	public bool _Visualize;

	// Token: 0x04000E6F RID: 3695
	private float TimeX = 1f;

	// Token: 0x04000E70 RID: 3696
	private Material SCMaterial;

	// Token: 0x04000E71 RID: 3697
	[Range(0f, 100f)]
	public float _FixDistance = 1f;

	// Token: 0x04000E72 RID: 3698
	[Range(-0.99f, 0.99f)]
	public float _Distance = 0.5f;

	// Token: 0x04000E73 RID: 3699
	[Range(0f, 0.5f)]
	public float _Size = 0.1f;

	// Token: 0x04000E74 RID: 3700
	[Range(0f, 10f)]
	public float DistortionLevel = 1.2f;

	// Token: 0x04000E75 RID: 3701
	[Range(0.1f, 10f)]
	public float DistortionSize = 1.4f;

	// Token: 0x04000E76 RID: 3702
	[Range(-2f, 4f)]
	public float LightIntensity = 0.08f;

	// Token: 0x04000E77 RID: 3703
	public bool AutoAnimatedNear;

	// Token: 0x04000E78 RID: 3704
	[Range(-5f, 5f)]
	public float AutoAnimatedNearSpeed = 0.5f;

	// Token: 0x04000E79 RID: 3705
	private Texture2D Texture2;

	// Token: 0x04000E7A RID: 3706
	public static Color ChangeColorRGB;
}
