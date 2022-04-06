using System;
using UnityEngine;

// Token: 0x0200010E RID: 270
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Fog_Smoke")]
public class CameraFilterPack_3D_Fog_Smoke : MonoBehaviour
{
	// Token: 0x17000212 RID: 530
	// (get) Token: 0x06000AD4 RID: 2772 RVA: 0x000695E7 File Offset: 0x000677E7
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

	// Token: 0x06000AD5 RID: 2773 RVA: 0x0006961B File Offset: 0x0006781B
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

	// Token: 0x06000AD6 RID: 2774 RVA: 0x00069654 File Offset: 0x00067854
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

	// Token: 0x06000AD7 RID: 2775 RVA: 0x00069855 File Offset: 0x00067A55
	private void Update()
	{
	}

	// Token: 0x06000AD8 RID: 2776 RVA: 0x00069857 File Offset: 0x00067A57
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000E7D RID: 3709
	public Shader SCShader;

	// Token: 0x04000E7E RID: 3710
	public bool _Visualize;

	// Token: 0x04000E7F RID: 3711
	private float TimeX = 1f;

	// Token: 0x04000E80 RID: 3712
	private Material SCMaterial;

	// Token: 0x04000E81 RID: 3713
	[Range(0f, 100f)]
	public float _FixDistance = 1f;

	// Token: 0x04000E82 RID: 3714
	[Range(-0.99f, 0.99f)]
	public float _Distance = 0.5f;

	// Token: 0x04000E83 RID: 3715
	[Range(0f, 0.5f)]
	public float _Size = 0.1f;

	// Token: 0x04000E84 RID: 3716
	[Range(0f, 10f)]
	public float DistortionLevel = 1.2f;

	// Token: 0x04000E85 RID: 3717
	[Range(0.1f, 10f)]
	public float DistortionSize = 1.4f;

	// Token: 0x04000E86 RID: 3718
	[Range(-2f, 4f)]
	public float LightIntensity = 0.08f;

	// Token: 0x04000E87 RID: 3719
	public bool AutoAnimatedNear;

	// Token: 0x04000E88 RID: 3720
	[Range(-5f, 5f)]
	public float AutoAnimatedNearSpeed = 0.5f;

	// Token: 0x04000E89 RID: 3721
	private Texture2D Texture2;

	// Token: 0x04000E8A RID: 3722
	public static Color ChangeColorRGB;
}
